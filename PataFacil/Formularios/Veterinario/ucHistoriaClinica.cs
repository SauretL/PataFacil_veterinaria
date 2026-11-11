using Microsoft.Data.SqlClient;
using PataFacil.Clases;
using PataFacil.Datos;
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
    public partial class ucHistoriaClinica : UserControl
    {
        private int? _idMascota;          // null = todavía no hay mascota elegida
        private int? _idTurno;            // turno del que viene la consulta (null si no corresponde)
        private string _motivoTurno = ""; // motivo del turno, solo para mostrar
        private bool _cargando;           // evita reacciones raras mientras se llena la grilla

        public ucHistoriaClinica()
        {
            InitializeComponent();
        }

        private void ucHistoriaClinica_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            txtMotivo.ReadOnly = true;      // el motivo viene del turno, no se escribe acá
            txtObservaciones.Enabled = false; // la base no tiene este campo
        }

        // La llama frmVeterinario cuando se elige un turno en la agenda.
        public void CargarMascota(int idMascota, int? idTurno, string motivoTurno)
        {
            try
            {
                DataTable mascota = new Dal().ObtenerMascota(idMascota);
                if (mascota.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró la mascota.");
                    return;
                }

                _idMascota = idMascota;
                _idTurno = idTurno;
                _motivoTurno = motivoTurno;

                lblMascota.Text = "Mascota: " + mascota.Rows[0]["Nombre"] + " (" + mascota.Rows[0]["Especie"] + ")";
                lblDueno.Text = "Dueño: " + mascota.Rows[0]["Dueno"];

                CargarConsultas();
                NuevaConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la mascota: " + ex.Message);
            }
        }

        // Llena la grilla con las consultas anteriores de la mascota.
        private void CargarConsultas()
        {
            _cargando = true;
            dgvConsultas.Rows.Clear();

            DataTable consultas = new Dal().ObtenerConsultas(_idMascota!.Value);
            foreach (DataRow fila in consultas.Rows)
            {
                int i = dgvConsultas.Rows.Add();
                DataGridViewRow r = dgvConsultas.Rows[i];

                r.Cells["colId"].Value = fila["IdConsulta"];
                r.Cells["colFecha"].Value = ((DateTime)fila["FechaHora"]).ToString("dd/MM/yyyy");
                r.Cells["colVeterinario"].Value = fila["Veterinario"];
                r.Cells["colMotivo"].Value = fila["Motivo"];
                r.Cells["colDiagnostico"].Value = fila["Diagnostico"];

                r.Tag = fila;   // guardo la fila completa para mostrar el tratamiento al seleccionarla
            }

            dgvConsultas.ClearSelection();
            _cargando = false;
        }

        // Deja los campos listos para escribir una consulta nueva.
        private void NuevaConsulta()
        {
            dtpFechaConsulta.Value = DateTime.Today;
            txtMotivo.Text = _motivoTurno;
            txtDiagnostico.Clear();
            txtTratamiento.Clear();
            PonerSoloLectura(false);
        }

        // Alterna entre "escribir una consulta nueva" y "ver una consulta vieja" (solo lectura).
        private void PonerSoloLectura(bool soloLectura)
        {
            txtDiagnostico.ReadOnly = soloLectura;
            txtTratamiento.ReadOnly = soloLectura;
            btnGuardarConsulta.Enabled = !soloLectura;
        }

        // Al elegir una consulta anterior en la grilla, se muestran sus datos sin poder editarlos.
        private void dgvConsultas_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvConsultas.SelectedRows.Count == 0 || dgvConsultas.CurrentRow == null)
                return;

            DataRow fila = (DataRow)dgvConsultas.CurrentRow.Tag;

            dtpFechaConsulta.Value = (DateTime)fila["FechaHora"];
            txtMotivo.Text = fila["Motivo"]?.ToString() ?? "";
            txtDiagnostico.Text = fila["Diagnostico"]?.ToString() ?? "";
            txtTratamiento.Text = fila["Tratamiento"]?.ToString() ?? "";
            PonerSoloLectura(true);
        }

        private void btnBuscarMascota_Click(object sender, EventArgs e)
        {
            // La ventana para buscar mascotas la hace Recepcionista; por ahora no está lista.
            MessageBox.Show("Por ahora, abrí la historia desde un turno de la Agenda.");
        }

        private void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            if (_idMascota == null)
            {
                MessageBox.Show("Primero elegí una mascota.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvConsultas.ClearSelection();
            NuevaConsulta();
        }

        private void btnGuardarConsulta_Click(object sender, EventArgs e)
        {
            if (_idMascota == null)
            {
                MessageBox.Show("Primero elegí una mascota.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_idTurno == null)
            {
                MessageBox.Show("Para guardar una consulta, abrí la historia desde un turno pendiente de la Agenda.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiagnostico.Text))
            {
                MessageBox.Show("Completá el campo Diagnóstico.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnostico.Focus();
                return;
            }

            try
            {
                new Dal().GuardarConsulta(_idTurno.Value, _idMascota.Value, Sesion.Email,
                                          txtDiagnostico.Text.Trim(), txtTratamiento.Text);

                MessageBox.Show("Consulta guardada.", "Listo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                _idTurno = null;        // ese turno ya se usó
                _motivoTurno = "";
                CargarConsultas();
                NuevaConsulta();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Error de "clave duplicada": ese turno ya tenía una consulta.
                MessageBox.Show("Ese turno ya tiene una consulta guardada.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
