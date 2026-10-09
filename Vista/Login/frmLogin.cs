using Modelo.Datos;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Administrador.Clientes;
using Vista.Conductor;

namespace Vista.Login
{
    public partial class frmLogin : Form
    {
        private int idUsuario;
        public frmLogin()
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void pnlInicioS_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Limpiar errores anteriores
            errorProvider1.Clear();

            bool hayErrores = false;

            // =========================
            // VALIDAR USUARIO
            // =========================

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorProvider1.SetError(
                    txtUsuario,
                    "El correo electrónico es obligatorio."
                );

                hayErrores = true;
            }
            else if (!CorreoValido(txtUsuario.Text.Trim()))
            {
                errorProvider1.SetError(
                    txtUsuario,
                    "Ingrese un correo electrónico válido."
                );

                hayErrores = true;
            }

            // =========================
            // VALIDAR CONTRASEÑA
            // =========================

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                errorProvider1.SetError(
                    txtContraseña,
                    "La contraseña es obligatoria."
                );

                hayErrores = true;
            }

            // =========================
            // DETENER SI HAY ERRORES
            // =========================

            if (hayErrores)
            {
                return;
            }

            // =========================
            // INICIAR SESIÓN
            // =========================

            UsuarioDAO usuarioDAO = new UsuarioDAO();

            Usuario usuario = usuarioDAO.IniciarSesion(
                txtUsuario.Text.Trim(),
                txtContraseña.Text
            );

            if (usuario != null)
            {
                UsuarioDAO UsuarioDAO = new UsuarioDAO();

                string tipoUsuario =
                    usuarioDAO.ObtenerTipoUsuario(usuario.IdUsuario);


                if (tipoUsuario == "Conductor")
                {
                    frmMenu menu = new frmMenu(usuario.IdUsuario);
                    menu.Show();
                    this.Hide();
                }
    
                else if (tipoUsuario == "Cliente")
                {
                    Dashboard ventanaCliente = new Dashboard();

                    ventanaCliente.Show();
                    this.Hide();
                }
                else if (tipoUsuario == "Administrador")
                {
                    MessageBox.Show(
                        "Usuario administrador detectado. " +
                        "El menú de administrador se conectará posteriormente.",
                        "Inicio de sesión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
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
                MessageBox.Show(
                    "Usuario o contraseña incorrectos",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private bool CorreoValido(string correo)
        {
            try
            {
                var direccion = new System.Net.Mail.MailAddress(correo);

                return direccion.Address == correo;
            }
            catch
            {
                return false;
            }
        }
    }
}
