using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

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
                            conductor.Dui = reader["dui"].ToString();
                            conductor.Correo = reader["correo"].ToString();

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

        public bool AgregarConductor()
        {
            using (SqlConnection con = Conexion_DB.Conexion.Conectar())
            {
                SqlTransaction transaccion = con.BeginTransaction();

                try
                {
                    string consultaUsuario = @"
                INSERT INTO Usuarios
                (dui, nombre, apellido, correo, contrasena, fotoPerfil)
                VALUES
                (@dui, @nombre, @apellido, @correo, @contrasena, @fotoPerfil);

                SELECT SCOPE_IDENTITY();";

                    int nuevoIdUsuario;

                    using (SqlCommand cmdUsuario = new SqlCommand(consultaUsuario, con, transaccion))
                    {
                        cmdUsuario.Parameters.AddWithValue("@dui", Dui);
                        cmdUsuario.Parameters.AddWithValue("@nombre", Nombre);
                        cmdUsuario.Parameters.AddWithValue("@apellido", Apellido);
                        cmdUsuario.Parameters.AddWithValue("@correo", Correo);
                        cmdUsuario.Parameters.AddWithValue("@contrasena", Contrasena);

                        if (FotoPerfil != null)
                        {
                            cmdUsuario.Parameters.Add("@fotoPerfil", System.Data.SqlDbType.VarBinary).Value = FotoPerfil;
                        }
                        else
                        {
                            cmdUsuario.Parameters.Add("@fotoPerfil", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        nuevoIdUsuario = Convert.ToInt32(cmdUsuario.ExecuteScalar());
                    }

                    string consultaConductor = @"
                INSERT INTO Conductores
                (idUsuario, ZonaEncargada)
                VALUES
                (@idUsuario, @zonaEncargada);";

                    using (SqlCommand cmdConductor = new SqlCommand(consultaConductor, con, transaccion))
                    {
                        cmdConductor.Parameters.AddWithValue("@idUsuario", nuevoIdUsuario);
                        cmdConductor.Parameters.AddWithValue("@zonaEncargada", ZonaEncargada);

                        cmdConductor.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    IdUsuario = nuevoIdUsuario;

                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }


        public bool ActualizarConductor()
        {
            using (SqlConnection con = Conexion_DB.Conexion.Conectar())
            {
                SqlTransaction transaccion = con.BeginTransaction();

                try
                {
                    string consultaUsuario = @"
                UPDATE Usuarios
                SET dui = @dui,
                    nombre = @nombre,
                    apellido = @apellido,
                    correo = @correo,
                    contrasena = @contrasena,
                    fotoPerfil = @fotoPerfil
                WHERE idUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(
                        consultaUsuario, con, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@dui", Dui);
                        cmd.Parameters.AddWithValue("@nombre", Nombre);
                        cmd.Parameters.AddWithValue("@apellido", Apellido);
                        cmd.Parameters.AddWithValue("@correo", Correo);
                        cmd.Parameters.AddWithValue("@contrasena", Contrasena);

                        cmd.Parameters.Add("@fotoPerfil", System.Data.SqlDbType.VarBinary, -1)
                            .Value = (object)FotoPerfil ?? DBNull.Value;

                        int filasUsuario = cmd.ExecuteNonQuery();

                        if (filasUsuario == 0)
                        {
                            transaccion.Rollback();
                            return false;
                        }
                    }

                    string consultaConductor = @"
                UPDATE Conductores
                SET zonaEncargada = @zonaEncargada
                WHERE idUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(
                        consultaConductor, con, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@zonaEncargada", ZonaEncargada);

                        int filasConductor = cmd.ExecuteNonQuery();

                        if (filasConductor == 0)
                        {
                            transaccion.Rollback();
                            return false;
                        }
                    }

                    transaccion.Commit();
                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        public bool EliminarConductor()
        {
            using (SqlConnection con = Conexion_DB.Conexion.Conectar())
            {
                SqlTransaction transaccion = con.BeginTransaction();

                try
                {
                    // 1. Eliminar rutas asignadas
                    string consultaRutas = @"
                DELETE FROM ListaDeRutas
                WHERE idUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(
                        consultaRutas, con, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Eliminar vehículos asignados
                    string consultaVehiculos = @"
                DELETE FROM ListaDeVehiculos
                WHERE idUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(
                        consultaVehiculos, con, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Eliminar conductor
                    string consultaConductor = @"
                DELETE FROM Conductores
                WHERE idUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(
                        consultaConductor, con, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Eliminar usuario
                    string consultaUsuario = @"
                DELETE FROM Usuarios
                WHERE idUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(
                        consultaUsuario, con, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        int filas = cmd.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            transaccion.Rollback();
                            return false;
                        }
                    }

                    transaccion.Commit();
                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

            public List<Conductor> ObtenerConductoresDisponibles(int idVehiculo)
        {
            List<Conductor> conductores = new List<Conductor>();

            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                SELECT u.idUsuario, u.nombre, u.apellido
                FROM Conductores c
                INNER JOIN Usuarios u
                    ON c.idUsuario = u.idUsuario
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM ListaDeVehiculos lv
                    WHERE lv.idUsuario = c.idUsuario
                      AND lv.idVehiculo = @idVehiculo
                )
                ORDER BY u.nombre, u.apellido";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idVehiculo", idVehiculo);

                        using (SqlDataReader reader = comando.ExecuteReader())
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

        public List<Vehiculos> ObtenerVehiculosAsignados()
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();

            try
            {
                using (SqlConnection conexion = Conexion_DB.Conexion.Conectar())
                {
                    string consulta = @"
                SELECT v.idVehiculo, v.Marca, v.Modelo
                FROM ListaDeVehiculos lv
                INNER JOIN Vehiculos v
                    ON lv.idVehiculo = v.idVehiculo
                WHERE lv.idUsuario = @idUsuario
                ORDER BY v.Marca, v.Modelo";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idUsuario", IdUsuario);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vehiculos vehiculo = new Vehiculos();

                                vehiculo.IdVehiculo =
                                    Convert.ToInt32(reader["idVehiculo"]);

                                vehiculo.Marca = reader["Marca"].ToString();
                                vehiculo.Modelo = reader["Modelo"].ToString();

                                vehiculos.Add(vehiculo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener los vehículos asignados: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return vehiculos;
        }

        public int ObtenerCantidadConductores()
        {
            try
            {
                using (SqlConnection conexion =
                    Conexion_DB.Conexion.Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Conductores";

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
                    "Error al contar los conductores: " + ex.Message);
                return 0;
            }
        }
    }
    
}
