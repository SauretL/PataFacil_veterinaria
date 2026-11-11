namespace PataFacil.Formularios.Recepcionista
{
    partial class ucCobros
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvCobros = new DataGridView();
            grpCobros = new GroupBox();
            btnConsultarCobros = new Button();
            cmbFormaPago = new ComboBox();
            lblFormaPago = new Label();
            txtMonto = new TextBox();
            lblMonto = new Label();
            txtConcepto = new TextBox();
            lblConcepto = new Label();
            lblDueno = new Label();
            lblMascota = new Label();
            btnBuscarMascota = new Button();
            btnRegistrarCobro = new Button();
            btnEmitirComprobante = new Button();
            colNumero = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colMascota = new DataGridViewTextBoxColumn();
            colConcepto = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colPago = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvCobros).BeginInit();
            grpCobros.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCobros
            // 
            dgvCobros.AllowUserToAddRows = false;
            dgvCobros.AllowUserToDeleteRows = false;
            dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCobros.BackgroundColor = Color.FromArgb(244, 241, 236);
            dgvCobros.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCobros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCobros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCobros.Columns.AddRange(new DataGridViewColumn[] { colNumero, colFecha, colCliente, colMascota, colConcepto, colMonto, colPago });
            dgvCobros.EnableHeadersVisualStyles = false;
            dgvCobros.Location = new Point(510, 10);
            dgvCobros.MultiSelect = false;
            dgvCobros.Name = "dgvCobros";
            dgvCobros.ReadOnly = true;
            dgvCobros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCobros.Size = new Size(570, 340);
            dgvCobros.TabIndex = 20;
            // 
            // grpCobros
            // 
            grpCobros.Controls.Add(btnConsultarCobros);
            grpCobros.Controls.Add(cmbFormaPago);
            grpCobros.Controls.Add(lblFormaPago);
            grpCobros.Controls.Add(txtMonto);
            grpCobros.Controls.Add(lblMonto);
            grpCobros.Controls.Add(txtConcepto);
            grpCobros.Controls.Add(lblConcepto);
            grpCobros.Controls.Add(lblDueno);
            grpCobros.Controls.Add(lblMascota);
            grpCobros.Controls.Add(btnBuscarMascota);
            grpCobros.Location = new Point(20, 10);
            grpCobros.Name = "grpCobros";
            grpCobros.Size = new Size(470, 340);
            grpCobros.TabIndex = 19;
            grpCobros.TabStop = false;
            grpCobros.Text = "Cobro";
            // 
            // btnConsultarCobros
            // 
            btnConsultarCobros.BackColor = Color.FromArgb(228, 224, 218);
            btnConsultarCobros.Cursor = Cursors.Hand;
            btnConsultarCobros.FlatAppearance.BorderSize = 0;
            btnConsultarCobros.FlatStyle = FlatStyle.Flat;
            btnConsultarCobros.ForeColor = Color.FromArgb(34, 34, 34);
            btnConsultarCobros.Location = new Point(290, 25);
            btnConsultarCobros.Name = "btnConsultarCobros";
            btnConsultarCobros.Size = new Size(140, 36);
            btnConsultarCobros.TabIndex = 25;
            btnConsultarCobros.Text = "Consultar Cobros";
            btnConsultarCobros.UseVisualStyleBackColor = false;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Items.AddRange(new object[] { "Efectivo", "Transferencia" });
            cmbFormaPago.Location = new Point(235, 226);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(220, 25);
            cmbFormaPago.TabIndex = 31;
            // 
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.Location = new Point(234, 204);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(112, 19);
            lblFormaPago.TabIndex = 30;
            lblFormaPago.Text = "Forma de pago *";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(15, 226);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(200, 25);
            txtMonto.TabIndex = 29;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(15, 204);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(61, 19);
            lblMonto.TabIndex = 28;
            lblMonto.Text = "Monto *";
            // 
            // txtConcepto
            // 
            txtConcepto.Location = new Point(15, 157);
            txtConcepto.Name = "txtConcepto";
            txtConcepto.Size = new Size(440, 25);
            txtConcepto.TabIndex = 27;
            // 
            // lblConcepto
            // 
            lblConcepto.AutoSize = true;
            lblConcepto.Location = new Point(15, 132);
            lblConcepto.Name = "lblConcepto";
            lblConcepto.Size = new Size(78, 19);
            lblConcepto.TabIndex = 22;
            lblConcepto.Text = "Concepto *";
            // 
            // lblDueno
            // 
            lblDueno.AutoSize = true;
            lblDueno.Location = new Point(15, 92);
            lblDueno.Name = "lblDueno";
            lblDueno.Size = new Size(63, 19);
            lblDueno.TabIndex = 18;
            lblDueno.Text = "Dueño: -";
            // 
            // lblMascota
            // 
            lblMascota.AutoSize = true;
            lblMascota.Location = new Point(15, 68);
            lblMascota.Name = "lblMascota";
            lblMascota.Size = new Size(163, 19);
            lblMascota.TabIndex = 17;
            lblMascota.Text = "Mascota: (sin seleccionar)";
            // 
            // btnBuscarMascota
            // 
            btnBuscarMascota.BackColor = Color.FromArgb(228, 224, 218);
            btnBuscarMascota.Cursor = Cursors.Hand;
            btnBuscarMascota.FlatAppearance.BorderSize = 0;
            btnBuscarMascota.FlatStyle = FlatStyle.Flat;
            btnBuscarMascota.ForeColor = Color.FromArgb(34, 34, 34);
            btnBuscarMascota.Location = new Point(15, 25);
            btnBuscarMascota.Name = "btnBuscarMascota";
            btnBuscarMascota.Size = new Size(140, 36);
            btnBuscarMascota.TabIndex = 16;
            btnBuscarMascota.Text = "Buscar mascota";
            btnBuscarMascota.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarCobro
            // 
            btnRegistrarCobro.BackColor = Color.FromArgb(31, 122, 140);
            btnRegistrarCobro.Cursor = Cursors.Hand;
            btnRegistrarCobro.FlatAppearance.BorderSize = 0;
            btnRegistrarCobro.FlatStyle = FlatStyle.Flat;
            btnRegistrarCobro.ForeColor = Color.White;
            btnRegistrarCobro.Location = new Point(20, 370);
            btnRegistrarCobro.Name = "btnRegistrarCobro";
            btnRegistrarCobro.Size = new Size(150, 36);
            btnRegistrarCobro.TabIndex = 23;
            btnRegistrarCobro.Text = "Registrar cobro";
            btnRegistrarCobro.UseVisualStyleBackColor = false;
            // 
            // btnEmitirComprobante
            // 
            btnEmitirComprobante.BackColor = Color.FromArgb(31, 122, 140);
            btnEmitirComprobante.Cursor = Cursors.Hand;
            btnEmitirComprobante.FlatAppearance.BorderSize = 0;
            btnEmitirComprobante.FlatStyle = FlatStyle.Flat;
            btnEmitirComprobante.ForeColor = Color.White;
            btnEmitirComprobante.Location = new Point(180, 370);
            btnEmitirComprobante.Name = "btnEmitirComprobante";
            btnEmitirComprobante.Size = new Size(207, 36);
            btnEmitirComprobante.TabIndex = 24;
            btnEmitirComprobante.Text = "Emitir comprobante de pago";
            btnEmitirComprobante.UseVisualStyleBackColor = false;
            // 
            // colNumero
            // 
            colNumero.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colNumero.HeaderText = "N°";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            colNumero.Width = 49;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            colCliente.Width = 76;
            // 
            // colMascota
            // 
            colMascota.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colMascota.HeaderText = "Mascota";
            colMascota.Name = "colMascota";
            colMascota.ReadOnly = true;
            colMascota.Width = 86;
            // 
            // colConcepto
            // 
            colConcepto.HeaderText = "Concepto";
            colConcepto.Name = "colConcepto";
            colConcepto.ReadOnly = true;
            // 
            // colMonto
            // 
            colMonto.HeaderText = "Monto";
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            // 
            // colPago
            // 
            colPago.HeaderText = "Pago";
            colPago.Name = "colPago";
            colPago.ReadOnly = true;
            // 
            // ucCobros
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 241, 236);
            Controls.Add(btnEmitirComprobante);
            Controls.Add(btnRegistrarCobro);
            Controls.Add(dgvCobros);
            Controls.Add(grpCobros);
            Font = new Font("Segoe UI", 10F);
            Name = "ucCobros";
            Size = new Size(1080, 612);
            ((System.ComponentModel.ISupportInitialize)dgvCobros).EndInit();
            grpCobros.ResumeLayout(false);
            grpCobros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCobros;
        private GroupBox grpCobros;
        private Label lblFechaHoraUrgencia;
        private TextBox txtMotivo;
        private Label lblMotivoUrgencia;
        private ComboBox cmbVeterinario;
        private Label lblConcepto;
        private Label lblDueno;
        private Label lblMascota;
        private Button btnBuscarMascota;
        private TextBox txtConcepto;
        private TextBox txtMonto;
        private Label lblMonto;
        private ComboBox cmbFormaPago;
        private Label lblFormaPago;
        private Button btnRegistrarCobro;
        private Button btnEmitirComprobante;
        private Button btnConsultarCobros;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colMascota;
        private DataGridViewTextBoxColumn colConcepto;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colPago;
    }
}
