using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;

namespace Modelo.Entidades
{
    public class PuntosEntregaDB
    {
        private int IdPuntoEntrega;

        private string Nombre;
        public class PuntoEntrega
        {
            public int IdPunto { get; set; }

            public string NombrePunto { get; set; }
        }

        public int IdPuntoEntrega1 { get => IdPuntoEntrega; set => IdPuntoEntrega = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public List<PuntoEntrega> ObtenerPuntosEntrega()
        {
            List<PuntoEntrega> puntos = new List<PuntoEntrega>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                string consulta = @"SELECT idPunto, Nombre
            FROM PuntosEntrega";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            puntos.Add(new PuntoEntrega
                            {
                                IdPunto = Convert.ToInt32(reader["idPunto"]),
                                NombrePunto = reader["Nombre"].ToString()
                            });
                        }
                    }
                }
            }

            return puntos;
        }
    }
}
