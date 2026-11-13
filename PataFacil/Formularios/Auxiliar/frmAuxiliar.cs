using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PataFacil.Clases;   // para poder usar la clase Producto y la clase Sesion

namespace PataFacil
{
    public partial class frmAuxiliar : Form
    {
        // Lista con TODOS los productos (por ahora son datos de prueba).
        // Más adelante esta lista se va a llenar desde la base de datos.
        private List<Producto> listaProductos = new List<Producto>();

        // Guarda el producto que la persona eligió en la grilla.
        // Si no hay ninguno elegido vale null (null = "nada").
        // ETAPA 3: también nos dice en qué modo estamos:
        //   - null     -> estamos creando un producto NUEVO
        //   - con dato -> estamos MODIFICANDO ese producto
        private Producto productoSeleccionado = null;

        // ETAPA 4: lista con los movimientos (ingresos y egresos) registrados.
        // Es de prueba: se pierde al cerrar el programa. Después se guarda en la base.
        private List<MovimientoStock> listaMovimientos = new List<MovimientoStock>();

        public frmAuxiliar()
        {
            InitializeComponent();

            // Todo lo que queremos que pase al abrir el formulario lo ponemos acá.

            // Conectamos los eventos de estos controles con sus métodos.
            // (Es lo mismo que hacer doble clic sobre el control en el diseñador.)
            btnBuscar.Click += btnBuscar_Click;
            dgvProductos.CellClick += dgvProductos_CellClick;
            btnNuevo.Click += btnNuevo_Click;                        // ETAPA 3
            btnGuardarProducto.Click += btnGuardarProducto_Click;    // ETAPA 3
            btnIngreso.Click += btnIngreso_Click;                    // ETAPA 4
            btnEgreso.Click += btnEgreso_Click;                      // ETAPA 4
            btnNotificar.Click += btnNotificar_Click;                // ETAPA 4

            // Mostramos el nombre de quien inició sesión (lo guardó el login en Sesion)
            lblUsuario.Text = "Usuario: " + Sesion.Nombre;

            // Dejamos seleccionada la primera opción de los combos ("Todas" y "Vacunas")
            cmbFiltroCategoria.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;

            // Obtenemos los productos y los mostramos en la grilla
            listaProductos = ObtenerProductos();
            MostrarProductos(listaProductos);
            ActualizarAlerta();
        }

        // -----------------------------------------------------------------
        // DATOS
        // Estos métodos son los únicos que tocan la lista de datos de prueba.
        // En la etapa de base de datos, se cambia lo que hay adentro de ellos
        // por llamadas a Dal_Auxiliar y el resto del formulario no se toca.
        // -----------------------------------------------------------------

        // Devuelve la lista de productos (datos de prueba escritos a mano).
        private List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            // Producto(id, nombre, categoria, stockActual, stockMinimo)
            productos.Add(new Producto(1, "Vacuna Antirrábica", "Vacunas", 12, 5));
            productos.Add(new Producto(2, "Vacuna Séxtuple", "Vacunas", 3, 8));              // stock bajo
            productos.Add(new Producto(3, "Amoxicilina 500mg", "Medicamentos", 20, 10));
            productos.Add(new Producto(4, "Antiparasitario Interno", "Medicamentos", 4, 6)); // stock bajo
            productos.Add(new Producto(5, "Alimento Perro Adulto 15kg", "Alimentos", 9, 5));
            productos.Add(new Producto(6, "Alimento Gato 10kg", "Alimentos", 2, 5));         // stock bajo
            productos.Add(new Producto(7, "Guantes descartables", "Insumos", 50, 20));
            productos.Add(new Producto(8, "Jeringas 5ml", "Insumos", 15, 15));               // justo en el mínimo: es OK
            productos.Add(new Producto(9, "Collar antipulgas", "Otros", 7, 3));

            return productos;
        }

        // ETAPA 3: agrega un producto nuevo a la lista.
        private void InsertarProducto(Producto nuevo)
        {
            // Buscamos el Id más grande que haya y le sumamos 1.
            // (Cuando usemos la base de datos, el Id lo va a poner SQL Server solo.)
            int idMasGrande = 0;
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id > idMasGrande)
                {
                    idMasGrande = producto.Id;
                }
            }
            nuevo.Id = idMasGrande + 1;

            listaProductos.Add(nuevo);
        }

        // ETAPA 3: modifica un producto que ya existe en la lista.
        // Busca el producto por Id y le cambia nombre, categoría y stock mínimo.
        // El stock actual NO se toca acá: solo cambia con ingresos y egresos.
        private void ModificarProducto(Producto editado)
        {
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id == editado.Id)
                {
                    producto.Nombre = editado.Nombre;
                    producto.Categoria = editado.Categoria;
                    producto.StockMinimo = editado.StockMinimo;
                }
            }
        }

        // ETAPA 4: registra un movimiento: cambia el stock del producto y guarda el movimiento.
        private void RegistrarMovimiento(MovimientoStock movimiento)
        {
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id == movimiento.Producto.Id)
                {
                    // Un ingreso suma stock y un egreso lo resta
                    if (movimiento.Tipo == "Ingreso")
                    {
                        producto.StockActual = producto.StockActual + movimiento.Cantidad;
                    }
                    else
                    {
                        producto.StockActual = producto.StockActual - movimiento.Cantidad;
                    }
                }
            }

            // Guardamos el movimiento en la lista de movimientos
            listaMovimientos.Add(movimiento);
        }

        // -----------------------------------------------------------------
        // GRILLA
        // -----------------------------------------------------------------

        // Recibe una lista de productos y la muestra en la grilla (dgvProductos).
        // OJO: solo dibuja la grilla. El aviso de stock bajo se hace en ActualizarAlerta().
        private void MostrarProductos(List<Producto> productos)
        {
            // Primero borramos las filas que hubiera, para no repetir productos
            dgvProductos.Rows.Clear();

            // Recorremos la lista: "producto" es cada uno de los productos
            foreach (Producto producto in productos)
            {
                // Agregamos una fila. Los valores van en el mismo orden que las columnas:
                // Id (oculta), Producto, Categoría, Stock actual, Stock mínimo, Estado
                int numeroFila = dgvProductos.Rows.Add(
                    producto.Id,
                    producto.Nombre,
                    producto.Categoria,
                    producto.StockActual,
                    producto.StockMinimo,
                    producto.ObtenerEstado());

                // Si el producto está bajo el mínimo, pintamos la fila
                if (producto.EstaBajoMinimo())
                {
                    dgvProductos.Rows[numeroFila].DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }

            // Dejamos la grilla sin fila seleccionada
            dgvProductos.ClearSelection();
        }

        // Cuenta cuántos productos de la lista COMPLETA están bajo el mínimo
        // y muestra el aviso debajo de la grilla.
        // Usa listaProductos (no la filtrada) para que el aviso no cambie al buscar.
        private void ActualizarAlerta()
        {
            int cantidadBajoMinimo = 0;

            foreach (Producto producto in listaProductos)
            {
                if (producto.EstaBajoMinimo())
                {
                    cantidadBajoMinimo++;
                }
            }

            if (cantidadBajoMinimo > 0)
            {
                lblAlerta.Text = "Atención: hay " + cantidadBajoMinimo + " producto(s) con stock bajo el mínimo";
            }
            else
            {
                lblAlerta.Text = "";   // si no hay ninguno, no mostramos nada
            }
        }

        // -----------------------------------------------------------------
        // BUSCAR Y FILTRAR
        // -----------------------------------------------------------------

        // Devuelve solo los productos que cumplen con lo que hay cargado en los filtros
        // (texto, categoría y check de stock bajo). No muestra nada: solo arma la lista.
        private List<Producto> FiltrarProductos()
        {
            // Lo que escribió la persona. Trim() borra espacios de los costados.
            // ToLower() lo pasa a minúsculas para que no importe si escribe "VACUNA" o "vacuna".
            string textoBuscado = txtBuscar.Text.Trim().ToLower();

            // Categoría elegida en el combo ("Todas" significa sin filtro)
            string categoriaElegida = cmbFiltroCategoria.Text;

            // true si está tildado "Solo stock bajo el mínimo"
            bool soloBajoMinimo = chkSoloBajoMinimo.Checked;

            // Lista nueva donde guardamos solo los productos que cumplen todo
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in listaProductos)
            {
                // 1) ¿El nombre contiene el texto buscado?
                //    (si no escribió nada, el texto vacío está contenido en todos los nombres)
                bool coincideNombre = producto.Nombre.ToLower().Contains(textoBuscado);

                // 2) ¿Coincide la categoría? (o está en "Todas")
                bool coincideCategoria = (categoriaElegida == "Todas") || (producto.Categoria == categoriaElegida);

                // 3) ¿Cumple lo del stock? (si no está tildado, no importa el stock)
                bool coincideStock = (soloBajoMinimo == false) || producto.EstaBajoMinimo();

                // Si cumple las tres cosas, lo agregamos a la lista filtrada
                if (coincideNombre && coincideCategoria && coincideStock)
                {
                    listaFiltrada.Add(producto);
                }
            }

            return listaFiltrada;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Armamos la lista filtrada y la mostramos
            List<Producto> listaFiltrada = FiltrarProductos();
            MostrarProductos(listaFiltrada);

            // Al cambiar la grilla, borramos lo que había en el panel de la derecha
            LimpiarPanelProducto();

            // Si no se encontró nada, avisamos
            if (listaFiltrada.Count == 0)
            {
                MessageBox.Show("No se encontraron productos con esos filtros.", "Búsqueda",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -----------------------------------------------------------------
        // SELECCIONAR UN PRODUCTO DE LA GRILLA
        // -----------------------------------------------------------------

        // Se ejecuta cuando la persona hace clic en una celda de la grilla.
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hizo clic en el encabezado de las columnas, RowIndex vale -1: no hacemos nada
            if (e.RowIndex < 0)
            {
                return;
            }

            // Leemos el Id de la fila elegida (está en la columna oculta colId)
            int idElegido = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["colId"].Value);

            // Buscamos ese Id dentro de la lista completa
            productoSeleccionado = null;
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id == idElegido)
                {
                    productoSeleccionado = producto;
                }
            }

            // Si lo encontramos, mostramos sus datos en el panel de la derecha
            if (productoSeleccionado != null)
            {
                txtNombreProducto.Text = productoSeleccionado.Nombre;
                cmbCategoria.SelectedItem = productoSeleccionado.Categoria;
                nudStockMinimo.Value = productoSeleccionado.StockMinimo;
                lblStockActual.Text = "Stock actual: " + productoSeleccionado.StockActual;
            }
        }

        // Deja el panel "Datos del producto" vacío y sin producto seleccionado.
        // Como productoSeleccionado queda en null, el próximo "Guardar" crea un producto nuevo.
        private void LimpiarPanelProducto()
        {
            productoSeleccionado = null;
            txtNombreProducto.Clear();
            cmbCategoria.SelectedIndex = 0;
            nudStockMinimo.Value = 0;
            lblStockActual.Text = "Stock actual: 0";
        }

        // -----------------------------------------------------------------
        // ETAPA 3: PRODUCTO NUEVO Y GUARDAR
        // -----------------------------------------------------------------

        // Botón "Producto Nuevo": prepara el panel para cargar un producto desde cero.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvProductos.ClearSelection();   // sacamos la selección de la grilla
            LimpiarPanelProducto();          // vaciamos el panel (y queda en modo "nuevo")
            txtNombreProducto.Focus();       // dejamos el cursor listo para escribir el nombre
        }

        // Botón "Guardar producto": sirve para crear uno nuevo o para modificar el elegido.
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            // Leemos lo que escribió la persona
            string nombre = txtNombreProducto.Text.Trim();
            string categoria = cmbCategoria.Text;
            int stockMinimo = (int)nudStockMinimo.Value;   // el NumericUpDown devuelve decimal, lo pasamos a int

            // --- VALIDACIONES: si algo está mal, avisamos y salimos con return ---

            if (nombre == "")
            {
                MessageBox.Show("Completá el nombre del producto.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                return;
            }

            if (nombre.Length > 100)
            {
                MessageBox.Show("El nombre no puede tener más de 100 letras.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                return;
            }

            if (categoria == "")
            {
                MessageBox.Show("Elegí una categoría.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return;
            }

            // Que no exista otro producto con el mismo nombre.
            // Si estamos modificando, ignoramos al propio producto (si no, se "repetiría" consigo mismo).
            foreach (Producto producto in listaProductos)
            {
                bool mismoNombre = producto.Nombre.ToLower() == nombre.ToLower();
                bool esElMismoProducto = (productoSeleccionado != null && producto.Id == productoSeleccionado.Id);

                if (mismoNombre && esElMismoProducto == false)
                {
                    MessageBox.Show("Ya existe un producto con ese nombre.", "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreProducto.Focus();
                    return;
                }
            }

            // --- GUARDAR ---

            if (productoSeleccionado == null)
            {
                // Modo NUEVO: el stock actual empieza en 0 (se carga después con un ingreso).
                // El Id es 0 por ahora; lo completa InsertarProducto.
                Producto nuevo = new Producto(0, nombre, categoria, 0, stockMinimo);
                InsertarProducto(nuevo);
            }
            else
            {
                // Modo MODIFICAR: armamos el producto con los datos nuevos (mismo Id y mismo stock actual).
                Producto editado = new Producto(productoSeleccionado.Id, nombre, categoria,
                                                productoSeleccionado.StockActual, stockMinimo);
                ModificarProducto(editado);
            }

            // --- ACTUALIZAR LA PANTALLA ---

            // Volvemos a mostrar la grilla respetando los filtros que estaban puestos
            MostrarProductos(FiltrarProductos());
            ActualizarAlerta();
            LimpiarPanelProducto();

            MessageBox.Show("Producto guardado correctamente.", "Listo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // -----------------------------------------------------------------
        // ETAPA 4: INGRESOS, EGRESOS Y NOTIFICAR REPOSICIÓN
        // -----------------------------------------------------------------

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            AbrirMovimiento("Ingreso");
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            AbrirMovimiento("Egreso");
        }

        // Abre el formulario de movimiento. Sirve para los dos botones: el tipo llega como texto.
        private void AbrirMovimiento(string tipo)
        {
            // Primero chequeamos que haya un producto elegido en la grilla
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Primero elegí un producto de la grilla.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // No tiene sentido abrir un egreso si no queda nada para sacar
            if (tipo == "Egreso" && productoSeleccionado.StockActual == 0)
            {
                MessageBox.Show("Este producto no tiene stock para sacar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Creamos el formulario pasándole el producto y el tipo.
            // "using" hace que se libere solo cuando termina.
            using (frmMovimientoStock formulario = new frmMovimientoStock(productoSeleccionado, tipo))
            {
                // ShowDialog abre el formulario y el programa espera hasta que se cierre
                DialogResult resultado = formulario.ShowDialog(this);

                // Si apretó Cancelar (o cerró la ventana), no hacemos nada
                if (resultado != DialogResult.OK)
                {
                    return;
                }

                // Confirmó: armamos el movimiento con los datos que cargó
                MovimientoStock movimiento = new MovimientoStock(
                    productoSeleccionado, tipo, formulario.Cantidad, formulario.Fecha, formulario.Detalle);

                RegistrarMovimiento(movimiento);
            }

            // Guardamos el producto en una variable porque LimpiarPanelProducto lo pone en null
            Producto productoModificado = productoSeleccionado;

            // Actualizamos la pantalla (la grilla respeta los filtros puestos)
            MostrarProductos(FiltrarProductos());
            ActualizarAlerta();
            LimpiarPanelProducto();

            // Avisamos cómo quedó el stock
            string mensaje = tipo + " registrado. Stock actual de " + productoModificado.Nombre + ": " + productoModificado.StockActual;
            if (productoModificado.EstaBajoMinimo())
            {
                mensaje = mensaje + "\n\nAtención: el producto quedó bajo el stock mínimo (" + productoModificado.StockMinimo + ").";
            }
            MessageBox.Show(mensaje, "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Botón "Notificar reposición": por ahora solo muestra un mensaje con los productos a reponer.
        private void btnNotificar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            // Recorremos TODOS los productos (no solo los que se ven en la grilla)
            foreach (Producto producto in listaProductos)
            {
                if (producto.EstaBajoMinimo())
                {
                    // Cuántas unidades faltan para llegar al mínimo
                    int faltan = producto.StockMinimo - producto.StockActual;

                    mensaje = mensaje + "- " + producto.Nombre + ": stock " + producto.StockActual
                              + ", mínimo " + producto.StockMinimo + " (faltan " + faltan + ")\n";
                }
            }

            if (mensaje == "")
            {
                MessageBox.Show("No hay productos para reponer.", "Reposición",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Productos para reponer:\n\n" + mensaje, "Reposición",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -----------------------------------------------------------------
        // OTROS BOTONES
        // -----------------------------------------------------------------

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Borramos el email guardado: así el login sabe que se cerró sesión
            // y vuelve a mostrarse solo.
            Sesion.Email = "";

            // Cerramos este formulario
            this.Close();
        }

        // Este método se completa más adelante (o se puede dejar vacío)
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
