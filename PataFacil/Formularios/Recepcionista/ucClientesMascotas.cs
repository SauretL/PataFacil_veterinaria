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

            // Vinculación de eventos por seguridad
            btnBajaCliente.Click -= btnDarBajaCliente_Click;
            btnBajaCliente.Click += btnDarBajaCliente_Click;

            // Impedir el resaltado azul en las grillas
            dgvClientes.SelectionChanged += DesactivarSeleccionClientes;
            dgvMascotas.SelectionChanged += DesactivarSeleccionMascotas;

            ConfigurarMapeoColumnas();
            InicializarCombos();
            CargarClientes();
        }

        private void DesactivarSeleccionClientes(object sender, EventArgs e)
        {
            dgvClientes.ClearSelection();
        }

        private void DesactivarSeleccionMascotas(object sender, EventArgs e)
        {
            dgvMascotas.ClearSelection();
        }

        private void ConfigurarMapeoColumnas()
        {
            dgvClientes.ReadOnly = true;
            dgvMascotas.ReadOnly = true;

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

            btnBajaCliente.Enabled = true;

            if (dgvClientes.Rows.Count > 0)
            {
                if (idClienteASeleccionar != -1)
                {
                    int indexFila = 0;
                    for (int i = 0; i < dgvClientes.Rows.Count; i++)
                    {
                        if (dgvClientes.Rows[i].DataBoundItem is DataRowView drvTemp && Convert.ToInt32(drvTemp["ID"]) == idClienteASeleccionar)
                        {
                            indexFila = i;
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

                        CargarMascotasDelCliente(clienteSeleccionadoId);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        CargarMascotasPorFiltroCliente(filtro);
                    }
                    else
                    {
                        CargarTodasLasMascotas();
                    }
                }
            }
            else
            {
                LimpiarCampos(limpiarGrillaMascotas: true);
            }

            dgvClientes.ClearSelection();
        }

        private void CargarTodasLasMascotas()
        {
            using var conn = new SqlConnection(connectionString);
            string query = "SELECT IdMascota AS ID, Nombre AS Nombre, Especie AS Especie, Raza AS Raza, Sexo AS Sexo, FechaNacimiento AS Nacimiento FROM Mascota";

            using var cmd = new SqlCommand(query, conn);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            da.Fill(dt);

            dgvMascotas.AutoGenerateColumns = false;
            dgvMascotas.DataSource = dt;

            if (dgvMascotas.Columns["ID"] != null)
                dgvMascotas.Columns["ID"].Visible = false;

            dgvMascotas.ClearSelection();
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

            dgvMascotas.ClearSelection();
        }

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

            dgvMascotas.ClearSelection();
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

                    CargarMascotasDelCliente(clienteSeleccionadoId);
                }
            }

            dgvClientes.ClearSelection();
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

            dgvMascotas.ClearSelection();
        }

        // ==========================================
        // BOTÓN REGISTRAR
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
                string dniIngresado = txtDni.Text.Trim();
                string nombreMascota = txtNombreMascota.Text.Trim();
                int idClienteDestino = -1;

                string queryBuscarCliente = "SELECT IdCliente FROM Cliente WHERE DNI = @dni";
                using (var cmdBuscar = new SqlCommand(queryBuscarCliente, conn, transaction))
                {
                    cmdBuscar.Parameters.AddWithValue("@dni", dniIngresado);
                    object res = cmdBuscar.ExecuteScalar();
                    if (res != null && res != DBNull.Value)
                    {
                        idClienteDestino = Convert.ToInt32(res);
                    }
                }

                if (idClienteDestino != -1)
                {
                    string queryUpdateCliente = @"UPDATE Cliente 
                                                  SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono, Email = @email 
                                                  WHERE IdCliente = @id";
                    using var cmdUpdate = new SqlCommand(queryUpdateCliente, conn, transaction);
                    cmdUpdate.Parameters.AddWithValue("@id", idClienteDestino);
                    cmdUpdate.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? DBNull.Value : txtEmail.Text.Trim());
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    string queryInsertCliente = @"INSERT INTO Cliente (Nombre, Apellido, DNI, Telefono, Email) 
                                                  VALUES (@nombre, @apellido, @dni, @telefono, @email); 
                                                  SELECT SCOPE_IDENTITY();";
                    using var cmdInsert = new SqlCommand(queryInsertCliente, conn, transaction);
                    cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@dni", dniIngresado);
                    cmdInsert.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? DBNull.Value : txtEmail.Text.Trim());

                    idClienteDestino = Convert.ToInt32(cmdInsert.ExecuteScalar());
                }

                string queryExisteMascota = "SELECT COUNT(*) FROM Mascota WHERE IdCliente = @idCliente AND Nombre = @nombreMascota";
                using (var cmdValidarMascota = new SqlCommand(queryExisteMascota, conn, transaction))
                {
                    cmdValidarMascota.Parameters.AddWithValue("@idCliente", idClienteDestino);
                    cmdValidarMascota.Parameters.AddWithValue("@nombreMascota", nombreMascota);

                    int existe = Convert.ToInt32(cmdValidarMascota.ExecuteScalar());
                    if (existe > 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"El cliente ya posee registrada una mascota con el nombre '{nombreMascota}'.", "Mascota existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string queryInsertMascota = @"INSERT INTO Mascota (IdCliente, Nombre, Especie, Raza, Sexo, FechaNacimiento) 
                                              VALUES (@idCliente, @nombreMascota, @especie, @raza, @sexo, @nacimiento)";

                using var cmdMascota = new SqlCommand(queryInsertMascota, conn, transaction);
                cmdMascota.Parameters.AddWithValue("@idCliente", idClienteDestino);
                cmdMascota.Parameters.AddWithValue("@nombreMascota", nombreMascota);
                cmdMascota.Parameters.AddWithValue("@especie", cmbEspecie.SelectedItem?.ToString() ?? string.Empty);
                cmdMascota.Parameters.AddWithValue("@raza", string.IsNullOrWhiteSpace(txtRaza.Text) ? DBNull.Value : txtRaza.Text.Trim());
                cmdMascota.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem?.ToString() ?? string.Empty);
                cmdMascota.Parameters.AddWithValue("@nacimiento", dtpNacimiento.Value.Date);

                cmdMascota.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Mascota registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos(limpiarGrillaMascotas: false);
                CargarClientes();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error al registrar: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // BOTÓN MODIFICAR (BASADO EN DNI ÚNICO)
        // ==========================================
        private void btnModificar_Click(object sender, EventArgs e)
        {
            string dniIngresado = txtDni.Text.Trim();
            string nombreIngresado = txtNombre.Text.Trim();
            string apellidoIngresado = txtApellido.Text.Trim();
            string telefonoIngresado = txtTelefono.Text.Trim();

            // 1. Validar que se haya ingresado el DNI (clave de búsqueda)
            if (string.IsNullOrWhiteSpace(dniIngresado))
            {
                MessageBox.Show("Por favor, ingrese el DNI del cliente a modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar campos obligatorios del cliente
            if (string.IsNullOrWhiteSpace(nombreIngresado) ||
                string.IsNullOrWhiteSpace(apellidoIngresado) ||
                string.IsNullOrWhiteSpace(telefonoIngresado))
            {
                MessageBox.Show(
                    "Para modificar un cliente debe completar los campos obligatorios:\n- Nombre\n- Apellido\n- Teléfono",
                    "Atención - Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            // 3. Buscar al cliente en la Base de Datos por DNI
            int idClienteAModificar = -1;
            string queryBuscarId = "SELECT IdCliente FROM Cliente WHERE DNI = @dni";
            using (var cmdBuscar = new SqlCommand(queryBuscarId, conn))
            {
                cmdBuscar.Parameters.AddWithValue("@dni", dniIngresado);
                object res = cmdBuscar.ExecuteScalar();

                if (res != null && res != DBNull.Value)
                {
                    idClienteAModificar = Convert.ToInt32(res);
                }
                else
                {
                    MessageBox.Show($"No se encontró ningún cliente registrado con el DNI '{dniIngresado}'.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 4. Iniciar transacción para actualizar los datos
            using SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // Actualizar datos personales y de contacto del cliente (mantiene intacta la relación de sus mascotas)
                string queryUpdateCliente = @"UPDATE Cliente 
                                              SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono, Email = @email 
                                              WHERE IdCliente = @id";

                using var cmdUpdate = new SqlCommand(queryUpdateCliente, conn, transaction);
                cmdUpdate.Parameters.AddWithValue("@id", idClienteAModificar);
                cmdUpdate.Parameters.AddWithValue("@nombre", nombreIngresado);
                cmdUpdate.Parameters.AddWithValue("@apellido", apellidoIngresado);
                cmdUpdate.Parameters.AddWithValue("@telefono", telefonoIngresado);
                cmdUpdate.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? DBNull.Value : txtEmail.Text.Trim());
                cmdUpdate.ExecuteNonQuery();

                // Si además se indicó/seleccionó una mascota existente para modificar sus características (Especie, Raza, Sexo, Nacimiento)
                string nombreMascota = txtNombreMascota.Text.Trim();
                if (!string.IsNullOrWhiteSpace(nombreMascota) && cmbEspecie.SelectedIndex != -1 && cmbSexo.SelectedIndex != -1)
                {
                    string queryUpdateMascota = @"UPDATE Mascota 
                                                  SET Especie = @especie, Raza = @raza, Sexo = @sexo, FechaNacimiento = @nacimiento 
                                                  WHERE IdCliente = @idCliente AND Nombre = @nombreMascota";

                    using var cmdMascota = new SqlCommand(queryUpdateMascota, conn, transaction);
                    cmdMascota.Parameters.AddWithValue("@idCliente", idClienteAModificar);
                    cmdMascota.Parameters.AddWithValue("@nombreMascota", nombreMascota);
                    cmdMascota.Parameters.AddWithValue("@especie", cmbEspecie.SelectedItem?.ToString() ?? string.Empty);
                    cmdMascota.Parameters.AddWithValue("@raza", string.IsNullOrWhiteSpace(txtRaza.Text) ? DBNull.Value : txtRaza.Text.Trim());
                    cmdMascota.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem?.ToString() ?? string.Empty);
                    cmdMascota.Parameters.AddWithValue("@nacimiento", dtpNacimiento.Value.Date);
                    cmdMascota.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show($"Datos del cliente con DNI '{dniIngresado}' actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos(limpiarGrillaMascotas: false);
                CargarClientes();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error al actualizar en la base de datos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // DAR DE BAJA
        // ==========================================
        private void btnDarBajaCliente_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombre.Text.Trim();
            string apellidoCliente = txtApellido.Text.Trim();
            string nombreMascota = txtNombreMascota.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreCliente) ||
                string.IsNullOrWhiteSpace(apellidoCliente) ||
                string.IsNullOrWhiteSpace(nombreMascota))
            {
                MessageBox.Show(
                    "Para dar de baja debe seleccionar un registro o indicar:\n- Nombre del cliente\n- Apellido del cliente\n- Nombre de la mascota",
                    "Atención - Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            if (clienteSeleccionadoId == -1)
            {
                string queryBuscarId = "SELECT TOP 1 IdCliente FROM Cliente WHERE Nombre = @nom AND Apellido = @ape";
                using var cmdBuscar = new SqlCommand(queryBuscarId, conn);
                cmdBuscar.Parameters.AddWithValue("@nom", nombreCliente);
                cmdBuscar.Parameters.AddWithValue("@ape", apellidoCliente);
                object resId = cmdBuscar.ExecuteScalar();

                if (resId != null && resId != DBNull.Value)
                {
                    clienteSeleccionadoId = Convert.ToInt32(resId);
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente registrado con esos datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int idMascotaAEliminar = -1;
            string queryValidarMascota = "SELECT IdMascota FROM Mascota WHERE IdCliente = @idCliente AND Nombre = @nombreMascota";
            using (var cmdValidar = new SqlCommand(queryValidarMascota, conn))
            {
                cmdValidar.Parameters.AddWithValue("@idCliente", clienteSeleccionadoId);
                cmdValidar.Parameters.AddWithValue("@nombreMascota", nombreMascota);

                object resMascota = cmdValidar.ExecuteScalar();
                if (resMascota == null || resMascota == DBNull.Value)
                {
                    MessageBox.Show(
                        $"La mascota '{nombreMascota}' no corresponde al cliente '{nombreCliente} {apellidoCliente}'. Por favor verifique los datos.",
                        "Incoherencia de datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                idMascotaAEliminar = Convert.ToInt32(resMascota);
            }

            DialogResult dr = MessageBox.Show(
                $"¿Desea dar de baja únicamente a la mascota '{nombreMascota}'?\n\n" +
                $"• [Sí] -> Elimina SOLO a la mascota '{nombreMascota}' (conserva al cliente).\n" +
                $"• [No] -> Elimina al cliente '{nombreCliente} {apellidoCliente}' y TODAS sus mascotas.\n" +
                $"• [Cancelar] -> No realiza ningún cambio.",
                "Seleccionar opción de baja",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Cancel)
                return;

            using SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                if (dr == DialogResult.Yes)
                {
                    using var cmdM = new SqlCommand("DELETE FROM Mascota WHERE IdMascota = @idMascota", conn, transaction);
                    cmdM.Parameters.AddWithValue("@idMascota", idMascotaAEliminar);
                    cmdM.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show($"La mascota '{nombreMascota}' fue dada de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dr == DialogResult.No)
                {
                    using var cmdM = new SqlCommand("DELETE FROM Mascota WHERE IdCliente = @idCliente", conn, transaction);
                    cmdM.Parameters.AddWithValue("@idCliente", clienteSeleccionadoId);
                    cmdM.ExecuteNonQuery();

                    using var cmdC = new SqlCommand("DELETE FROM Cliente WHERE IdCliente = @idCliente", conn, transaction);
                    cmdC.Parameters.AddWithValue("@idCliente", clienteSeleccionadoId);
                    cmdC.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show($"El cliente '{nombreCliente} {apellidoCliente}' y sus mascotas fueron eliminados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos(limpiarGrillaMascotas: false);
                CargarClientes();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error al ejecutar la baja: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(limpiarGrillaMascotas: false);
            CargarClientes();
        }

        private void LimpiarCampos(bool limpiarGrillaMascotas = false)
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

            if (limpiarGrillaMascotas)
            {
                dgvMascotas.DataSource = null;
            }

            dgvClientes.ClearSelection();
            dgvMascotas.ClearSelection();
        }
    }
}