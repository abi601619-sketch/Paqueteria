
using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;



namespace Modelo.Entidades
{
    public class PedidoDB
    {
        public List<Pedido> ObtenerPedidosPorEstado(string estado)
        {
            List<Pedido> lista = new List<Pedido>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                string sql = @"SELECT
                                    dp.idPedido,
                                    dp.FechaPedido,
                                    dp.Estado,
                                    dp.Cantidad,
                                    dp.idProducto,
                                    dp.idUsuario,
                                    dp.idPuntoEntrega,
                                    p.Nombre,
                                    p.Precio,
                                    p.Foto
                               FROM DetallePedidos dp
                               INNER JOIN Productos p
                                   ON dp.idProducto = p.idProducto
                               WHERE dp.Estado = @Estado";

                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@Estado", estado);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido();

                            pedido.IdPedido =
                                Convert.ToInt32(reader["idPedido"]);

                            pedido.FechaPedido =
                                Convert.ToDateTime(reader["FechaPedido"]);

                            pedido.Estado =
                                reader["Estado"].ToString();

                            pedido.Cantidad =
                                Convert.ToInt32(reader["Cantidad"]);

                            pedido.IdProducto =
                                Convert.ToInt32(reader["idProducto"]);

                            pedido.IdUsuario =
                                Convert.ToInt32(reader["idUsuario"]);

                            pedido.IdPuntoEntrega =
                                Convert.ToInt32(reader["idPuntoEntrega"]);

                            pedido.NombreProducto =
                                reader["Nombre"].ToString();

                            pedido.Precio =
                                Convert.ToDecimal(reader["Precio"]);

                            if (reader["Foto"] != DBNull.Value)
                            {
                                pedido.Foto =
                                    (byte[])reader["Foto"];
                            }

                            lista.Add(pedido);
                        }
                    }
                }
            }

            return lista;
        }



        public bool CrearPedido(int cantidad, int idProducto, int idUsuario, int idPuntoEntrega)
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    string consulta = @"
                INSERT INTO DetallePedidos
                (
                    FechaPedido,
                    Estado,
                    Cantidad,
                    idProducto,
                    idUsuario,
                    idPuntoEntrega
                )
                VALUES
                (
                    GETDATE(),
                    'Pendiente',
                    @Cantidad,
                    @IdProducto,
                    @IdUsuario,
                    @IdPuntoEntrega
                )";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@Cantidad", cantidad);

                        comando.Parameters.AddWithValue(
                            "@IdProducto", idProducto);

                        comando.Parameters.AddWithValue(
                            "@IdUsuario", idUsuario);

                        comando.Parameters.AddWithValue(
                            "@IdPuntoEntrega", idPuntoEntrega);

                        conexion.Open();

                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        public List<Pedido> BuscarPedidos(string texto)
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                string consulta = @"SELECT * FROM VerPedidos
            WHERE NombreProducto LIKE @Texto";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedidos.Add(new Pedido
                            {
                                IdPedido = Convert.ToInt32(reader["IdPedido"]),
                                FechaPedido = Convert.ToDateTime(reader["FechaPedido"]),
                                Estado = reader["Estado"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                                IdPuntoEntrega = Convert.ToInt32(reader["IdPuntoEntrega"]),
                                NombreProducto = reader["NombreProducto"].ToString(),
                                Precio = Convert.ToDecimal(reader["Precio"]),

                            });
                        }
                    }
                }
            }

            return pedidos;
        }
    }





    public class Pedido
    {
        public int IdPedido { get; set; }

        public DateTime FechaPedido { get; set; }

        public string Estado { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public int IdProducto { get; set; }

        public int IdUsuario { get; set; }

        public int IdPuntoEntrega { get; set; }

        // Información del producto
        public string NombreProducto { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public byte[] Foto { get; set; }
    }
}


