namespace PataFacil
// Hice el codigo bastante basico, si ven algo que tengan que cambiar haganlo tranquilos,
// aunque creo que funciona bien, abre los formularios correspondientes segun el usuario
// y muestra un mensaje de error si el usuario o la contraseña son incorrectos.
{
    public partial class frmLogin : Form
    {
        // Usuarios de prueba: usuario -> (clave, rol)
        private readonly Dictionary<string, (string Clave, string Rol)> usuarios = new()
        {
            ["recepcion"] = ("1234", "Recepcionista"),
            ["vet"] = ("1234", "Veterinario"),
            ["aux"] = ("1234", "Auxiliar")
        };

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim().ToLower();
            string clave = txtClave.Text;

            if (usuarios.TryGetValue(user, out var datos) && datos.Clave == clave)
            {
                Form destino = datos.Rol switch
                {
                    "Recepcionista" => new frmRecepcionista(),
                    "Veterinario" => new frmVeterinario(),
                    _ => new frmAuxiliar()
                };

                destino.FormClosed += (s, args) => this.Close();
                this.Hide();
                destino.Show();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos";
                txtClave.Clear();
                txtClave.Focus();
            }
        }
    }
}
