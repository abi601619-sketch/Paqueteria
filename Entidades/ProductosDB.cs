using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;

namespace Modelo.Entidades
{
    public class ProductoDB
    {
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                string sql = @"SELECT idProducto,Nombre,Foto,Precio,Descripcion,Stock,LugarOrigen,idCategoria
                               FROM Productos";

                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();

                        producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                        producto.Nombre = reader["Nombre"].ToString();
                        producto.Precio = Convert.ToDecimal(reader["Precio"]);
                        producto.Descripcion = reader["Descripcion"] == DBNull.Value ? "" : reader["Descripcion"].ToString();

                        producto.Stock = Convert.ToInt32(reader["Stock"]);

                        producto.LugarOrigen = reader["LugarOrigen"] == DBNull.Value ? "" : reader["LugarOrigen"].ToString();

                        producto.IdCategoria = Convert.ToInt32(reader["idCategoria"]);

                        if (reader["Foto"] != DBNull.Value)
                        {
                            producto.Foto = (byte[])reader["Foto"];
                        }

                        lista.Add(producto);
                    }
                }
            }

            return lista;
        }



        public List<Producto> ObtenerProductosPorCategoria(int idCategoria)
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                string sql = @"SELECT idProducto,Nombre,Foto,Precio,Descripcion,Stock,LugarOrigen,idCategoria FROM Productos
                       WHERE idCategoria = @idCategoria";

                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();

                            producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                            producto.Nombre = reader["Nombre"].ToString();
                            producto.Precio = Convert.ToDecimal(reader["Precio"]);

                            producto.Descripcion = reader["Descripcion"] == DBNull.Value ? "" : reader["Descripcion"].ToString();

                            producto.Stock = Convert.ToInt32(reader["Stock"]);

                            producto.LugarOrigen = reader["LugarOrigen"] == DBNull.Value ? "" : reader["LugarOrigen"].ToString();

                            producto.IdCategoria = Convert.ToInt32(reader["idCategoria"]);

                            if (reader["Foto"] != DBNull.Value)
                            {
                                producto.Foto = (byte[])reader["Foto"];
                            }

                            lista.Add(producto);
                        }
                    }
                }
            }

            return lista;
        }


        public List<Producto> BuscarProductos(string texto)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                string consulta = @"
            SELECT 
                idProducto,
                Nombre,
                Precio,
                IdCategoria,
                Descripcion,
                Stock,
                LugarOrigen
            FROM Productos
            WHERE Nombre LIKE @Texto
               OR LugarOrigen LIKE @Texto";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["idProducto"]),
                                Nombre = reader["Nombre"].ToString(),
                                Precio = Convert.ToDecimal(reader["Precio"]),
                                IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                LugarOrigen = reader["LugarOrigen"].ToString()
                            });
                        }
                    }
                }
            }

            return productos;
        }



        public class Producto
        {
            public int IdProducto { get; set; }

            public string Nombre { get; set; } = string.Empty;

            public byte[] Foto { get; set; }

            public decimal Precio { get; set; }

            public string Descripcion { get; set; } = string.Empty;

            public int Stock { get; set; }

            public string LugarOrigen { get; set; } = string.Empty;

            public int IdCategoria { get; set; }
        }
    }
}