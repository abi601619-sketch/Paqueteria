using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Vehiculos
    {
        private int idVehiculo;
        private string marca;
        private string capacidad;
        private string modelo;
        private string kilometraje;
        private string estado;
        private bool disponibilidad;
        private byte[] fotoCarro;
        private bool tipoCarro;

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Capacidad { get => capacidad; set => capacidad = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Kilometraje { get => kilometraje; set => kilometraje = value; }
        public string Estado { get => estado; set => estado = value; }
        public bool Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public byte[] FotoCarro { get => fotoCarro; set => fotoCarro = value; }
        public bool TipoCarro { get => tipoCarro; set => tipoCarro = value; }

        public List<Vehiculos> CargarVehiculosPorTipo(bool grandes)
        {
            List<Vehiculos> lista = new List<Vehiculos>();

            using (SqlConnection con = Conexion_DB.Conexion.Conectar())
            {
                string consulta;

                if (grandes)
                {
                    consulta = @"SELECT *FROM Vehiculos
                         WHERE TipoCarro = 1;";
                }
                else
                {
                    consulta = @"SELECT * FROM Vehiculos
                         WHERE TipoCarro = 0";
                }

                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehiculos vehiculo = new Vehiculos();

                            vehiculo.IdVehiculo = Convert.ToInt32(reader["idVehiculo"]);
                            vehiculo.Capacidad = reader["Capacidad"].ToString();
                            vehiculo.Estado = reader["Estado"].ToString();
                            vehiculo.Marca = reader["Marca"].ToString();
                            vehiculo.Modelo = reader["Modelo"].ToString();
                            vehiculo.Kilometraje = reader["Kilometraje"].ToString();
                            vehiculo.FotoCarro = reader["FotoCarro"] != DBNull.Value? (byte[])reader["FotoCarro"]: null;
                            vehiculo.TipoCarro = Convert.ToBoolean(reader["TipoCarro"]);

                            lista.Add(vehiculo);
                        }
                    }
                }
            }

            return lista;
        }

        public bool AgregarVehiculo()
        {
            using (SqlConnection con = Conexion_DB.Conexion.Conectar())
            {
                string consulta = @"
            INSERT INTO Vehiculos
            (
                Marca,
                Capacidad,
                Modelo,
                Kilometraje,
                Estado,
                Disponibilidad,
                FotoCarro,
                TipoCarro
            )
            VALUES
            (
                @Marca,
                @Capacidad,
                @Modelo,
                @Kilometraje,
                @Estado,
                @Disponibilidad,
                @FotoCarro,
                @TipoCarro
            );";

                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@Marca", Marca);
                    cmd.Parameters.AddWithValue("@Capacidad", Capacidad);
                    cmd.Parameters.AddWithValue("@Modelo", Modelo);

                    cmd.Parameters.AddWithValue(
                        "@Kilometraje",
                        string.IsNullOrWhiteSpace(Kilometraje)
                            ? (object)DBNull.Value
                            : Kilometraje
                    );

                    cmd.Parameters.AddWithValue(
                        "@Estado",
                        string.IsNullOrWhiteSpace(Estado)
                            ? (object)DBNull.Value
                            : Estado
                    );

                    cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);

                    cmd.Parameters.AddWithValue(
                        "@FotoCarro",
                        FotoCarro == null
                            ? (object)DBNull.Value
                            : FotoCarro
                    );

                    cmd.Parameters.AddWithValue("@TipoCarro", TipoCarro);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
