using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Usuario
    {
        private int idUsuario;

        private string dui;

        private string nombre;

        private string apellido;

        private string correo;

        private string contrasena;

        private byte[] fotoPerfil;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public byte[] FotoPerfil { get => fotoPerfil; set => fotoPerfil = value; }
    

    public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            Usuario usuario = null;

            using (SqlConnection conexion = Conexion_DB.Conexion.Conectar())
            {
                string consulta = @"
            SELECT idUsuario, correo, dui
            FROM Usuarios
            WHERE idUsuario = @idUsuario";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario();

                            usuario.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
                            usuario.Correo = reader["correo"].ToString();
                            usuario.Dui = reader["dui"].ToString();
                        }
                    }
                }
            }

            return usuario;
        }
    }
}
