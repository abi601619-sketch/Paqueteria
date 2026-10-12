using Microsoft.Data.SqlClient;
namespace Modelo.Conexion_DB
{
    public class Conexion
    {
        private static string servidor = "Johnny\\SQLEXPRESS";
        private static string baseDeDatos = "MyPickup12";

        public static SqlConnection Conectar()
        {
            string cadena = $"Data source={servidor};" +
                $"Initial Catalog={baseDeDatos};" +
                $"Integrated Security=true;" +
                $"TrustServerCertificate=True;";
            SqlConnection conectar = new SqlConnection(cadena);
            conectar.Open();
            return conectar;
        }
    }
}
