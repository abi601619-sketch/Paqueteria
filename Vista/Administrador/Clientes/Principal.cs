using Modelo.Entidades;
using static Modelo.Entidades.ProductoDB;

namespace Vista.Administrador.Clientes
{
    public partial class Principal : Form
    {
        private Usuario usuarioActual;
        private List<Producto> productosFiltrados = new List<Producto>();
        private int indiceActual = 0;
        private const int TAMANO_PAGINA = 12;
        private bool mostrandoTodos = false;
        public Principal(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            DiseñarBarraBusqueda();
        }
        private void ConfigurarPanelProductos()
        {
            flpProductos.AutoScroll = true;
            flpProductos.WrapContents = true;
            flpProductos.FlowDirection = FlowDirection.LeftToRight;
            flpProductos.Padding = new Padding(15);
            flpProductos.BackColor = ColorTranslator.FromHtml("#F3F1EF");

            flpProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void CargarProductos(List<Producto> productos)
        {
            productosFiltrados = productos ?? new List<Producto>();
            indiceActual = 0;
            mostrandoTodos = false;

            flpProductos.Controls.Clear();

            CargarSiguientePagina();
        }

        private void CargarSiguientePagina()
        {
            int limite = Math.Min(
                indiceActual + TAMANO_PAGINA,
                productosFiltrados.Count
            );

            for (int i = indiceActual; i < limite; i++)
            {
                ProductoCard card = new ProductoCard(
                    productosFiltrados[i],
                    usuarioActual
                );

                flpProductos.Controls.Add(card);
            }

            indiceActual = limite;

            // Si hay más de 12 productos, mostrar el botón.
            btnVerMas.Visible = productosFiltrados.Count > TAMANO_PAGINA;

            // Mostrar "Ver menos" cuando ya se cargaron todos.
            mostrandoTodos = indiceActual >= productosFiltrados.Count;

            btnVerMas.Text = mostrandoTodos
                ? "↑ Ver menos productos"
                : "↓ Ver más productos";
        }

        private void btnVerMas_Click(object sender, EventArgs e)
        {
            if (mostrandoTodos)
            {
                // Volver a los primeros 12 productos.
                indiceActual = 0;
                mostrandoTodos = false;

                flpProductos.Controls.Clear();

                CargarSiguientePagina();
            }
            else
            {
                // Agregar los siguientes 12 productos.
                CargarSiguientePagina();
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

            CargarProductos(db.ObtenerProductos());
            ConfigurarPanelProductos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ProductoDB db = new ProductoDB();

            List<Producto> productos = db.BuscarProductos(txtBuscar.Text.Trim());

            CargarProductos(productos);
        }


    }
}
