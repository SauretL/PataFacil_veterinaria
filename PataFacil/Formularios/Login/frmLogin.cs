using PataFacil.Datos;
using PataFacil.Clases;
namespace PataFacil

{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // .Text es lo que escribió la persona. Trim() borra espacios al principio y al final.
            string email = txtEmail.Text.Trim();
            string contrasena = txtClave.Text;

            // --- VALIDAR QUE NO ESTÉN VACÍOS ---
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

            // try/catch: si algo falla (por ejemplo, la base no responde), no se cierra el programa
            // con un error feo: se va al "catch" y se muestra un mensaje.
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
                // Llegó hasta acá: los datos son correctos. Se guarda quién entró.
                Sesion.Email = email;
                Sesion.Nombre = dal.ObtenerNombre(email);

                // Según el rol, se abre un formulario distinto.
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
        // Abre el formulario que recibe, oculta el login, y decide qué hacer cuando ese
        // formulario se cierre.
        private void AbrirFormulario(Form formulario)
        {
            formulario.FormClosed += (s, args) =>
            {
                if (Sesion.Email == "")
                {
                    // cerró sesión: vuelve el login
                    txtEmail.Clear();
                    txtClave.Clear();
                    this.Show();
                    txtEmail.Focus();
                }
                else
                {
                    // cerró con la X: se termina el programa
                    Application.Exit();
                }
            };
            formulario.Show();
            this.Hide();
        }
    }
}
