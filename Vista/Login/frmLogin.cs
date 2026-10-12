
using Modelo.Datos;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Vista.Administrador.Clientes;
using Vista.Conductor;
using Vista.Crear_cuenta;

namespace Vista.Login
{
    public partial class frmLogin : Form
    {
        private int intentosFallidos = 0;
        private DateTime bloqueoHasta = DateTime.MinValue;

        public frmLogin()
        {
            InitializeComponent();

            txtUsuario.KeyDown += BloquearCopiarPegar;
            txtContraseña.KeyDown += BloquearCopiarPegar;

            txtUsuario.MouseDown += BloquearMenuContextual;
            txtContraseña.MouseDown += BloquearMenuContextual;

            this.AcceptButton = btnIniciarSesion;
            txtContraseña.UseSystemPasswordChar = true;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
            this.TopMost = false;
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Verificar si el inicio de sesión está bloqueado
            if (DateTime.Now < bloqueoHasta)
            {
                TimeSpan restante = bloqueoHasta - DateTime.Now;

                MessageBox.Show(
                    $"Demasiados intentos fallidos. Intente nuevamente en " +
                    $"{Math.Ceiling(restante.TotalMinutes)} minuto(s).",
                    "Acceso temporalmente bloqueado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Limpiar errores anteriores
            errorProvider1.Clear();

            string correo = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;

            bool hayErrores = false;

            // VALIDAR CORREO
            if (string.IsNullOrWhiteSpace(correo))
            {
                errorProvider1.SetError(txtUsuario, "El correo electrónico es obligatorio.");

                hayErrores = true;
            }
            else if (!CorreoValido(correo))
            {
                errorProvider1.SetError(txtUsuario, "Ingrese un correo electrónico válido.");
                errorProvider1.SetError(
                    txtUsuario,
                    "Ingrese un correo válido del dominio @mypickup.com."
                );

                hayErrores = true;
            }

            // VALIDAR CONTRASEÑA
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                errorProvider1.SetError(txtContraseña, "La contraseña es obligatoria.");

                hayErrores = true;
            }
            else if (!ContrasenaValida(contraseña))
            {
                errorProvider1.SetError(
                    txtContraseña,
                    "La contraseña solo puede contener letras, números y el carácter *."
                );

                hayErrores = true;
            }

            // DETENER SI HAY ERRORES
            if (hayErrores)
            {
                return;
            }

            // INICIAR SESIÓN
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            Usuario usuario = usuarioDAO.IniciarSesion(txtUsuario.Text.Trim(), txtContraseña.Text);

            if (usuario != null)
            {
                // Reiniciar intentos fallidos
                intentosFallidos = 0;
                bloqueoHasta = DateTime.MinValue;

                string tipoUsuario = usuarioDAO.ObtenerTipoUsuario(usuario.IdUsuario);

                if (tipoUsuario == "Conductor")
                {
                    frmMenu dashboard =
                        new frmMenu(usuario.IdUsuario);

                    dashboard.Show();
                    this.Hide();
                }
                else if (tipoUsuario == "Cliente")
                {
                    Dashboard ventanaCliente = new Dashboard(usuario);

                    ventanaCliente.Show();
                    this.Hide();
                }
                else if (tipoUsuario == "Administrador")
                {
                    MessageBox.Show("Usuario administrador detectado. " + "El menú de administrador se conectará posteriormente.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo determinar el tipo de usuario.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            else
            {
                // Contabilizar intentos fallidos
                intentosFallidos++;

                if (intentosFallidos >= 5)
                {
                    bloqueoHasta = DateTime.Now.AddMinutes(5);

                    MessageBox.Show(
                        "Has superado los 5 intentos fallidos. " +
                        "El inicio de sesión se bloqueará durante 5 minutos.",
                        "Acceso bloqueado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"Correo o contraseña incorrectos. " +
                        $"Intento {intentosFallidos} de 5.",
                        "Inicio de sesión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }




        private bool CorreoValido(string correo)
        {
            string patron = @"^[A-Za-z]+(?:\.[A-Za-z]+)*@mypickup.com$";

            return Regex.IsMatch(
                correo,
                patron,
                RegexOptions.IgnoreCase
            );
        }



        private bool ContrasenaValida(string contrasena)
        {
            return Regex.IsMatch(
                contrasena,
                @"^[A-Za-z0-9*]+$"
            );
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
               "¿Está seguro de que desea salir?",
               "Salir",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar =
                !txtContraseña.UseSystemPasswordChar;

            label3.Text =
                txtContraseña.UseSystemPasswordChar
                ? "Mostrar Contraseña"
                : "Ocultar Contraseña";
        }

        private void BloquearCopiarPegar(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C ||
                              e.KeyCode == Keys.V ||
                              e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            if (e.Shift && e.KeyCode == Keys.Insert)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void BloquearMenuContextual(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmCrearCuenta dashboard = new frmCrearCuenta();
            dashboard.Show();
            this.Hide();
        }
    }
}
