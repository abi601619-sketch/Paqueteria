
using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using System.Data;



namespace Modelo.Entidades
{
    public class PedidoDB
    {
        public List<Pedido> ObtenerPedidosPorEstado(string estado)
        {
            List<Pedido> lista = new List<Pedido>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerPedidosPorEstado", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Estado", estado);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido();

                            pedido.IdPedido = Convert.ToInt32(reader["IdPedido"]);

                            pedido.FechaPedido = Convert.ToDateTime(reader["FechaPedido"]);

                            pedido.Estado = reader["Estado"].ToString();

                            pedido.Cantidad = Convert.ToInt32(reader["Cantidad"]);

                            pedido.IdProducto = Convert.ToInt32(reader["IdProducto"]);

                            pedido.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                            pedido.IdPuntoEntrega = Convert.ToInt32(reader["IdPuntoEntrega"]);

                            pedido.NombreProducto = reader["NombreProducto"].ToString();

                            pedido.Precio = Convert.ToDecimal(reader["Precio"]);

                            if (reader["Foto"] != DBNull.Value)
                            {
                                pedido.Foto = (byte[])reader["Foto"];
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
                    if (conexion.State != ConnectionState.Open)
                        conexion.Open();

                    using (SqlCommand comando = new SqlCommand("sp_CrearPedido", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cantidad;
                        comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;
                        comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                        comando.Parameters.Add("@IdPuntoEntrega", SqlDbType.Int).Value = idPuntoEntrega;

                        // Ejecutar el procedimiento almacenado.
                        // No depender del número de filas afectadas.
                        comando.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error SQL al crear el pedido:\n" + ex.Message,
                    "Error al registrar pedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }


        public List<Pedido> BuscarPedidos(string texto)
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comando = new SqlCommand("sp_BuscarPedidos", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Texto", texto);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido();

                            pedido.IdPedido = Convert.ToInt32(reader["IdPedido"]);

                            pedido.FechaPedido = Convert.ToDateTime(reader["FechaPedido"]);

                            pedido.Estado = reader["Estado"].ToString();

                            pedido.Cantidad = Convert.ToInt32(reader["Cantidad"]);

                            pedido.IdProducto = Convert.ToInt32(reader["IdProducto"]);

                            pedido.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                            pedido.IdPuntoEntrega = Convert.ToInt32(reader["IdPuntoEntrega"]);

                            pedido.NombreProducto = reader["NombreProducto"].ToString();

                            pedido.Precio = Convert.ToDecimal(reader["Precio"]);

                            if (reader["Foto"] != DBNull.Value)
                            {
                                pedido.Foto = (byte[])reader["Foto"];
                            }

                            pedidos.Add(pedido);
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


