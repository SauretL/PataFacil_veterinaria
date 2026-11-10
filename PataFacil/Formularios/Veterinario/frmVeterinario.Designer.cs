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
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabAgenda = new System.Windows.Forms.TabPage();
            this.tabHistoria = new System.Windows.Forms.TabPage();
            this.ucAgenda1 = new PataFacil.ucAgenda();
            this.ucHistoriaClinica1 = new PataFacil.ucHistoriaClinica();
            this.pnlCabecera.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabAgenda.SuspendLayout();
            this.tabHistoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(47)))), ((int)(((byte)(74)))));
            this.pnlCabecera.Controls.Add(this.btnCerrarSesion);
            this.pnlCabecera.Controls.Add(this.lblUsuario);
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1084, 56);
            this.pnlCabecera.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "PataF\u00e1cil \u00b7 Veterinario";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(740, 18);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(192, 23);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario: Nombre Apellido";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnCerrarSesion.Location = new System.Drawing.Point(944, 12);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 32);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar sesi\u00f3n";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabAgenda);
            this.tabPrincipal.Controls.Add(this.tabHistoria);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 56);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1084, 585);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabAgenda
            // 
            this.tabAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(236)))));
            this.tabAgenda.Controls.Add(this.ucAgenda1);
            this.tabAgenda.Location = new System.Drawing.Point(4, 32);
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgenda.Size = new System.Drawing.Size(1076, 549);
            this.tabAgenda.TabIndex = 0;
            this.tabAgenda.Text = "Agenda";
            // 
            // tabHistoria
            // 
            this.tabHistoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(236)))));
            this.tabHistoria.Controls.Add(this.ucHistoriaClinica1);
            this.tabHistoria.Location = new System.Drawing.Point(4, 32);
            this.tabHistoria.Name = "tabHistoria";
            this.tabHistoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistoria.Size = new System.Drawing.Size(1076, 549);
            this.tabHistoria.TabIndex = 1;
            this.tabHistoria.Text = "Historia cl\u00ednica";
            // 
            // ucAgenda1
            // 
            this.ucAgenda1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAgenda1.Location = new System.Drawing.Point(3, 3);
            this.ucAgenda1.Name = "ucAgenda1";
            this.ucAgenda1.Size = new System.Drawing.Size(1070, 543);
            this.ucAgenda1.TabIndex = 0;
            // 
            // ucHistoriaClinica1
            // 
            this.ucHistoriaClinica1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHistoriaClinica1.Location = new System.Drawing.Point(3, 3);
            this.ucHistoriaClinica1.Name = "ucHistoriaClinica1";
            this.ucHistoriaClinica1.Size = new System.Drawing.Size(1070, 543);
            this.ucHistoriaClinica1.TabIndex = 0;
            // 
            // frmVeterinario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1084, 641);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.pnlCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmVeterinario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PataF\u00e1cil - Veterinario";
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.tabAgenda.ResumeLayout(false);
            this.tabHistoria.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

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