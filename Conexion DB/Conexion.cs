using Microsoft.Data.SqlClient;
namespace Modelo.Conexion_DB
{
    internal class Conexion
    {
        private static string servidor = "(localdb)\\MSSQLLocalDB";
        private static string baseDeDatos = "MyPickup";

        public static SqlConnection Conectar()
        {
            string cadena = $"Data source={servidor};" +
                $"Initial Catalog={baseDeDatos};" +
                $"Integrated Security=true;";
            SqlConnection conectar = new SqlConnection(cadena);
            conectar.Open();
            return conectar;
        }
    }
}
