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
    public partial class ucCobros : UserControl
    {
        private readonly string connectionString = Conexion.sConnection;

        private int mascotaSeleccionadaId = -1;
        private int clienteSeleccionadoId = -1;
        private int comprobanteUltimoId = -1;

        // Diccionario para almacenar localmente en la sesión el concepto tipeado en txtConcepto por cada IdComprobante
        private static readonly Dictionary<int, string> conceptosPorComprobante = new Dictionary<int, string>();

        // Referencias a controles
        private DataGridView dgvCobrosRef;
        private Button btnBuscarMascotaRef;
        private Button btnConsultarCobrosRef;
        private Button btnRegistrarCobroRef;
        private Button btnEmitirComprobanteRef;
        private Label lblMascotaRef;
        private Label lblDuenoRef;
        private TextBox txtConceptoRef;
        private TextBox txtMontoRef;
        private ComboBox cmbFormaPagoRef;

        // Formas de pago estándar
        private static readonly string[] FormasPago = { "Efectivo", "Tarjeta de Débito", "Tarjeta de Crédito", "Transferencia", "Mercado Pago" };

        public ucCobros()
        {
            InitializeComponent();
            ResolverReferenciasControles();

            // Enlace de eventos principales
            if (btnBuscarMascotaRef != null) btnBuscarMascotaRef.Click += btnBuscarMascota_Click;
            if (btnConsultarCobrosRef != null) btnConsultarCobrosRef.Click += btnConsultarCobros_Click;
            if (btnRegistrarCobroRef != null) btnRegistrarCobroRef.Click += btnRegistrarCobro_Click;
            if (btnEmitirComprobanteRef != null) btnEmitirComprobanteRef.Click += btnEmitirComprobante_Click;

            if (dgvCobrosRef != null)
            {
                dgvCobrosRef.CellClick += dgvCobros_CellClick;
                dgvCobrosRef.SelectionChanged += (s, e) => dgvCobrosRef.ClearSelection();
            }

            ConfigurarEstadoInicial();
            ConfigurarMapeoGrilla();
            CargarCobrosGrilla();
        }

        private void ConfigurarEstadoInicial()
        {
            if (btnEmitirComprobanteRef != null) btnEmitirComprobanteRef.Enabled = false;

            if (cmbFormaPagoRef != null)
            {
                cmbFormaPagoRef.Items.Clear();
                cmbFormaPagoRef.Items.AddRange(FormasPago);
                cmbFormaPagoRef.SelectedIndex = -1;
            }
        }

        private void ResolverReferenciasControles()
        {
            var posiblesGrillas = new[] { "dgvCobros", "dgvPagos", "dataGridView1", "dgvListaCobros" };
            foreach (var nombre in posiblesGrillas)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as DataGridView;
                if (hallado != null) { dgvCobrosRef = hallado; break; }
            }

            btnBuscarMascotaRef = this.Controls.Find("btnBuscarMascota", true).FirstOrDefault() as Button;
            btnConsultarCobrosRef = this.Controls.Find("btnConsultarCobros", true).FirstOrDefault() as Button;

            var posiblesRegistrar = new[] { "btnRegistrarCobro", "btnRegistrar", "btnGuardarCobro" };
            foreach (var nombre in posiblesRegistrar)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as Button;
                if (hallado != null) { btnRegistrarCobroRef = hallado; break; }
            }

            var posiblesEmitir = new[] { "btnEmitirComprobante", "btnEmitirComprobantePago", "btnComprobante" };
            foreach (var nombre in posiblesEmitir)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as Button;
                if (hallado != null) { btnEmitirComprobanteRef = hallado; break; }
            }

            var posiblesMascota = new[] { "lblMascotaCobro", "lblMascota", "lblPaciente" };
            foreach (var nombre in posiblesMascota)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as Label;
                if (hallado != null) { lblMascotaRef = hallado; break; }
            }

            var posiblesDueno = new[] { "lblDuenoCobro", "lblDueno", "lblCliente" };
            foreach (var nombre in posiblesDueno)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as Label;
                if (hallado != null) { lblDuenoRef = hallado; break; }
            }

            txtConceptoRef = this.Controls.Find("txtConcepto", true).FirstOrDefault() as TextBox;
            txtMontoRef = this.Controls.Find("txtMonto", true).FirstOrDefault() as TextBox;

            var posiblesFormaPago = new[] { "cmbFormaPago", "cmbPago", "cmbFormaDePago" };
            foreach (var nombre in posiblesFormaPago)
            {
                var hallado = this.Controls.Find(nombre, true).FirstOrDefault() as ComboBox;
                if (hallado != null) { cmbFormaPagoRef = hallado; break; }
            }
        }

        private void ConfigurarMapeoGrilla()
        {
            if (dgvCobrosRef == null) return;

            dgvCobrosRef.ReadOnly = true;
            dgvCobrosRef.AutoGenerateColumns = false;

            if (dgvCobrosRef.Columns["colNumero"] != null) dgvCobrosRef.Columns["colNumero"].DataPropertyName = "Numero";
            if (dgvCobrosRef.Columns["N°"] != null) dgvCobrosRef.Columns["N°"].DataPropertyName = "Numero";

            if (dgvCobrosRef.Columns["colFecha"] != null) dgvCobrosRef.Columns["colFecha"].DataPropertyName = "FechaFormateada";
            if (dgvCobrosRef.Columns["Fecha"] != null) dgvCobrosRef.Columns["Fecha"].DataPropertyName = "FechaFormateada";

            if (dgvCobrosRef.Columns["colCliente"] != null) dgvCobrosRef.Columns["colCliente"].DataPropertyName = "Cliente";
            if (dgvCobrosRef.Columns["Cliente"] != null) dgvCobrosRef.Columns["Cliente"].DataPropertyName = "Cliente";

            if (dgvCobrosRef.Columns["colMascota"] != null) dgvCobrosRef.Columns["colMascota"].DataPropertyName = "Mascota";
            if (dgvCobrosRef.Columns["Mascota"] != null) dgvCobrosRef.Columns["Mascota"].DataPropertyName = "Mascota";

            if (dgvCobrosRef.Columns["colConcepto"] != null) dgvCobrosRef.Columns["colConcepto"].DataPropertyName = "Concepto";
            if (dgvCobrosRef.Columns["Concepto"] != null) dgvCobrosRef.Columns["Concepto"].DataPropertyName = "Concepto";

            if (dgvCobrosRef.Columns["colMonto"] != null) dgvCobrosRef.Columns["colMonto"].DataPropertyName = "MontoTotal";
            if (dgvCobrosRef.Columns["Monto"] != null) dgvCobrosRef.Columns["Monto"].DataPropertyName = "MontoTotal";

            if (dgvCobrosRef.Columns["colPago"] != null) dgvCobrosRef.Columns["colPago"].DataPropertyName = "FormaPago";
            if (dgvCobrosRef.Columns["Pago"] != null) dgvCobrosRef.Columns["Pago"].DataPropertyName = "FormaPago";

            foreach (DataGridViewColumn col in dgvCobrosRef.Columns)
            {
                if (string.IsNullOrEmpty(col.DataPropertyName))
                {
                    if (col.Name.Equals("N°", StringComparison.OrdinalIgnoreCase) || col.HeaderText.Equals("N°", StringComparison.OrdinalIgnoreCase))
                        col.DataPropertyName = "Numero";
                    else if (col.Name.Equals("Fecha", StringComparison.OrdinalIgnoreCase) || col.HeaderText.Equals("Fecha", StringComparison.OrdinalIgnoreCase))
                        col.DataPropertyName = "FechaFormateada";
                    else if (col.Name.Equals("Monto", StringComparison.OrdinalIgnoreCase) || col.HeaderText.Equals("Monto", StringComparison.OrdinalIgnoreCase))
                        col.DataPropertyName = "MontoTotal";
                    else if (col.Name.Equals("Pago", StringComparison.OrdinalIgnoreCase) || col.HeaderText.Equals("Pago", StringComparison.OrdinalIgnoreCase))
                        col.DataPropertyName = "FormaPago";
                    else
                        col.DataPropertyName = col.Name;
                }
            }
        }

        // ==========================================
        // CARGA GENERAL DE COBROS EN LA GRILLA
        // ==========================================
        private void CargarCobrosGrilla()
        {
            using var conn = new SqlConnection(connectionString);
            string query = @"
                SELECT 
                    cp.IdComprobante AS ID,
                    cp.IdComprobante AS Numero,
                    CONVERT(VARCHAR(10), cp.FechaEmision, 103) AS FechaFormateada,
                    ISNULL(c.Nombre, '') + ' ' + ISNULL(c.Apellido, '') AS Cliente,
                    ISNULL(m.Nombre, 'Sin especificar') AS Mascota,
                    cp.TipoComprobante AS FormaPago,
                    cp.MontoTotal AS MontoTotal,
                    c.IdCliente AS IdCliente
                FROM Comprobante cp
                INNER JOIN Cliente c ON cp.IdCliente = c.IdCliente
                LEFT JOIN Mascota m ON m.IdCliente = c.IdCliente
                ORDER BY cp.FechaEmision DESC";

            using var cmd = new SqlCommand(query, conn);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                da.Fill(dt);

                // Mapear el concepto que tipeó el usuario o valor por defecto si es histórico
                dt.Columns.Add("Concepto", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    int idComp = Convert.ToInt32(row["ID"]);
                    if (conceptosPorComprobante.ContainsKey(idComp))
                    {
                        row["Concepto"] = conceptosPorComprobante[idComp];
                    }
                    else
                    {
                        row["Concepto"] = "Consulta Veterinaria";
                    }
                }

                AplicarDataSourceGrilla(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de comprobantes: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // BÚSQUEDA Y SELECCIÓN DE MASCOTA
        // ==========================================
        private void btnBuscarMascota_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese DNI del dueño o Nombre de la Mascota:", "Buscar Paciente para Cobro", "");

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

        // ==========================================
        // CONSULTAR COBROS
        // ==========================================
        private void btnConsultarCobros_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese DNI del dueño o Nombre de la Mascota para consultar cobros:", "Consultar Cobros", "");

            if (string.IsNullOrWhiteSpace(input)) return;

            using var conn = new SqlConnection(connectionString);
            string query = @"
                SELECT 
                    cp.IdComprobante AS ID,
                    cp.IdComprobante AS Numero,
                    CONVERT(VARCHAR(10), cp.FechaEmision, 103) AS FechaFormateada,
                    ISNULL(c.Nombre, '') + ' ' + ISNULL(c.Apellido, '') AS Cliente,
                    ISNULL(m.Nombre, 'Sin especificar') AS Mascota,
                    cp.TipoComprobante AS FormaPago,
                    cp.MontoTotal AS MontoTotal,
                    c.IdCliente AS IdCliente
                FROM Comprobante cp
                INNER JOIN Cliente c ON cp.IdCliente = c.IdCliente
                LEFT JOIN Mascota m ON m.IdCliente = c.IdCliente
                WHERE c.DNI = @filtro OR m.Nombre LIKE @likeFiltro OR c.Apellido LIKE @likeFiltro
                ORDER BY cp.FechaEmision DESC";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@filtro", input.Trim());
            cmd.Parameters.AddWithValue("@likeFiltro", $"%{input.Trim()}%");

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                da.Fill(dt);

                dt.Columns.Add("Concepto", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    int idComp = Convert.ToInt32(row["ID"]);
                    if (conceptosPorComprobante.ContainsKey(idComp))
                    {
                        row["Concepto"] = conceptosPorComprobante[idComp];
                    }
                    else
                    {
                        row["Concepto"] = "Consulta Veterinaria";
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    AplicarDataSourceGrilla(dt);

                    DataRow dr = dt.Rows[0];
                    if (dr["IdCliente"] != DBNull.Value) clienteSeleccionadoId = Convert.ToInt32(dr["IdCliente"]);

                    ActualizarLabelsCliente(dr["Mascota"]?.ToString(), dr["Cliente"]?.ToString());
                }
                else
                {
                    MessageBox.Show("No se encontraron registros de cobros para el criterio ingresado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar cobros: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REGISTRAR NUEVO COBRO
        // ==========================================
        private void btnRegistrarCobro_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId == -1)
            {
                MessageBox.Show("Por favor, busque y seleccione una mascota/cliente primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (btnBuscarMascotaRef != null) btnBuscarMascotaRef.Focus();
                return;
            }

            if (txtConceptoRef == null || string.IsNullOrWhiteSpace(txtConceptoRef.Text))
            {
                MessageBox.Show("El campo 'Concepto' es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtConceptoRef != null) txtConceptoRef.Focus();
                return;
            }

            if (txtMontoRef == null || string.IsNullOrWhiteSpace(txtMontoRef.Text) || !decimal.TryParse(txtMontoRef.Text.Trim(), out decimal montoTotal) || montoTotal <= 0)
            {
                MessageBox.Show("Debe ingresar un 'Monto' válido mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtMontoRef != null) txtMontoRef.Focus();
                return;
            }

            if (cmbFormaPagoRef == null || cmbFormaPagoRef.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una 'Forma de pago'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (cmbFormaPagoRef != null) cmbFormaPagoRef.Focus();
                return;
            }

            string tipoComprobante = cmbFormaPagoRef.SelectedItem.ToString();
            string conceptoIngresado = txtConceptoRef.Text.Trim();
            DateTime fechaEmision = DateTime.Now;

            using var conn = new SqlConnection(connectionString);
            string queryInsert = @"
                INSERT INTO Comprobante (IdCliente, FechaEmision, TipoComprobante, MontoTotal) 
                VALUES (@idCliente, @fechaEmision, @tipoComprobante, @montoTotal);
                SELECT SCOPE_IDENTITY();";

            using var cmdInsert = new SqlCommand(queryInsert, conn);
            cmdInsert.Parameters.AddWithValue("@idCliente", clienteSeleccionadoId);
            cmdInsert.Parameters.AddWithValue("@fechaEmision", fechaEmision);
            cmdInsert.Parameters.AddWithValue("@tipoComprobante", tipoComprobante);
            cmdInsert.Parameters.AddWithValue("@montoTotal", montoTotal);

            try
            {
                conn.Open();
                comprobanteUltimoId = Convert.ToInt32(cmdInsert.ExecuteScalar());

                // Guardar localmente el concepto tipeado para mostrarlo exactamente en la grilla
                conceptosPorComprobante[comprobanteUltimoId] = conceptoIngresado;

                MessageBox.Show("Cobro registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (btnEmitirComprobanteRef != null)
                {
                    btnEmitirComprobanteRef.Enabled = true;
                }

                CargarCobrosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cobro: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // EMITIR COMPROBANTE DE PAGO
        // ==========================================
        private void btnEmitirComprobante_Click(object sender, EventArgs e)
        {
            if (comprobanteUltimoId == -1)
            {
                MessageBox.Show("No hay un comprobante reciente o seleccionado para emitir.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Comprobante N° {comprobanteUltimoId:D6} generado exitosamente.", "Comprobante Emitido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvCobros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCobrosRef == null) return;

            if (e.RowIndex >= 0 && dgvCobrosRef.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
            {
                if (drv["ID"] != DBNull.Value) comprobanteUltimoId = Convert.ToInt32(drv["ID"]);
                if (drv["IdCliente"] != DBNull.Value) clienteSeleccionadoId = Convert.ToInt32(drv["IdCliente"]);

                ActualizarLabelsCliente(drv["Mascota"]?.ToString(), drv["Cliente"]?.ToString());

                if (txtConceptoRef != null) txtConceptoRef.Text = drv["Concepto"]?.ToString() ?? string.Empty;
                if (txtMontoRef != null) txtMontoRef.Text = drv["MontoTotal"]?.ToString() ?? string.Empty;
                if (cmbFormaPagoRef != null && drv["FormaPago"] != DBNull.Value)
                    cmbFormaPagoRef.SelectedItem = drv["FormaPago"].ToString();

                if (btnEmitirComprobanteRef != null) btnEmitirComprobanteRef.Enabled = true;
            }

            dgvCobrosRef.ClearSelection();
        }

        private void AplicarDataSourceGrilla(DataTable dt)
        {
            if (dgvCobrosRef == null) ResolverReferenciasControles();

            if (dgvCobrosRef != null)
            {
                dgvCobrosRef.DataSource = null;
                dgvCobrosRef.DataSource = dt;

                if (dgvCobrosRef.Columns["ID"] != null) dgvCobrosRef.Columns["ID"].Visible = false;
                if (dgvCobrosRef.Columns["IdCliente"] != null) dgvCobrosRef.Columns["IdCliente"].Visible = false;

                dgvCobrosRef.ClearSelection();
                dgvCobrosRef.Refresh();
            }
        }

        private void ActualizarLabelsCliente(string mascota, string dueno)
        {
            if (lblMascotaRef != null) lblMascotaRef.Text = $"Mascota: {mascota}";
            if (lblDuenoRef != null) lblDuenoRef.Text = $"Dueño: {dueno}";
        }
    }
}