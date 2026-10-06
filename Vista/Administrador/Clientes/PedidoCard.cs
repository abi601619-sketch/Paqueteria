namespace Vista.Administrador.Clientes
{
    public partial class PedidoCard : UserControl
    {
        private Pedido pedido;

        public PedidoCard(Pedido pedido)
        {
            InitializeComponent();

            this.pedido = pedido;

            this.Width = 220;
            this.Height = 260;

            CargarDatos();
        }

        private void CargarDatos()
        {
            lblNombre.Text = pedido.NombreProducto;

            lblCantidad.Text = "Cantidad: " + pedido.Cantidad;

            lblPrecio.Text = "Precio: $" +
                             pedido.Precio.ToString("0.00");

            lblFecha.Text = "Fecha: " +
                            pedido.FechaPedido.ToString("dd/MM/yyyy");

            lblEstado.Text = pedido.Estado;

            if (pedido.Estado == "Pendiente")
            {
                lblEstado.BackColor = Color.Orange;
                lblEstado.ForeColor = Color.White;
            }
            else if (pedido.Estado == "En Proceso")
            {
                lblEstado.BackColor = Color.MediumPurple;
                lblEstado.ForeColor = Color.White;
            }
            else if (pedido.Estado == "Entregado")
            {
                lblEstado.BackColor = Color.SeaGreen;
                lblEstado.ForeColor = Color.White;
            }
            if (pedido.Foto != null && pedido.Foto.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(pedido.Foto))
                {
                    picProducto.Image = Image.FromStream(ms);
                }
            }
        }
    }
}