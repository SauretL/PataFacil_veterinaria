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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvCobros = new DataGridView();
            grpCobros = new GroupBox();
            cmbFormaPago = new ComboBox();
            lblFormaPago = new Label();
            txtMonto = new TextBox();
            lblMonto = new Label();
            txtConcepto = new TextBox();
            lblConcepto = new Label();
            this.lblDueno = new Label();
            this.lblMascota = new Label();
            this.btnBuscarMascota = new Button();
            grpComprobante = new GroupBox();
            label1 = new Label();
            colNumero = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colMascota = new DataGridViewTextBoxColumn();
            colConcepto = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colPago = new DataGridViewTextBoxColumn();
            btnRegistrarCobro = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCobros).BeginInit();
            grpCobros.SuspendLayout();
            grpComprobante.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCobros
            // 
            dgvCobros.AllowUserToAddRows = false;
            dgvCobros.AllowUserToDeleteRows = false;
            dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCobros.BackgroundColor = Color.FromArgb(244, 241, 236);
            dgvCobros.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCobros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            grpCobros.Controls.Add(grpComprobante);
            grpCobros.Controls.Add(cmbFormaPago);
            grpCobros.Controls.Add(lblFormaPago);
            grpCobros.Controls.Add(txtMonto);
            grpCobros.Controls.Add(lblMonto);
            grpCobros.Controls.Add(txtConcepto);
            grpCobros.Controls.Add(lblConcepto);
            grpCobros.Controls.Add(this.lblDueno);
            grpCobros.Controls.Add(this.lblMascota);
            grpCobros.Controls.Add(this.btnBuscarMascota);
            grpCobros.Location = new Point(20, 10);
            grpCobros.Name = "grpCobros";
            grpCobros.Size = new Size(470, 340);
            grpCobros.TabIndex = 19;
            grpCobros.TabStop = false;
            grpCobros.Text = "Cobro";
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Items.AddRange(new object[] { "Efectivo", "Transferencia" });
            cmbFormaPago.Location = new Point(235, 204);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(220, 25);
            cmbFormaPago.TabIndex = 31;
            // 
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.Location = new Point(234, 182);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(112, 19);
            lblFormaPago.TabIndex = 30;
            lblFormaPago.Text = "Forma de pago *";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(15, 204);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(200, 25);
            txtMonto.TabIndex = 29;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(15, 182);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(61, 19);
            lblMonto.TabIndex = 28;
            lblMonto.Text = "Monto *";
            // 
            // txtConcepto
            // 
            txtConcepto.Location = new Point(15, 147);
            txtConcepto.Name = "txtConcepto";
            txtConcepto.Size = new Size(440, 25);
            txtConcepto.TabIndex = 27;
            // 
            // lblConcepto
            // 
            lblConcepto.AutoSize = true;
            lblConcepto.Location = new Point(15, 125);
            lblConcepto.Name = "lblConcepto";
            lblConcepto.Size = new Size(78, 19);
            lblConcepto.TabIndex = 22;
            lblConcepto.Text = "Concepto *";
            // 
            // lblDueno
            // 
            this.lblDueno.AutoSize = true;
            this.lblDueno.Location = new Point(15, 92);
            this.lblDueno.Name = "lblDueno";
            this.lblDueno.Size = new Size(63, 19);
            this.lblDueno.TabIndex = 18;
            this.lblDueno.Text = "Dueño: -";
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Location = new Point(15, 68);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new Size(163, 19);
            this.lblMascota.TabIndex = 17;
            this.lblMascota.Text = "Mascota: (sin seleccionar)";
            // 
            // btnBuscarMascota
            // 
            this.btnBuscarMascota.BackColor = Color.FromArgb(228, 224, 218);
            this.btnBuscarMascota.Cursor = Cursors.Hand;
            this.btnBuscarMascota.FlatAppearance.BorderSize = 0;
            this.btnBuscarMascota.FlatStyle = FlatStyle.Flat;
            this.btnBuscarMascota.ForeColor = Color.FromArgb(34, 34, 34);
            this.btnBuscarMascota.Location = new Point(15, 25);
            this.btnBuscarMascota.Name = "btnBuscarMascota";
            this.btnBuscarMascota.Size = new Size(140, 36);
            this.btnBuscarMascota.TabIndex = 16;
            this.btnBuscarMascota.Text = "Buscar mascota";
            this.btnBuscarMascota.UseVisualStyleBackColor = false;
            // 
            // grpComprobante
            // 
            grpComprobante.Controls.Add(label1);
            grpComprobante.Location = new Point(15, 245);
            grpComprobante.Name = "grpComprobante";
            grpComprobante.Size = new Size(440, 80);
            grpComprobante.TabIndex = 32;
            grpComprobante.TabStop = false;
            grpComprobante.Text = "Comprobante";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 21);
            label1.Name = "label1";
            label1.Size = new Size(434, 56);
            label1.TabIndex = 0;
            // 
            // colNumero
            // 
            colNumero.HeaderText = "N°";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colMascota
            // 
            colMascota.HeaderText = "Mascota";
            colMascota.Name = "colMascota";
            colMascota.ReadOnly = true;
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
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(228, 224, 218);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.FromArgb(34, 34, 34);
            btnLimpiar.Location = new Point(180, 370);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 36);
            btnLimpiar.TabIndex = 24;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // ucCobros
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 241, 236);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrarCobro);
            Controls.Add(dgvCobros);
            Controls.Add(grpCobros);
            Font = new Font("Segoe UI", 10F);
            Name = "ucCobros";
            Size = new Size(1080, 612);
            ((System.ComponentModel.ISupportInitialize)dgvCobros).EndInit();
            grpCobros.ResumeLayout(false);
            grpCobros.PerformLayout();
            grpComprobante.ResumeLayout(false);
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
        private GroupBox grpComprobante;
        private Label label1;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colMascota;
        private DataGridViewTextBoxColumn colConcepto;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colPago;
        private Button btnRegistrarCobro;
        private Button btnLimpiar;
    }
}
