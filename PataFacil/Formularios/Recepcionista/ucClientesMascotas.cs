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
    public partial class ucClientesMascotas : UserControl
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=PataFacil;Integrated Security=True;TrustServerCertificate=True;";
        private int clienteSeleccionadoId = -1;
        private int mascotaSeleccionadaId = -1;

        private static readonly string[] Especies = { "Perro", "Gato", "Ave", "Roedor", "Otro" };
        private static readonly string[] Sexos = { "Macho", "Hembra" };

        public ucClientesMascotas()
        {
            InitializeComponent();
            ConfigurarMapeoColumnas();
            InicializarCombos();
            CargarClientes();
        }

        private void ConfigurarMapeoColumnas()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvMascotas.AutoGenerateColumns = false;

            if (dgvClientes.Columns["colApellido"] != null) dgvClientes.Columns["colApellido"].DataPropertyName = "Apellido";
            if (dgvClientes.Columns["colNombre"] != null) dgvClientes.Columns["colNombre"].DataPropertyName = "Nombre";
            if (dgvClientes.Columns["colDni"] != null) dgvClientes.Columns["colDni"].DataPropertyName = "DNI";
            if (dgvClientes.Columns["colTelefono"] != null) dgvClientes.Columns["colTelefono"].DataPropertyName = "Telefono";
            if (dgvClientes.Columns["colEmail"] != null) dgvClientes.Columns["colEmail"].DataPropertyName = "Email";

            foreach (DataGridViewColumn col in dgvClientes.Columns)
            {
                if (string.IsNullOrEmpty(col.DataPropertyName))
                    col.DataPropertyName = col.Name;
            }

            if (dgvMascotas.Columns["colNombreMascota"] != null) dgvMascotas.Columns["colNombreMascota"].DataPropertyName = "Nombre";
            if (dgvMascotas.Columns["colEspecie"] != null) dgvMascotas.Columns["colEspecie"].DataPropertyName = "Especie";
            if (dgvMascotas.Columns["colRaza"] != null) dgvMascotas.Columns["colRaza"].DataPropertyName = "Raza";
            if (dgvMascotas.Columns["colSexo"] != null) dgvMascotas.Columns["colSexo"].DataPropertyName = "Sexo";
            if (dgvMascotas.Columns["colNacimiento"] != null) dgvMascotas.Columns["colNacimiento"].DataPropertyName = "Nacimiento";

            foreach (DataGridViewColumn col in dgvMascotas.Columns)
            {
                if (string.IsNullOrEmpty(col.DataPropertyName))
                    col.DataPropertyName = col.Name;
            }
        }

        private void InicializarCombos()
        {
            cmbEspecie.Items.Clear();
            cmbEspecie.Items.AddRange(Especies);

            cmbSexo.Items.Clear();
            cmbSexo.Items.AddRange(Sexos);
        }

        // ==========================================
        // CARGA Y BÚSQUEDA DE DATOS
        // ==========================================
        private void CargarClientes(string filtro = "", int idClienteASeleccionar = -1)
        {
            using var conn = new SqlConnection(connectionString);
            string query = "SELECT IdCliente AS ID, Apellido AS Apellido, Nombre AS Nombre, DNI AS DNI, Telefono AS Telefono, Email AS Email FROM Cliente WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (Nombre LIKE @filtro OR Apellido LIKE @filtro OR DNI LIKE @filtro)";
            }

            using var cmd = new SqlCommand(query, conn);
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");
            }

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            da.Fill(dt);

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = dt;

            if (dgvClientes.Columns["ID"] != null)
                dgvClientes.Columns["ID"].Visible = false;

            if (dgvClientes.Rows.Count > 0)
            {
                int indexFila = 0;

                if (idClienteASeleccionar != -1)
                {
                    for (int i = 0; i < dgvClientes.Rows.Count; i++)
                    {
                        if (dgvClientes.Rows[i].DataBoundItem is DataRowView drvTemp && Convert.ToInt32(drvTemp["ID"]) == idClienteASeleccionar)
                        {
                            indexFila = i;
                            break;
                        }
                    }
                }

                dgvClientes.ClearSelection();
                dgvClientes.Rows[indexFila].Selected = true;

                for (int c = 0; c < dgvClientes.Columns.Count; c++)
                {
                    if (dgvClientes.Columns[c].Visible)
                    {
                        dgvClientes.CurrentCell = dgvClientes.Rows[indexFila].Cells[c];
                        break;
                    }
                }

                if (dgvClientes.Rows[indexFila].DataBoundItem is DataRowView drv)
                {
                    clienteSeleccionadoId = Convert.ToInt32(drv["ID"]);
                    txtApellido.Text = drv["Apellido"]?.ToString() ?? string.Empty;
                    txtNombre.Text = drv["Nombre"]?.ToString() ?? string.Empty;
                    txtDni.Text = drv["DNI"]?.ToString() ?? string.Empty;
                    txtTelefono.Text = drv["Telefono"]?.ToString() ?? string.Empty;
                    txtEmail.Text = drv["Email"]?.ToString() ?? string.Empty;

                    // Si hay filtro activo de búsqueda, carga las mascotas de TODOS los clientes filtrados
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        CargarMascotasPorFiltroCliente(filtro);
                    }
                    else
                    {
                        CargarMascotasDelCliente(clienteSeleccionadoId);
                    }
                }
            }
            else
            {
                LimpiarCampos(limpiarGrillaMascotas: true);
            }
        }

        private void CargarMascotasDelCliente(int idCliente)
        {
            using var conn = new SqlConnection(connectionString);
            string query = "SELECT IdMascota AS ID, Nombre AS Nombre, Especie AS Especie, Raza AS Raza, Sexo AS Sexo, FechaNacimiento AS Nacimiento FROM Mascota WHERE IdCliente = @idCliente";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            da.Fill(dt);

            dgvMascotas.AutoGenerateColumns = false;
            dgvMascotas.DataSource = dt;

            if (dgvMascotas.Columns["ID"] != null)
                dgvMascotas.Columns["ID"].Visible = false;
        }

        // Carga todas las mascotas pertenecientes a cualquier cliente que coincida con la búsqueda
        private void CargarMascotasPorFiltroCliente(string filtro)
        {
            using var conn = new SqlConnection(connectionString);
            string query = @"SELECT m.IdMascota AS ID, m.Nombre AS Nombre, m.Especie AS Especie, m.Raza AS Raza, m.Sexo AS Sexo, m.FechaNacimiento AS Nacimiento 
                            FROM Mascota m
                            INNER JOIN Cliente c ON m.IdCliente = c.IdCliente
                            WHERE (c.Nombre LIKE @filtro OR c.Apellido LIKE @filtro OR c.DNI LIKE @filtro)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            da.Fill(dt);

            dgvMascotas.AutoGenerateColumns = false;
            dgvMascotas.DataSource = dt;

            if (dgvMascotas.Columns["ID"] != null)
                dgvMascotas.Columns["ID"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text.Trim());
        }

        // ==========================================
        // SELECCIÓN EN GRILLAS
        // ==========================================
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];

                if (row.DataBoundItem is DataRowView drv)
                {
                    clienteSeleccionadoId = Convert.ToInt32(drv["ID"]);
                    txtApellido.Text = drv["Apellido"]?.ToString() ?? string.Empty;
                    txtNombre.Text = drv["Nombre"]?.ToString() ?? string.Empty;
                    txtDni.Text = drv["DNI"]?.ToString() ?? string.Empty;
                    txtTelefono.Text = drv["Telefono"]?.ToString() ?? string.Empty;
                    txtEmail.Text = drv["Email"]?.ToString() ?? string.Empty;

                    // Al hacer clic manual sobre un cliente individual, filtra solo sus mascotas
                    CargarMascotasDelCliente(clienteSeleccionadoId);
                }
            }
        }

        private void dgvMascotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMascotas.Rows[e.RowIndex];

                if (row.DataBoundItem is DataRowView drv)
                {
                    mascotaSeleccionadaId = Convert.ToInt32(drv["ID"]);
                    txtNombreMascota.Text = drv["Nombre"]?.ToString() ?? string.Empty;
                    cmbEspecie.SelectedItem = drv["Especie"]?.ToString();
                    txtRaza.Text = drv["Raza"]?.ToString() ?? string.Empty;
                    cmbSexo.SelectedItem = drv["Sexo"]?.ToString();

                    if (drv["Nacimiento"] != DBNull.Value && drv["Nacimiento"] != null)
                        dtpNacimiento.Value = Convert.ToDateTime(drv["Nacimiento"]);
                }
            }
        }

        // ==========================================
        // BOTONES DE ACCIÓN
        // ==========================================
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombreMascota.Text) ||
                cmbEspecie.SelectedIndex == -1 || cmbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete los campos obligatorios (*).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                string queryCliente = @"INSERT INTO Cliente (Nombre, Apellido, DNI, Telefono, Email) 
                                        VALUES (@nombre, @apellido, @dni, @telefono, @email); 
                                        SELECT SCOPE_IDENTITY();";

                using var cmdCliente = new SqlCommand(queryCliente, conn, transaction);
                cmdCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@dni", txtDni.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? DBNull.Value : txtEmail.Text.Trim());

                int idNuevoCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                string queryMascota = @"INSERT INTO Mascota (IdCliente, Nombre, Especie, Raza, Sexo, FechaNacimiento) 
                                        VALUES (@idCliente, @nombreMascota, @especie, @raza, @sexo, @nacimiento)";

                using var cmdMascota = new SqlCommand(queryMascota, conn, transaction);
                cmdMascota.Parameters.AddWithValue("@idCliente", idNuevoCliente);
                cmdMascota.Parameters.AddWithValue("@nombreMascota", txtNombreMascota.Text.Trim());
                cmdMascota.Parameters.AddWithValue("@especie", cmbEspecie.SelectedItem?.ToString() ?? string.Empty);
                cmdMascota.Parameters.AddWithValue("@raza", string.IsNullOrWhiteSpace(txtRaza.Text) ? DBNull.Value : txtRaza.Text.Trim());
                cmdMascota.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem?.ToString() ?? string.Empty);
                cmdMascota.Parameters.AddWithValue("@nacimiento", dtpNacimiento.Value.Date);

                cmdMascota.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Cliente y mascota registrados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos(limpiarGrillaMascotas: false);
                CargarClientes(idClienteASeleccionar: idNuevoCliente);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error al registrar: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId == -1)
            {
                MessageBox.Show("Seleccione un cliente de la tabla para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                string queryCliente = "UPDATE Cliente SET Nombre=@nombre, Apellido=@apellido, DNI=@dni, Telefono=@telefono, Email=@email WHERE IdCliente=@id";
                using var cmdCliente = new SqlCommand(queryCliente, conn, transaction);
                cmdCliente.Parameters.AddWithValue("@id", clienteSeleccionadoId);
                cmdCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@dni", txtDni.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? DBNull.Value : txtEmail.Text.Trim());
                cmdCliente.ExecuteNonQuery();

                if (mascotaSeleccionadaId != -1)
                {
                    string queryMascota = "UPDATE Mascota SET Nombre=@nombre, Especie=@especie, Raza=@raza, Sexo=@sexo, FechaNacimiento=@nacimiento WHERE IdMascota=@id";
                    using var cmdMascota = new SqlCommand(queryMascota, conn, transaction);
                    cmdMascota.Parameters.AddWithValue("@id", mascotaSeleccionadaId);
                    cmdMascota.Parameters.AddWithValue("@nombre", txtNombreMascota.Text.Trim());
                    cmdMascota.Parameters.AddWithValue("@especie", cmbEspecie.SelectedItem?.ToString() ?? string.Empty);
                    cmdMascota.Parameters.AddWithValue("@raza", string.IsNullOrWhiteSpace(txtRaza.Text) ? DBNull.Value : txtRaza.Text.Trim());
                    cmdMascota.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem?.ToString() ?? string.Empty);
                    cmdMascota.Parameters.AddWithValue("@nacimiento", dtpNacimiento.Value.Date);
                    cmdMascota.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Datos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarClientes(idClienteASeleccionar: clienteSeleccionadoId);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDarBajaCliente_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId == -1)
            {
                MessageBox.Show("Seleccione un cliente de la lista para dar de baja.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "¿Está seguro de dar de baja al cliente seleccionado y a todas sus mascotas vinculadas?",
                "Confirmar baja unificada",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using var cmdM = new SqlCommand("DELETE FROM Mascota WHERE IdCliente = @id", conn, transaction);
                    cmdM.Parameters.AddWithValue("@id", clienteSeleccionadoId);
                    cmdM.ExecuteNonQuery();

                    using var cmdC = new SqlCommand("DELETE FROM Cliente WHERE IdCliente = @id", conn, transaction);
                    cmdC.Parameters.AddWithValue("@id", clienteSeleccionadoId);
                    cmdC.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Cliente y sus mascotas dados de baja correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos(limpiarGrillaMascotas: true);
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al dar de baja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(limpiarGrillaMascotas: false);
        }

        private void LimpiarCampos(bool limpiarGrillaMascotas = false)
        {
            mascotaSeleccionadaId = -1;
            txtBuscar.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtNombreMascota.Clear();
            txtRaza.Clear();
            cmbEspecie.SelectedIndex = -1;
            cmbSexo.SelectedIndex = -1;
            dtpNacimiento.Value = DateTime.Now;

            if (limpiarGrillaMascotas)
            {
                clienteSeleccionadoId = -1;
                dgvMascotas.DataSource = null;
            }
        }
    }
}