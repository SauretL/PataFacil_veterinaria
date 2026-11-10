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
            InicializarCombos();
            CargarClientes();
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
        private void CargarClientes(string filtro = "")
        {
            using var conn = new SqlConnection(connectionString);
            string query = "SELECT idCliente AS ID, apellido AS Apellido, nombre AS Nombre, dni AS DNI, telefono AS Telefono, email AS Email FROM Cliente WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (nombre LIKE @filtro OR apellido LIKE @filtro OR dni LIKE @filtro)";
            }

            using var cmd = new SqlCommand(query, conn);
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");
            }

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            dgvClientes.DataSource = dt;

            if (dgvClientes.Columns["ID"] != null)
                dgvClientes.Columns["ID"].Visible = false;
        }

        private void CargarMascotasDelCliente(int idCliente)
        {
            using var conn = new SqlConnection(connectionString);
            string query = "SELECT id_mascota AS ID, nombre AS Nombre, especie AS Especie, raza AS Raza, sexo AS Sexo, fecha_nacimiento AS Nacimiento FROM Mascota WHERE idCliente = @idCliente";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
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
                clienteSeleccionadoId = Convert.ToInt32(row.Cells["ID"].Value);
                txtApellido.Text = row.Cells["Apellido"].Value?.ToString() ?? string.Empty;
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                txtDni.Text = row.Cells["DNI"].Value?.ToString() ?? string.Empty;
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? string.Empty;
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;

                CargarMascotasDelCliente(clienteSeleccionadoId);
            }
        }

        private void dgvMascotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMascotas.Rows[e.RowIndex];
                mascotaSeleccionadaId = Convert.ToInt32(row.Cells["ID"].Value);
                txtNombreMascota.Text = row.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                cmbEspecie.SelectedItem = row.Cells["Especie"].Value?.ToString();
                txtRaza.Text = row.Cells["Raza"].Value?.ToString() ?? string.Empty;
                cmbSexo.SelectedItem = row.Cells["Sexo"].Value?.ToString();

                if (row.Cells["Nacimiento"].Value != null && row.Cells["Nacimiento"].Value != DBNull.Value)
                    dtpNacimiento.Value = Convert.ToDateTime(row.Cells["Nacimiento"].Value);
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
                string queryCliente = @"INSERT INTO Cliente (nombre, apellido, dni, telefono, email) 
                                        VALUES (@nombre, @apellido, @dni, @telefono, @email); 
                                        SELECT SCOPE_IDENTITY();";

                using var cmdCliente = new SqlCommand(queryCliente, conn, transaction);
                cmdCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@dni", txtDni.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdCliente.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? DBNull.Value : txtEmail.Text.Trim());

                int idNuevoCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                string queryMascota = @"INSERT INTO Mascota (idCliente, nombre, especie, raza, sexo, fecha_nacimiento) 
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

                LimpiarCampos();
                CargarClientes();
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
                string queryCliente = "UPDATE Cliente SET nombre=@nombre, apellido=@apellido, dni=@dni, telefono=@telefono, email=@email WHERE idCliente=@id";
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
                    string queryMascota = "UPDATE Mascota SET nombre=@nombre, especie=@especie, raza=@raza, sexo=@sexo, fecha_nacimiento=@nacimiento WHERE id_mascota=@id";
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

                CargarClientes();
                CargarMascotasDelCliente(clienteSeleccionadoId);
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
                MessageBox.Show("Seleccione un cliente para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("¿Está seguro de eliminar al cliente y sus mascotas?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using var cmdM = new SqlCommand("DELETE FROM Mascota WHERE idCliente = @id", conn, transaction);
                    cmdM.Parameters.AddWithValue("@id", clienteSeleccionadoId);
                    cmdM.ExecuteNonQuery();

                    using var cmdC = new SqlCommand("DELETE FROM Cliente WHERE idCliente = @id", conn, transaction);
                    cmdC.Parameters.AddWithValue("@id", clienteSeleccionadoId);
                    cmdC.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Cliente eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDarBajaMascota_Click(object sender, EventArgs e)
        {
            if (mascotaSeleccionadaId == -1)
            {
                MessageBox.Show("Seleccione una mascota de la lista derecha para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("¿Está seguro de eliminar la mascota seleccionada?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using var conn = new SqlConnection(connectionString);
                using var cmd = new SqlCommand("DELETE FROM Mascota WHERE id_mascota = @id", conn);
                cmd.Parameters.AddWithValue("@id", mascotaSeleccionadaId);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Mascota eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int tempClienteId = clienteSeleccionadoId;
                LimpiarCampos();
                CargarClientes();
                if (tempClienteId != -1) CargarMascotasDelCliente(tempClienteId);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            clienteSeleccionadoId = -1;
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

            dgvMascotas.DataSource = null;
        }
    }
}
