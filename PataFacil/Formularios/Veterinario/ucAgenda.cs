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
    public partial class ucAgenda : UserControl
    {
        public ucAgenda()
        {
            InitializeComponent();
        }

        // Se ejecuta cuando el control se carga. DesignMode evita que corra dentro del diseñador de VS.
        private void ucAgenda_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dtpFecha.Value = DateTime.Today;
            CargarAgenda();
        }

        // Llena la grilla con los turnos del veterinario que entró, según la fecha y el checkbox.
        public void CargarAgenda()
        {
            if (DesignMode || Sesion.Email == "") return;

            try
            {
                DataTable tabla = new Dal().ObtenerAgenda(Sesion.Email, dtpFecha.Value, chkSoloPendientes.Checked);

                dgvAgenda.Rows.Clear();   // borra lo que había antes

                foreach (DataRow fila in tabla.Rows)
                {
                    int i = dgvAgenda.Rows.Add();                 // agrega una fila vacía y devuelve su posición
                    DataGridViewRow r = dgvAgenda.Rows[i];

                    r.Cells["colId"].Value = fila["IdTurno"];
                    r.Cells["colHora"].Value = ((DateTime)fila["FechaHora"]).ToString("HH:mm");
                    r.Cells["colMascota"].Value = fila["Mascota"];
                    r.Cells["colEspecie"].Value = fila["Especie"];
                    r.Cells["colDueno"].Value = fila["Dueno"];
                    r.Cells["colMotivo"].Value = fila["Motivo"];
                    r.Cells["colTipo"].Value = "Turno";           // la base no tiene tipo de turno
                    r.Cells["colEstado"].Value = fila["Estado"];

                    r.Tag = fila["IdMascota"];                    // guardo el id de la mascota en la fila, sin mostrarlo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la agenda: " + ex.Message);
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            CargarAgenda();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarAgenda();
        }

        private void chkSoloPendientes_CheckedChanged(object sender, EventArgs e)
        {
            CargarAgenda();
        }

        // Avisa al formulario: (idMascota, idTurno, motivo). idTurno es null si el turno ya no está pendiente.
        public event Action<int, int?, string>? PedidoAbrirHistoria;
        private void btnAbrirHistoria_Click(object sender, EventArgs e)
        {
            if (dgvAgenda.CurrentRow == null)
            {
                MessageBox.Show("Elegí un turno de la lista.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow r = dgvAgenda.CurrentRow;
            int idMascota = Convert.ToInt32(r.Tag);                          // lo guardamos en Tag al cargar
            string motivo = r.Cells["colMotivo"].Value?.ToString() ?? "";

            // Solo un turno pendiente se puede convertir en una consulta nueva.
            int? idTurno = null;
            if (r.Cells["colEstado"].Value?.ToString() == "Pendiente")
                idTurno = Convert.ToInt32(r.Cells["colId"].Value);

            PedidoAbrirHistoria?.Invoke(idMascota, idTurno, motivo);
        }
    }
}