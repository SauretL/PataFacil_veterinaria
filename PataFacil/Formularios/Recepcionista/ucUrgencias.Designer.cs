namespace PataFacil.Formularios.Recepcionista
{
    partial class ucUrgencias
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grpUrgencias = new GroupBox();
            lblFechaHoraUrgencia = new Label();
            txtMotivo = new TextBox();
            lblMotivoUrgencia = new Label();
            cmbVeterinario = new ComboBox();
            lblVeterinarioUrgencia = new Label();
            lblDuenoUrgencia = new Label();
            lblMascotaUrgencia = new Label();
            this.btnBuscarMascota = new Button();
            dgvUrgenciasHoy = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colHora = new DataGridViewTextBoxColumn();
            colMascota = new DataGridViewTextBoxColumn();
            colDueno = new DataGridViewTextBoxColumn();
            colVeterinario = new DataGridViewTextBoxColumn();
            colMotivo = new DataGridViewTextBoxColumn();
            btnLimpiar = new Button();
            btnRegistrarUrgencia = new Button();
            grpUrgencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUrgenciasHoy).BeginInit();
            SuspendLayout();
            // 
            // grpUrgencias
            // 
            grpUrgencias.Controls.Add(lblFechaHoraUrgencia);
            grpUrgencias.Controls.Add(txtMotivo);
            grpUrgencias.Controls.Add(lblMotivoUrgencia);
            grpUrgencias.Controls.Add(cmbVeterinario);
            grpUrgencias.Controls.Add(lblVeterinarioUrgencia);
            grpUrgencias.Controls.Add(lblDuenoUrgencia);
            grpUrgencias.Controls.Add(lblMascotaUrgencia);
            grpUrgencias.Controls.Add(this.btnBuscarMascota);
            grpUrgencias.Location = new Point(20, 11);
            grpUrgencias.Name = "grpUrgencias";
            grpUrgencias.Size = new Size(520, 340);
            grpUrgencias.TabIndex = 0;
            grpUrgencias.TabStop = false;
            grpUrgencias.Text = "Urgencia (sin turno previo)";
            // 
            // lblFechaHoraUrgencia
            // 
            lblFechaHoraUrgencia.AutoSize = true;
            lblFechaHoraUrgencia.Location = new Point(310, 171);
            lblFechaHoraUrgencia.Name = "lblFechaHoraUrgencia";
            lblFechaHoraUrgencia.Size = new Size(170, 19);
            lblFechaHoraUrgencia.TabIndex = 26;
            lblFechaHoraUrgencia.Text = "Fecha y hora: (automática)";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(15, 235);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(490, 67);
            txtMotivo.TabIndex = 25;
            // 
            // lblMotivoUrgencia
            // 
            lblMotivoUrgencia.AutoSize = true;
            lblMotivoUrgencia.Location = new Point(15, 210);
            lblMotivoUrgencia.Name = "lblMotivoUrgencia";
            lblMotivoUrgencia.Size = new Size(152, 19);
            lblMotivoUrgencia.TabIndex = 24;
            lblMotivoUrgencia.Text = "Motivo de la urgencia *";
            // 
            // cmbVeterinario
            // 
            cmbVeterinario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVeterinario.FormattingEnabled = true;
            cmbVeterinario.Location = new Point(15, 167);
            cmbVeterinario.Name = "cmbVeterinario";
            cmbVeterinario.Size = new Size(280, 25);
            cmbVeterinario.TabIndex = 23;
            // 
            // lblVeterinarioUrgencia
            // 
            lblVeterinarioUrgencia.AutoSize = true;
            lblVeterinarioUrgencia.Location = new Point(15, 142);
            lblVeterinarioUrgencia.Name = "lblVeterinarioUrgencia";
            lblVeterinarioUrgencia.Size = new Size(161, 19);
            lblVeterinarioUrgencia.TabIndex = 22;
            lblVeterinarioUrgencia.Text = "Veterinario que atiende *";
            // 
            // lblDuenoUrgencia
            // 
            lblDuenoUrgencia.AutoSize = true;
            lblDuenoUrgencia.Location = new Point(15, 104);
            lblDuenoUrgencia.Name = "lblDuenoUrgencia";
            lblDuenoUrgencia.Size = new Size(63, 19);
            lblDuenoUrgencia.TabIndex = 18;
            lblDuenoUrgencia.Text = "Dueño: -";
            // 
            // lblMascotaUrgencia
            // 
            lblMascotaUrgencia.AutoSize = true;
            lblMascotaUrgencia.Location = new Point(15, 77);
            lblMascotaUrgencia.Name = "lblMascotaUrgencia";
            lblMascotaUrgencia.Size = new Size(163, 19);
            lblMascotaUrgencia.TabIndex = 17;
            lblMascotaUrgencia.Text = "Mascota: (sin seleccionar)";
            // 
            // btnBuscarMascota
            // 
            this.btnBuscarMascota.BackColor = Color.FromArgb(228, 224, 218);
            this.btnBuscarMascota.Cursor = Cursors.Hand;
            this.btnBuscarMascota.FlatAppearance.BorderSize = 0;
            this.btnBuscarMascota.FlatStyle = FlatStyle.Flat;
            this.btnBuscarMascota.ForeColor = Color.FromArgb(34, 34, 34);
            this.btnBuscarMascota.Location = new Point(15, 23);
            this.btnBuscarMascota.Name = "btnBuscarMascota";
            this.btnBuscarMascota.Size = new Size(140, 36);
            this.btnBuscarMascota.TabIndex = 16;
            this.btnBuscarMascota.Text = "Buscar mascota";
            this.btnBuscarMascota.UseVisualStyleBackColor = false;
            // 
            // dgvUrgenciasHoy
            // 
            dgvUrgenciasHoy.AllowUserToAddRows = false;
            dgvUrgenciasHoy.AllowUserToDeleteRows = false;
            dgvUrgenciasHoy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUrgenciasHoy.BackgroundColor = Color.FromArgb(244, 241, 236);
            dgvUrgenciasHoy.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUrgenciasHoy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUrgenciasHoy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUrgenciasHoy.Columns.AddRange(new DataGridViewColumn[] { colId, colHora, colMascota, colDueno, colVeterinario, colMotivo });
            dgvUrgenciasHoy.EnableHeadersVisualStyles = false;
            dgvUrgenciasHoy.Location = new Point(560, 11);
            dgvUrgenciasHoy.MultiSelect = false;
            dgvUrgenciasHoy.Name = "dgvUrgenciasHoy";
            dgvUrgenciasHoy.ReadOnly = true;
            dgvUrgenciasHoy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrgenciasHoy.Size = new Size(510, 340);
            dgvUrgenciasHoy.TabIndex = 18;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colHora
            // 
            colHora.HeaderText = "Hora";
            colHora.Name = "colHora";
            colHora.ReadOnly = true;
            // 
            // colMascota
            // 
            colMascota.HeaderText = "Mascota";
            colMascota.Name = "colMascota";
            colMascota.ReadOnly = true;
            // 
            // colDueno
            // 
            colDueno.HeaderText = "Dueño";
            colDueno.Name = "colDueno";
            colDueno.ReadOnly = true;
            // 
            // colVeterinario
            // 
            colVeterinario.HeaderText = "Veterinario";
            colVeterinario.Name = "colVeterinario";
            colVeterinario.ReadOnly = true;
            // 
            // colMotivo
            // 
            colMotivo.HeaderText = "Motivo";
            colMotivo.Name = "colMotivo";
            colMotivo.ReadOnly = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(228, 224, 218);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.FromArgb(34, 34, 34);
            btnLimpiar.Location = new Point(202, 374);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 36);
            btnLimpiar.TabIndex = 20;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarUrgencia
            // 
            btnRegistrarUrgencia.BackColor = Color.FromArgb(31, 122, 140);
            btnRegistrarUrgencia.Cursor = Cursors.Hand;
            btnRegistrarUrgencia.FlatAppearance.BorderSize = 0;
            btnRegistrarUrgencia.FlatStyle = FlatStyle.Flat;
            btnRegistrarUrgencia.ForeColor = Color.White;
            btnRegistrarUrgencia.Location = new Point(20, 374);
            btnRegistrarUrgencia.Name = "btnRegistrarUrgencia";
            btnRegistrarUrgencia.Size = new Size(170, 36);
            btnRegistrarUrgencia.TabIndex = 19;
            btnRegistrarUrgencia.Text = "Registrar Urgencia";
            btnRegistrarUrgencia.UseVisualStyleBackColor = false;
            // 
            // ucUrgencias
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 241, 236);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrarUrgencia);
            Controls.Add(dgvUrgenciasHoy);
            Controls.Add(grpUrgencias);
            Font = new Font("Segoe UI", 10F);
            Name = "ucUrgencias";
            Size = new Size(1080, 612);
            grpUrgencias.ResumeLayout(false);
            grpUrgencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUrgenciasHoy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpUrgencias;
        private DataGridView dgvUrgenciasHoy;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colMascota;
        private DataGridViewTextBoxColumn colDueno;
        private DataGridViewTextBoxColumn colVeterinario;
        private DataGridViewTextBoxColumn colMotivo;
        private Label lblDueno;
        private Label lblMascota;
        private Button btnBuscarMascota;
        private ComboBox cmbVeterinario;
        private Label lblVeterinario;
        private TextBox txtMotivo;
        private Label lblMotivoUrgencia;
        private Label lblFechaHoraUrgencia;
        private Label lblDuenoUrgencia;
        private Label lblMascotaUrgencia;
        private Label lblVeterinarioUrgencia;
        private Button btnLimpiar;
        private Button btnRegistrarUrgencia;
    }
}
