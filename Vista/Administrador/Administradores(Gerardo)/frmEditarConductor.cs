using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Conductor = Modelo.Entidades.Conductor;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmEditarConductor : Form
    {
        private Modelo.Entidades.Conductor conductorActual;
        public event Action ConductorEliminado;

        public event Action ConductorActualizado;
        public frmEditarConductor(Modelo.Entidades.Conductor conductor)
        {
            InitializeComponent();

            conductorActual = conductor;

            txtCorreo.KeyPress += SoloCorreo_KeyPress;
            txtDui.KeyPress += SoloNumeros_KeyPress;
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;

            CargarDatosConductor();
        }

        private void CargarDatosConductor()
        {
            txtNombre.Text = conductorActual.Nombre;
            txtApellido.Text = conductorActual.Apellido;
            txtDui.Text = conductorActual.Dui;
            txtCorreo.Text = conductorActual.Correo;
            txtContraseña.Text = conductorActual.Contrasena;

            cmbZona.Text = conductorActual.ZonaEncargada;

            if (conductorActual.FotoPerfil != null &&
                conductorActual.FotoPerfil.Length > 0)
            {
                using (MemoryStream ms =
                    new MemoryStream(conductorActual.FotoPerfil))
                using (Image imagen = Image.FromStream(ms))
                {
                    ptbFotoVehiculo.Image = new Bitmap(imagen);
                }

                ptbFotoVehiculo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

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

        private void ptb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
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

            // Validar DUI
            string duiTexto = txtDui.Text.Trim();

            if (!Regex.IsMatch(duiTexto, @"^\d{8}-\d$"))
            {
                MessageBox.Show("El DUI debe tener el formato 00000000-0.");
                txtDui.Focus();
                return;
            }

            // Validar correo
            string correoTexto = txtCorreo.Text.Trim();

            try
            {
                MailAddress correo = new MailAddress(correoTexto);

                if (correo.Address != correoTexto ||
                    !Regex.IsMatch(correoTexto, @"^[^@\s]+@[^@\s]+\.com$"))
                {
                    MessageBox.Show(
                        "Ingrese un correo válido que termine en .com.");

                    txtCorreo.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show(
                    "Ingrese un correo válido, por ejemplo: usuario@gmail.com");

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

            // La foto es obligatoria
            if (ptbFotoVehiculo.Image == null)
            {
                MessageBox.Show("Debe seleccionar una foto de perfil.");
                ptbFotoVehiculo.Focus();
                return;
            }

            try
            {
                // Actualizar los datos del conductor seleccionado.
                conductorActual.Nombre = txtNombre.Text.Trim();
                conductorActual.Apellido = txtApellido.Text.Trim();
                conductorActual.Dui = duiTexto;
                conductorActual.Correo = correoTexto;
                conductorActual.Contrasena = txtContraseña.Text;
                conductorActual.ZonaEncargada = cmbZona.Text;

                // Guardar la foto actual, sea nueva o la original.
                using (MemoryStream ms = new MemoryStream())
                {
                    ptbFotoVehiculo.Image.Save(
                        ms,
                        System.Drawing.Imaging.ImageFormat.Png);

                    conductorActual.FotoPerfil = ms.ToArray();
                }

                bool actualizado = conductorActual.ActualizarConductor();

                if (actualizado)
                {
                    MessageBox.Show(
                        "Conductor actualizado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ConductorActualizado?.Invoke();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo actualizar el conductor.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al actualizar el conductor:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ptbFotoPerfil_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar foto de perfil";
                dialogo.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    using (Image imagenOriginal = Image.FromFile(dialogo.FileName))
                    {
                        Image imagenAnterior = ptbFotoVehiculo.Image;
                        ptbFotoVehiculo.Image = new Bitmap(imagenOriginal);

                        if (imagenAnterior != null)
                            imagenAnterior.Dispose();
                    }

                    ptbFotoVehiculo.SizeMode = PictureBoxSizeMode.Zoom;
                }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
       "¿Estás seguro de que deseas eliminar al conductor " +
       conductorActual.Nombre + " " + conductorActual.Apellido +
       "?\n\nTambién se eliminarán sus asignaciones de rutas y vehículos.",
       "Confirmar eliminación",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning
   );

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool eliminado = conductorActual.EliminarConductor();

                if (eliminado)
                {
                    MessageBox.Show(
                        "El conductor se eliminó correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ConductorEliminado?.Invoke();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo eliminar el conductor.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al eliminar el conductor:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
