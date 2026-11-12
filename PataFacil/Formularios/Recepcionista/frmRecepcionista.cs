using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace PataFacil
{
    public partial class frmRecepcionista : Form
    {
        public frmRecepcionista()
        {
            InitializeComponent();
        }

        private void ucClientesMascotas1_Load(object sender, EventArgs e)
        {

        }

        private void ucTurnos1_Load(object sender, EventArgs e)
        {

        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        "¿Está seguro de que desea cerrar sesión?",
        "Cerrar Sesión",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (resultado == DialogResult.Yes)
            {
                Application.Restart(); 
                Environment.Exit(0); // esto asegura que la aplicación se cierre completamente
            }
        }
    }
}
