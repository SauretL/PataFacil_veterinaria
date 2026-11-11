using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PataFacil
{
    public partial class frmAuxiliar : Form
    {

        // Productos de prueba
        private readonly Dictionary<string, (string Clave, string Rol)> productos = new()
        {
            ["recepcion"] = ("1234", "Recepcionista"),
            ["vet"] = ("1234", "Veterinario"),
            ["aux"] = ("1234", "Auxiliar")
        };

        public frmAuxiliar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();

            login.Show();

            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
