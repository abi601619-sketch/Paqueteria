using Modelo.Entidades;

namespace Vista.Administrador.Clientes
{
    public partial class Carretilla : Form
    {
        public Carretilla()
        {
            InitializeComponent();
        }

        private void AplicarDiseño()
        {
            Color gris = ColorTranslator.FromHtml("#F0F0F2");

            // Pendientes
            btnPendientes.FillColor = gris;
            btnPendientes.ForeColor = Color.FromArgb(40, 40, 40);
            btnPendientes.BorderRadius = 10;

            // En proceso
            btnEnProceso.FillColor = gris;
            btnEnProceso.ForeColor = Color.FromArgb(40, 40, 40);
            btnEnProceso.BorderRadius = 10;

            // Entregados
            btnEtregados.FillColor = gris;
            btnEtregados.ForeColor = Color.FromArgb(40, 40, 40);
            btnEtregados.BorderRadius = 10;

            flpPedidos.BackColor = Color.White;
        }

        private void SeleccionarBoton(Guna.UI2.WinForms.Guna2Button boton, string color)
        {
            Color gris = ColorTranslator.FromHtml("#F0F0F2");

            // Todos vuelven a gris
            btnPendientes.FillColor = gris;
            btnEnProceso.FillColor = gris;
            btnEtregados.FillColor = gris;

            btnPendientes.ForeColor = Color.FromArgb(40, 40, 40);
            btnEnProceso.ForeColor = Color.FromArgb(40, 40, 40);
            btnEtregados.ForeColor = Color.FromArgb(40, 40, 40);

            // Botón seleccionado
            boton.FillColor = ColorTranslator.FromHtml(color);
            boton.ForeColor = Color.White;
        }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
        private void MostrarPedidos(List<Pedido> pedidos)
        {
            flpPedidos.Controls.Clear();

            foreach (Pedido pedido in pedidos)
            {
                PedidoCard card = new PedidoCard(pedido);

                flpPedidos.Controls.Add(card);
            }
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnPendientes, "#F51B23");

            PedidoDB db = new PedidoDB();

            List<Pedido> pedidos = db.ObtenerPedidosPorEstado("Pendiente");

            MostrarPedidos(pedidos);
        }

        private void btnEnProceso_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEnProceso, "#7B18D8");

            PedidoDB db = new PedidoDB();

            List<Pedido> pedidos = db.ObtenerPedidosPorEstado("En Proceso");

            MostrarPedidos(pedidos);
        }

        private void btnEtregados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEtregados, "#FFBF16");

            PedidoDB db = new PedidoDB();

            List<Pedido> pedidos = db.ObtenerPedidosPorEstado("Entregado");

            MostrarPedidos(pedidos);
        }

        private void Carretilla_Load(object sender, EventArgs e)
        {
            AplicarDiseño();
            DiseñarBarraBusqueda();

            // Cargar pedidos pendientes inicialmente
            btnPendientes.PerformClick();

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
            txtBuscar.PlaceholderForeColor = Color.FromArgb(140, 140, 140);

            txtBuscar.BorderRadius = 18;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            PedidoDB db = new PedidoDB();

            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                List<Pedido> pedidos =
                    db.ObtenerPedidosPorEstado("Pendiente");

                MostrarPedidos(pedidos);
                return;
            }

            List<Pedido> resultados =
                db.BuscarPedidos(txtBuscar.Text);

            MostrarPedidos(resultados);

        }
    }
}
