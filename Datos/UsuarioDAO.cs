using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Datos
{
    public class UsuarioDAO
    {
        public Usuario IniciarSesion(string correo, string contrasena)
        {
            try
            {
                Usuario usuario = null;

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
                {
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@correo", correo);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener el hash almacenado en la base de datos
                                string hashGuardado =
                                    reader["contrasena"].ToString();

                                // Verificar la contraseña ingresada con BCrypt
                                bool contraseñaCorrecta = false;

                                try
                                {
                                    contraseñaCorrecta =
                                        BCrypt.Net.BCrypt.Verify(
                                            contrasena,
                                            hashGuardado
                                        );
                                }
                                catch (BCrypt.Net.SaltParseException)
                                {
                                    contraseñaCorrecta = false;
                                }
                                catch (ArgumentException)
                                {
                                    contraseñaCorrecta = false;
                                }

                                // Solo permitir el acceso si la contraseña es correcta
                                if (contraseñaCorrecta)
                                {
                                    usuario = new Usuario();

                                    usuario.IdUsuario =
                                        Convert.ToInt32(reader["idUsuario"]);

                                    usuario.Dui =
                                        reader["dui"].ToString();

                                    usuario.Nombre =
                                        reader["nombre"].ToString();

                                    usuario.Apellido =
                                        reader["apellido"].ToString();

                                    usuario.Correo =
                                        reader["correo"].ToString();

                                    if (reader["fotoPerfil"] != DBNull.Value)
                                    {
                                        usuario.FotoPerfil =
                                            (byte[])reader["fotoPerfil"];
                                    }
                                }
                            }
                        }
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al iniciar sesión en UsuarioDAO.",
                    ex
                );
            }
        }

        public string ObtenerTipoUsuario(int idUsuario)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al obtener el tipo de usuario en UsuarioDAO.",
                    ex
                );
            }
        }
    }
}