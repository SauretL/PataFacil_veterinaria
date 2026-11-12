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
        // Lista de productos de prueba (sin DAL)
        private List<Producto> listaProductos = new List<Producto>();

        public frmAuxiliar()
        {
            InitializeComponent();

            // Nombre del usuario
            lblUsuario.Text = "Usuario: " + Sesion.Nombre;

            // Selección default de los cmb
            cmbFiltroCategoria.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;

            // Obtener los productos y mostrarlos
            listaProductos = ObtenerProductos();
            MostrarProductos(listaProductos);
        }

        // 
        // DATOS
        // 

        //datos de prueba
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

        // 
        // GRILLA
        // 

        // Recibe una lista de productos y la muestra en la grilla (dgvProductos).
        private void MostrarProductos(List<Producto> productos)
        {
            // borrar las filas para empezar
            dgvProductos.Rows.Clear();

            int cantidadBajoMinimo = 0;

            // recorrido de la lista
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

                // Si el producto esta bajo el min, se pinta y cuenta
                if (producto.EstaBajoMinimo())
                {
                    dgvProductos.Rows[numeroFila].DefaultCellStyle.BackColor = Color.MistyRose;
                    cantidadBajoMinimo++;
                }
            }

            // Mostramos el aviso debajo de la grilla
            if (cantidadBajoMinimo > 0)
            {
                lblAlerta.Text = "Atención: hay " + cantidadBajoMinimo + " producto(s) con stock bajo el mínimo";
            }
            else
            {
                lblAlerta.Text = "";   // si no hay ninguno, no mostramos nada
            }

            // Dejamos la grilla sin fila seleccionada
            dgvProductos.ClearSelection();
        }

        // 
        // BOTONES
        // 

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Se borra el usuario guardado.
            Sesion.Email = "";

            // Cierra el formulario
            this.Close();
        }

        // otros botones
        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
