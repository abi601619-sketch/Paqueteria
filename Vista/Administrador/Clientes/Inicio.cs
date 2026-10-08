using Modelo.Entidades;
using static Modelo.Entidades.ProductoDB;
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
            ProductoDB db = new ProductoDB();

            List<Producto> productos = db.BuscarProductos(txtBuscar.Text);

            MostrarProductos(productos);
        }


        private void Inicio_Load(object sender, EventArgs e)
        {

            AplicarDiseñoCategorias();
            DiseñarBarraBusqueda();

            // Cargar productos de Limpieza
            CargarCategoria(1);
            // Marcar Limpieza como seleccionada
            SeleccionarCategoria(btnLimpieza);

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
            SeleccionarCategoria(btnLimpieza);
        }

        private void btnTecnologia_Click(object sender, EventArgs e)
        {
            CargarCategoria(2);
            SeleccionarCategoria(btnTecnologia);
        }

        private void btnRopa_Click(object sender, EventArgs e)
        {
            CargarCategoria(3);
            SeleccionarCategoria(btnRopa);
        }

        private void AplicarDiseñoCategorias()
        {
            Color gris = ColorTranslator.FromHtml("#F0F0F2");

            btnLimpieza.FillColor = gris;
            btnLimpieza.ForeColor = Color.FromArgb(40, 40, 40);
            btnLimpieza.BorderRadius = 10;

            btnTecnologia.FillColor = gris;
            btnTecnologia.ForeColor = Color.FromArgb(40, 40, 40);
            btnTecnologia.BorderRadius = 10;

            btnRopa.FillColor = gris;
            btnRopa.ForeColor = Color.FromArgb(40, 40, 40);
            btnRopa.BorderRadius = 10;
        }

        private void SeleccionarCategoria(Guna.UI2.WinForms.Guna2Button boton)
        {
            Color gris = ColorTranslator.FromHtml("#F0F0F2");
            Color rojo = ColorTranslator.FromHtml("#F51B23");

            btnLimpieza.FillColor = gris;
            btnTecnologia.FillColor = gris;
            btnRopa.FillColor = gris;

            btnLimpieza.ForeColor = Color.FromArgb(40, 40, 40);
            btnTecnologia.ForeColor = Color.FromArgb(40, 40, 40);
            btnRopa.ForeColor = Color.FromArgb(40, 40, 40);

            boton.FillColor = rojo;
            boton.ForeColor = Color.White;
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

    }
}
