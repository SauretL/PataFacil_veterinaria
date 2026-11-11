namespace PataFacil
{
    partial class ucAgenda
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            btnHoy = new Button();
            chkSoloPendientes = new CheckBox();
            dgvAgenda = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colHora = new DataGridViewTextBoxColumn();
            colMascota = new DataGridViewTextBoxColumn();
            colEspecie = new DataGridViewTextBoxColumn();
            colDueno = new DataGridViewTextBoxColumn();
            colMotivo = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            btnAbrirHistoria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAgenda).BeginInit();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(20, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(54, 23);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(20, 40);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(160, 30);
            dtpFecha.TabIndex = 1;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // btnHoy
            // 
            btnHoy.BackColor = Color.FromArgb(228, 224, 218);
            btnHoy.Cursor = Cursors.Hand;
            btnHoy.FlatAppearance.BorderSize = 0;
            btnHoy.FlatStyle = FlatStyle.Flat;
            btnHoy.ForeColor = Color.FromArgb(34, 34, 34);
            btnHoy.Location = new Point(195, 38);
            btnHoy.Name = "btnHoy";
            btnHoy.Size = new Size(100, 32);
            btnHoy.TabIndex = 2;
            btnHoy.Text = "Hoy";
            btnHoy.UseVisualStyleBackColor = false;
            btnHoy.Click += btnHoy_Click;
            // 
            // chkSoloPendientes
            // 
            chkSoloPendientes.AutoSize = true;
            chkSoloPendientes.Location = new Point(315, 44);
            chkSoloPendientes.Name = "chkSoloPendientes";
            chkSoloPendientes.Size = new Size(154, 27);
            chkSoloPendientes.TabIndex = 3;
            chkSoloPendientes.Text = "Solo pendientes";
            chkSoloPendientes.UseVisualStyleBackColor = true;
            chkSoloPendientes.CheckedChanged += chkSoloPendientes_CheckedChanged;
            // 
            // dgvAgenda
            // 
            dgvAgenda.AllowUserToAddRows = false;
            dgvAgenda.AllowUserToDeleteRows = false;
            dgvAgenda.AllowUserToResizeRows = false;
            dgvAgenda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAgenda.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvAgenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAgenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAgenda.Columns.AddRange(new DataGridViewColumn[] { colId, colHora, colMascota, colEspecie, colDueno, colMotivo, colTipo, colEstado });
            dgvAgenda.EnableHeadersVisualStyles = false;
            dgvAgenda.Location = new Point(20, 90);
            dgvAgenda.MultiSelect = false;
            dgvAgenda.Name = "dgvAgenda";
            dgvAgenda.ReadOnly = true;
            dgvAgenda.RowHeadersVisible = false;
            dgvAgenda.RowHeadersWidth = 51;
            dgvAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAgenda.Size = new Size(1060, 300);
            dgvAgenda.TabIndex = 4;
            // 
            // colId
            // 
            colId.HeaderText = "Id (oculta)";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colHora
            // 
            colHora.HeaderText = "Hora";
            colHora.MinimumWidth = 6;
            colHora.Name = "colHora";
            colHora.ReadOnly = true;
            // 
            // colMascota
            // 
            colMascota.HeaderText = "Mascota";
            colMascota.MinimumWidth = 6;
            colMascota.Name = "colMascota";
            colMascota.ReadOnly = true;
            // 
            // colEspecie
            // 
            colEspecie.HeaderText = "Especie";
            colEspecie.MinimumWidth = 6;
            colEspecie.Name = "colEspecie";
            colEspecie.ReadOnly = true;
            // 
            // colDueno
            // 
            colDueno.HeaderText = "Dueño";
            colDueno.MinimumWidth = 6;
            colDueno.Name = "colDueno";
            colDueno.ReadOnly = true;
            // 
            // colMotivo
            // 
            colMotivo.HeaderText = "Motivo";
            colMotivo.MinimumWidth = 6;
            colMotivo.Name = "colMotivo";
            colMotivo.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // btnAbrirHistoria
            // 
            btnAbrirHistoria.BackColor = Color.FromArgb(31, 122, 140);
            btnAbrirHistoria.Cursor = Cursors.Hand;
            btnAbrirHistoria.FlatAppearance.BorderSize = 0;
            btnAbrirHistoria.FlatStyle = FlatStyle.Flat;
            btnAbrirHistoria.ForeColor = Color.White;
            btnAbrirHistoria.Location = new Point(20, 405);
            btnAbrirHistoria.Name = "btnAbrirHistoria";
            btnAbrirHistoria.Size = new Size(200, 32);
            btnAbrirHistoria.TabIndex = 5;
            btnAbrirHistoria.Text = "Abrir historia clínica";
            btnAbrirHistoria.UseVisualStyleBackColor = false;
            btnAbrirHistoria.Click += btnAbrirHistoria_Click;
            // 
            // ucAgenda
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 241, 236);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(btnHoy);
            Controls.Add(chkSoloPendientes);
            Controls.Add(dgvAgenda);
            Controls.Add(btnAbrirHistoria);
            Font = new Font("Segoe UI", 10F);
            Name = "ucAgenda";
            Size = new Size(1100, 560);
            Load += ucAgenda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAgenda).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.CheckBox chkSoloPendientes;
        private System.Windows.Forms.DataGridView dgvAgenda;
        private System.Windows.Forms.Button btnAbrirHistoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDueno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}