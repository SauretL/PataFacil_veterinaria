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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnBuscarMascota = new Button();
            lblMascota = new Label();
            lblDueno = new Label();
            dgvConsultas = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colVeterinario = new DataGridViewTextBoxColumn();
            colMotivo = new DataGridViewTextBoxColumn();
            colDiagnostico = new DataGridViewTextBoxColumn();
            btnNuevaConsulta = new Button();
            btnGuardarConsulta = new Button();
            grpConsulta = new GroupBox();
            lblFechaConsulta = new Label();
            dtpFechaConsulta = new DateTimePicker();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            lblDiagnostico = new Label();
            txtDiagnostico = new TextBox();
            lblTratamiento = new Label();
            txtTratamiento = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
            grpConsulta.SuspendLayout();
            SuspendLayout();
            // 
            // btnBuscarMascota
            // 
            btnBuscarMascota.BackColor = Color.FromArgb(228, 224, 218);
            btnBuscarMascota.Cursor = Cursors.Hand;
            btnBuscarMascota.FlatAppearance.BorderSize = 0;
            btnBuscarMascota.FlatStyle = FlatStyle.Flat;
            btnBuscarMascota.ForeColor = Color.FromArgb(34, 34, 34);
            btnBuscarMascota.Location = new Point(20, 15);
            btnBuscarMascota.Name = "btnBuscarMascota";
            btnBuscarMascota.Size = new Size(140, 32);
            btnBuscarMascota.TabIndex = 0;
            btnBuscarMascota.Text = "Buscar mascota";
            btnBuscarMascota.UseVisualStyleBackColor = false;
            btnBuscarMascota.Click += btnBuscarMascota_Click;
            // 
            // lblMascota
            // 
            lblMascota.AutoSize = true;
            lblMascota.Location = new Point(180, 21);
            lblMascota.Name = "lblMascota";
            lblMascota.Size = new Size(203, 23);
            lblMascota.TabIndex = 1;
            lblMascota.Text = "Mascota: (sin seleccionar)";
            // 
            // lblDueno
            // 
            lblDueno.AutoSize = true;
            lblDueno.Location = new Point(480, 21);
            lblDueno.Name = "lblDueno";
            lblDueno.Size = new Size(77, 23);
            lblDueno.TabIndex = 2;
            lblDueno.Text = "Dueño: -";
            // 
            // dgvConsultas
            // 
            dgvConsultas.AllowUserToAddRows = false;
            dgvConsultas.AllowUserToDeleteRows = false;
            dgvConsultas.AllowUserToResizeRows = false;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultas.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvConsultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultas.Columns.AddRange(new DataGridViewColumn[] { colId, colFecha, colVeterinario, colMotivo, colDiagnostico });
            dgvConsultas.EnableHeadersVisualStyles = false;
            dgvConsultas.Location = new Point(20, 70);
            dgvConsultas.MultiSelect = false;
            dgvConsultas.Name = "dgvConsultas";
            dgvConsultas.ReadOnly = true;
            dgvConsultas.RowHeadersVisible = false;
            dgvConsultas.RowHeadersWidth = 51;
            dgvConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultas.Size = new Size(500, 300);
            dgvConsultas.TabIndex = 3;
            dgvConsultas.SelectionChanged += dgvConsultas_SelectionChanged;
            // 
            // colId
            // 
            colId.HeaderText = "Id (oculta)";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colVeterinario
            // 
            colVeterinario.HeaderText = "Veterinario";
            colVeterinario.MinimumWidth = 6;
            colVeterinario.Name = "colVeterinario";
            colVeterinario.ReadOnly = true;
            // 
            // colMotivo
            // 
            colMotivo.HeaderText = "Motivo";
            colMotivo.MinimumWidth = 6;
            colMotivo.Name = "colMotivo";
            colMotivo.ReadOnly = true;
            // 
            // colDiagnostico
            // 
            colDiagnostico.HeaderText = "Diagnóstico";
            colDiagnostico.MinimumWidth = 6;
            colDiagnostico.Name = "colDiagnostico";
            colDiagnostico.ReadOnly = true;
            // 
            // btnNuevaConsulta
            // 
            btnNuevaConsulta.BackColor = Color.FromArgb(228, 224, 218);
            btnNuevaConsulta.Cursor = Cursors.Hand;
            btnNuevaConsulta.FlatAppearance.BorderSize = 0;
            btnNuevaConsulta.FlatStyle = FlatStyle.Flat;
            btnNuevaConsulta.ForeColor = Color.FromArgb(34, 34, 34);
            btnNuevaConsulta.Location = new Point(550, 465);
            btnNuevaConsulta.Name = "btnNuevaConsulta";
            btnNuevaConsulta.Size = new Size(140, 32);
            btnNuevaConsulta.TabIndex = 5;
            btnNuevaConsulta.Text = "Nueva consulta";
            btnNuevaConsulta.UseVisualStyleBackColor = false;
            btnNuevaConsulta.Click += btnNuevaConsulta_Click;
            // 
            // btnGuardarConsulta
            // 
            btnGuardarConsulta.BackColor = Color.FromArgb(31, 122, 140);
            btnGuardarConsulta.Cursor = Cursors.Hand;
            btnGuardarConsulta.FlatAppearance.BorderSize = 0;
            btnGuardarConsulta.FlatStyle = FlatStyle.Flat;
            btnGuardarConsulta.ForeColor = Color.White;
            btnGuardarConsulta.Location = new Point(710, 465);
            btnGuardarConsulta.Name = "btnGuardarConsulta";
            btnGuardarConsulta.Size = new Size(160, 32);
            btnGuardarConsulta.TabIndex = 6;
            btnGuardarConsulta.Text = "Guardar consulta";
            btnGuardarConsulta.UseVisualStyleBackColor = false;
            btnGuardarConsulta.Click += btnGuardarConsulta_Click;
            // 
            // grpConsulta
            // 
            grpConsulta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpConsulta.Controls.Add(lblFechaConsulta);
            grpConsulta.Controls.Add(dtpFechaConsulta);
            grpConsulta.Controls.Add(lblMotivo);
            grpConsulta.Controls.Add(txtMotivo);
            grpConsulta.Controls.Add(lblDiagnostico);
            grpConsulta.Controls.Add(txtDiagnostico);
            grpConsulta.Controls.Add(lblTratamiento);
            grpConsulta.Controls.Add(txtTratamiento);
            grpConsulta.Controls.Add(lblObservaciones);
            grpConsulta.Controls.Add(txtObservaciones);
            grpConsulta.Location = new Point(550, 70);
            grpConsulta.Name = "grpConsulta";
            grpConsulta.Size = new Size(530, 382);
            grpConsulta.TabIndex = 4;
            grpConsulta.TabStop = false;
            grpConsulta.Text = "Consulta";
            // 
            // lblFechaConsulta
            // 
            lblFechaConsulta.AutoSize = true;
            lblFechaConsulta.Location = new Point(15, 28);
            lblFechaConsulta.Name = "lblFechaConsulta";
            lblFechaConsulta.Size = new Size(54, 23);
            lblFechaConsulta.TabIndex = 0;
            lblFechaConsulta.Text = "Fecha";
            // 
            // dtpFechaConsulta
            // 
            dtpFechaConsulta.Enabled = false;
            dtpFechaConsulta.Format = DateTimePickerFormat.Short;
            dtpFechaConsulta.Location = new Point(15, 50);
            dtpFechaConsulta.Name = "dtpFechaConsulta";
            dtpFechaConsulta.Size = new Size(160, 30);
            dtpFechaConsulta.TabIndex = 1;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(15, 88);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(75, 23);
            lblMotivo.TabIndex = 2;
            lblMotivo.Text = "Motivo *";
            // 
            // txtMotivo
            // 
            txtMotivo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMotivo.Location = new Point(15, 110);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.ScrollBars = ScrollBars.Vertical;
            txtMotivo.Size = new Size(500, 45);
            txtMotivo.TabIndex = 3;
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Location = new Point(15, 162);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(112, 23);
            lblDiagnostico.TabIndex = 4;
            lblDiagnostico.Text = "Diagnóstico *";
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiagnostico.Location = new Point(15, 184);
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.ScrollBars = ScrollBars.Vertical;
            txtDiagnostico.Size = new Size(500, 45);
            txtDiagnostico.TabIndex = 5;
            // 
            // lblTratamiento
            // 
            lblTratamiento.AutoSize = true;
            lblTratamiento.Location = new Point(15, 236);
            lblTratamiento.Name = "lblTratamiento";
            lblTratamiento.Size = new Size(102, 23);
            lblTratamiento.TabIndex = 6;
            lblTratamiento.Text = "Tratamiento";
            // 
            // txtTratamiento
            // 
            txtTratamiento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTratamiento.Location = new Point(15, 258);
            txtTratamiento.Multiline = true;
            txtTratamiento.Name = "txtTratamiento";
            txtTratamiento.ScrollBars = ScrollBars.Vertical;
            txtTratamiento.Size = new Size(500, 40);
            txtTratamiento.TabIndex = 7;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(15, 305);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(120, 23);
            lblObservaciones.TabIndex = 8;
            lblObservaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservaciones.Location = new Point(15, 327);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(500, 40);
            txtObservaciones.TabIndex = 9;
            // 
            // ucHistoriaClinica
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 241, 236);
            Controls.Add(btnBuscarMascota);
            Controls.Add(lblMascota);
            Controls.Add(lblDueno);
            Controls.Add(dgvConsultas);
            Controls.Add(btnNuevaConsulta);
            Controls.Add(btnGuardarConsulta);
            Controls.Add(grpConsulta);
            Font = new Font("Segoe UI", 10F);
            Name = "ucHistoriaClinica";
            Size = new Size(1100, 560);
            Load += ucHistoriaClinica_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
            grpConsulta.ResumeLayout(false);
            grpConsulta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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