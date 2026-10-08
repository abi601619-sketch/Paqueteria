using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Datos
{
    public class VehiculoDAO
    {
        public List<Vehiculos> ObtenerVehiculosPorConductor(int idUsuario)
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();

            string consulta = @"
                SELECT
                    V.idVehiculo,
                    V.Marca,
                    V.Capacidad,
                    V.Modelo,
                    V.Kilometraje,
                    V.Estado,
                    V.Disponibilidad
                FROM Vehiculos V
                INNER JOIN ListaDeVehiculos LV
                    ON V.idVehiculo = LV.idVehiculo
                WHERE LV.idUsuario = @idUsuario";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehiculos vehiculo = new Vehiculos();

                            vehiculo.IdVehiculo = Convert.ToInt32(reader["idVehiculo"]);
                            vehiculo.Marca = reader["Marca"].ToString();
                            vehiculo.Capacidad = reader["Capacidad"].ToString();
                            vehiculo.Modelo = reader["Modelo"].ToString();
                            vehiculo.Kilometraje = reader["Kilometraje"].ToString();
                            vehiculo.Estado = reader["Estado"].ToString();
                            vehiculo.Disponibilidad = Convert.ToInt32(reader["Disponibilidad"]);

                            vehiculos.Add(vehiculo);
                        }
                    }
                }
            }

            return vehiculos;
        }
    }
}
