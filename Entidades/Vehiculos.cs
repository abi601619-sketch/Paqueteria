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


        public bool ActualizarVehiculo()
        {
            try
            {
                using (SqlConnection conexion = Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                UPDATE Vehiculos
                SET 
                    Marca = @Marca,
                    Capacidad = @Capacidad,
                    Modelo = @Modelo,
                    Kilometraje = @Kilometraje,
                    Estado = @Estado,
                    Disponibilidad = @Disponibilidad,
                    FotoCarro = @FotoCarro,
                    TipoCarro = @TipoCarro
                WHERE idVehiculo = @idVehiculo";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idVehiculo", IdVehiculo);
                        comando.Parameters.AddWithValue("@Marca", Marca);
                        comando.Parameters.AddWithValue("@Capacidad", Capacidad);
                        comando.Parameters.AddWithValue("@Modelo", Modelo);
                        comando.Parameters.AddWithValue("@Kilometraje", Kilometraje);
                        comando.Parameters.AddWithValue("@Estado", Estado);
                        comando.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                        comando.Parameters.Add("@fotoCarro", System.Data.SqlDbType.VarBinary, -1)
                          .Value = (object)FotoCarro ?? DBNull.Value;
                        comando.Parameters.AddWithValue("@TipoCarro", TipoCarro);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar el vehículo: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        public bool EliminarVehiculo()
        {
            using (SqlConnection conexion = Conexion_DB.Conexion.Conectar())
            {
                SqlTransaction transaccion = null;

                try
                {
                    transaccion = conexion.BeginTransaction();

                    // 1. Eliminar las relaciones del vehículo con los listados.
                    string consultaListado = @"
                DELETE FROM ListaDeVehiculos
                WHERE idVehiculo = @idVehiculo";

                    using (SqlCommand comando = new SqlCommand(
                        consultaListado, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@idVehiculo", IdVehiculo);
                        comando.ExecuteNonQuery();
                    }

                    // 2. Eliminar el vehículo.
                    string consultaVehiculo = @"
                DELETE FROM Vehiculos
                WHERE idVehiculo = @idVehiculo";

                    int filasAfectadas;

                    using (SqlCommand comando = new SqlCommand(
                        consultaVehiculo, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@idVehiculo", IdVehiculo);
                        filasAfectadas = comando.ExecuteNonQuery();
                    }

                    // Confirmar los cambios únicamente si se eliminó el vehículo.
                    if (filasAfectadas == 0)
                    {
                        transaccion.Rollback();
                        return false;
                    }

                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (transaccion != null)
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch
                        {
                            // La transacción podría haberse revertido ya.
                        }
                    }

                    MessageBox.Show(
                        "Error al eliminar el vehículo: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return false;
                }
            }
        }


        public List<Conductor> ObtenerConductoresPorVehiculo()
        {
            List<Conductor> conductores = new List<Conductor>();

            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                SELECT u.idUsuario, u.nombre, u.apellido
                FROM ListaDeVehiculos lv
                INNER JOIN Conductores c
                    ON lv.idUsuario = c.idUsuario
                INNER JOIN Usuarios u
                    ON c.idUsuario = u.idUsuario
                WHERE lv.idVehiculo = @idVehiculo
                ORDER BY u.nombre, u.apellido";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idVehiculo", IdVehiculo);

                        using (SqlDataReader reader =
                            comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Conductor conductor = new Conductor();

                                conductor.IdUsuario =
                                    Convert.ToInt32(reader["idUsuario"]);

                                conductor.Nombre =
                                    reader["nombre"].ToString();

                                conductor.Apellido =
                                    reader["apellido"].ToString();

                                conductores.Add(conductor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los conductores: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return conductores;
        }


        public bool AgregarConductor(int idUsuario)
        {
            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                IF NOT EXISTS (
                    SELECT 1
                    FROM ListaDeVehiculos
                    WHERE idVehiculo = @idVehiculo
                      AND idUsuario = @idUsuario
                )
                BEGIN
                    INSERT INTO ListaDeVehiculos
                        (idVehiculo, idUsuario)
                    VALUES
                        (@idVehiculo, @idUsuario);

                    SELECT 1;
                END
                ELSE
                BEGIN
                    SELECT 0;
                END";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idVehiculo", IdVehiculo);

                        comando.Parameters.AddWithValue(
                            "@idUsuario", idUsuario);

                        int resultado = Convert.ToInt32(
                            comando.ExecuteScalar());

                        return resultado == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al agregar el conductor: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        public bool EliminarConductor(int idUsuario)
        {
            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                DELETE FROM ListaDeVehiculos
                WHERE idVehiculo = @idVehiculo
                  AND idUsuario = @idUsuario";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idVehiculo", IdVehiculo);

                        comando.Parameters.AddWithValue(
                            "@idUsuario", idUsuario);

                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al quitar al conductor: " + ex.Message);
                return false;
            }
        }

        public bool EliminarVehiculoDeConductor(int idUsuario)
        {
            try
            {
                using (SqlConnection conexion = Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                DELETE FROM ListaDeVehiculos
                WHERE idUsuario = @idUsuario
                  AND idVehiculo = @idVehiculo";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                        comando.Parameters.AddWithValue("@idVehiculo", IdVehiculo);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al quitar el vehículo del conductor: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
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
                    FROM ListaDeVehiculos
                    WHERE idVehiculo = @idVehiculo
                      AND idUsuario = @idUsuario
                )
                BEGIN
                    INSERT INTO ListaDeVehiculos
                        (idVehiculo, idUsuario)
                    VALUES
                        (@idVehiculo, @idUsuario);

                    SELECT 1;
                END
                ELSE
                    SELECT 0;";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idVehiculo", IdVehiculo);

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
                    "Error al asignar el vehículo: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        public List<Vehiculos> ObtenerVehiculosDisponiblesParaConductor(
    int idUsuario)
        {
            List<Vehiculos> lista = new List<Vehiculos>();

            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                SELECT v.idVehiculo, v.Marca, v.Modelo
                FROM Vehiculos v
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM ListaDeVehiculos lv
                    WHERE lv.idVehiculo = v.idVehiculo
                      AND lv.idUsuario = @idUsuario
                )
                ORDER BY v.Marca, v.Modelo";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idUsuario", idUsuario);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vehiculos v = new Vehiculos();

                                v.IdVehiculo =
                                    Convert.ToInt32(reader["idVehiculo"]);

                                v.Marca = reader["Marca"].ToString();
                                v.Modelo = reader["Modelo"].ToString();

                                lista.Add(v);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar vehículos disponibles: " + ex.Message);
            }

            return lista;
        }

        public int ObtenerCantidadVehiculos()
        {
            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Vehiculos";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al contar los vehículos: " + ex.Message);
                return 0;
            }
        }
    }
}
