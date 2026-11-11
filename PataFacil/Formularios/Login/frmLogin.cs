using PataFacil.Datos;
namespace PataFacil
// Hice el codigo bastante basico, si ven algo que tengan que cambiar haganlo tranquilos,
// aunque creo que funciona bien, abre los formularios correspondientes segun el usuario
// y muestra un mensaje de error si el usuario o la contraseña son incorrectos.
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contrasena = txtClave.Text;

            if (email == "")
            {
                MessageBox.Show("Completá el campo Email.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (contrasena == "")
            {
                MessageBox.Show("Completá el campo Contraseña.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            try
            {
                Dal dal = new Dal();
                string? rol = dal.ObtenerRol(email, contrasena);

                if (rol == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                switch (rol)
                {
                    case "Veterinario":
                        AbrirFormulario(new frmVeterinario());
                        break;
                    case "Recepcionista":
                        AbrirFormulario(new frmRecepcionista());
                        break;
                    case "Auxiliar":
                        AbrirFormulario(new frmAuxiliar());
                        break;
                    default:
                        MessageBox.Show("Ese rol todavía no tiene formulario.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }

        }
        private void AbrirFormulario(Form formulario)
        {
            formulario.FormClosed += (s, args) => Application.Exit();
            formulario.Show();
            this.Hide();
        }
    }
}
