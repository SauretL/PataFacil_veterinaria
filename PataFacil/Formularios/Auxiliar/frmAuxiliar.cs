using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PataFacil.Clases;  
using PataFacil.Datos;   

namespace PataFacil
{
    public partial class frmAuxiliar : Form
    {
        // lista con productos
        private List<Producto> listaProductos = new List<Producto>();

        // Guarda el producto en la grilla
        private Producto productoSeleccionado = null;

        public frmAuxiliar()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            dgvProductos.CellClick += dgvProductos_CellClick;
            btnNuevo.Click += btnNuevo_Click;                        
            btnGuardarProducto.Click += btnGuardarProducto_Click;    
            btnIngreso.Click += btnIngreso_Click;                    
            btnEgreso.Click += btnEgreso_Click;                     
            btnNotificar.Click += btnNotificar_Click;                

            // se muestra nombre del usuario
            lblUsuario.Text = "Usuario: " + Sesion.Nombre;

            // seleccion default de los cmb
            cmbFiltroCategoria.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;

            // se obtienen lso productos y se muestran en grilla
            listaProductos = ObtenerProductos();
            MostrarProductos(listaProductos);
            ActualizarAlerta();
        }

        // -----------------------------------------------------------------
        // DATOS
        // -----------------------------------------------------------------

        // devuelve la lista de productos desde la BD
        private List<Producto> ObtenerProductos()
        {
            // try/catch para q si hay error en BD no se cierre todo
            try
            {
                Dal_Auxiliar dal = new Dal_Auxiliar();
                return dal.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los productos: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Producto>();
            }
        }

        // agregar un producto nuevo en la base de datos.
        private void InsertarProducto(Producto nuevo)
        {
            Dal_Auxiliar dal = new Dal_Auxiliar();
            dal.InsertarProducto(nuevo);
        }

        // modificar un producto que ya existe en la base de datos.
        private void ModificarProducto(Producto editado)
        {
            Dal_Auxiliar dal = new Dal_Auxiliar();
            dal.ModificarProducto(editado);
        }

        // registra un ingreso o egreso en la base de datos
        private void RegistrarMovimiento(MovimientoStock movimiento)
        {
            Dal_Auxiliar dal = new Dal_Auxiliar();
            dal.RegistrarMovimiento(movimiento, Sesion.Email);
        }

        // Busca un producto de la lista por su Id. Si no lo encuentra devuelve null.
        private Producto BuscarProductoPorId(int id)
        {
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id == id)
                {
                    return producto;
                }
            }
            return null;
        }

        // -----------------------------------------------------------------
        // GRILLA
        // -----------------------------------------------------------------

        // Recibe una lista de productos y la muestra en la grilla
        private void MostrarProductos(List<Producto> productos)
        {
            // se borran las filas que hay, para no repetir productos
            dgvProductos.Rows.Clear();

            // se recorre lista con un foreach
            foreach (Producto producto in productos)
            {
                // Agregamos una fila. Los valores van en el mismo orden que las columnas:
                // (Id no se muestra), producto, categoria, stock actual, stock min, estado
                int numeroFila = dgvProductos.Rows.Add(
                    producto.Id,
                    producto.Nombre,
                    producto.Categoria,
                    producto.StockActual,
                    producto.StockMinimo,
                    producto.ObtenerEstado());

                // Si el producto está bajo el min, se resalta la fila
                if (producto.EstaBajoMinimo())
                {
                    dgvProductos.Rows[numeroFila].DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }

            // grilla sin fila seleccionada
            dgvProductos.ClearSelection();
        }

        // cuantos productos de la lista completa están bajo el min
        // muestra el aviso debajo de la grilla
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
                lblAlerta.Text = ""; // si no hay nada debajo del min entonces no muestra nada
            }
        }

        // -----------------------------------------------------------------
        // BUSCAR Y FILTRAR
        // -----------------------------------------------------------------

        // Devuelve solo los productos que cumplen con lo que hay cargado en los filtros
        private List<Producto> FiltrarProductos()
        {
            // arregla mayus, minus y espacios de más
            string textoBuscado = txtBuscar.Text.Trim().ToLower();

            // Categoría elegida en el cmb
            string categoriaElegida = cmbFiltroCategoria.Text;

            // booleano por si se tilda solo stock bajo min
            bool soloBajoMinimo = chkSoloBajoMinimo.Checked;

            // Lista nueva donde guardamos solo los productos que cumplen todo
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in listaProductos)
            {
                // 1) ¿El nombre contiene el texto buscado?
                bool coincideNombre = producto.Nombre.ToLower().Contains(textoBuscado);

                // 2) ¿Coincide la categoria? (todas incluye todas las categorias)
                bool coincideCategoria = (categoriaElegida == "Todas") || (producto.Categoria == categoriaElegida);

                // 3) ¿Cumple lo del stock?
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

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int idElegido = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["colId"].Value);

            productoSeleccionado = null;
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id == idElegido)
                {
                    productoSeleccionado = producto;
                }
            }

            if (productoSeleccionado != null)
            {
                txtNombreProducto.Text = productoSeleccionado.Nombre;
                cmbCategoria.SelectedItem = productoSeleccionado.Categoria;
                nudStockMinimo.Value = productoSeleccionado.StockMinimo;
                lblStockActual.Text = "Stock actual: " + productoSeleccionado.StockActual;
            }
        }

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvProductos.ClearSelection();  
            LimpiarPanelProducto();          
            txtNombreProducto.Focus();       
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreProducto.Text.Trim();
            string categoria = cmbCategoria.Text;
            int stockMinimo = (int)nudStockMinimo.Value;  

            // VALIDACIONES

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

            // try/catch
            try
            {
                if (productoSeleccionado == null)
                {
                    // Modo NUEVO: el stock actual empieza en 0 (se carga después con un ingreso).
                    // El Id es 0 porque lo pone la base de datos sola.
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el producto: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- ACTUALIZAR LA PANTALLA ---

            listaProductos = ObtenerProductos();
            MostrarProductos(FiltrarProductos());
            ActualizarAlerta();
            LimpiarPanelProducto();

            MessageBox.Show("Producto guardado correctamente.", "Listo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // -----------------------------------------------------------------
        // INGRESOS, EGRESOS Y NOTIFICAR REPOSICION
        // -----------------------------------------------------------------

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            AbrirMovimiento("Ingreso");
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            AbrirMovimiento("Egreso");
        }

        private void AbrirMovimiento(string tipo)
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Primero elegí un producto de la grilla.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tipo == "Egreso" && productoSeleccionado.StockActual == 0)
            {
                MessageBox.Show("Este producto no tiene stock para sacar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MovimientoStock movimiento = null;

      
            using (frmMovimientoStock formulario = new frmMovimientoStock(productoSeleccionado, tipo))
            {
                DialogResult resultado = formulario.ShowDialog(this);

                if (resultado != DialogResult.OK)
                {
                    return;
                }

                movimiento = new MovimientoStock(
                    productoSeleccionado, tipo, formulario.Cantidad, formulario.Fecha, formulario.Detalle);
            }

            int idModificado = productoSeleccionado.Id;

            try
            {
                RegistrarMovimiento(movimiento);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el movimiento: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listaProductos = ObtenerProductos();
            Producto productoModificado = BuscarProductoPorId(idModificado);

            MostrarProductos(FiltrarProductos());
            ActualizarAlerta();
            LimpiarPanelProducto();

            if (productoModificado != null)
            {
                string mensaje = tipo + " registrado. Stock actual de " + productoModificado.Nombre + ": " + productoModificado.StockActual;
                if (productoModificado.EstaBajoMinimo())
                {
                    mensaje = mensaje + "\n\nAtención: el producto quedó bajo el stock mínimo (" + productoModificado.StockMinimo + ").";
                }
                MessageBox.Show(mensaje, "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNotificar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            foreach (Producto producto in listaProductos)
            {
                if (producto.EstaBajoMinimo())
                {
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

            Sesion.Email = "";

            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
