using Microsoft.Data.SqlClient;
using Modelo.Conexion_DB;
using System.Data;

namespace Modelo.Entidades
{
    public class Usuario
    {
        private int idUsuario;

        private string dui;

        private string nombre;

        private string apellido;

        private string correo;

        private string contrasena;

        private byte[] fotoPerfil;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public byte[] FotoPerfil { get => fotoPerfil; set => fotoPerfil = value; }

        public bool RegistrarCliente(string dui, string nombre, string apellido, string correo, string contrasena, byte[] fotoPerfil)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {

                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        // 1. Verificar si el correo ya existe

                        string verificarCorreo = @"SELECT COUNT(*) FROM Usuarios WHERE correo = @correo";

                        using (SqlCommand cmdVerificar = new SqlCommand(verificarCorreo, cn, transaccion))
                        {
                            cmdVerificar.Parameters.AddWithValue("@correo", correo);

                            int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                            if (existe > 0)
                            {
                                transaccion.Rollback();
                                return false;
                            }
                        }

                        // 2. Insertar usuario

                        string insertarUsuario = @"INSERT INTO Usuarios(dui,nombre,apellido,correo,contrasena,fotoPerfil)
                            VALUES(@dui,@nombre,@apellido,@correo,@contrasena,@fotoPerfil);
                            SELECT SCOPE_IDENTITY();";

                        int idUsuario;

                        using (SqlCommand cmdUsuario = new SqlCommand(insertarUsuario, cn, transaccion))
                        {
                            cmdUsuario.Parameters.AddWithValue("@dui", string.IsNullOrWhiteSpace(dui) ? (object)DBNull.Value : dui);

                            cmdUsuario.Parameters.AddWithValue("@nombre", nombre);

                            cmdUsuario.Parameters.AddWithValue("@apellido", apellido);

                            cmdUsuario.Parameters.AddWithValue("@correo", correo);

                            cmdUsuario.Parameters.AddWithValue("@contrasena", contrasena);

                            cmdUsuario.Parameters.Add("@fotoPerfil", SqlDbType.VarBinary, -1).Value = fotoPerfil != null ? (object)fotoPerfil : DBNull.Value;

                            idUsuario = Convert.ToInt32(cmdUsuario.ExecuteScalar());
                        }

                        // 3. Registrar como CLIENTE

                        string insertarCliente = @"INSERT INTO Clientes (idUsuario)
                            VALUES (@idUsuario)";

                        using (SqlCommand cmdCliente = new SqlCommand(insertarCliente, cn, transaccion))
                        {
                            cmdCliente.Parameters.AddWithValue("@idUsuario", idUsuario);

                            cmdCliente.ExecuteNonQuery();
                        }

                        // 4. Confirmar

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
        }
    }
}
