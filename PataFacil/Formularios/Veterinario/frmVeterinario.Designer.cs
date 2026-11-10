namespace PataFacil
{
    partial class frmVeterinario
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
            pnlCabecera = new Panel();
            btnCerrarSesion = new Button();
            lblUsuario = new Label();
            lblTitulo = new Label();
            tabPrincipal = new TabControl();
            tabAgenda = new TabPage();
            ucAgenda1 = new ucAgenda();
            tabHistoria = new TabPage();
            ucHistoriaClinica1 = new ucHistoriaClinica();
            pnlCabecera.SuspendLayout();
            tabPrincipal.SuspendLayout();
            tabAgenda.SuspendLayout();
            tabHistoria.SuspendLayout();
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
            pnlCabecera.TabIndex = 1;
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
            lblTitulo.Size = new Size(204, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PataFácil · Veterinario";
            // 
            // tabPrincipal
            // 
            tabPrincipal.Controls.Add(tabAgenda);
            tabPrincipal.Controls.Add(tabHistoria);
            tabPrincipal.Dock = DockStyle.Fill;
            tabPrincipal.Location = new Point(0, 56);
            tabPrincipal.Name = "tabPrincipal";
            tabPrincipal.SelectedIndex = 0;
            tabPrincipal.Size = new Size(1084, 585);
            tabPrincipal.TabIndex = 0;
            // 
            // tabAgenda
            // 
            tabAgenda.BackColor = Color.FromArgb(244, 241, 236);
            tabAgenda.Controls.Add(ucAgenda1);
            tabAgenda.Location = new Point(4, 26);
            tabAgenda.Name = "tabAgenda";
            tabAgenda.Padding = new Padding(3);
            tabAgenda.Size = new Size(1076, 555);
            tabAgenda.TabIndex = 0;
            tabAgenda.Text = "Agenda";
            // 
            // ucAgenda1
            // 
            ucAgenda1.BackColor = Color.FromArgb(244, 241, 236);
            ucAgenda1.Dock = DockStyle.Fill;
            ucAgenda1.Font = new Font("Segoe UI", 10F);
            ucAgenda1.Location = new Point(3, 3);
            ucAgenda1.Name = "ucAgenda1";
            ucAgenda1.Size = new Size(1070, 549);
            ucAgenda1.TabIndex = 0;
            // 
            // tabHistoria
            // 
            tabHistoria.BackColor = Color.FromArgb(244, 241, 236);
            tabHistoria.Controls.Add(ucHistoriaClinica1);
            tabHistoria.Location = new Point(4, 26);
            tabHistoria.Name = "tabHistoria";
            tabHistoria.Padding = new Padding(3);
            tabHistoria.Size = new Size(1076, 555);
            tabHistoria.TabIndex = 1;
            tabHistoria.Text = "Historia clínica";
            // 
            // ucHistoriaClinica1
            // 
            ucHistoriaClinica1.BackColor = Color.FromArgb(244, 241, 236);
            ucHistoriaClinica1.Dock = DockStyle.Fill;
            ucHistoriaClinica1.Font = new Font("Segoe UI", 10F);
            ucHistoriaClinica1.Location = new Point(3, 3);
            ucHistoriaClinica1.Name = "ucHistoriaClinica1";
            ucHistoriaClinica1.Size = new Size(1070, 549);
            ucHistoriaClinica1.TabIndex = 0;
            // 
            // frmVeterinario
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 241, 236);
            ClientSize = new Size(1084, 641);
            Controls.Add(tabPrincipal);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmVeterinario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PataFácil - Veterinario";
            pnlCabecera.ResumeLayout(false);
            pnlCabecera.PerformLayout();
            tabPrincipal.ResumeLayout(false);
            tabAgenda.ResumeLayout(false);
            tabHistoria.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabAgenda;
        private System.Windows.Forms.TabPage tabHistoria;
        private PataFacil.ucAgenda ucAgenda1;
        private PataFacil.ucHistoriaClinica ucHistoriaClinica1;
    }
}