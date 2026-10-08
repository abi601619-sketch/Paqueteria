using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Datos
{
    public class RutaDAO
    {
        public List<Ruta> ObtenerRutasPorConductor(int idUsuario)
        {
            List<Ruta> rutas = new List<Ruta>();

            string consulta = @"
                SELECT
                    R.idRuta,
                    R.Nombre,
                    R.Estado,
                    R.Zona,
                    PO.Nombre AS PuntoOrigen,
                    DA.Nombre AS DestinoA,
                    PF.Nombre AS PuntoFinal
                FROM Rutas R
                INNER JOIN ListaDeRutas LR
                    ON R.idRuta = LR.idRuta
                INNER JOIN PuntosEntrega PO
                    ON R.PuntoOrigen = PO.idPunto
                LEFT JOIN PuntosEntrega DA
                    ON R.DestinoA = DA.idPunto
                INNER JOIN PuntosEntrega PF
                    ON R.PuntoFinal = PF.idPunto
                WHERE LR.idUsuario = @idUsuario";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ruta ruta = new Ruta();

                            ruta.IdRuta = Convert.ToInt32(reader["idRuta"]);
                            ruta.Nombre = reader["Nombre"].ToString();
                            ruta.Estado = reader["Estado"].ToString();
                            ruta.Zona = reader["Zona"].ToString();
                            ruta.PuntoOrigen = reader["PuntoOrigen"].ToString();
                            ruta.DestinoA = reader["DestinoA"].ToString();
                            ruta.PuntoFinal = reader["PuntoFinal"].ToString();

                            rutas.Add(ruta);
                        }
                    }
                }
            }

            return rutas;
        }
    }
}
