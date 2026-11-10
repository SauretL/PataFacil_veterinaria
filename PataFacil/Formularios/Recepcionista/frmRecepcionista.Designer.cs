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
            pnlCabecera = new Panel();
            btnCerrarSesion = new Button();
            lblTitulo = new Label();
            lblUsuario = new Label();
            tabPrincipal = new TabControl();
            tabClientes = new TabPage();
            tabTurnos = new TabPage();
            tabUrgencias = new TabPage();
            tabCobros = new TabPage();
            ucClientesMascotas1 = new PataFacil.Formularios.Recepcionista.ucClientesMascotas();
            pnlCabecera.SuspendLayout();
            tabPrincipal.SuspendLayout();
            tabClientes.SuspendLayout();
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
            lblTitulo.Location = new Point(22, 16);
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
            tabPrincipal.Size = new Size(1114, 645);
            tabPrincipal.TabIndex = 1;
            // 
            // tabClientes
            // 
            tabClientes.BackColor = Color.FromArgb(244, 241, 236);
            tabClientes.Controls.Add(ucClientesMascotas1);
            tabClientes.Location = new Point(4, 26);
            tabClientes.Name = "tabClientes";
            tabClientes.Padding = new Padding(3);
            tabClientes.Size = new Size(1106, 615);
            tabClientes.TabIndex = 0;
            tabClientes.Text = "Clientes y Mascotas";
            // 
            // tabTurnos
            // 
            tabTurnos.BackColor = Color.FromArgb(244, 241, 236);
            tabTurnos.Location = new Point(4, 26);
            tabTurnos.Name = "tabTurnos";
            tabTurnos.Padding = new Padding(3);
            tabTurnos.Size = new Size(1106, 615);
            tabTurnos.TabIndex = 1;
            tabTurnos.Text = "Turnos";
            // 
            // tabUrgencias
            // 
            tabUrgencias.BackColor = Color.FromArgb(244, 241, 236);
            tabUrgencias.Location = new Point(4, 24);
            tabUrgencias.Name = "tabUrgencias";
            tabUrgencias.Size = new Size(1106, 617);
            tabUrgencias.TabIndex = 2;
            tabUrgencias.Text = "Urgencias";
            // 
            // tabCobros
            // 
            tabCobros.BackColor = Color.FromArgb(244, 241, 236);
            tabCobros.Location = new Point(4, 24);
            tabCobros.Name = "tabCobros";
            tabCobros.Size = new Size(1106, 617);
            tabCobros.TabIndex = 3;
            tabCobros.Text = "Cobros";
            // 
            // ucClientesMascotas1
            // 
            ucClientesMascotas1.BackColor = Color.FromArgb(244, 241, 236);
            ucClientesMascotas1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ucClientesMascotas1.Location = new Point(-2, 0);
            ucClientesMascotas1.Name = "ucClientesMascotas1";
            ucClientesMascotas1.Size = new Size(1108, 612);
            ucClientesMascotas1.TabIndex = 0;
            // 
            // frmRecepcionista
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1114, 701);
            Controls.Add(tabPrincipal);
            Controls.Add(pnlCabecera);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmRecepcionista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pata Fácil - Recepcionista";
            pnlCabecera.ResumeLayout(false);
            pnlCabecera.PerformLayout();
            tabPrincipal.ResumeLayout(false);
            tabClientes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCabecera;
        private Button btnCerrarSesion;
        private Label lblTitulo;
        private Label lblUsuario;
        private TabControl tabPrincipal;
        private TabPage tabClientes;
        private TabPage tabTurnos;
        private TabPage tabUrgencias;
        private TabPage tabCobros;
        private Formularios.Recepcionista.ucClientesMascotas ucClientesMascotas1;
    }
}