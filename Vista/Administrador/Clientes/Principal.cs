using Modelo.Entidades;
using static Modelo.Entidades.ProductoDB;

namespace Vista.Administrador.Clientes
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            DiseñarBarraBusqueda();
        }
        private void CargarProductos(List<Producto> productos)
        {
            flpProductos.Controls.Clear();

            foreach (Producto producto in productos)
            {
                ProductoCard card = new ProductoCard(producto);

                flpProductos.Controls.Add(card);
            }
        }
        private void DiseñarBarraBusqueda()
        {
            txtBuscar.FillColor = Color.White;
            txtBuscar.ForeColor = Color.FromArgb(50, 50, 50);

            // Estado normal
            txtBuscar.BorderColor = Color.FromArgb(220, 220, 220);
            txtBuscar.BorderThickness = 1;

            // Cuando haces clic: solo cambiar color (BorderThickness no existe en FocusedState)
            txtBuscar.FocusedState.BorderColor = ColorTranslator.FromHtml("#55240E");

            // Cuando quitas el cursor
            txtBuscar.HoverState.BorderColor = ColorTranslator.FromHtml("#55240E");

            txtBuscar.PlaceholderText = "BUSCAR PRODUCTO";
            txtBuscar.PlaceholderForeColor =
                Color.FromArgb(140, 140, 140);

            txtBuscar.BorderRadius = 18;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ProductoDB db = new ProductoDB();

            List<Producto> productos = db.ObtenerProductos();

            CargarProductos(productos);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ProductoDB db = new ProductoDB();

            List<Producto> productos = db.BuscarProductos(txtBuscar.Text);

            CargarProductos(productos);
        }
    }
}
