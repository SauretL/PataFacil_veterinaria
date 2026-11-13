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
    public partial class frmVeterinario : Form
    {
        public frmVeterinario()
        {
            InitializeComponent();
            lblUsuario.Text = "Usuario: " + Sesion.Nombre;

            ucAgenda1.PedidoAbrirHistoria += (idMascota, idTurno, motivo) =>
            {
                ucHistoriaClinica1.CargarMascota(idMascota, idTurno, motivo);
                tabPrincipal.SelectedTab = tabHistoria;
            };
        }

        // Al volver a la pestaña Agenda, se recarga para ver los estados actualizados.
        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPrincipal.SelectedTab == tabAgenda)
                ucAgenda1.CargarAgenda();
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Se vacía la sesión: así el login sabe que fue un cierre de sesión y no la X.
            Sesion.Email = "";
            Sesion.Nombre = "";

            // Se cierra este formulario. Eso dispara el FormClosed del login, que lo vuelve a mostrar.
            this.Close();
        }
    }
}
