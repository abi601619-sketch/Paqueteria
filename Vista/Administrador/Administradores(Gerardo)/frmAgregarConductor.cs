
using System;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmAgregarConductor : Form
    {
        public event Action ConductorAgregado;

        public frmAgregarConductor()
        {
            InitializeComponent();

            txtCorreo.KeyPress += SoloCorreo_KeyPress;
            txtDui.KeyPress += SoloNumeros_KeyPress;
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;
        }

        // Permitir números y guion en el DUI
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        // Permitir letras y espacios en nombres y apellidos
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // Permitir caracteres habituales de un correo
        private void SoloCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != '@' &&
                e.KeyChar != '.' &&
                e.KeyChar != '_' &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        // Cerrar formulario
        private void ptb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del conductor.");
                txtNombre.Focus();
                return;
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido del conductor.");
                txtApellido.Focus();
                return;
            }

            // Validar que el DUI no esté vacío
            if (string.IsNullOrWhiteSpace(txtDui.Text))
            {
                MessageBox.Show("Debe ingresar el DUI del conductor.");
                txtDui.Focus();
                return;
            }

            // Validar formato del DUI: 00000000-0
            string duiTexto = txtDui.Text.Trim();

            if (!Regex.IsMatch(duiTexto, @"^\d{8}-\d$"))
            {
                MessageBox.Show(
                    "El DUI debe tener el formato 00000000-0.",
                    "DUI inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDui.Focus();
                return;
            }

            // Validar que el correo no esté vacío
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar el correo del conductor.");
                txtCorreo.Focus();
                return;
            }

            // Validar formato del correo y terminación .com
            string correoTexto = txtCorreo.Text.Trim();

            try
            {
                MailAddress correo = new MailAddress(correoTexto);

                if (correo.Address != correoTexto ||
                    !Regex.IsMatch(
                        correoTexto,
                        @"^[^@\s]+@[^@\s]+\.com$"))
                {
                    MessageBox.Show(
                        "Ingrese un correo válido que termine en .com. " +
                        "Ejemplo: usuario@gmail.com",
                        "Correo inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCorreo.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show(
                    "Ingrese un correo válido, por ejemplo: usuario@gmail.com",
                    "Correo inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Debe ingresar la contraseña del conductor.");
                txtContraseña.Focus();
                return;
            }

            // Validar zona
            if (cmbZona.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una zona.");
                cmbZona.Focus();
                return;
            }

            // Validar foto obligatoria
            if (ptbFotoVehiculo.Image == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una foto de perfil para el conductor.",
                    "Foto obligatoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                ptbFotoVehiculo.Focus();
                return;
            }

            try
            {
                Modelo.Entidades.Conductor conductor =
                    new Modelo.Entidades.Conductor();

                conductor.Nombre = txtNombre.Text.Trim();
                conductor.Apellido = txtApellido.Text.Trim();
                conductor.Dui = duiTexto;
                conductor.Correo = correoTexto;
                conductor.Contrasena = txtContraseña.Text;
                conductor.ZonaEncargada = cmbZona.Text;

                // Convertir la foto a byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    ptbFotoVehiculo.Image.Save(
                        ms,
                        System.Drawing.Imaging.ImageFormat.Png);

                    conductor.FotoPerfil = ms.ToArray();
                }

                // Guardar el conductor en la base de datos
                bool agregado = conductor.AgregarConductor();

                if (agregado)
                {
                    MessageBox.Show(
                        "Conductor agregado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Limpiar campos
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtDui.Clear();
                    txtCorreo.Clear();
                    txtContraseña.Clear();

                    cmbZona.SelectedIndex = -1;

                    ptbFotoVehiculo.Image = null;

                    // Avisar al formulario que debe actualizar la lista
                    ConductorAgregado?.Invoke();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo agregar el conductor.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al agregar el conductor:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ptbFotoVehiculo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar foto de perfil";
                dialogo.Filter =
                    "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    using (Image imagenOriginal =
                           Image.FromFile(dialogo.FileName))
                    {
                        ptbFotoVehiculo.Image =
                            new Bitmap(imagenOriginal);
                    }

                    ptbFotoVehiculo.SizeMode =
                        PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
