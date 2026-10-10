using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Conductor
    {
        private int idUsuario;
        private string dui;
        private string nombre;
        private string apellido;
        private string correo;
        private string contrasena;
        private byte[] fotoPerfil;
        private string zonaEncargada;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public byte[] FotoPerfil { get => fotoPerfil; set => fotoPerfil = value; }
        public string ZonaEncargada { get => zonaEncargada; set => zonaEncargada = value; }

        public List<Conductor> CargarConductoresPorZona(string zona)
        {
            List<Conductor> lista = new List<Conductor>();

            using (SqlConnection con = Conexion_DB.Conexion.Conectar())
            {
                string consulta = @"SELECT * FROM Conductores INNER JOIN Usuarios ON Conductores.idUsuario = Usuarios.idUsuario WHERE zonaEncargada = @zonaEncargada";

                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@zonaEncargada", zona);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Conductor conductor = new Conductor();

                            conductor.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
                            conductor.Nombre = reader["nombre"].ToString();
                            conductor.Apellido = reader["apellido"].ToString();
                            conductor.ZonaEncargada = reader["zonaEncargada"].ToString();

                            if (reader["fotoPerfil"] != DBNull.Value)
                            {
                                conductor.FotoPerfil = (byte[])reader["fotoPerfil"];
                            }

                            lista.Add(conductor);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
