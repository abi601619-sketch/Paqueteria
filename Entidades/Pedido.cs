
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


