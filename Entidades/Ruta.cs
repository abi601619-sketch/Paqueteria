using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Ruta
    {
        private int idRuta;
        private string nombre;
        private string estado;
        private string zona;
        private string puntoOrigen;
        private string destinoA;
        private string puntoFinal;

        public int IdRuta { get => idRuta; set => idRuta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Zona { get => zona; set => zona = value; }
        public string PuntoOrigen { get => puntoOrigen; set => puntoOrigen = value; }
        public string DestinoA { get => destinoA; set => destinoA = value; }
        public string PuntoFinal { get => puntoFinal; set => puntoFinal = value; }

        public List<Ruta> ObtenerRutasDisponibles(int idUsuario)
        {
            List<Ruta> rutas = new List<Ruta>();

            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                        SELECT r.idRuta, r.Nombre, r.Zona
                        FROM Rutas r
                        WHERE NOT EXISTS (
                            SELECT 1
                            FROM ListaDeRutas lr
                            WHERE lr.idRuta = r.idRuta
                              AND lr.idUsuario = @idUsuario
                        )
                        ORDER BY r.Nombre";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idUsuario", idUsuario);

                        using (SqlDataReader reader =
                            comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rutas.Add(new Ruta
                                {
                                    IdRuta = Convert.ToInt32(
                                        reader["idRuta"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Zona = reader["Zona"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar las rutas: " + ex.Message);
            }

            return rutas;
        }

        public List<Ruta> ObtenerRutasAsignadas(int idUsuario)
        {
            List<Ruta> rutas = new List<Ruta>();

            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                        SELECT r.idRuta, r.Nombre, r.Zona
                        FROM ListaDeRutas lr
                        INNER JOIN Rutas r ON lr.idRuta = r.idRuta
                        WHERE lr.idUsuario = @idUsuario
                        ORDER BY r.Nombre";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idUsuario", idUsuario);

                        using (SqlDataReader reader =
                            comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rutas.Add(new Ruta
                                {
                                    IdRuta = Convert.ToInt32(
                                        reader["idRuta"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Zona = reader["Zona"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar las rutas asignadas: " + ex.Message);
            }

            return rutas;
        }

        public bool AgregarAConductor(int idUsuario)
        {
            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                        IF NOT EXISTS (
                            SELECT 1
                            FROM ListaDeRutas
                            WHERE idRuta = @idRuta
                              AND idUsuario = @idUsuario
                        )
                        BEGIN
                            INSERT INTO ListaDeRutas (idRuta, idUsuario)
                            VALUES (@idRuta, @idUsuario);

                            SELECT 1;
                        END
                        ELSE
                            SELECT 0;";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idRuta", IdRuta);

                        comando.Parameters.AddWithValue(
                            "@idUsuario", idUsuario);

                        return Convert.ToInt32(
                            comando.ExecuteScalar()) == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al asignar la ruta: " + ex.Message);
                return false;
            }
        }

        public bool EliminarDeConductor(int idUsuario)
        {
            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                        DELETE FROM ListaDeRutas
                        WHERE idRuta = @idRuta
                          AND idUsuario = @idUsuario";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idRuta", IdRuta);

                        comando.Parameters.AddWithValue(
                            "@idUsuario", idUsuario);

                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al quitar la ruta: " + ex.Message);
                return false;
            }
        }
    }
}
