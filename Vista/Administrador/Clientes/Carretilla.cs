using Modelo.Entidades;

namespace Vista.Administrador.Clientes
{
    public partial class Carretilla : Form
    {
        public Carretilla()
        {
            InitializeComponent();
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
            PedidoDB db = new PedidoDB();

            List<Pedido> pedidos =
                db.ObtenerPedidosPorEstado("Pendiente");

            MostrarPedidos(pedidos);
        }

        private void btnEnProceso_Click(object sender, EventArgs e)
        {
            PedidoDB db = new PedidoDB();

            List<Pedido> pedidos =
                db.ObtenerPedidosPorEstado("En Proceso");

            MostrarPedidos(pedidos);
        }

        private void btnEtregados_Click(object sender, EventArgs e)
        {
            PedidoDB db = new PedidoDB();

            List<Pedido> pedidos =
                db.ObtenerPedidosPorEstado("Entregado");

            MostrarPedidos(pedidos);
        }
    }
}
