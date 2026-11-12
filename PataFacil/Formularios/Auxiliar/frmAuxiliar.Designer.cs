namespace PataFacil
{
    partial class frmAuxiliar
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlCabecera = new Panel();
            btnCerrarSesion = new Button();
            lblUsuario = new Label();
            lblTitulo = new Label();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblFiltroCategoria = new Label();
            cmbFiltroCategoria = new ComboBox();
            chkSoloBajoMinimo = new CheckBox();
            btnBuscar = new Button();
            dgvProductos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            lblAlerta = new Label();
            grpProducto = new GroupBox();
            lblNombre = new Label();
            txtNombreProducto = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblStockMinimo = new Label();
            nudStockMinimo = new NumericUpDown();
            lblStockActual = new Label();
            btnGuardarProducto = new Button();
            btnNuevo = new Button();
            btnIngreso = new Button();
            btnEgreso = new Button();
            btnNotificar = new Button();
            pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            SuspendLayout();
            // 
            // pnlCabecera
            // 
            pnlCabecera.BackColor = Color.FromArgb(59, 47, 74);
            pnlCabecera.Controls.Add(btnCerrarSesion);
            pnlCabecera.Controls.Add(lblUsuario);
            pnlCabecera.Controls.Add(lblTitulo);
            pnlCabecera.Dock = DockStyle.Top;
            pnlCabecera.Location = new Point(0, 0);
            pnlCabecera.Name = "pnlCabecera";
            pnlCabecera.Size = new Size(1084, 56);
            pnlCabecera.TabIndex = 99;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.FromArgb(228, 224, 218);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.ForeColor = Color.FromArgb(34, 34, 34);
            btnCerrarSesion.Location = new Point(944, 12);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(120, 32);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(740, 18);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(166, 19);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario: Nombre Apellido";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(174, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PataFácil · Auxiliar";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 62);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(186, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar producto por nombre";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(20, 86);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(240, 25);
            txtBuscar.TabIndex = 1;
            // 
            // lblFiltroCategoria
            // 
            lblFiltroCategoria.AutoSize = true;
            lblFiltroCategoria.Location = new Point(275, 62);
            lblFiltroCategoria.Name = "lblFiltroCategoria";
            lblFiltroCategoria.Size = new Size(68, 19);
            lblFiltroCategoria.TabIndex = 2;
            lblFiltroCategoria.Text = "Categoría";
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Items.AddRange(new object[] { "Todas", "Vacunas", "Medicamentos", "Alimentos", "Insumos", "Otros" });
            cmbFiltroCategoria.Location = new Point(275, 86);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(140, 25);
            cmbFiltroCategoria.TabIndex = 3;
            // 
            // chkSoloBajoMinimo
            // 
            chkSoloBajoMinimo.AutoSize = true;
            chkSoloBajoMinimo.Location = new Point(430, 90);
            chkSoloBajoMinimo.Name = "chkSoloBajoMinimo";
            chkSoloBajoMinimo.Size = new Size(184, 23);
            chkSoloBajoMinimo.TabIndex = 4;
            chkSoloBajoMinimo.Text = "Solo stock bajo el mínimo";
            chkSoloBajoMinimo.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(228, 224, 218);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.FromArgb(34, 34, 34);
            btnBuscar.Location = new Point(620, 84);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 32);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(228, 224, 218);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colId, colProducto, colCategoria, colStockActual, colStockMinimo, colEstado });
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.Location = new Point(20, 140);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(690, 300);
            dgvProductos.TabIndex = 6;
            // 
            // colId
            // 
            colId.HeaderText = "Id (oculta)";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colProducto
            // 
            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            // 
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoría";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            // 
            // colStockActual
            // 
            colStockActual.HeaderText = "Stock actual";
            colStockActual.Name = "colStockActual";
            colStockActual.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            colStockMinimo.HeaderText = "Stock mínimo";
            colStockMinimo.Name = "colStockMinimo";
            colStockMinimo.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // lblAlerta
            // 
            lblAlerta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAlerta.ForeColor = Color.FromArgb(181, 69, 47);
            lblAlerta.Location = new Point(20, 452);
            lblAlerta.Name = "lblAlerta";
            lblAlerta.Size = new Size(690, 30);
            lblAlerta.TabIndex = 7;
            lblAlerta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpProducto
            // 
            grpProducto.Controls.Add(lblNombre);
            grpProducto.Controls.Add(txtNombreProducto);
            grpProducto.Controls.Add(lblCategoria);
            grpProducto.Controls.Add(cmbCategoria);
            grpProducto.Controls.Add(lblStockMinimo);
            grpProducto.Controls.Add(nudStockMinimo);
            grpProducto.Controls.Add(lblStockActual);
            grpProducto.Location = new Point(740, 132);
            grpProducto.Name = "grpProducto";
            grpProducto.Size = new Size(340, 310);
            grpProducto.TabIndex = 8;
            grpProducto.TabStop = false;
            grpProducto.Text = "Datos del producto";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(69, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre *";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(15, 54);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(310, 25);
            txtNombreProducto.TabIndex = 1;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(15, 94);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(78, 19);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "Categoría *";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "Vacunas", "Medicamentos", "Alimentos", "Insumos", "Otros" });
            cmbCategoria.Location = new Point(15, 118);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(310, 25);
            cmbCategoria.TabIndex = 3;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(15, 158);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(102, 19);
            lblStockMinimo.TabIndex = 4;
            lblStockMinimo.Text = "Stock mínimo *";
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.Location = new Point(15, 182);
            nudStockMinimo.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(150, 25);
            nudStockMinimo.TabIndex = 5;
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(15, 232);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(97, 19);
            lblStockActual.TabIndex = 6;
            lblStockActual.Text = "Stock actual: 0";
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(31, 122, 140);
            btnGuardarProducto.Cursor = Cursors.Hand;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(740, 466);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(150, 32);
            btnGuardarProducto.TabIndex = 9;
            btnGuardarProducto.Text = "Guardar producto";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(228, 224, 218);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.FromArgb(34, 34, 34);
            btnNuevo.Location = new Point(900, 466);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(150, 32);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Producto Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnIngreso
            // 
            btnIngreso.BackColor = Color.FromArgb(228, 224, 218);
            btnIngreso.Cursor = Cursors.Hand;
            btnIngreso.FlatAppearance.BorderSize = 0;
            btnIngreso.FlatStyle = FlatStyle.Flat;
            btnIngreso.ForeColor = Color.FromArgb(34, 34, 34);
            btnIngreso.Location = new Point(740, 511);
            btnIngreso.Name = "btnIngreso";
            btnIngreso.Size = new Size(150, 32);
            btnIngreso.TabIndex = 11;
            btnIngreso.Text = "Registrar ingreso";
            btnIngreso.UseVisualStyleBackColor = false;
            // 
            // btnEgreso
            // 
            btnEgreso.BackColor = Color.FromArgb(228, 224, 218);
            btnEgreso.Cursor = Cursors.Hand;
            btnEgreso.FlatAppearance.BorderSize = 0;
            btnEgreso.FlatStyle = FlatStyle.Flat;
            btnEgreso.ForeColor = Color.FromArgb(34, 34, 34);
            btnEgreso.Location = new Point(900, 511);
            btnEgreso.Name = "btnEgreso";
            btnEgreso.Size = new Size(150, 32);
            btnEgreso.TabIndex = 12;
            btnEgreso.Text = "Registrar egreso";
            btnEgreso.UseVisualStyleBackColor = false;
            // 
            // btnNotificar
            // 
            btnNotificar.BackColor = Color.FromArgb(228, 224, 218);
            btnNotificar.Cursor = Cursors.Hand;
            btnNotificar.FlatAppearance.BorderSize = 0;
            btnNotificar.FlatStyle = FlatStyle.Flat;
            btnNotificar.ForeColor = Color.FromArgb(34, 34, 34);
            btnNotificar.Location = new Point(740, 556);
            btnNotificar.Name = "btnNotificar";
            btnNotificar.Size = new Size(200, 32);
            btnNotificar.TabIndex = 13;
            btnNotificar.Text = "Notificar reposición";
            btnNotificar.UseVisualStyleBackColor = false;
            // 
            // frmAuxiliar
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 241, 236);
            ClientSize = new Size(1084, 641);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblFiltroCategoria);
            Controls.Add(cmbFiltroCategoria);
            Controls.Add(chkSoloBajoMinimo);
            Controls.Add(btnBuscar);
            Controls.Add(dgvProductos);
            Controls.Add(lblAlerta);
            Controls.Add(grpProducto);
            Controls.Add(btnGuardarProducto);
            Controls.Add(btnNuevo);
            Controls.Add(btnIngreso);
            Controls.Add(btnEgreso);
            Controls.Add(btnNotificar);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAuxiliar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PataFácil - Auxiliar";
            pnlCabecera.ResumeLayout(false);
            pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            grpProducto.ResumeLayout(false);
            grpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroCategoria;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.CheckBox chkSoloBajoMinimo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.GroupBox grpProducto;
        private System.Windows.Forms.Button btnGuardarProducto;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnEgreso;
        private System.Windows.Forms.Button btnNotificar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.NumericUpDown nudStockMinimo;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}