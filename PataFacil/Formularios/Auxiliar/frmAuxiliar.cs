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

namespace PataFacil
{
    public partial class frmAuxiliar : Form
    {
        // Lista con productos de prueba
        private List<Producto> listaProductos = new List<Producto>();

        // Si no hay ninguno elegido vale null
        private Producto productoSeleccionado = null;

        public frmAuxiliar()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            dgvProductos.CellClick += dgvProductos_CellClick;

            // se muestra nombre del q inicia sesion
            lblUsuario.Text = "Usuario: " + Sesion.Nombre;

            // seleccion default
            cmbFiltroCategoria.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;

            // se obtienen productos y muestran en la grilla
            listaProductos = ObtenerProductos();
            MostrarProductos(listaProductos);
            ActualizarAlerta();
        }

        // -----------------------------------------------------------------
        // DATOS
        // -----------------------------------------------------------------

        // productos de prueba

        private List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            // Producto(id, nombre, categoria, stockActual, stockMinimo)
            productos.Add(new Producto(1, "Vacuna Antirrábica", "Vacunas", 12, 5));
            productos.Add(new Producto(2, "Vacuna Séxtuple", "Vacunas", 3, 8));             
            productos.Add(new Producto(3, "Amoxicilina 500mg", "Medicamentos", 20, 10));
            productos.Add(new Producto(4, "Antiparasitario Interno", "Medicamentos", 4, 6)); 
            productos.Add(new Producto(5, "Alimento Perro Adulto 15kg", "Alimentos", 9, 5));
            productos.Add(new Producto(6, "Alimento Gato 10kg", "Alimentos", 2, 5));       
            productos.Add(new Producto(7, "Guantes descartables", "Insumos", 50, 20));
            productos.Add(new Producto(8, "Jeringas 5ml", "Insumos", 15, 15));               
            productos.Add(new Producto(9, "Collar antipulgas", "Otros", 7, 3));

            return productos;
        }

        // -----------------------------------------------------------------
        // GRILLA
        // -----------------------------------------------------------------

        // Recibe una lista de productos y la muestra en la grilla (dgvProductos).
        private void MostrarProductos(List<Producto> productos)
        {
            // se borrran las filoas q habia antes para no repetir
            dgvProductos.Rows.Clear();

            // Recorremos la lista: "producto" es cada uno de los productos
            foreach (Producto producto in productos)
            {
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
        // ETAPA 2: BUSCAR Y FILTRAR
        // -----------------------------------------------------------------

        private void btnBuscar_Click(object sender, EventArgs e)
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

            // Mostramos solo los productos filtrados
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
        // ETAPA 2: SELECCIONAR UN PRODUCTO DE LA GRILLA
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
        private void LimpiarPanelProducto()
        {
            productoSeleccionado = null;
            txtNombreProducto.Clear();
            cmbCategoria.SelectedIndex = 0;
            nudStockMinimo.Value = 0;
            lblStockActual.Text = "Stock actual: 0";
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

        // Estos métodos se completan en las próximas etapas
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
