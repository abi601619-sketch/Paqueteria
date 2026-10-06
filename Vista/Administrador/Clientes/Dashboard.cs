using Modelo.Entidades;

namespace Vista.Administrador.Clientes
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void AbrirFormulario(Form formulario)
        {
            panelContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);
            panelContenido.Tag = formulario;

            formulario.Show();
            formulario.BringToFront();
        }
        private Inicio inicioForm = new Inicio();
        private Dashboard DashForm = new Dashboard();
        private Carretilla CarretillaForm = new Carretilla();



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(inicioForm);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CargarProductos()
        {
            ProductoDB db = new ProductoDB();

            List<Producto> productos = db.ObtenerProductos();

            flpProductos.Controls.Clear();

            foreach (Producto producto in productos)
            {
                ProductoCard card = new ProductoCard(producto);

                flpProductos.Controls.Add(card);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(DashForm);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario(CarretillaForm);

        }
    }
}
