using Modelo.Entidades;
namespace Vista.Administrador.Clientes
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
        private void MostrarProductos(List<Producto> productos)
        {
            flpProductos.Controls.Clear();

            foreach (Producto producto in productos)
            {
                ProductoCard card = new ProductoCard(producto);

                flpProductos.Controls.Add(card);
            }
        }

        private void CargarCategoria(int idCategoria)
        {
            ProductoDB db = new ProductoDB();

            List<Producto> productos = db.ObtenerProductosPorCategoria(idCategoria);

            MostrarProductos(productos);
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            CargarCategoria(1);
        }

        private void btnTecnologia_Click(object sender, EventArgs e)
        {
            CargarCategoria(2);
        }

        private void btnRopa_Click(object sender, EventArgs e)
        {
            CargarCategoria(3);
        }
    }
}
