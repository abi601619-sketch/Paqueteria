using Modelo.Entidades;

namespace Vista.Administrador.Clientes
{
    public partial class PedidoCard : UserControl
    {
        private Pedido pedido;

        public PedidoCard(Pedido pedido)
        {
            InitializeComponent();

            this.pedido = pedido;


            DiseñarCard();
            CargarDatos();
        }

        private void DiseñarCard()
        {
            this.BackColor = Color.White;

            this.BorderStyle = BorderStyle.FixedSingle;

            // Imagen
            picProducto.SizeMode = PictureBoxSizeMode.Zoom;
            picProducto.BackColor = Color.White;

            // Nombre
            lblNombre.ForeColor = ColorTranslator.FromHtml("#55240E");
            lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Cantidad
            lblCantidad.ForeColor = Color.FromArgb(80, 80, 80);

            // Precio
            lblPrecio.ForeColor = ColorTranslator.FromHtml("#55240E");

            lblPrecio.Font = new Font(
                "Segoe UI",
                10,
                FontStyle.Bold
            );

            // Fecha
            lblFecha.ForeColor = Color.FromArgb(120, 120, 120);

            // Estado
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;

            lblEstado.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblEstado.AutoSize = false;
            lblEstado.Width = 100;
            lblEstado.Height = 30;
        }

        private void CargarDatos()
        {
            lblNombre.Text = pedido.NombreProducto;

            lblCantidad.Text =
                "Cantidad: " + pedido.Cantidad;

            lblPrecio.Text =
                "Precio: $" +
                pedido.Precio.ToString("0.00");

            lblFecha.Text =
                "Fecha: " +
                pedido.FechaPedido.ToString("dd/MM/yyyy");

            lblEstado.Text = pedido.Estado;

            DiseñarEstado();

            CargarImagen();
        }

        private void DiseñarEstado()
        {
            if (pedido.Estado == "Pendiente")
            {
                lblEstado.BackColor = Color.FromArgb(245, 27, 35);

                lblEstado.ForeColor = Color.White;
            }
            else if (pedido.Estado == "En Proceso")
            {
                lblEstado.BackColor = Color.FromArgb(123, 24, 216);

                lblEstado.ForeColor = Color.White;
            }
            else if (pedido.Estado == "Entregado")
            {
                lblEstado.BackColor = Color.SeaGreen;

                lblEstado.ForeColor = Color.White;
            }
        }

        private void CargarImagen()
        {
            string carpetaImagenes = Path.Combine(
                Directory.GetParent(
                    AppContext.BaseDirectory
                ).Parent.Parent.Parent.FullName,
                "Administrador",
                "Clientes",
                "Imagenes"
            );

            string nombreImagen =
                ObtenerNombreImagen(pedido.IdProducto);

            if (string.IsNullOrEmpty(nombreImagen))
                return;

            string rutaImagen =
                Path.Combine(
                    carpetaImagenes,
                    nombreImagen
                );

            if (File.Exists(rutaImagen))
            {
                using (Image imagen =
                       Image.FromFile(rutaImagen))
                {
                    picProducto.Image =
                        new Bitmap(imagen);
                }
            }
        }

        private string ObtenerNombreImagen(int idProducto)
        {
            switch (idProducto)
            {
                case 1: return "detergente en polvo.jpeg";
                case 2: return "jabon liquido.jpeg";
                case 3: return "cloro.jpeg";
                case 4: return "desinfectante.jpeg";
                case 5: return "limpia vidrios.jpeg";
                case 6: return "suavizante.jpeg";
                case 7: return "esponja.jpeg";
                case 8: return "escoba.jpeg";
                case 9: return "trapeador.jpeg";
                case 10: return "recolector.jpeg";
                case 11: return "guantes limpieza.jpeg";
                case 12: return "bolsa grande.jpeg";
                case 13: return "papel higienico.jpeg";
                case 14: return "toallas.jpeg";
                case 15: return "limpiador maestro.jpeg";
                case 16: return "cepillo de baño.jpeg";
                case 17: return "jabon de manos.jpeg";
                case 18: return "aromatizante.jpeg";
                case 19: return "limpiador de cocina.jpeg";
                case 20: return "cera de pisos.jpeg";
                case 21: return "audifonos bloot.jpeg";
                case 22: return "teclado inalambrico.jpeg";
                case 23: return "mouse 2.jpeg";
                case 24: return "tarjeta de 64.jpeg";
                case 25: return "terjeta de 128.jpeg";
                case 26: return "cargador.jpeg";
                case 27: return "cable.jpeg";
                case 28: return "bateria.jpeg";
                case 29: return "bocina.jpeg";
                case 30: return "camara.jpeg";
                case 31: return "hub usb.jpeg";
                case 32: return "soporte.jpeg";
                case 33: return "mouse 2.jpeg";
                case 34: return "adaptador hdmi.jpeg";
                case 35: return "cable hdmi.jpeg";
                case 36: return "lampara.jpeg";
                case 37: return "reloj.jpeg";
                case 38: return "calculadora.jpeg";
                case 39: return "microfono.jpeg";
                case 40: return "disco duro.jpeg";
                case 41: return "camiseta negra.jpeg";
                case 42: return "camiseta balnca.jpeg";
                case 43: return "pantalon.jpeg";
                case 44: return "sudadera.jpeg";
                case 45: return "chaqueta.jpeg";
                case 46: return "gorra.jpeg";
                case 47: return "calcetines.jpeg";
                case 48: return "manga larga.jpeg";
                case 49: return "manga corta.jpeg";
                case 50: return "short.jpeg";
                case 51: return "pantalon deportivo.jpeg";
                case 52: return "vestido.jpeg";
                case 53: return "blusa.jpeg";
                case 54: return "sueter tejido.jpeg";
                case 55: return "invierno.jpeg";
                case 56: return "pijama.jpeg";
                case 57: return "ropa deportiva.jpeg";
                case 58: return "zandalias.jpeg";
                case 59: return "tenis.jpeg";
                case 60: return "mochila.jpeg";

                default:
                    return null;
            }
        }
    }
}