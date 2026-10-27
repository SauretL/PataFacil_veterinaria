namespace PataFacil
{
    partial class frmRecepcionista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionista));
            pnlCabecera = new Panel();
            btnCerrarSesion = new Button();
            lblTitulo = new Label();
            lblUsuario = new Label();
            tabPrincipal = new TabControl();
            tabClientes = new TabPage();
            ucClientesMascotas1 = new PataFacil.Formularios.Recepcionista.ucClientesMascotas();
            tabTurnos = new TabPage();
            ucTurnos1 = new PataFacil.Formularios.Recepcionista.ucTurnos();
            tabUrgencias = new TabPage();
            ucUrgencias1 = new PataFacil.Formularios.Recepcionista.ucUrgencias();
            tabCobros = new TabPage();
            ucCobros1 = new PataFacil.Formularios.Recepcionista.ucCobros();
            pnlCabecera.SuspendLayout();
            tabPrincipal.SuspendLayout();
            tabClientes.SuspendLayout();
            tabTurnos.SuspendLayout();
            tabUrgencias.SuspendLayout();
            tabCobros.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCabecera
            // 
            pnlCabecera.BackColor = Color.FromArgb(59, 47, 74);
            pnlCabecera.Controls.Add(btnCerrarSesion);
            pnlCabecera.Controls.Add(lblTitulo);
            pnlCabecera.Controls.Add(lblUsuario);
            pnlCabecera.Dock = DockStyle.Top;
            pnlCabecera.Location = new Point(0, 0);
            pnlCabecera.Name = "pnlCabecera";
            pnlCabecera.Size = new Size(1114, 56);
            pnlCabecera.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(950, 12);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(148, 36);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(226, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PataFácil · Recepcionista";
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(775, 20);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(166, 19);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario: Nombre Apellido";
            // 
            // tabPrincipal
            // 
            tabPrincipal.Controls.Add(tabClientes);
            tabPrincipal.Controls.Add(tabTurnos);
            tabPrincipal.Controls.Add(tabUrgencias);
            tabPrincipal.Controls.Add(tabCobros);
            tabPrincipal.Dock = DockStyle.Fill;
            tabPrincipal.Location = new Point(0, 56);
            tabPrincipal.Name = "tabPrincipal";
            tabPrincipal.SelectedIndex = 0;
            tabPrincipal.Size = new Size(1114, 670);
            tabPrincipal.TabIndex = 1;
            // 
            // tabClientes
            // 
            tabClientes.BackColor = Color.FromArgb(244, 241, 236);
            tabClientes.Controls.Add(ucClientesMascotas1);
            tabClientes.Location = new Point(4, 26);
            tabClientes.Name = "tabClientes";
            tabClientes.Padding = new Padding(3);
            tabClientes.Size = new Size(1106, 640);
            tabClientes.TabIndex = 0;
            tabClientes.Text = "Clientes y Mascotas";
            // 
            // ucClientesMascotas1
            // 
            ucClientesMascotas1.BackColor = Color.FromArgb(244, 241, 236);
            ucClientesMascotas1.Dock = DockStyle.Fill;
            ucClientesMascotas1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ucClientesMascotas1.Location = new Point(3, 3);
            ucClientesMascotas1.Name = "ucClientesMascotas1";
            ucClientesMascotas1.Size = new Size(1100, 634);
            ucClientesMascotas1.TabIndex = 0;
            ucClientesMascotas1.Load += ucClientesMascotas1_Load;
            // 
            // tabTurnos
            // 
            tabTurnos.BackColor = Color.FromArgb(244, 241, 236);
            tabTurnos.Controls.Add(ucTurnos1);
            tabTurnos.Location = new Point(4, 24);
            tabTurnos.Name = "tabTurnos";
            tabTurnos.Padding = new Padding(3);
            tabTurnos.Size = new Size(1106, 642);
            tabTurnos.TabIndex = 1;
            tabTurnos.Text = "Turnos";
            // 
            // ucTurnos1
            // 
            ucTurnos1.BackColor = Color.FromArgb(244, 241, 236);
            ucTurnos1.Dock = DockStyle.Fill;
            ucTurnos1.Font = new Font("Segoe UI", 10F);
            ucTurnos1.Location = new Point(3, 3);
            ucTurnos1.Name = "ucTurnos1";
            ucTurnos1.Size = new Size(1100, 636);
            ucTurnos1.TabIndex = 0;
            ucTurnos1.Load += ucTurnos1_Load;
            // 
            // tabUrgencias
            // 
            tabUrgencias.BackColor = Color.FromArgb(244, 241, 236);
            tabUrgencias.Controls.Add(ucUrgencias1);
            tabUrgencias.Location = new Point(4, 26);
            tabUrgencias.Name = "tabUrgencias";
            tabUrgencias.Size = new Size(1106, 640);
            tabUrgencias.TabIndex = 2;
            tabUrgencias.Text = "Urgencias";
            // 
            // ucUrgencias1
            // 
            ucUrgencias1.BackColor = Color.FromArgb(244, 241, 236);
            ucUrgencias1.Dock = DockStyle.Fill;
            ucUrgencias1.Font = new Font("Segoe UI", 10F);
            ucUrgencias1.Location = new Point(0, 0);
            ucUrgencias1.Name = "ucUrgencias1";
            ucUrgencias1.Size = new Size(1106, 640);
            ucUrgencias1.TabIndex = 0;
            // 
            // tabCobros
            // 
            tabCobros.BackColor = Color.FromArgb(244, 241, 236);
            tabCobros.Controls.Add(ucCobros1);
            tabCobros.Location = new Point(4, 24);
            tabCobros.Name = "tabCobros";
            tabCobros.Size = new Size(1106, 642);
            tabCobros.TabIndex = 3;
            tabCobros.Text = "Cobros";
            // 
            // ucCobros1
            // 
            ucCobros1.BackColor = Color.FromArgb(244, 241, 236);
            ucCobros1.Dock = DockStyle.Fill;
            ucCobros1.Font = new Font("Segoe UI", 10F);
            ucCobros1.Location = new Point(0, 0);
            ucCobros1.Name = "ucCobros1";
            ucCobros1.Size = new Size(1106, 642);
            ucCobros1.TabIndex = 0;
            // 
            // frmRecepcionista
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1114, 726);
            Controls.Add(tabPrincipal);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmRecepcionista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pata Fácil - Recepcionista";
            pnlCabecera.ResumeLayout(false);
            pnlCabecera.PerformLayout();
            tabPrincipal.ResumeLayout(false);
            tabClientes.ResumeLayout(false);
            tabTurnos.ResumeLayout(false);
            tabUrgencias.ResumeLayout(false);
            tabCobros.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCabecera;
        private Button btnCerrarSesion;
        private Label lblTitulo;
        private Label lblUsuario;
        private TabControl tabPrincipal;
        private TabPage tabClientes;
        private TabPage tabPage1;
        private TabPage tabTurnos;
        private TabPage tabUrgencias;
        private TabPage tabCobros;
        private Formularios.Recepcionista.ucClientesMascotas ucClientesMascotas1;
        private Formularios.Recepcionista.ucTurnos ucTurnos1;
        private Formularios.Recepcionista.ucUrgencias ucUrgencias1;
        private Formularios.Recepcionista.ucCobros ucCobros1;
    }
}