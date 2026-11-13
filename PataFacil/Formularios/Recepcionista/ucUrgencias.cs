using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PataFacil.Datos;


namespace PataFacil.Formularios.Recepcionista
{
    public partial class ucUrgencias : UserControl
    {
        private readonly string connectionString = Conexion.sConnection;

        private int mascotaSeleccionadaId = -1;
        private int clienteSeleccionadoId = -1;

        // Referencias a controles
        private DataGridView dgvTurnosRef;
        private Button btnRegistrarRef;
        private Label lblMascotaRef;
        private Label lblDuenoRef;

        public ucUrgencias()
        {
            InitializeComponent();
            ResolverReferenciasControles();

            // Enlace de eventos principales
            if (btnBuscarMascota != null) btnBuscarMascota.Click += btnBuscarMascota_Click;
            if (btnConsultarTurnos != null) btnConsultarTurnos.Click += btnConsultarTurnos_Click;
            if (btnRegistrarRef != null) btnRegistrarRef.Click += btnRegistrarUrgencia_Click;
            if (btnLimpiar != null) btnLimpiar.Click += btnLimpiar_Click;

            if (dgvTurnosRef != null)
            {
                dgvTurnosRef.CellClick += dgvTurnos_CellClick;
                dgvTurnosRef.SelectionChanged += (s, e) => dgvTurnosRef.ClearSelection();
            }

            ConfigurarMapeoGrilla();
            CargarVeterinarios();
            CargarUrgenciasGrilla();
        }

        private void ResolverReferenciasControles()
        {
            // Resolución prioritaria para la grilla dgvUrgenciasHoy
            var posiblesGrillas = new[] { "dgvUrgenciasHoy", "dgvTurnos", "dgvUrgencias", "dataGridView1" };
            foreach (var nombre in posiblesGrillas)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as DataGridView;
                if (hallado != null)
                {
                    dgvTurnosRef = hallado;
                    break;
                }
            }

            // Resolución para Botón Registrar Urgencia
            var posiblesBotones = new[] { "btnRegistrarUrgencia", "btnRegistrar", "btnGuardarUrgencia" };
            foreach (var nombre in posiblesBotones)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as Button;
                if (hallado != null)
                {
                    btnRegistrarRef = hallado;
                    break;
                }
            }

            // Resolución para Label Mascota
            var posiblesLblMascota = new[] { "lblMascotaUrgencia", "lblMascota", "lblPaciente" };
            foreach (var nombre in posiblesLblMascota)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as Label;
                if (hallado != null)
                {
                    lblMascotaRef = hallado;
                    break;
                }
            }

            // Resolución para Label Dueño
            var posiblesLblDueno = new[] { "lblDuenoUrgencia", "lblDueno", "lblCliente" };
            foreach (var nombre in posiblesLblDueno)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as Label;
                if (hallado != null)
                {
                    lblDuenoRef = hallado;
                    break;
                }
            }
        }

        private void ConfigurarMapeoGrilla()
        {
            if (dgvTurnosRef == null) return;

            dgvTurnosRef.ReadOnly = true;
            dgvTurnosRef.AutoGenerateColumns = false;

            if (dgvTurnosRef.Columns["colFecha"] != null) dgvTurnosRef.Columns["colFecha"].DataPropertyName = "FechaFormateada";
            if (dgvTurnosRef.Columns["Fecha"] != null) dgvTurnosRef.Columns["Fecha"].DataPropertyName = "FechaFormateada";

            if (dgvTurnosRef.Columns["colHora"] != null) dgvTurnosRef.Columns["colHora"].DataPropertyName = "Hora";
            if (dgvTurnosRef.Columns["Hora"] != null) dgvTurnosRef.Columns["Hora"].DataPropertyName = "Hora";

            if (dgvTurnosRef.Columns["colMascota"] != null) dgvTurnosRef.Columns["colMascota"].DataPropertyName = "Mascota";
            if (dgvTurnosRef.Columns["Mascota"] != null) dgvTurnosRef.Columns["Mascota"].DataPropertyName = "Mascota";

            if (dgvTurnosRef.Columns["colDuenio"] != null) dgvTurnosRef.Columns["colDuenio"].DataPropertyName = "Duenio";
            if (dgvTurnosRef.Columns["Dueño"] != null) dgvTurnosRef.Columns["Dueño"].DataPropertyName = "Duenio";
            if (dgvTurnosRef.Columns["Duenio"] != null) dgvTurnosRef.Columns["Duenio"].DataPropertyName = "Duenio";

            if (dgvTurnosRef.Columns["colVeterinario"] != null) dgvTurnosRef.Columns["colVeterinario"].DataPropertyName = "Veterinario";
            if (dgvTurnosRef.Columns["Veterinario"] != null) dgvTurnosRef.Columns["Veterinario"].DataPropertyName = "Veterinario";

            if (dgvTurnosRef.Columns["colMotivo"] != null) dgvTurnosRef.Columns["colMotivo"].DataPropertyName = "Motivo";
            if (dgvTurnosRef.Columns["Motivo"] != null) dgvTurnosRef.Columns["Motivo"].DataPropertyName = "Motivo";

            if (dgvTurnosRef.Columns["colEstado"] != null) dgvTurnosRef.Columns["colEstado"].DataPropertyName = "Estado";
            if (dgvTurnosRef.Columns["Estado"] != null) dgvTurnosRef.Columns["Estado"].DataPropertyName = "Estado";

            foreach (DataGridViewColumn col in dgvTurnosRef.Columns)
            {
                if (string.IsNullOrEmpty(col.DataPropertyName))
                {
                    if (col.Name.Equals("Dueño", StringComparison.OrdinalIgnoreCase) || col.HeaderText.Equals("Dueño", StringComparison.OrdinalIgnoreCase))
                        col.DataPropertyName = "Duenio";
                    else if (col.Name.Equals("Fecha", StringComparison.OrdinalIgnoreCase) || col.HeaderText.Equals("Fecha", StringComparison.OrdinalIgnoreCase))
                        col.DataPropertyName = "FechaFormateada";
                    else
                        col.DataPropertyName = col.Name;
                }
            }
        }

        private void CargarVeterinarios()
        {
            using var conn = new SqlConnection(connectionString);
            string query = @"SELECT IdUsuario AS IdVeterinario, Nombre AS NombreCompleto 
                             FROM Usuario 
                             WHERE (LOWER(Rol) = 'veterinario' OR LOWER(Rol) = 'vet') AND Activo = 1";

            using var cmd = new SqlCommand(query, conn);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                da.Fill(dt);

                if (cmbVeterinario != null)
                {
                    cmbVeterinario.DataSource = dt;
                    cmbVeterinario.DisplayMember = "NombreCompleto";
                    cmbVeterinario.ValueMember = "IdVeterinario";
                    cmbVeterinario.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de veterinarios: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUrgenciasGrilla()
        {
            using var conn = new SqlConnection(connectionString);
            string query = @"
                SELECT 
                    t.IdTurno AS ID,
                    CONVERT(VARCHAR(10), t.FechaHora, 103) AS FechaFormateada,
                    CONVERT(VARCHAR(5), t.FechaHora, 108) AS Hora,
                    m.Nombre AS Mascota,
                    ISNULL(c.Nombre, '') + ' ' + ISNULL(c.Apellido, '') AS Duenio,
                    u.Nombre AS Veterinario,
                    t.Motivo AS Motivo,
                    t.Estado AS Estado,
                    t.FechaHora AS FechaHora,
                    t.IdMascota AS IdMascota,
                    c.IdCliente AS IdCliente,
                    t.IdUsuario AS IdVeterinario
                FROM Turno t
                INNER JOIN Mascota m ON t.IdMascota = m.IdMascota
                INNER JOIN Cliente c ON m.IdCliente = c.IdCliente
                INNER JOIN Usuario u ON t.IdUsuario = u.IdUsuario
                WHERE CAST(t.FechaHora AS DATE) = CAST(GETDATE() AS DATE)
                  AND LOWER(t.Estado) = 'urgencia'
                ORDER BY t.FechaHora DESC";

            using var cmd = new SqlCommand(query, conn);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                da.Fill(dt);
                AplicarDataSourceGrilla(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar urgencias: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarMascota_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese DNI del dueño o Nombre de la Mascota:", "Buscar Paciente para Urgencia", "");

            if (string.IsNullOrWhiteSpace(input)) return;

            using var conn = new SqlConnection(connectionString);
            string query = @"
                SELECT TOP 1 m.IdMascota, m.Nombre AS Mascota, c.IdCliente, ISNULL(c.Nombre, '') + ' ' + ISNULL(c.Apellido, '') AS Duenio 
                FROM Mascota m
                INNER JOIN Cliente c ON m.IdCliente = c.IdCliente
                WHERE c.DNI = @filtro OR m.Nombre LIKE @likeFiltro OR c.Apellido LIKE @likeFiltro";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@filtro", input.Trim());
            cmd.Parameters.AddWithValue("@likeFiltro", $"%{input.Trim()}%");

            try
            {
                conn.Open();
                using var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mascotaSeleccionadaId = Convert.ToInt32(dr["IdMascota"]);
                    clienteSeleccionadoId = Convert.ToInt32(dr["IdCliente"]);

                    ActualizarLabelsCliente(dr["Mascota"]?.ToString(), dr["Duenio"]?.ToString());
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna mascota/cliente con ese criterio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar paciente: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarTurnos_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese DNI del dueño o Nombre de la Mascota para consultar urgencias:", "Consultar Urgencias", "");

            if (string.IsNullOrWhiteSpace(input)) return;

            using var conn = new SqlConnection(connectionString);
            string query = @"
                SELECT 
                    t.IdTurno AS ID,
                    CONVERT(VARCHAR(10), t.FechaHora, 103) AS FechaFormateada,
                    CONVERT(VARCHAR(5), t.FechaHora, 108) AS Hora,
                    m.Nombre AS Mascota,
                    ISNULL(c.Nombre, '') + ' ' + ISNULL(c.Apellido, '') AS Duenio,
                    u.Nombre AS Veterinario,
                    t.Motivo AS Motivo,
                    t.Estado AS Estado,
                    t.FechaHora AS FechaHora,
                    t.IdMascota AS IdMascota,
                    c.IdCliente AS IdCliente,
                    t.IdUsuario AS IdVeterinario
                FROM Turno t
                INNER JOIN Mascota m ON t.IdMascota = m.IdMascota
                INNER JOIN Cliente c ON m.IdCliente = c.IdCliente
                INNER JOIN Usuario u ON t.IdUsuario = u.IdUsuario
                WHERE (c.DNI = @filtro OR m.Nombre LIKE @likeFiltro OR c.Apellido LIKE @likeFiltro)
                  AND LOWER(t.Estado) = 'urgencia'
                ORDER BY t.FechaHora DESC";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@filtro", input.Trim());
            cmd.Parameters.AddWithValue("@likeFiltro", $"%{input.Trim()}%");

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    AplicarDataSourceGrilla(dt);

                    DataRow dr = dt.Rows[0];
                    if (dr["IdMascota"] != DBNull.Value) mascotaSeleccionadaId = Convert.ToInt32(dr["IdMascota"]);
                    if (dr["IdCliente"] != DBNull.Value) clienteSeleccionadoId = Convert.ToInt32(dr["IdCliente"]);

                    ActualizarLabelsCliente(dr["Mascota"]?.ToString(), dr["Duenio"]?.ToString());
                }
                else
                {
                    MessageBox.Show("No se encontraron registros de URGENCIA para el criterio ingresado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar registros: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarDataSourceGrilla(DataTable dt)
        {
            if (dgvTurnosRef == null)
                ResolverReferenciasControles();

            if (dgvTurnosRef != null)
            {
                dgvTurnosRef.DataSource = null;
                dgvTurnosRef.DataSource = dt;

                if (dgvTurnosRef.Columns["ID"] != null) dgvTurnosRef.Columns["ID"].Visible = false;
                if (dgvTurnosRef.Columns["FechaHora"] != null) dgvTurnosRef.Columns["FechaHora"].Visible = false;
                if (dgvTurnosRef.Columns["IdMascota"] != null) dgvTurnosRef.Columns["IdMascota"].Visible = false;
                if (dgvTurnosRef.Columns["IdCliente"] != null) dgvTurnosRef.Columns["IdCliente"].Visible = false;
                if (dgvTurnosRef.Columns["IdVeterinario"] != null) dgvTurnosRef.Columns["IdVeterinario"].Visible = false;

                dgvTurnosRef.ClearSelection();
                dgvTurnosRef.Refresh();
            }
        }

        private void btnRegistrarUrgencia_Click(object sender, EventArgs e)
        {
            if (mascotaSeleccionadaId == -1)
            {
                MessageBox.Show("Por favor, seleccione una mascota mediante el botón 'Buscar mascota'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (btnBuscarMascota != null) btnBuscarMascota.Focus();
                return;
            }

            if (cmbVeterinario == null || cmbVeterinario.SelectedIndex == -1 || cmbVeterinario.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un 'Veterinario' para la urgencia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (cmbVeterinario != null) cmbVeterinario.Focus();
                return;
            }

            if (txtMotivo == null || string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("El campo 'Motivo de la urgencia' no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtMotivo != null) txtMotivo.Focus();
                return;
            }

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            // Validar si la mascota ya posee una urgencia registrada en el día actual
            string queryValidar = @"SELECT COUNT(*) 
                                    FROM Turno 
                                    WHERE IdMascota = @idMascota 
                                      AND CAST(FechaHora AS DATE) = CAST(GETDATE() AS DATE) 
                                      AND LOWER(Estado) = 'urgencia'";

            using (var cmdVal = new SqlCommand(queryValidar, conn))
            {
                cmdVal.Parameters.AddWithValue("@idMascota", mascotaSeleccionadaId);
                int urgenciasHoy = Convert.ToInt32(cmdVal.ExecuteScalar());

                if (urgenciasHoy > 0)
                {
                    MessageBox.Show("La mascota seleccionada ya posee una urgencia registrada en el día de hoy.", "Urgencia Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DateTime fechaHoraActual = DateTime.Now;
            int idVeterinario = Convert.ToInt32(cmbVeterinario.SelectedValue);

            string queryInsert = @"INSERT INTO Turno (IdMascota, IdUsuario, FechaHora, Motivo, Estado) 
                                   VALUES (@idMascota, @idVet, @fechaHora, @motivo, 'Urgencia')";

            using (var cmdInsert = new SqlCommand(queryInsert, conn))
            {
                cmdInsert.Parameters.AddWithValue("@idMascota", mascotaSeleccionadaId);
                cmdInsert.Parameters.AddWithValue("@idVet", idVeterinario);
                cmdInsert.Parameters.AddWithValue("@fechaHora", fechaHoraActual);
                cmdInsert.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());

                cmdInsert.ExecuteNonQuery();
            }

            MessageBox.Show("Urgencia registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarUrgenciasGrilla();
        }

        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTurnosRef == null) return;

            if (e.RowIndex >= 0 && dgvTurnosRef.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
            {
                if (drv["IdMascota"] != DBNull.Value) mascotaSeleccionadaId = Convert.ToInt32(drv["IdMascota"]);
                if (drv["IdCliente"] != DBNull.Value) clienteSeleccionadoId = Convert.ToInt32(drv["IdCliente"]);

                ActualizarLabelsCliente(drv["Mascota"]?.ToString(), drv["Duenio"]?.ToString());

                if (cmbVeterinario != null && drv["IdVeterinario"] != DBNull.Value)
                    cmbVeterinario.SelectedValue = Convert.ToInt32(drv["IdVeterinario"]);

                if (txtMotivo != null)
                    txtMotivo.Text = drv["Motivo"]?.ToString() ?? string.Empty;
            }

            dgvTurnosRef.ClearSelection();
        }

        private void ActualizarLabelsCliente(string mascota, string dueno)
        {
            if (lblMascotaRef != null) lblMascotaRef.Text = $"Mascota: {mascota}";
            if (lblDuenoRef != null) lblDuenoRef.Text = $"Dueño: {dueno}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            mascotaSeleccionadaId = -1;
            clienteSeleccionadoId = -1;

            if (lblMascotaRef != null) lblMascotaRef.Text = "Mascota: (sin seleccionar)";
            if (lblDuenoRef != null) lblDuenoRef.Text = "Dueño: -";

            if (cmbVeterinario != null) cmbVeterinario.SelectedIndex = -1;
            if (txtMotivo != null) txtMotivo.Clear();

            if (dgvTurnosRef != null) dgvTurnosRef.ClearSelection();
        }
    }
}