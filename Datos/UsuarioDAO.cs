using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using Modelo.Entidades;

namespace Modelo.Datos
{
    public class UsuarioDAO
    {
        public Usuario IniciarSesion(string correo, string contrasena)
        {
            Usuario usuario = null;

            string consulta = @"SELECT
            idUsuario,
            dui,
            nombre,
            apellido,
            correo,
            contrasena,
            fotoPerfil
        FROM Usuarios
        WHERE correo = @correo";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@correo", correo);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashContrasena = reader["contrasena"].ToString();

                            // Verificar contraseña con BCrypt
                            if (BCrypt.Net.BCrypt.Verify(contrasena, hashContrasena))
                            {
                                usuario = new Usuario();

                                usuario.IdUsuario = Convert.ToInt32(reader["idUsuario"]);

                                usuario.Dui = reader["dui"].ToString();

                                usuario.Nombre = reader["nombre"].ToString();

                                usuario.Apellido = reader["apellido"].ToString();

                                usuario.Correo = reader["correo"].ToString();

                                if (reader["fotoPerfil"] != DBNull.Value)
                                {
                                    usuario.FotoPerfil = (byte[])reader["fotoPerfil"];
                                }
                            }
                        }
                    }
                }
            }

            return usuario;
        }

        public string ObtenerTipoUsuario(int idUsuario)
        {
            string tipoUsuario = "";

            string consulta = @"SELECT CASE
                WHEN EXISTS (
                    SELECT 1
                    FROM Administradores
                    WHERE idUsuario = @idUsuario
                ) THEN 'Administrador'

                WHEN EXISTS (
                    SELECT 1
                    FROM Clientes
                    WHERE idUsuario = @idUsuario
                ) THEN 'Cliente'

                WHEN EXISTS (
                    SELECT 1
                    FROM Conductores
                    WHERE idUsuario = @idUsuario
                ) THEN 'Conductor'

                ELSE 'Desconocido'
            END";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    tipoUsuario = comando.ExecuteScalar().ToString();
                }
            }

            return tipoUsuario;
        }

        public Usuario ObtenerUsuario(int idUsuario)
        {
            Usuario usuario = null;

            string consulta = @"SELECT
            idUsuario,
            dui,
            nombre,
            apellido,
            correo,
            contrasena,
            fotoPerfil FROM Usuarios WHERE idUsuario = @idUsuario";

            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario();

                        usuario.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
                        usuario.Dui = reader["dui"].ToString();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Apellido = reader["apellido"].ToString();
                        usuario.Correo = reader["correo"].ToString();

                        if (reader["fotoPerfil"] != DBNull.Value)
                        {
                            usuario.FotoPerfil = (byte[])reader["fotoPerfil"];
                        }
                    }
                }
            }

            return usuario;
        }
    }
}
