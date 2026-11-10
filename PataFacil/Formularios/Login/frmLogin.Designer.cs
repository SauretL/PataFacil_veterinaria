namespace PataFacil
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblTitulo = new Label();
            lblSubTitulo = new Label();
            lblUsuario = new Label();
            lblClave = new Label();
            lblError = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.LightSeaGreen;
            lblTitulo.Location = new Point(108, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(152, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PataFácil";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubTitulo
            // 
            lblSubTitulo.AutoSize = true;
            lblSubTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubTitulo.ForeColor = Color.Gray;
            lblSubTitulo.Location = new Point(115, 57);
            lblSubTitulo.Name = "lblSubTitulo";
            lblSubTitulo.Size = new Size(139, 21);
            lblSubTitulo.TabIndex = 1;
            lblSubTitulo.Text = "Clínica Veterinaria";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(144, 108);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(65, 21);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClave.Location = new Point(130, 189);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(92, 21);
            lblClave.TabIndex = 3;
            lblClave.Text = "Contraseña";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(95, 335);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 4;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.Location = new Point(42, 132);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(280, 29);
            txtUsuario.TabIndex = 5;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 12F);
            txtClave.Location = new Point(42, 213);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(280, 29);
            txtClave.TabIndex = 6;
            txtClave.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightSeaGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(42, 283);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(280, 40);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // frmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 421);
            Controls.Add(btnIngresar);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(lblTitulo);
            Controls.Add(lblError);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(lblSubTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login PataFacíl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubTitulo;
        private Label lblUsuario;
        private Label lblClave;
        private Label lblError;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnIngresar;
    }
}
