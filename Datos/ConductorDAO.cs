using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modelo.Datos
{
    public class ConductorDAO
    {
        public Conductor ObtenerConductor(int idUsuario)
        {
            Conductor conductor = null;

            string consulta = @"
                SELECT
                    U.idUsuario,
                    U.dui,
                    U.nombre,
                    U.apellido,
                    U.correo,
                    U.fotoPerfil,
                    C.ZonaEncargada
                FROM Usuarios U
                INNER JOIN Conductores C
                    ON U.idUsuario = C.idUsuario
                WHERE U.idUsuario = @idUsuario";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            conductor = new Conductor();

                            conductor.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
                            conductor.Dui = reader["dui"].ToString();
                            conductor.Nombre = reader["nombre"].ToString();
                            conductor.Apellido = reader["apellido"].ToString();
                            conductor.Correo = reader["correo"].ToString();
                            conductor.ZonaEncargada = reader["ZonaEncargada"].ToString();

                            if (reader["fotoPerfil"] != DBNull.Value)
                            {
                                conductor.FotoPerfil =
                                    (byte[])reader["fotoPerfil"];
                            }
                        }
                    }
                }
            }

            return conductor;
        }

        public bool EsConductor(int idUsuario)
        {
            string consulta = @"
        SELECT COUNT(*)
        FROM Conductores
        WHERE idUsuario = @idUsuario";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

        public DataTable ObtenerRutas(int idUsuario)
        {
            DataTable tabla = new DataTable();

            string consulta = @"
        SELECT
            r.idRuta,
            r.Nombre,
            r.Estado,
            r.Zona,
            origen.Nombre AS PuntoOrigen,
            destinoA.Nombre AS DestinoA,
            puntoFinal.Nombre AS PuntoFinal
        FROM ListaDeRutas lr

        INNER JOIN Rutas r
            ON lr.idRuta = r.idRuta

        INNER JOIN PuntosEntrega origen
            ON r.PuntoOrigen = origen.idPunto

        LEFT JOIN PuntosEntrega destinoA
            ON r.DestinoA = destinoA.idPunto

        INNER JOIN PuntosEntrega puntoFinal
            ON r.PuntoFinal = puntoFinal.idPunto

        WHERE lr.idUsuario = @idUsuario";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando =
                       new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idUsuario",
                        idUsuario
                    );

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        public DataTable ObtenerRutaProgreso(int idUsuario)
        {
            DataTable tabla = new DataTable();

            string consulta = @"
        SELECT TOP 1
            pr.idProgramacion,
            pr.idRuta,
            pr.FechaRuta,
            pr.PuntoActual,
            pr.HoraInicioReal,
            pr.HoraFinReal,

            r.Nombre AS Ruta,

            origen.Nombre AS PuntoOrigen,

            destinoA.Nombre AS DestinoA,

            finalRuta.Nombre AS PuntoFinal

        FROM ProgramacionRutas pr

        INNER JOIN Rutas r
            ON pr.idRuta = r.idRuta

        INNER JOIN PuntosEntrega origen
            ON r.PuntoOrigen = origen.idPunto

        LEFT JOIN PuntosEntrega destinoA
            ON r.DestinoA = destinoA.idPunto

        INNER JOIN PuntosEntrega finalRuta
            ON r.PuntoFinal = finalRuta.idPunto

        WHERE pr.idUsuario = @idUsuario
          AND pr.FechaRuta >= CAST(GETDATE() AS DATE)

        ORDER BY pr.FechaRuta ASC";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }


        public DataTable ObtenerProgresoProgramacion(int idProgramacion)
        {
            DataTable tabla = new DataTable();

            string consulta = @"
        SELECT
            pr.idProgramacion,
            pr.idRuta,
            pr.FechaRuta,
            pr.PuntoActual,
            pr.HoraInicioReal,
            pr.HoraFinReal,
            r.Nombre AS Ruta,
            origen.Nombre AS PuntoOrigen,
            destinoA.Nombre AS DestinoA,
            finalRuta.Nombre AS PuntoFinal
        FROM ProgramacionRutas pr
        INNER JOIN Rutas r
            ON pr.idRuta = r.idRuta
        INNER JOIN PuntosEntrega origen
            ON r.PuntoOrigen = origen.idPunto
        LEFT JOIN PuntosEntrega destinoA
            ON r.DestinoA = destinoA.idPunto
        INNER JOIN PuntosEntrega finalRuta
            ON r.PuntoFinal = finalRuta.idPunto
        WHERE pr.idProgramacion = @idProgramacion";

            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue(
                    "@idProgramacion",
                    idProgramacion
                );

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable ObtenerProgramacionRutas(int idUsuario)
        {
            DataTable tabla = new DataTable();

            string consulta = @"
        SELECT
            pr.idProgramacion,
            pr.idRuta,
            pr.FechaRuta,
            pr.HoraInicioReal,
            pr.HoraFinReal,
            r.Nombre AS NombreRuta,
            r.Zona,
            r.Estado AS EstadoRuta
        FROM ProgramacionRutas pr
        INNER JOIN Rutas r
            ON pr.idRuta = r.idRuta
        WHERE pr.idUsuario = @idUsuario
        ORDER BY pr.FechaRuta";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }


        public DataTable ObtenerRutasDelDia(int idUsuario)
        {
            DataTable tabla = new DataTable();



            string consulta = @"
    SELECT
        pr.idProgramacion,
        pr.idRuta,
        pr.FechaRuta,
        pr.PuntoActual,
        pr.HoraInicioReal,
        pr.HoraFinReal,
        r.Nombre AS NombreRuta,
        r.Zona,
        r.Estado AS Estado,
        origen.Nombre AS PuntoOrigen,
        destinoA.Nombre AS DestinoA,
        finalRuta.Nombre AS PuntoFinal
    FROM ProgramacionRutas pr
    INNER JOIN Rutas r
        ON pr.idRuta = r.idRuta
    INNER JOIN PuntosEntrega origen
        ON r.PuntoOrigen = origen.idPunto
    LEFT JOIN PuntosEntrega destinoA
        ON r.DestinoA = destinoA.idPunto
    INNER JOIN PuntosEntrega finalRuta
        ON r.PuntoFinal = finalRuta.idPunto
    WHERE pr.idUsuario = @idUsuario
      AND pr.FechaRuta = CAST(GETDATE() AS DATE)
    ORDER BY pr.FechaRuta, pr.idProgramacion";


            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                using (SqlDataAdapter adaptador =
                    new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public bool IniciarRuta(int idProgramacion)
        {
            string consulta = @"
        UPDATE ProgramacionRutas
        SET HoraInicioReal = GETDATE(),
            PuntoActual = 1
        WHERE idProgramacion = @idProgramacion
          AND HoraInicioReal IS NULL
          AND HoraFinReal IS NULL";

            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue(
                    "@idProgramacion",
                    idProgramacion
                );

                return comando.ExecuteNonQuery() > 0;
            }
        }


        public bool AvanzarPuntoRuta(int idProgramacion)
        {
            string consulta = @"
        UPDATE ProgramacionRutas
        SET PuntoActual = PuntoActual + 1
        WHERE idProgramacion = @idProgramacion
          AND HoraInicioReal IS NOT NULL
          AND HoraFinReal IS NULL
          AND PuntoActual < 3";

            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue(
                    "@idProgramacion",
                    idProgramacion
                );

                return comando.ExecuteNonQuery() > 0;
            }
        }


        public bool FinalizarRuta(int idProgramacion)
        {
            string consulta = @"
        UPDATE ProgramacionRutas
        SET HoraFinReal = GETDATE()
        WHERE idProgramacion = @idProgramacion
          AND HoraInicioReal IS NOT NULL
          AND HoraFinReal IS NULL
          AND PuntoActual = 3";

            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue(
                    "@idProgramacion",
                    idProgramacion
                );

                return comando.ExecuteNonQuery() > 0;
            }
        }

    }
}
