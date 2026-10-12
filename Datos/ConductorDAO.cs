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
            try
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
                                    conductor.FotoPerfil = (byte[])reader["fotoPerfil"];
                                }
                            }
                        }
                    }
                }

                return conductor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerConductor de ConductorDAO.", ex);
            }
        }

        public bool EsConductor(int idUsuario)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error en EsConductor de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerRutas(int idUsuario, DateTime fechaSeleccionada)
        {
            try
            {
                DataTable tabla = new DataTable();

                string consulta = @"
                    SELECT
                        pr.idProgramacion,
                        r.idRuta,
                        pr.FechaRuta AS fecha,
                        r.Nombre,
                        r.Estado,
                        r.Zona,
                        origen.Nombre AS PuntoOrigen,
                        destinoA.Nombre AS DestinoA,
                        puntoFinal.Nombre AS PuntoFinal
                    FROM ProgramacionRutas pr
                    INNER JOIN Rutas r
                        ON pr.idRuta = r.idRuta
                    INNER JOIN PuntosEntrega origen
                        ON r.PuntoOrigen = origen.idPunto
                    LEFT JOIN PuntosEntrega destinoA
                        ON r.DestinoA = destinoA.idPunto
                    INNER JOIN PuntosEntrega puntoFinal
                        ON r.PuntoFinal = puntoFinal.idPunto
                    WHERE pr.idUsuario = @idUsuario
                      AND pr.FechaRuta = @fecha
                    ORDER BY pr.idProgramacion;";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    comando.Parameters.Add("@fecha", SqlDbType.Date).Value = fechaSeleccionada.Date;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerRutas de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerRutaProgreso(int idUsuario)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerRutaProgreso de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerProgresoProgramacion(int idProgramacion)
        {
            try
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
                        pr.EstadoPunto1,
                        pr.EstadoPunto2,
                        pr.EstadoPunto3,
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
                    comando.Parameters.AddWithValue("@idProgramacion", idProgramacion);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerProgresoProgramacion de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerProgramacionRutas(int idUsuario)
        {
            try
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
                    FROM dbo.ProgramacionRutas pr
                    INNER JOIN dbo.Rutas r
                        ON pr.idRuta = r.idRuta
                    WHERE pr.idUsuario = @idUsuario
                    ORDER BY pr.FechaRuta, pr.idProgramacion;";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerProgramacionRutas de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerRutasDelDia(int idUsuario)
        {
            try
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

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerRutasDelDia de ConductorDAO.", ex);
            }
        }

        public bool IniciarRuta(int idProgramacion)
        {
            try
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
                    comando.Parameters.AddWithValue("@idProgramacion", idProgramacion);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en IniciarRuta de ConductorDAO.", ex);
            }
        }

        public bool AvanzarPuntoRuta(int idProgramacion)
        {
            try
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
                    comando.Parameters.AddWithValue("@idProgramacion", idProgramacion);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en AvanzarPuntoRuta de ConductorDAO.", ex);
            }
        }

        public bool FinalizarRuta(int idProgramacion)
        {
            try
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
                    comando.Parameters.AddWithValue("@idProgramacion", idProgramacion);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en FinalizarRuta de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerRutasDelMes(int idUsuario, DateTime fecha)
        {
            try
            {
                DataTable tabla = new DataTable();

                DateTime inicioMes = new DateTime(fecha.Year, fecha.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1);

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
                        r.Estado AS EstadoRuta,
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
                      AND PR.FechaRuta >= CAST(GETDATE() AS DATE)
                      AND pr.FechaRuta < @finMes
                      AND pr.HoraFinReal IS NULL
                    ORDER BY pr.FechaRuta, pr.idProgramacion";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@inicioMes", inicioMes);
                    comando.Parameters.AddWithValue("@finMes", finMes);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerRutasDelMes de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerRutasActivasDelMes(int idUsuario, DateTime fecha)
        {
            try
            {
                DataTable tabla = new DataTable();

                DateTime inicioMes = new DateTime(fecha.Year, fecha.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1);

                string consulta = @"
                    SELECT
                        PR.idProgramacion,
                        PR.idRuta,
                        PR.FechaRuta,
                        PR.PuntoActual,
                        PR.HoraInicioReal,
                        R.Nombre AS NombreRuta,
                        R.Estado AS EstadoRuta,
                        R.Zona,
                        Origen.Nombre AS PuntoOrigen,
                        Destino.Nombre AS DestinoA,
                        FinalRuta.Nombre AS PuntoFinal,
                        COUNT(A.idPedido) AS TotalPedidos
                    FROM ProgramacionRutas PR
                    INNER JOIN Rutas R
                        ON R.idRuta = PR.idRuta
                    INNER JOIN PuntosEntrega Origen
                        ON Origen.idPunto = R.PuntoOrigen
                    LEFT JOIN PuntosEntrega Destino
                        ON Destino.idPunto = R.DestinoA
                    INNER JOIN PuntosEntrega FinalRuta
                        ON FinalRuta.idPunto = R.PuntoFinal
                    LEFT JOIN AsignacionPedidosRuta A
                        ON A.idProgramacion = PR.idProgramacion
                    WHERE PR.idUsuario = @idUsuario
                      AND PR.FechaRuta >= CAST(GETDATE() AS DATE)
                      AND PR.FechaRuta < @finMes
                      AND PR.HoraFinReal IS NULL
                    GROUP BY
                        PR.idProgramacion,
                        PR.idRuta,
                        PR.FechaRuta,
                        PR.PuntoActual,
                        PR.HoraInicioReal,
                        R.Nombre,
                        R.Estado,
                        R.Zona,
                        Origen.Nombre,
                        Destino.Nombre,
                        FinalRuta.Nombre
                    ORDER BY PR.FechaRuta, PR.idProgramacion";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@inicioMes", inicioMes);
                    comando.Parameters.AddWithValue("@finMes", finMes);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerRutasActivasDelMes de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerProductosSolicitadosPorRuta(int idProgramacion)
        {
            try
            {
                DataTable tabla = new DataTable();

                string consulta = @"
                    SELECT
                        A.idAsignacion,
                        D.idPedido,
                        D.idProducto,
                        P.Nombre AS NombreProducto,
                        P.Precio,
                        D.Cantidad,
                        (P.Precio * D.Cantidad) AS Subtotal,
                        PE.Nombre AS PuntoEntrega,
                        A.EstadoAsignacion,
                        A.FechaAsignacion,
                        A.Entregado,
                        D.Estado AS EstadoPedido
                    FROM dbo.AsignacionPedidosRuta A
                    INNER JOIN dbo.DetallePedidos D
                        ON D.idPedido = A.idPedido
                    INNER JOIN dbo.Productos P
                        ON P.idProducto = D.idProducto
                    INNER JOIN dbo.PuntosEntrega PE
                        ON PE.idPunto = D.idPuntoEntrega
                    WHERE A.idProgramacion = @idProgramacion
                    ORDER BY PE.Nombre, D.idPedido;";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idProgramacion", SqlDbType.Int).Value = idProgramacion;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerProductosSolicitadosPorRuta de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerCuatroRutas(int idUsuario)
        {
            try
            {
                DataTable tabla = new DataTable();

                string consulta = @"
                    SELECT TOP 4
                        pr.idProgramacion,
                        pr.idRuta,
                        pr.FechaRuta,
                        pr.PuntoActual,
                        pr.HoraInicioReal,
                        pr.HoraFinReal,
                        r.Nombre AS NombreRuta,
                        r.Estado AS EstadoRuta,
                        r.Zona,
                        origen.Nombre AS PuntoOrigen,
                        destino.Nombre AS DestinoA,
                        finalRuta.Nombre AS PuntoFinal
                    FROM ProgramacionRutas pr
                    INNER JOIN Rutas r
                        ON r.idRuta = pr.idRuta
                    INNER JOIN PuntosEntrega origen
                        ON origen.idPunto = r.PuntoOrigen
                    LEFT JOIN PuntosEntrega destino
                        ON destino.idPunto = r.DestinoA
                    INNER JOIN PuntosEntrega finalRuta
                        ON finalRuta.idPunto = r.PuntoFinal
                    WHERE pr.idUsuario = @idUsuario
                      AND pr.FechaRuta >= CAST(GETDATE() AS DATE)
                    ORDER BY pr.FechaRuta, pr.idProgramacion;";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerCuatroRutas de ConductorDAO.", ex);
            }
        }

        public void ActualizarEstadoPunto(
            int idProgramacion,
            int numeroPunto,
            string estado)
        {
            try
            {
                string columna;

                switch (numeroPunto)
                {
                    case 1:
                        columna = "EstadoPunto1";
                        break;

                    case 2:
                        columna = "EstadoPunto2";
                        break;

                    case 3:
                        columna = "EstadoPunto3";
                        break;

                    default:
                        throw new ArgumentException("Número de punto inválido.");
                }

                string consulta =
                    $"UPDATE dbo.ProgramacionRutas " +
                    $"SET {columna} = @Estado " +
                    "WHERE idProgramacion = @idProgramacion " +
                    "AND FechaRuta = CAST(GETDATE() AS DATE)";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = estado;
                    comando.Parameters.Add("@idProgramacion", SqlDbType.Int).Value = idProgramacion;

                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    if (comando.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No se encontró la programación de la ruta.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ActualizarEstadoPunto de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerEstadosPuntos(int idProgramacion)
        {
            try
            {
                DataTable tabla = new DataTable();

                string consulta = @"
                    SELECT
                        FechaRuta,
                        EstadoPunto1,
                        EstadoPunto2,
                        EstadoPunto3
                    FROM dbo.ProgramacionRutas
                    WHERE idProgramacion = @idProgramacion";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idProgramacion", SqlDbType.Int).Value = idProgramacion;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerEstadosPuntos de ConductorDAO.", ex);
            }
        }

        public DataTable ObtenerPuntosRuta(int idProgramacion)
        {
            try
            {
                DataTable tabla = new DataTable();

                string consulta = @"
                    SELECT
                        R.PuntoOrigen,
                        R.DestinoA,
                        R.PuntoFinal
                    FROM dbo.ProgramacionRutas PR
                    INNER JOIN dbo.Rutas R
                        ON R.idRuta = PR.idRuta
                    WHERE PR.idProgramacion = @idProgramacion";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idProgramacion", SqlDbType.Int).Value = idProgramacion;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerPuntosRuta de ConductorDAO.", ex);
            }
        }

        public void ActualizarEntregaProducto(int idAsignacion, bool entregado)
        {
            try
            {
                string consulta = @"
                    UPDATE A
                    SET Entregado = @Entregado
                    FROM dbo.AsignacionPedidosRuta A
                    INNER JOIN dbo.ProgramacionRutas PR
                        ON PR.idProgramacion = A.idProgramacion
                    WHERE A.idAsignacion = @idAsignacion
                      AND PR.FechaRuta = CAST(GETDATE() AS DATE)";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@Entregado", SqlDbType.Bit).Value = entregado;
                    comando.Parameters.Add("@idAsignacion", SqlDbType.Int).Value = idAsignacion;

                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    if (comando.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No se encontró la asignación del producto.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ActualizarEntregaProducto de ConductorDAO.", ex);
            }
        }

        public bool EsRutaDelDia(int idProgramacion)
        {
            try
            {
                string consulta = @"
                    SELECT COUNT(1)
                    FROM dbo.ProgramacionRutas
                    WHERE idProgramacion = @idProgramacion
                      AND FechaRuta = CAST(GETDATE() AS DATE)";

                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idProgramacion", SqlDbType.Int).Value = idProgramacion;

                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    return Convert.ToInt32(comando.ExecuteScalar()) > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en EsRutaDelDia de ConductorDAO.", ex);
            }
        }
    }
}