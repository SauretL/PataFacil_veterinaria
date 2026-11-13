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
    public partial class frmMovimientoStock : Form
    {
        private Producto producto;
        private string tipo;      

     
        public int Cantidad { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Detalle { get; private set; }

        public frmMovimientoStock()
        {
            InitializeComponent();
        }


        internal frmMovimientoStock(Producto productoElegido, string tipoMovimiento) : this()
        {
            producto = productoElegido;
            tipo = tipoMovimiento;

            btnConfirmar.Click += btnConfirmar_Click;
            btnCancelar.Click += btnCancelar_Click;

            this.Text = tipo + " de stock";
            lblProducto.Text = "Producto: " + producto.Nombre;

            if (tipo == "Ingreso")
            {
                lblTipo.Text = "Ingreso de stock";
            }
            else
            {
                lblTipo.Text = "Egreso de stock - disponible: " + producto.StockActual;
            }

            dtpFecha.Value = DateTime.Today;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int cantidad = (int)nudCantidad.Value;
            string detalle = txtDetalle.Text.Trim();

            if (tipo == "Egreso" && cantidad > producto.StockActual)
            {
                MessageBox.Show("No hay stock suficiente. Disponible: " + producto.StockActual, "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return;
            }

            if (dtpFecha.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha no puede ser posterior a hoy.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return;
            }

            if (detalle.Length > 250)
            {
                MessageBox.Show("El detalle no puede tener más de 250 letras.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDetalle.Focus();
                return;
            }

            Cantidad = cantidad;
            Fecha = dtpFecha.Value.Date;
            Detalle = detalle;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
