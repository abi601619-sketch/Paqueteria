using Guna.UI2.WinForms;
using Modelo.Entidades;
using System.Net.Mail;
using Vista.Login;

namespace Vista.Crear_cuenta
{
    public partial class frmCrearCuenta : Form
    {
        private byte[] fotoPerfil = null;
        public frmCrearCuenta()
        {
            InitializeComponent();
        }
        private void frmCrearCuenta_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            ConfigurarTextos();
            ConfigurarLabels();
            ConfigurarCampos();
        }

        //-------------------------------------CONFIGURACIONES-------------------------------------
        private void ConfigurarFormulario()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void ConfigurarTextos()
        {
            lblDui.Text = "DUI (opcional)";
            lblNombre.Text = "Nombre";
            lblApellido.Text = "Apellido";
            lblCorreo.Text = "Correo electrónico";
            lblContrasena.Text = "Contraseña";
            lblConfirmarContrasena.Text = "Confirmar contraseña";

            lblFotoPerfil.Text = "Foto de perfil (opcional)";

            btnCrearCuenta.Text = "Crear Cuenta";

            lblYaTieneCuenta.Text = "¿Ya tienes una cuenta?";
            lnkIniciarSesion.Text = "Iniciar sesión";

            txtDui.PlaceholderText = "Ingresa tu DUI";
            txtNombre.PlaceholderText = "Ingresa tu nombre";
            txtApellido.PlaceholderText = "Ingresa tu apellido";
            txtCorreo.PlaceholderText = "Ingresa tu correo";
            txtContrasena.PlaceholderText = "Crea una contraseña";
            txtConfirmarContrasena.PlaceholderText = "Confirma tu contraseña";
        }

        private void ConfigurarLabels()
        {
            Guna2HtmlLabel[] labels =
            {lblDui,lblNombre,lblApellido,lblCorreo,lblContrasena,lblConfirmarContrasena,lblFotoPerfil};

            foreach (Guna2HtmlLabel label in labels)
            {
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                label.ForeColor = Color.FromArgb(45, 45, 45);

                label.AutoSize = true;
            }



            // Texto inferior
            lblYaTieneCuenta.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            lblYaTieneCuenta.ForeColor = Color.FromArgb(120, 120, 120);

            // Enlace
            lnkIniciarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            lnkIniciarSesion.LinkColor = Color.FromArgb(220, 115, 0);

            lnkIniciarSesion.ActiveLinkColor = Color.FromArgb(180, 85, 0);
        }
        private void ConfigurarCampos()
        {
            Guna.UI2.WinForms.Guna2TextBox[] campos = { txtDui, txtNombre, txtApellido, txtCorreo, txtContrasena, txtConfirmarContrasena };

            foreach (var campo in campos)
            {
                campo.BorderRadius = 6;

                campo.BorderThickness = 1;

                campo.BorderColor = Color.FromArgb(210, 210, 210);

                campo.FillColor = Color.FromArgb(250, 250, 250);

                campo.ForeColor = Color.FromArgb(50, 50, 50);

                campo.Font = new Font("Segoe UI", 9F);

                campo.FocusedState.BorderColor = Color.FromArgb(220, 115, 0);

                campo.HoverState.BorderColor = Color.FromArgb(220, 115, 0);

                campo.PlaceholderForeColor = Color.FromArgb(160, 160, 160);

                campo.Padding = new Padding(10, 0, 10, 0);
            }

            txtContrasena.UseSystemPasswordChar = true;

            txtConfirmarContrasena.UseSystemPasswordChar = true;
        }
        //-------------------------------------FIN DE CONFIGURACIONES-------------------------------------  
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog abrirImagen = new OpenFileDialog())
            {
                abrirImagen.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                abrirImagen.Title = "Seleccionar foto de perfil";

                if (abrirImagen.ShowDialog() == DialogResult.OK)
                {
                    // Mostrar imagen
                    picFotoPerfil.Image = Image.FromFile(abrirImagen.FileName);

                    // Convertir imagen a bytes
                    fotoPerfil = File.ReadAllBytes(abrirImagen.FileName);

                    lblFotoPerfil.Text = "Imagen seleccionada";
                }
            }
        }

        // Validar correo electrónico

        private bool CorreoValido(string correo)
        {
            try
            {
                MailAddress mail = new MailAddress(correo);

                return mail.Address == correo;
            }
            catch
            {
                return false;
            }
        }
        // Validar formulario
        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa tu nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingresa tu apellido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingresa tu correo electrónico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            if (!CorreoValido(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Ingresa un correo electrónico válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Ingresa una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtContrasena.Focus();
                return false;
            }

            if (txtContrasena.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtContrasena.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                MessageBox.Show("Confirma tu contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtConfirmarContrasena.Focus();
                return false;
            }

            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtConfirmarContrasena.Focus();
                return false;
            }

            return true;
        }
        // Crear cuenta
        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                    return;

                string dui = txtDui.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string correo = txtCorreo.Text.Trim().ToLower();

                // Encriptar contraseña
                string contrasenaHash = BCrypt.Net.BCrypt.HashPassword(txtContrasena.Text);

                Usuario usuario = new Usuario();

                bool registrado = usuario.RegistrarCliente(dui, nombre, apellido, correo, contrasenaHash, fotoPerfil);

                if (registrado)
                {
                    MessageBox.Show("Cuenta creada correctamente. ¡Bienvenido a MyPickup!", "Cuenta creada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();

                    // Aquí posteriormente podemos abrir el Login
                    // this.Hide();
                    // FrmLogin login = new FrmLogin();
                    // login.Show();
                }
                else
                {
                    MessageBox.Show("El correo electrónico ya está registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtCorreo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al crear la cuenta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtDui.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();

            picFotoPerfil.Image = null;

            fotoPerfil = null;

            lblFotoPerfil.Text = "Foto de perfil (opcional)";
        }
        // Mostrar u ocultar contraseña
        private void btnMostrarContrasena_Click(object sender, EventArgs e)
        {
            txtConfirmarContrasena.UseSystemPasswordChar = !txtConfirmarContrasena.UseSystemPasswordChar;

        }

        private void btnMostrarcontrasena1_Click(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !txtContrasena.UseSystemPasswordChar;
        }
        // Enlace para iniciar sesión
        private void lnkIniciarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin login = new frmLogin();

            login.Show();

            this.Hide();
        }
        // Salir de la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Validar que solo se ingresen números en el campo DUI
        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control, como Backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Solo permitir números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // Formatear el DUI mientras se escribe
        private void txtDui_TextChanged(object sender, EventArgs e)
        {

            string dui = txtDui.Text.Replace("-", "");

            // Máximo 9 números
            if (dui.Length > 9)
            {
                dui = dui.Substring(0, 9);
            }

            // Evitar modificar innecesariamente el texto
            string formato;

            if (dui.Length > 8)
            {
                formato = dui.Substring(0, 8) + "-" + dui.Substring(8);
            }
            else
            {
                formato = dui;
            }

            if (txtDui.Text != formato)
            {
                int posicion = formato.Length;

                txtDui.Text = formato;
                txtDui.SelectionStart = posicion;
            }
        }
    }
}



