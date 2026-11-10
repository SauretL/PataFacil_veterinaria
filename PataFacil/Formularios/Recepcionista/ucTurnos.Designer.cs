namespace PataFacil.Formularios.Recepcionista
{
    partial class ucTurnos
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
            grpTurnos = new GroupBox();
            txtMotivo = new TextBox();
            lblMotivo = new Label();
            cmbVeterinario = new ComboBox();
            lblVeterinario = new Label();
            cmbHora = new ComboBox();
            lblHora = new Label();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            lblDueno = new Label();
            lblMascota = new Label();
            btnBuscarMascota = new Button();
            btnCancelarTurno = new Button();
            btnReprogramar = new Button();
            btnRegistrarTurno = new Button();
            lblFiltroFecha = new Label();
            dtpFiltroFecha = new DateTimePicker();
            lblFiltroVet = new Label();
            this.cmbFiltroVet = new ComboBox();
            dgvTurnos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colHora = new DataGridViewTextBoxColumn();
            colMascota = new DataGridViewTextBoxColumn();
            colDueno = new DataGridViewTextBoxColumn();
            colVeterinario = new DataGridViewTextBoxColumn();
            colMotivo = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            btnLimpiar = new Button();
            grpTurnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // grpTurnos
            // 
            grpTurnos.Controls.Add(txtMotivo);
            grpTurnos.Controls.Add(lblMotivo);
            grpTurnos.Controls.Add(cmbVeterinario);
            grpTurnos.Controls.Add(lblVeterinario);
            grpTurnos.Controls.Add(cmbHora);
            grpTurnos.Controls.Add(lblHora);
            grpTurnos.Controls.Add(dtpFecha);
            grpTurnos.Controls.Add(lblFecha);
            grpTurnos.Controls.Add(lblDueno);
            grpTurnos.Controls.Add(lblMascota);
            grpTurnos.Controls.Add(btnBuscarMascota);
            grpTurnos.Location = new Point(20, 11);
            grpTurnos.Name = "grpTurnos";
            grpTurnos.Size = new Size(420, 385);
            grpTurnos.TabIndex = 0;
            grpTurnos.TabStop = false;
            grpTurnos.Text = "Datos del turno";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(15, 296);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(380, 67);
            txtMotivo.TabIndex = 23;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(15, 271);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(59, 19);
            lblMotivo.TabIndex = 22;
            lblMotivo.Text = "Motivo*";
            // 
            // cmbVeterinario
            // 
            cmbVeterinario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVeterinario.FormattingEnabled = true;
            cmbVeterinario.Location = new Point(15, 231);
            cmbVeterinario.Name = "cmbVeterinario";
            cmbVeterinario.Size = new Size(380, 25);
            cmbVeterinario.TabIndex = 21;
            // 
            // lblVeterinario
            // 
            lblVeterinario.AutoSize = true;
            lblVeterinario.Location = new Point(15, 206);
            lblVeterinario.Name = "lblVeterinario";
            lblVeterinario.Size = new Size(81, 19);
            lblVeterinario.TabIndex = 20;
            lblVeterinario.Text = "Veterinario*";
            // 
            // cmbHora
            // 
            cmbHora.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHora.FormattingEnabled = true;
            cmbHora.Items.AddRange(new object[] { "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "" });
            cmbHora.Location = new Point(215, 167);
            cmbHora.Name = "cmbHora";
            cmbHora.Size = new Size(180, 25);
            cmbHora.TabIndex = 19;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(215, 142);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(49, 19);
            lblHora.TabIndex = 18;
            lblHora.Text = "Hora *";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(15, 167);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(180, 25);
            dtpFecha.TabIndex = 17;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(15, 142);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(54, 19);
            lblFecha.TabIndex = 16;
            lblFecha.Text = "Fecha *";
            // 
            // lblDueno
            // 
            lblDueno.AutoSize = true;
            lblDueno.Location = new Point(15, 104);
            lblDueno.Name = "lblDueno";
            lblDueno.Size = new Size(63, 19);
            lblDueno.TabIndex = 15;
            lblDueno.Text = "Dueño: -";
            // 
            // lblMascota
            // 
            lblMascota.AutoSize = true;
            lblMascota.Location = new Point(15, 77);
            lblMascota.Name = "lblMascota";
            lblMascota.Size = new Size(163, 19);
            lblMascota.TabIndex = 14;
            lblMascota.Text = "Mascota: (sin seleccionar)";
            // 
            // btnBuscarMascota
            // 
            btnBuscarMascota.BackColor = Color.FromArgb(228, 224, 218);
            btnBuscarMascota.Cursor = Cursors.Hand;
            btnBuscarMascota.FlatAppearance.BorderSize = 0;
            btnBuscarMascota.FlatStyle = FlatStyle.Flat;
            btnBuscarMascota.ForeColor = Color.FromArgb(34, 34, 34);
            btnBuscarMascota.Location = new Point(15, 28);
            btnBuscarMascota.Name = "btnBuscarMascota";
            btnBuscarMascota.Size = new Size(140, 36);
            btnBuscarMascota.TabIndex = 13;
            btnBuscarMascota.Text = "Buscar mascota";
            btnBuscarMascota.UseVisualStyleBackColor = false;
            // 
            // btnCancelarTurno
            // 
            btnCancelarTurno.BackColor = Color.FromArgb(181, 69, 47);
            btnCancelarTurno.Cursor = Cursors.Hand;
            btnCancelarTurno.FlatAppearance.BorderSize = 0;
            btnCancelarTurno.FlatStyle = FlatStyle.Flat;
            btnCancelarTurno.ForeColor = Color.White;
            btnCancelarTurno.Location = new Point(304, 419);
            btnCancelarTurno.Name = "btnCancelarTurno";
            btnCancelarTurno.Size = new Size(130, 36);
            btnCancelarTurno.TabIndex = 12;
            btnCancelarTurno.Text = "Cancelar Turno";
            btnCancelarTurno.UseVisualStyleBackColor = false;
            // 
            // btnReprogramar
            // 
            btnReprogramar.BackColor = Color.FromArgb(228, 224, 218);
            btnReprogramar.Cursor = Cursors.Hand;
            btnReprogramar.FlatAppearance.BorderSize = 0;
            btnReprogramar.FlatStyle = FlatStyle.Flat;
            btnReprogramar.ForeColor = Color.FromArgb(34, 34, 34);
            btnReprogramar.Location = new Point(172, 419);
            btnReprogramar.Name = "btnReprogramar";
            btnReprogramar.Size = new Size(120, 36);
            btnReprogramar.TabIndex = 11;
            btnReprogramar.Text = "Reprogramar";
            btnReprogramar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarTurno
            // 
            btnRegistrarTurno.BackColor = Color.FromArgb(31, 122, 140);
            btnRegistrarTurno.Cursor = Cursors.Hand;
            btnRegistrarTurno.FlatAppearance.BorderSize = 0;
            btnRegistrarTurno.FlatStyle = FlatStyle.Flat;
            btnRegistrarTurno.ForeColor = Color.White;
            btnRegistrarTurno.Location = new Point(20, 419);
            btnRegistrarTurno.Name = "btnRegistrarTurno";
            btnRegistrarTurno.Size = new Size(140, 36);
            btnRegistrarTurno.TabIndex = 10;
            btnRegistrarTurno.Text = "Registrar Turno";
            btnRegistrarTurno.UseVisualStyleBackColor = false;
            // 
            // lblFiltroFecha
            // 
            lblFiltroFecha.AutoSize = true;
            lblFiltroFecha.Location = new Point(470, 11);
            lblFiltroFecha.Name = "lblFiltroFecha";
            lblFiltroFecha.Size = new Size(117, 19);
            lblFiltroFecha.TabIndex = 13;
            lblFiltroFecha.Text = "Ver turnos del día";
            // 
            // dtpFiltroFecha
            // 
            dtpFiltroFecha.Format = DateTimePickerFormat.Short;
            dtpFiltroFecha.Location = new Point(470, 39);
            dtpFiltroFecha.Name = "dtpFiltroFecha";
            dtpFiltroFecha.Size = new Size(150, 25);
            dtpFiltroFecha.TabIndex = 14;
            // 
            // lblFiltroVet
            // 
            lblFiltroVet.AutoSize = true;
            lblFiltroVet.Location = new Point(640, 11);
            lblFiltroVet.Name = "lblFiltroVet";
            lblFiltroVet.Size = new Size(75, 19);
            lblFiltroVet.TabIndex = 15;
            lblFiltroVet.Text = "Veterinario";
            // 
            // cmbFiltroVet
            // 
            this.cmbFiltroVet.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFiltroVet.FormattingEnabled = true;
            this.cmbFiltroVet.Location = new Point(640, 39);
            this.cmbFiltroVet.Name = "cmbFiltroVet";
            this.cmbFiltroVet.Size = new Size(250, 25);
            this.cmbFiltroVet.TabIndex = 16;
            // 
            // dgvTurnos
            // 
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.BackgroundColor = Color.FromArgb(244, 241, 236);
            dgvTurnos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnos.Columns.AddRange(new DataGridViewColumn[] { colId, colHora, colMascota, colDueno, colVeterinario, colMotivo, colEstado });
            dgvTurnos.EnableHeadersVisualStyles = false;
            dgvTurnos.Location = new Point(470, 91);
            dgvTurnos.MultiSelect = false;
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.ReadOnly = true;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.Size = new Size(610, 306);
            dgvTurnos.TabIndex = 17;
            dgvTurnos.CellContentClick += dataGridView1_CellContentClick;
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
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(228, 224, 218);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.FromArgb(34, 34, 34);
            btnLimpiar.Location = new Point(446, 419);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 36);
            btnLimpiar.TabIndex = 18;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // ucTurnos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 241, 236);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvTurnos);
            Controls.Add(this.cmbFiltroVet);
            Controls.Add(lblFiltroVet);
            Controls.Add(dtpFiltroFecha);
            Controls.Add(lblFiltroFecha);
            Controls.Add(btnCancelarTurno);
            Controls.Add(btnReprogramar);
            Controls.Add(btnRegistrarTurno);
            Controls.Add(grpTurnos);
            Font = new Font("Segoe UI", 10F);
            Name = "ucTurnos";
            Size = new Size(1080, 612);
            grpTurnos.ResumeLayout(false);
            grpTurnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpTurnos;
        private Button btnBuscarMascota;
        private Button btnBajaCliente;
        private Button btnModificar;
        private Button btnRegistrarTurno;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private Label lblDueno;
        private Label lblMascota;
        private Label lblMotivo;
        private ComboBox cmbVeterinario;
        private Label lblVeterinario;
        private ComboBox cmbHora;
        private Label lblHora;
        private TextBox txtMotivo;
        private Label lblFiltroFecha;
        private DateTimePicker dtpFiltroFecha;
        private Label lblFiltroVet;
        private ComboBox cmbFiltroVet;
        private DataGridView dgvTurnos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colMascota;
        private DataGridViewTextBoxColumn colDueno;
        private DataGridViewTextBoxColumn colVeterinario;
        private DataGridViewTextBoxColumn colMotivo;
        private DataGridViewTextBoxColumn colEstado;
        private Button btnCancelarTurno;
        private Button btnReprogramar;
        private Button btnLimpiar;
    }
}
