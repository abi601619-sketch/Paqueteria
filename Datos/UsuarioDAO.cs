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
            string hashGuardado = null;

            string consulta = @"
        SELECT
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
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hashGuardado = reader["contrasena"] == DBNull.Value
                            ? null
                            : reader["contrasena"].ToString();

                        usuario = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["idUsuario"]),
                            Dui = reader["dui"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            Correo = reader["correo"].ToString()
                        };

                        if (reader["fotoPerfil"] != DBNull.Value)
                        {
                            usuario.FotoPerfil = (byte[])reader["fotoPerfil"];
                        }
                    }
                }
            }

            if (usuario == null || string.IsNullOrEmpty(hashGuardado))
                return null;

            bool esHashBCrypt =
                hashGuardado.StartsWith("$2a$") ||
                hashGuardado.StartsWith("$2b$") ||
                hashGuardado.StartsWith("$2y$");

            if (esHashBCrypt)
            {
                try
                {
                    return BCrypt.Net.BCrypt.Verify(contrasena, hashGuardado)
                        ? usuario
                        : null;
                }
                catch (BCrypt.Net.SaltParseException)
                {
                    return null;
                }
                catch (BCrypt.Net.HashInformationException)
                {
                    return null;
                }
            }

            // Compatibilidad temporal con contraseñas antiguas.
            // Si coincide, se convierte a BCrypt automáticamente.
            if (hashGuardado != contrasena)
                return null;

            string nuevoHash = BCrypt.Net.BCrypt.HashPassword(contrasena);

            string actualizar = @"
        UPDATE Usuarios
        SET contrasena = @hash
        WHERE idUsuario = @idUsuario";

            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand comando = new SqlCommand(actualizar, conexion))
            {
                comando.Parameters.AddWithValue("@hash", nuevoHash);
                comando.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                if (comando.ExecuteNonQuery() != 1)
                    return null;
            }

            return usuario;
        }

        public string ObtenerTipoUsuario(int idUsuario)
        {
            string tipoUsuario = "";

            string consulta = @"
        SELECT
            CASE
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
    }
}
