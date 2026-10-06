using Modelo.Entidades;

namespace Vista.Administrador.Clientes
{
    public partial class ProductoCard : UserControl
    {
        private Producto producto;

        public ProductoCard(Producto producto)
        {
            InitializeComponent();

            this.producto = producto;

            CargarDatos();
        }

        private void CargarDatos()
        {
            lblNombre.Text = producto.Nombre;

            lblPrecio.Text = "$" + producto.Precio.ToString("0.00");

            if (producto.Foto != null)
            {
                using (MemoryStream ms = new MemoryStream(producto.Foto))
                {
                    picProducto.Image = Image.FromStream(ms);
                }
            }
        }
    }
}