using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using Modelo.Datos;
using Modelo.Entidades;
using System.Data;
using Vista.Administrador.Clientes;
using Vista.Conductor;


namespace Vista.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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
                    frmDashboardConductor dashboard =
                        new frmDashboardConductor(usuario.IdUsuario);

                    dashboard.Show();
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

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
      "Se convertirán las contraseñas actuales de Usuarios " +
      "a hashes BCrypt.\n\n" +
      "Haz una copia de seguridad antes de continuar.\n\n" +
      "¿Deseas continuar?",
      "Proteger contraseñas",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Warning
  );

            if (respuesta != DialogResult.Yes)
                return;

            int procesadas = 0;
            int omitidas = 0;

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    using (SqlTransaction transaccion =
                           conexion.BeginTransaction())
                    {
                        try
                        {
                            var usuarios =
                                new List<(int id, string contrasena)>();

                            using (SqlCommand comando = new SqlCommand(
                                @"SELECT idUsuario, contrasena
                          FROM Usuarios",
                                conexion, transaccion))
                            using (SqlDataReader reader =
                                   comando.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.IsDBNull(1))
                                    {
                                        throw new Exception(
                                            "Existe un usuario sin contraseña. " +
                                            "Se canceló la operación."
                                        );
                                    }

                                    usuarios.Add((
                                        reader.GetInt32(0),
                                        reader.GetString(1)
                                    ));
                                }
                            }

                            foreach (var usuario in usuarios)
                            {
                                string contrasena = usuario.contrasena;

                                // Evitar volver a hashear contraseñas BCrypt.
                                if (contrasena.StartsWith("$2a$") ||
                                    contrasena.StartsWith("$2b$") ||
                                    contrasena.StartsWith("$2y$"))
                                {
                                    omitidas++;
                                    continue;
                                }

                                string hash =
                                    BCrypt.Net.BCrypt.HashPassword(
                                        contrasena
                                    );

                                using (SqlCommand actualizar =
                                       new SqlCommand(
                                           @"UPDATE Usuarios
                                     SET contrasena = @hash
                                     WHERE idUsuario = @id",
                                           conexion, transaccion))
                                {
                                    actualizar.Parameters.Add(
                                        "@hash",
                                        SqlDbType.VarChar,
                                        100
                                    ).Value = hash;

                                    actualizar.Parameters.Add(
                                        "@id",
                                        SqlDbType.Int
                                    ).Value = usuario.id;

                                    if (actualizar.ExecuteNonQuery() != 1)
                                    {
                                        throw new Exception(
                                            "No se pudo actualizar el usuario ID " +
                                            usuario.id
                                        );
                                    }
                                }

                                procesadas++;
                            }

                            transaccion.Commit();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Proceso completado.\n\n" +
                    "Contraseñas convertidas: " + procesadas + "\n" +
                    "Hashes ya existentes omitidos: " + omitidas,
                    "BCrypt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron procesar las contraseñas:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
