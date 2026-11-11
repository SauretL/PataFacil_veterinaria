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

namespace PataFacil.Formularios.Recepcionista
{
    public partial class ucTurnos : UserControl
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=PataFacil;Integrated Security=True;TrustServerCertificate=True;";

        private int mascotaSeleccionadaId = -1;
        private int clienteSeleccionadoId = -1;
        private int turnoSeleccionadoId = -1;

        // Horarios disponibles para turnos (cada 30 min)
        private static readonly string[] Horarios = {
            "08:00", "08:30", "09:00", "09:30", "10:00", "10:30",
            "11:00", "11:30", "12:00", "12:30", "16:00", "16:30",
            "17:00", "17:30", "18:00", "18:30", "19:00", "19:30"
        };

        public ucTurnos()
        {
            InitializeComponent();

            // Enlace de eventos principales
            btnBuscarMascota.Click += btnBuscarMascota_Click;
            btnConsultarTurnos.Click += btnConsultarTurnos_Click;
            btnRegistrarTurno.Click += btnRegistrarTurno_Click;
            btnReprogramar.Click += btnReprogramar_Click;
            btnCancelarTurno.Click += btnCancelarTurno_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            // Al cambiar la fecha del turno, actualiza la grilla de turnos
            dtpFecha.ValueChanged += (s, e) => CargarTurnosGrilla();

            dgvTurnos.CellClick += dgvTurnos_CellClick;
            dgvTurnos.SelectionChanged += (s, e) => dgvTurnos.ClearSelection();

            ConfigurarMapeoGrilla();
            InicializarCombos();
            CargarVeterinarios();
            CargarTurnosGrilla();
        }

        private void ConfigurarMapeoGrilla()
        {
            dgvTurnos.ReadOnly = true;
            dgvTurnos.AutoGenerateColumns = false;

            // Mapeo explícito de columnas
            if (dgvTurnos.Columns["colFecha"] != null) dgvTurnos.Columns["colFecha"].DataPropertyName = "FechaFormateada";
            if (dgvTurnos.Columns["Fecha"] != null) dgvTurnos.Columns["Fecha"].DataPropertyName = "FechaFormateada";

            if (dgvTurnos.Columns["colHora"] != null) dgvTurnos.Columns["colHora"].DataPropertyName = "Hora";
            if (dgvTurnos.Columns["colMascota"] != null) dgvTurnos.Columns["colMascota"].DataPropertyName = "Mascota";

            if (dgvTurnos.Columns["colDuenio"] != null) dgvTurnos.Columns["colDuenio"].DataPropertyName = "Duenio";
            if (dgvTurnos.Columns["Dueño"] != null) dgvTurnos.Columns["Dueño"].DataPropertyName = "Duenio";
            if (dgvTurnos.Columns["Duenio"] != null) dgvTurnos.Columns["Duenio"].DataPropertyName = "Duenio";

            if (dgvTurnos.Columns["colVeterinario"] != null) dgvTurnos.Columns["colVeterinario"].DataPropertyName = "Veterinario";
            if (dgvTurnos.Columns["colMotivo"] != null) dgvTurnos.Columns["colMotivo"].DataPropertyName = "Motivo";
            if (dgvTurnos.Columns["colEstado"] != null) dgvTurnos.Columns["colEstado"].DataPropertyName = "Estado";

            foreach (DataGridViewColumn col in dgvTurnos.Columns)
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

        private void InicializarCombos()
        {
            cmbHora.Items.Clear();
            cmbHora.Items.AddRange(Horarios);
            dtpFecha.MinDate = DateTime.Today;
        }

        // ==========================================
        // CARGA DE VETERINARIOS DESDE LA TABLA USUARIO
        // ==========================================
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

                cmbVeterinario.DataSource = dt;
                cmbVeterinario.DisplayMember = "NombreCompleto";
                cmbVeterinario.ValueMember = "IdVeterinario";
                cmbVeterinario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de veterinarios: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // CARGA Y BÚSQUEDA DE TURNOS EN GRILLA
        // ==========================================
        private void CargarTurnosGrilla()
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
                WHERE CAST(t.FechaHora AS DATE) = @fecha
                ORDER BY t.FechaHora ASC";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                da.Fill(dt);
                AplicarDataSourceGrilla(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // CONSULTAR TURNOS EN LA GRILLA
        // ==========================================
        private void btnConsultarTurnos_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese DNI del dueño o Nombre de la Mascota para consultar turnos:", "Consultar Turnos", "");

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
                WHERE c.DNI = @filtro OR m.Nombre LIKE @likeFiltro OR c.Apellido LIKE @likeFiltro
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
                    mascotaSeleccionadaId = Convert.ToInt32(dr["IdMascota"]);
                    clienteSeleccionadoId = Convert.ToInt32(dr["IdCliente"]);
                    lblMascota.Text = $"Mascota: {dr["Mascota"]}";
                    lblDueno.Text = $"Dueño: {dr["Duenio"]}";
                }
                else
                {
                    MessageBox.Show("No se encontraron turnos registrados para el criterio ingresado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar turnos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarDataSourceGrilla(DataTable dt)
        {
            dgvTurnos.DataSource = dt;
            if (dgvTurnos.Columns["ID"] != null) dgvTurnos.Columns["ID"].Visible = false;
            if (dgvTurnos.Columns["FechaHora"] != null) dgvTurnos.Columns["FechaHora"].Visible = false;
            if (dgvTurnos.Columns["IdMascota"] != null) dgvTurnos.Columns["IdMascota"].Visible = false;
            if (dgvTurnos.Columns["IdCliente"] != null) dgvTurnos.Columns["IdCliente"].Visible = false;
            if (dgvTurnos.Columns["IdVeterinario"] != null) dgvTurnos.Columns["IdVeterinario"].Visible = false;

            dgvTurnos.ClearSelection();
        }

        // ==========================================
        // BÚSQUEDA Y SELECCIÓN DE MASCOTA
        // ==========================================
        private void btnBuscarMascota_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese DNI del dueño o Nombre de la Mascota:", "Buscar Paciente/Mascota", "");

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

            conn.Open();
            using var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mascotaSeleccionadaId = Convert.ToInt32(dr["IdMascota"]);
                clienteSeleccionadoId = Convert.ToInt32(dr["IdCliente"]);

                lblMascota.Text = $"Mascota: {dr["Mascota"]}";
                lblDueno.Text = $"Dueño: {dr["Duenio"]}";
            }
            else
            {
                MessageBox.Show("No se encontró ninguna mascota/cliente con ese criterio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // REGISTRAR NUEVO TURNO
        // ==========================================
        private void btnRegistrarTurno_Click(object sender, EventArgs e)
        {
            if (mascotaSeleccionadaId == -1)
            {
                MessageBox.Show("Por favor, seleccione una mascota mediante el botón 'Buscar mascota'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBuscarMascota.Focus();
                return;
            }

            if (cmbHora.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una 'Hora' para el turno.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHora.Focus();
                return;
            }

            if (cmbVeterinario.SelectedIndex == -1 || cmbVeterinario.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un 'Veterinario' para la atención.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVeterinario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("El campo 'Motivo' no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return;
            }

            TimeSpan horaParsed = TimeSpan.Parse(cmbHora.SelectedItem.ToString());
            DateTime fechaHoraFinal = dtpFecha.Value.Date.Add(horaParsed);
            int idVeterinario = Convert.ToInt32(cmbVeterinario.SelectedValue);

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string queryValidar = "SELECT COUNT(*) FROM Turno WHERE FechaHora = @fechaHora AND IdUsuario = @idVet AND Estado <> 'Cancelado'";
            using (var cmdVal = new SqlCommand(queryValidar, conn))
            {
                cmdVal.Parameters.AddWithValue("@fechaHora", fechaHoraFinal);
                cmdVal.Parameters.AddWithValue("@idVet", idVeterinario);

                int ocupados = Convert.ToInt32(cmdVal.ExecuteScalar());
                if (ocupados > 0)
                {
                    MessageBox.Show("El veterinario ya posee un turno agendado en ese horario.", "Horario Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbHora.Focus();
                    return;
                }
            }

            string queryInsert = @"INSERT INTO Turno (IdMascota, IdUsuario, FechaHora, Motivo, Estado) 
                                   VALUES (@idMascota, @idVet, @fechaHora, @motivo, 'Pendiente')";

            using (var cmdInsert = new SqlCommand(queryInsert, conn))
            {
                cmdInsert.Parameters.AddWithValue("@idMascota", mascotaSeleccionadaId);
                cmdInsert.Parameters.AddWithValue("@idVet", idVeterinario);
                cmdInsert.Parameters.AddWithValue("@fechaHora", fechaHoraFinal);
                cmdInsert.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());

                cmdInsert.ExecuteNonQuery();
            }

            MessageBox.Show("Turno registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarTurnosGrilla();
        }

        // ==========================================
        // REPROGRAMAR TURNO EXISTENTE
        // ==========================================
        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionadoId == -1)
            {
                MessageBox.Show("Seleccione un turno de la tabla para reprogramar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbHora.SelectedIndex == -1 || cmbVeterinario.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Por favor complete Fecha, Hora, Veterinario y Motivo antes de reprogramar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan horaParsed = TimeSpan.Parse(cmbHora.SelectedItem.ToString());
            DateTime fechaHoraFinal = dtpFecha.Value.Date.Add(horaParsed);
            int idVeterinario = Convert.ToInt32(cmbVeterinario.SelectedValue);

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string queryValidar = "SELECT COUNT(*) FROM Turno WHERE FechaHora = @fechaHora AND IdUsuario = @idVet AND IdTurno <> @idTurno AND Estado <> 'Cancelado'";
            using (var cmdVal = new SqlCommand(queryValidar, conn))
            {
                cmdVal.Parameters.AddWithValue("@fechaHora", fechaHoraFinal);
                cmdVal.Parameters.AddWithValue("@idVet", idVeterinario);
                cmdVal.Parameters.AddWithValue("@idTurno", turnoSeleccionadoId);

                int ocupados = Convert.ToInt32(cmdVal.ExecuteScalar());
                if (ocupados > 0)
                {
                    MessageBox.Show("El veterinario no tiene disponible ese horario para la reprogramación.", "Horario Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string queryUpdate = @"UPDATE Turno 
                                   SET FechaHora = @fechaHora, IdUsuario = @idVet, Motivo = @motivo, Estado = 'Reprogramado' 
                                   WHERE IdTurno = @idTurno";

            using (var cmdUpdate = new SqlCommand(queryUpdate, conn))
            {
                cmdUpdate.Parameters.AddWithValue("@fechaHora", fechaHoraFinal);
                cmdUpdate.Parameters.AddWithValue("@idVet", idVeterinario);
                cmdUpdate.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());
                cmdUpdate.Parameters.AddWithValue("@idTurno", turnoSeleccionadoId);

                cmdUpdate.ExecuteNonQuery();
            }

            MessageBox.Show("Turno reprogramado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarTurnosGrilla();
        }

        // ==========================================
        // CANCELAR TURNO
        // ==========================================
        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionadoId == -1)
            {
                MessageBox.Show("Seleccione un turno de la tabla para cancelar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("¿Está seguro de que desea cancelar este turno?", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using var conn = new SqlConnection(connectionString);
                string query = "UPDATE Turno SET Estado = 'Cancelado' WHERE IdTurno = @idTurno";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTurno", turnoSeleccionadoId);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Turno cancelado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarTurnosGrilla();
            }
        }

        // ==========================================
        // SELECCIÓN DE FILA EN GRILLA DE TURNOS
        // ==========================================
        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTurnos.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
            {
                turnoSeleccionadoId = Convert.ToInt32(drv["ID"]);
                mascotaSeleccionadaId = Convert.ToInt32(drv["IdMascota"]);
                clienteSeleccionadoId = Convert.ToInt32(drv["IdCliente"]);

                lblMascota.Text = $"Mascota: {drv["Mascota"]}";
                lblDueno.Text = $"Dueño: {drv["Duenio"]}";

                if (drv["FechaHora"] != DBNull.Value)
                {
                    DateTime fh = Convert.ToDateTime(drv["FechaHora"]);
                    dtpFecha.Value = fh.Date;
                    cmbHora.SelectedItem = fh.ToString("hh\\:mm");
                }

                if (drv["IdVeterinario"] != DBNull.Value) cmbVeterinario.SelectedValue = Convert.ToInt32(drv["IdVeterinario"]);
                txtMotivo.Text = drv["Motivo"]?.ToString() ?? string.Empty;
            }

            dgvTurnos.ClearSelection();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            turnoSeleccionadoId = -1;
            mascotaSeleccionadaId = -1;
            clienteSeleccionadoId = -1;

            lblMascota.Text = "Mascota: (sin seleccionar)";
            lblDueno.Text = "Dueño: -";

            dtpFecha.Value = DateTime.Today;
            cmbHora.SelectedIndex = -1;
            cmbVeterinario.SelectedIndex = -1;
            txtMotivo.Clear();

            dgvTurnos.ClearSelection();
        }
    }
}