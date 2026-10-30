namespace PataFacil.Formularios.Recepcionista
{
    partial class ucClientesMascotas
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvClientes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDni = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            dgvMascotas = new DataGridView();
            colIdMascota = new DataGridViewTextBoxColumn();
            colNombreMascota = new DataGridViewTextBoxColumn();
            colEspecie = new DataGridViewTextBoxColumn();
            colRaza = new DataGridViewTextBoxColumn();
            colSexo = new DataGridViewTextBoxColumn();
            colNacimiento = new DataGridViewTextBoxColumn();
            grpCliente = new GroupBox();
            textBox1 = new TextBox();
            lblEmail = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            grpMascota = new GroupBox();
            dtpNacimiento = new DateTimePicker();
            txtRaza = new TextBox();
            cmbSexo = new ComboBox();
            cmbEspecie = new ComboBox();
            txtNombreMascota = new TextBox();
            lblNacimiento = new Label();
            lblRaza = new Label();
            lblSexo = new Label();
            lblEspecie = new Label();
            lblNombreMascota = new Label();
            btnBajaCliente = new Button();
            btnModificar = new Button();
            btnRegistrar = new Button();
            btnBajaMascota = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMascotas).BeginInit();
            grpCliente.SuspendLayout();
            grpMascota.SuspendLayout();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 10);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(246, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar cliente (nombre, apellido o DNI)";
            lblBuscar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(20, 36);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 25);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(228, 224, 218);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.FromArgb(34, 34, 34);
            btnBuscar.Location = new Point(332, 34);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 32);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.FromArgb(244, 241, 236);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colId, colApellido, colNombre, colDni, colTelefono });
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.Location = new Point(20, 80);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(520, 170);
            dgvClientes.TabIndex = 3;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colApellido
            // 
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colDni
            // 
            colDni.HeaderText = "DNI";
            colDni.Name = "colDni";
            colDni.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // dgvMascotas
            // 
            dgvMascotas.AllowUserToAddRows = false;
            dgvMascotas.AllowUserToDeleteRows = false;
            dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMascotas.BackgroundColor = Color.FromArgb(244, 241, 236);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMascotas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMascotas.Columns.AddRange(new DataGridViewColumn[] { colIdMascota, colNombreMascota, colEspecie, colRaza, colSexo, colNacimiento });
            dgvMascotas.EnableHeadersVisualStyles = false;
            dgvMascotas.Location = new Point(562, 80);
            dgvMascotas.MultiSelect = false;
            dgvMascotas.Name = "dgvMascotas";
            dgvMascotas.ReadOnly = true;
            dgvMascotas.RowHeadersVisible = false;
            dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMascotas.Size = new Size(520, 170);
            dgvMascotas.TabIndex = 4;
            // 
            // colIdMascota
            // 
            colIdMascota.HeaderText = "Id";
            colIdMascota.Name = "colIdMascota";
            colIdMascota.ReadOnly = true;
            colIdMascota.Visible = false;
            // 
            // colNombreMascota
            // 
            colNombreMascota.HeaderText = "Nombre";
            colNombreMascota.Name = "colNombreMascota";
            colNombreMascota.ReadOnly = true;
            // 
            // colEspecie
            // 
            colEspecie.HeaderText = "Especie";
            colEspecie.Name = "colEspecie";
            colEspecie.ReadOnly = true;
            // 
            // colRaza
            // 
            colRaza.HeaderText = "Raza";
            colRaza.Name = "colRaza";
            colRaza.ReadOnly = true;
            // 
            // colSexo
            // 
            colSexo.HeaderText = "Sexo";
            colSexo.Name = "colSexo";
            colSexo.ReadOnly = true;
            // 
            // colNacimiento
            // 
            colNacimiento.HeaderText = "Nacimiento";
            colNacimiento.Name = "colNacimiento";
            colNacimiento.ReadOnly = true;
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(textBox1);
            grpCliente.Controls.Add(lblEmail);
            grpCliente.Controls.Add(txtTelefono);
            grpCliente.Controls.Add(lblTelefono);
            grpCliente.Controls.Add(txtDni);
            grpCliente.Controls.Add(lblDni);
            grpCliente.Controls.Add(txtApellido);
            grpCliente.Controls.Add(lblApellido);
            grpCliente.Controls.Add(txtNombre);
            grpCliente.Controls.Add(lblNombre);
            grpCliente.Location = new Point(20, 262);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(520, 200);
            grpCliente.TabIndex = 5;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del cliente";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(15, 160);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(490, 25);
            textBox1.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(15, 138);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(107, 19);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email (Opcional)";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(275, 104);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(230, 25);
            txtTelefono.TabIndex = 7;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(275, 82);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(66, 19);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono*";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(15, 104);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(230, 25);
            txtDni.TabIndex = 5;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(15, 82);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(39, 19);
            lblDni.TabIndex = 4;
            lblDni.Text = "DNI*";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(275, 48);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(230, 25);
            txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(275, 26);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(64, 19);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido*";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(15, 48);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(230, 25);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 26);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(65, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre*";
            // 
            // grpMascota
            // 
            grpMascota.Controls.Add(dtpNacimiento);
            grpMascota.Controls.Add(txtRaza);
            grpMascota.Controls.Add(cmbSexo);
            grpMascota.Controls.Add(cmbEspecie);
            grpMascota.Controls.Add(txtNombreMascota);
            grpMascota.Controls.Add(lblNacimiento);
            grpMascota.Controls.Add(lblRaza);
            grpMascota.Controls.Add(lblSexo);
            grpMascota.Controls.Add(lblEspecie);
            grpMascota.Controls.Add(lblNombreMascota);
            grpMascota.Location = new Point(560, 262);
            grpMascota.Name = "grpMascota";
            grpMascota.Size = new Size(520, 200);
            grpMascota.TabIndex = 6;
            grpMascota.TabStop = false;
            grpMascota.Text = "Datos de la mascota";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Format = DateTimePickerFormat.Short;
            dtpNacimiento.Location = new Point(335, 127);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(150, 25);
            dtpNacimiento.TabIndex = 9;
            // 
            // txtRaza
            // 
            txtRaza.Location = new Point(175, 127);
            txtRaza.Name = "txtRaza";
            txtRaza.Size = new Size(150, 25);
            txtRaza.TabIndex = 8;
            // 
            // cmbSexo
            // 
            cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Items.AddRange(new object[] { "Macho", "Hembra" });
            cmbSexo.Location = new Point(15, 127);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(150, 25);
            cmbSexo.TabIndex = 7;
            // 
            // cmbEspecie
            // 
            cmbEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecie.FormattingEnabled = true;
            cmbEspecie.Items.AddRange(new object[] { "Perro", "Gato", "Ave", "Conejo", "Otro" });
            cmbEspecie.Location = new Point(275, 71);
            cmbEspecie.Name = "cmbEspecie";
            cmbEspecie.Size = new Size(230, 25);
            cmbEspecie.TabIndex = 6;
            // 
            // txtNombreMascota
            // 
            txtNombreMascota.Location = new Point(15, 71);
            txtNombreMascota.Name = "txtNombreMascota";
            txtNombreMascota.Size = new Size(230, 25);
            txtNombreMascota.TabIndex = 5;
            // 
            // lblNacimiento
            // 
            lblNacimiento.AutoSize = true;
            lblNacimiento.Location = new Point(335, 105);
            lblNacimiento.Name = "lblNacimiento";
            lblNacimiento.Size = new Size(126, 19);
            lblNacimiento.TabIndex = 4;
            lblNacimiento.Text = "Nacimiento (Aprox)";
            // 
            // lblRaza
            // 
            lblRaza.AutoSize = true;
            lblRaza.Location = new Point(175, 105);
            lblRaza.Name = "lblRaza";
            lblRaza.Size = new Size(103, 19);
            lblRaza.TabIndex = 3;
            lblRaza.Text = "Raza (Opcional)";
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Location = new Point(15, 105);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(43, 19);
            lblSexo.TabIndex = 2;
            lblSexo.Text = "Sexo*";
            // 
            // lblEspecie
            // 
            lblEspecie.AutoSize = true;
            lblEspecie.Location = new Point(275, 49);
            lblEspecie.Name = "lblEspecie";
            lblEspecie.Size = new Size(59, 19);
            lblEspecie.TabIndex = 1;
            lblEspecie.Text = "Especie*";
            // 
            // lblNombreMascota
            // 
            lblNombreMascota.AutoSize = true;
            lblNombreMascota.Location = new Point(15, 49);
            lblNombreMascota.Name = "lblNombreMascota";
            lblNombreMascota.Size = new Size(65, 19);
            lblNombreMascota.TabIndex = 0;
            lblNombreMascota.Text = "Nombre*";
            // 
            // btnBajaCliente
            // 
            btnBajaCliente.BackColor = Color.FromArgb(181, 69, 47);
            btnBajaCliente.Cursor = Cursors.Hand;
            btnBajaCliente.FlatAppearance.BorderSize = 0;
            btnBajaCliente.FlatStyle = FlatStyle.Flat;
            btnBajaCliente.ForeColor = Color.White;
            btnBajaCliente.Location = new Point(364, 478);
            btnBajaCliente.Name = "btnBajaCliente";
            btnBajaCliente.Size = new Size(150, 32);
            btnBajaCliente.TabIndex = 9;
            btnBajaCliente.Text = "Dar de baja cliente";
            btnBajaCliente.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(228, 224, 218);
            btnModificar.Cursor = Cursors.Hand;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.ForeColor = Color.FromArgb(34, 34, 34);
            btnModificar.Location = new Point(242, 478);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 32);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(31, 122, 140);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(20, 478);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(210, 32);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar cliente y mascota";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // btnBajaMascota
            // 
            btnBajaMascota.BackColor = Color.FromArgb(181, 69, 47);
            btnBajaMascota.Cursor = Cursors.Hand;
            btnBajaMascota.FlatAppearance.BorderSize = 0;
            btnBajaMascota.FlatStyle = FlatStyle.Flat;
            btnBajaMascota.ForeColor = Color.White;
            btnBajaMascota.Location = new Point(526, 478);
            btnBajaMascota.Name = "btnBajaMascota";
            btnBajaMascota.Size = new Size(150, 32);
            btnBajaMascota.TabIndex = 10;
            btnBajaMascota.Text = "Dar de baja mascota";
            btnBajaMascota.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(228, 224, 218);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.FromArgb(34, 34, 34);
            btnLimpiar.Location = new Point(688, 478);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 32);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // ucClientesMascotas
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 241, 236);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBajaMascota);
            Controls.Add(btnBajaCliente);
            Controls.Add(btnModificar);
            Controls.Add(btnRegistrar);
            Controls.Add(grpMascota);
            Controls.Add(grpCliente);
            Controls.Add(dgvMascotas);
            Controls.Add(dgvClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ucClientesMascotas";
            Size = new Size(1102, 612);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMascotas).EndInit();
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpMascota.ResumeLayout(false);
            grpMascota.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDni;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridView dgvMascotas;
        private DataGridViewTextBoxColumn colIdMascota;
        private DataGridViewTextBoxColumn colNombreMascota;
        private DataGridViewTextBoxColumn colEspecie;
        private DataGridViewTextBoxColumn colRaza;
        private DataGridViewTextBoxColumn colSexo;
        private DataGridViewTextBoxColumn colNacimiento;
        private GroupBox grpCliente;
        private GroupBox grpMascota;
        private TextBox textBox1;
        private Label lblApellido;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblNombre;
        private Label lblEmail;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtDni;
        private Label lblDni;
        private Label lblNacimiento;
        private Label lblRaza;
        private Label lblSexo;
        private Label lblEspecie;
        private Label lblNombreMascota;
        private TextBox txtNombreMascota;
        private DateTimePicker dtpNacimiento;
        private TextBox txtRaza;
        private ComboBox cmbSexo;
        private ComboBox cmbEspecie;
        private Button btnBajaCliente;
        private Button btnModificar;
        private Button btnRegistrar;
        private Button btnBajaMascota;
        private Button btnLimpiar;
    }
}
