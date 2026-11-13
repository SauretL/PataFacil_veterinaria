using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PataFacil.Clases;   // para poder usar la clase Producto

namespace PataFacil
{
    // Formulario chico que se abre desde frmAuxiliar para registrar un ingreso o un egreso.
    public partial class frmMovimientoStock : Form
    {
        // Datos que recibe del formulario principal
        private Producto producto;
        private string tipo;          // "Ingreso" o "Egreso"

        // Datos que le devuelve al formulario principal cuando se confirma
        // (el formulario principal los lee después de que este se cierra)
        public int Cantidad { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Detalle { get; private set; }

        // Constructor sin datos: lo necesita el diseñador de Visual Studio para poder abrir el formulario.
        public frmMovimientoStock()
        {
            InitializeComponent();
        }

        // Constructor que usamos nosotros: recibe el producto y el tipo de movimiento.
        // (Es "internal" porque la clase Producto también es internal.)
        // ": this()" significa que primero ejecuta el constructor de arriba.
        internal frmMovimientoStock(Producto productoElegido, string tipoMovimiento) : this()
        {
            producto = productoElegido;
            tipo = tipoMovimiento;

            // Conectamos los botones con sus métodos
            btnConfirmar.Click += btnConfirmar_Click;
            btnCancelar.Click += btnCancelar_Click;

            // Cambiamos los textos según el tipo de movimiento
            this.Text = tipo + " de stock";
            lblProducto.Text = "Producto: " + producto.Nombre;

            if (tipo == "Ingreso")
            {
                lblTipo.Text = "Ingreso de stock";
            }
            else
            {
                // En un egreso mostramos cuánto stock hay disponible
                lblTipo.Text = "Egreso de stock - disponible: " + producto.StockActual;
            }

            // La fecha empieza en el día de hoy
            dtpFecha.Value = DateTime.Today;
        }

        // Botón Confirmar: valida y, si está todo bien, cierra el formulario con resultado OK
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int cantidad = (int)nudCantidad.Value;
            string detalle = txtDetalle.Text.Trim();

            // Si es un egreso, no se puede sacar más de lo que hay
            if (tipo == "Egreso" && cantidad > producto.StockActual)
            {
                MessageBox.Show("No hay stock suficiente. Disponible: " + producto.StockActual, "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return;
            }

            // La fecha no puede ser futura
            if (dtpFecha.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha no puede ser posterior a hoy.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return;
            }

            // El detalle se guarda en la base en un campo de 250 letras como máximo
            if (detalle.Length > 250)
            {
                MessageBox.Show("El detalle no puede tener más de 250 letras.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDetalle.Focus();
                return;
            }

            // Todo bien: guardamos los datos en las propiedades para que el otro formulario los lea
            Cantidad = cantidad;
            Fecha = dtpFecha.Value.Date;
            Detalle = detalle;

            // Poner DialogResult.OK cierra el formulario
            this.DialogResult = DialogResult.OK;
        }

        // Botón Cancelar: cierra sin guardar nada
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
