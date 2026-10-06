using Modelo.Entidades;

namespace Vista.Administrador.Clientes
{
    public partial class frmProductos : Form
    {

        public frmProductos()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            CargarDatos();
        }
        private Producto producto;

        private void CargarDatos()
        {
            lblNombre.Text = producto.Nombre;

            lblPrecio.Text = "$" + producto.Precio.ToString("0.00");


            cmbLugarOrigen.Text =
                producto.LugarOrigen;

            lblDescripcion.Text =
                producto.Descripcion;

            lblCantidadValor.Text = "1";
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            lblNombre.ForeColor = ColorTranslator.FromHtml("#111111");

            lblNombre.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTipo.ForeColor =
    ColorTranslator.FromHtml("#F51B23");

            lblTipo.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Bold
            );
            lblPrecio.ForeColor =
    ColorTranslator.FromHtml("#F51B23");

            lblPrecio.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold
            );
            cmbPuntoEntrega.BorderColor =
    ColorTranslator.FromHtml("#D9D9D9");

            cmbPuntoEntrega.BorderRadius = 8;

            cmbPuntoEntrega.FillColor = Color.White;

            cmbPuntoEntrega.ForeColor =
                Color.FromArgb(50, 50, 50);
            btnMenos.FillColor =
    ColorTranslator.FromHtml("#F0F0F2");

            btnMenos.ForeColor =
                Color.FromArgb(40, 40, 40);

            btnMenos.BorderRadius = 8;

            btnMas.FillColor =
    ColorTranslator.FromHtml("#F0F0F2");

            btnMas.ForeColor =
                Color.FromArgb(40, 40, 40);

            btnMas.BorderRadius = 8;

            lblCantidadValor.Text = "1";

            lblCantidadValor.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            lblCantidadValor.ForeColor =
                Color.FromArgb(40, 40, 40);

            btnComprar.Text = "COMPRAR";

            btnComprar.FillColor =
                ColorTranslator.FromHtml("#F51B23");

            btnComprar.ForeColor = Color.White;

            btnComprar.BorderRadius = 8;

            btnComprar.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            btnComprar.HoverState.FillColor =
                ColorTranslator.FromHtml("#D9141B");

            btnCerrar.Text = "✕";

            btnCerrar.FillColor = Color.Transparent;

            btnCerrar.ForeColor =
                Color.FromArgb(30, 30, 30);

            btnCerrar.HoverState.FillColor =
                Color.FromArgb(240, 240, 240);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(lblCantidadValor.Text);

            cantidad++;

            lblCantidadValor.Text = cantidad.ToString();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            int cantidad =
        int.Parse(lblCantidadValor.Text);

            if (cantidad > 1)
            {
                cantidad--;
            }

            lblCantidadValor.Text = cantidad.ToString();
        }
    }
}
