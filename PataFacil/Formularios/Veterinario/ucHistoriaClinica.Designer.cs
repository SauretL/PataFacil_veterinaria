namespace PataFacil
{
    partial class ucHistoriaClinica
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBuscarMascota = new System.Windows.Forms.Button();
            this.lblMascota = new System.Windows.Forms.Label();
            this.lblDueno = new System.Windows.Forms.Label();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.btnNuevaConsulta = new System.Windows.Forms.Button();
            this.btnGuardarConsulta = new System.Windows.Forms.Button();
            this.grpConsulta = new System.Windows.Forms.GroupBox();
            this.lblFechaConsulta = new System.Windows.Forms.Label();
            this.dtpFechaConsulta = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblTratamiento = new System.Windows.Forms.Label();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVeterinario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.grpConsulta.SuspendLayout();
            this.SuspendLayout();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnBuscarMascota
            // 
            this.btnBuscarMascota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.btnBuscarMascota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarMascota.FlatAppearance.BorderSize = 0;
            this.btnBuscarMascota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnBuscarMascota.Location = new System.Drawing.Point(20, 15);
            this.btnBuscarMascota.Name = "btnBuscarMascota";
            this.btnBuscarMascota.Size = new System.Drawing.Size(140, 32);
            this.btnBuscarMascota.TabIndex = 0;
            this.btnBuscarMascota.Text = "Buscar mascota";
            this.btnBuscarMascota.UseVisualStyleBackColor = false;
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Location = new System.Drawing.Point(180, 21);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(208, 23);
            this.lblMascota.TabIndex = 1;
            this.lblMascota.Text = "Mascota: (sin seleccionar)";
            // 
            // lblDueno
            // 
            this.lblDueno.AutoSize = true;
            this.lblDueno.Location = new System.Drawing.Point(480, 21);
            this.lblDueno.Name = "lblDueno";
            this.lblDueno.Size = new System.Drawing.Size(64, 23);
            this.lblDueno.TabIndex = 2;
            this.lblDueno.Text = "Due\u00f1o: -";
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.AllowUserToDeleteRows = false;
            this.dgvConsultas.AllowUserToResizeRows = false;
            this.dgvConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultas.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFecha,
            this.colVeterinario,
            this.colMotivo,
            this.colDiagnostico});
            this.dgvConsultas.EnableHeadersVisualStyles = false;
            this.dgvConsultas.Location = new System.Drawing.Point(20, 70);
            this.dgvConsultas.MultiSelect = false;
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.ReadOnly = true;
            this.dgvConsultas.RowHeadersVisible = false;
            this.dgvConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultas.Size = new System.Drawing.Size(500, 300);
            this.dgvConsultas.TabIndex = 3;
            // 
            // btnNuevaConsulta
            // 
            this.btnNuevaConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.btnNuevaConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaConsulta.FlatAppearance.BorderSize = 0;
            this.btnNuevaConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaConsulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnNuevaConsulta.Location = new System.Drawing.Point(550, 465);
            this.btnNuevaConsulta.Name = "btnNuevaConsulta";
            this.btnNuevaConsulta.Size = new System.Drawing.Size(140, 32);
            this.btnNuevaConsulta.TabIndex = 5;
            this.btnNuevaConsulta.Text = "Nueva consulta";
            this.btnNuevaConsulta.UseVisualStyleBackColor = false;
            // 
            // btnGuardarConsulta
            // 
            this.btnGuardarConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(122)))), ((int)(((byte)(140)))));
            this.btnGuardarConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarConsulta.FlatAppearance.BorderSize = 0;
            this.btnGuardarConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarConsulta.ForeColor = System.Drawing.Color.White;
            this.btnGuardarConsulta.Location = new System.Drawing.Point(710, 465);
            this.btnGuardarConsulta.Name = "btnGuardarConsulta";
            this.btnGuardarConsulta.Size = new System.Drawing.Size(160, 32);
            this.btnGuardarConsulta.TabIndex = 6;
            this.btnGuardarConsulta.Text = "Guardar consulta";
            this.btnGuardarConsulta.UseVisualStyleBackColor = false;
            // 
            // grpConsulta
            // 
            this.grpConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.grpConsulta.Controls.Add(this.lblFechaConsulta);
            this.grpConsulta.Controls.Add(this.dtpFechaConsulta);
            this.grpConsulta.Controls.Add(this.lblMotivo);
            this.grpConsulta.Controls.Add(this.txtMotivo);
            this.grpConsulta.Controls.Add(this.lblDiagnostico);
            this.grpConsulta.Controls.Add(this.txtDiagnostico);
            this.grpConsulta.Controls.Add(this.lblTratamiento);
            this.grpConsulta.Controls.Add(this.txtTratamiento);
            this.grpConsulta.Controls.Add(this.lblObservaciones);
            this.grpConsulta.Controls.Add(this.txtObservaciones);
            this.grpConsulta.Location = new System.Drawing.Point(550, 70);
            this.grpConsulta.Name = "grpConsulta";
            this.grpConsulta.Size = new System.Drawing.Size(530, 382);
            this.grpConsulta.TabIndex = 4;
            this.grpConsulta.TabStop = false;
            this.grpConsulta.Text = "Consulta";
            // 
            // lblFechaConsulta
            // 
            this.lblFechaConsulta.AutoSize = true;
            this.lblFechaConsulta.Location = new System.Drawing.Point(15, 28);
            this.lblFechaConsulta.Name = "lblFechaConsulta";
            this.lblFechaConsulta.Size = new System.Drawing.Size(40, 23);
            this.lblFechaConsulta.TabIndex = 0;
            this.lblFechaConsulta.Text = "Fecha";
            // 
            // dtpFechaConsulta
            // 
            this.dtpFechaConsulta.Enabled = false;
            this.dtpFechaConsulta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaConsulta.Location = new System.Drawing.Point(15, 50);
            this.dtpFechaConsulta.Name = "dtpFechaConsulta";
            this.dtpFechaConsulta.Size = new System.Drawing.Size(160, 29);
            this.dtpFechaConsulta.TabIndex = 1;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(15, 88);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(64, 23);
            this.lblMotivo.TabIndex = 2;
            this.lblMotivo.Text = "Motivo *";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtMotivo.Location = new System.Drawing.Point(15, 110);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(500, 45);
            this.txtMotivo.TabIndex = 3;
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(15, 162);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(104, 23);
            this.lblDiagnostico.TabIndex = 4;
            this.lblDiagnostico.Text = "Diagn\u00f3stico *";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtDiagnostico.Location = new System.Drawing.Point(15, 184);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnostico.Size = new System.Drawing.Size(500, 45);
            this.txtDiagnostico.TabIndex = 5;
            // 
            // lblTratamiento
            // 
            this.lblTratamiento.AutoSize = true;
            this.lblTratamiento.Location = new System.Drawing.Point(15, 236);
            this.lblTratamiento.Name = "lblTratamiento";
            this.lblTratamiento.Size = new System.Drawing.Size(88, 23);
            this.lblTratamiento.TabIndex = 6;
            this.lblTratamiento.Text = "Tratamiento";
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtTratamiento.Location = new System.Drawing.Point(15, 258);
            this.txtTratamiento.Multiline = true;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTratamiento.Size = new System.Drawing.Size(500, 40);
            this.txtTratamiento.TabIndex = 7;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(15, 305);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(104, 23);
            this.lblObservaciones.TabIndex = 8;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtObservaciones.Location = new System.Drawing.Point(15, 327);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(500, 40);
            this.txtObservaciones.TabIndex = 9;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id (oculta)";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colVeterinario
            // 
            this.colVeterinario.HeaderText = "Veterinario";
            this.colVeterinario.Name = "colVeterinario";
            this.colVeterinario.ReadOnly = true;
            // 
            // colMotivo
            // 
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            // 
            // colDiagnostico
            // 
            this.colDiagnostico.HeaderText = "Diagn\u00f3stico";
            this.colDiagnostico.Name = "colDiagnostico";
            this.colDiagnostico.ReadOnly = true;
            // 
            // ucHistoriaClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(236)))));
            this.Controls.Add(this.btnBuscarMascota);
            this.Controls.Add(this.lblMascota);
            this.Controls.Add(this.lblDueno);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.btnNuevaConsulta);
            this.Controls.Add(this.btnGuardarConsulta);
            this.Controls.Add(this.grpConsulta);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ucHistoriaClinica";
            this.Size = new System.Drawing.Size(1100, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.grpConsulta.ResumeLayout(false);
            this.grpConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarMascota;
        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.Label lblDueno;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Button btnNuevaConsulta;
        private System.Windows.Forms.Button btnGuardarConsulta;
        private System.Windows.Forms.GroupBox grpConsulta;
        private System.Windows.Forms.Label lblFechaConsulta;
        private System.Windows.Forms.DateTimePicker dtpFechaConsulta;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblTratamiento;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVeterinario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnostico;
    }
}