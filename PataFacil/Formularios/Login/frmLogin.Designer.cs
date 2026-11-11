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
            txtEmail = new TextBox();
            txtClave = new TextBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.LightSeaGreen;
            lblTitulo.Location = new Point(123, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(191, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PataFácil";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubTitulo
            // 
            lblSubTitulo.AutoSize = true;
            lblSubTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubTitulo.ForeColor = Color.Gray;
            lblSubTitulo.Location = new Point(131, 76);
            lblSubTitulo.Name = "lblSubTitulo";
            lblSubTitulo.Size = new Size(173, 28);
            lblSubTitulo.TabIndex = 1;
            lblSubTitulo.Text = "Clínica Veterinaria";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(173, 144);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(60, 28);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Email";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClave.Location = new Point(149, 252);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(114, 28);
            lblClave.TabIndex = 3;
            lblClave.Text = "Contraseña";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(109, 447);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(48, 176);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(319, 34);
            txtEmail.TabIndex = 5;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 12F);
            txtClave.Location = new Point(48, 284);
            txtClave.Margin = new Padding(3, 4, 3, 4);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(319, 34);
            txtClave.TabIndex = 6;
            txtClave.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.LightSeaGreen;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(48, 377);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(320, 53);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // frmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 561);
            Controls.Add(btnIngresar);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Controls.Add(lblTitulo);
            Controls.Add(lblError);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(lblSubTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
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
        private TextBox txtEmail;
        private TextBox txtClave;
        private Button btnIngresar;
    }
}
