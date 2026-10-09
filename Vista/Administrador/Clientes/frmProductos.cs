using Modelo.Entidades;
using static Modelo.Entidades.ProductoDB;
using static Modelo.Entidades.PuntosEntregaDB;

namespace Vista.Administrador.Clientes
{
    public partial class frmProductos : Form
    {
        private Producto producto;
        private Usuario usuarioActual;

        public frmProductos(Producto producto, Usuario usuario)
        {
            InitializeComponent();

            this.producto = producto;
            this.usuarioActual = usuario;

            CargarDatos();
        }

        private void CargarDatos()
        {
            lblNombre.Text = producto.Nombre;

            lblLugarOrigen.Text = producto.LugarOrigen;

            lblTipo.Text = ObtenerNombreCategoria(producto.IdCategoria.ToString());

            lblPrecio.Text = "$" + producto.Precio.ToString("0.00");

            lblLugarOrigen.Text = producto.LugarOrigen;

            lblDescripcion.Text = producto.Descripcion;

            lblCantidadValor.Text = "1";
            CargarImagen();
        }
        private string ObtenerNombreCategoria(string categoria)
        {
            switch (categoria)
            {
                case "1":
                    return "Limpieza";

                case "2":
                    return "Tecnología";

                case "3":
                    return "Ropa";

                default:
                    return "Sin categoría";
            }
        }

        private void CargarImagen()
        {
            string carpetaImagenes = Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName, "Administrador", "Clientes", "Imagenes");

            string nombreImagen =
                ObtenerNombreImagen(producto.IdProducto);

            if (string.IsNullOrEmpty(nombreImagen))
                return;

            string rutaImagen = Path.Combine(carpetaImagenes, nombreImagen);

            if (File.Exists(rutaImagen))
            {
                using (Image imagen = Image.FromFile(rutaImagen))
                {
                    picProducto.Image = new Bitmap(imagen);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la imagen:\n\n" + rutaImagen, "Imagen no encontrada");
            }
        }

        private string ObtenerNombreImagen(int idProducto)
        {
            switch (idProducto)
            {
                case 1:
                    return "detergente en polvo.jpeg";
                case 2:
                    return "jabon liquido.jpeg";

                case 3:
                    return "cloro.jpeg";

                case 4:
                    return "desinfectante.jpeg";

                case 5:
                    return "limpia vidrios.jpeg";

                case 6:
                    return "suavizante.jpeg";

                case 7:
                    return "esponja.jpeg";

                case 8:
                    return "escoba.jpeg";

                case 9:
                    return "trapeador.jpeg";

                case 10:
                    return "recolector.jpeg";

                case 11:
                    return "guantes limpieza.jpeg";

                case 12:
                    return "bolsa grande.jpeg";

                case 13:
                    return "papel higienico.jpeg";

                case 14:
                    return "toallas.jpeg";

                case 15:
                    return "limpiador maestro.jpeg";
                case 16:
                    return "cepillo de baño.jpeg";

                case 17:
                    return "jabon de manos.jpeg";
                case 18:
                    return "aromatizante.jpeg";
                case 19:
                    return "limpiador de cocina.jpeg";

                case 20:
                    return "cera de pisos.jpeg";

                case 21:
                    return "audifonos bloot.jpeg";

                case 22:
                    return "teclado inalambrico.jpeg";

                case 23:
                    return "mouse 2.jpeg";

                case 24:
                    return "tarjeta de 64.jpeg";

                case 25:
                    return "terjeta de 128.jpeg";

                case 26:
                    return "cargador.jpeg";

                case 27:
                    return "cable.jpeg";

                case 28:
                    return "bateria.jpeg";

                case 29:
                    return "bocina.jpeg";

                case 30:
                    return "camara.jpeg";

                case 31:
                    return "hub usb.jpeg";

                case 32:
                    return "soporte.jpeg";
                case 33:
                    return "mouse 2.jpeg";

                case 34:
                    return "adaptador hdmi.jpeg";
                case 35:
                    return "cable hdmi.jpeg";

                case 36:
                    return "lampara.jpeg";

                case 37:
                    return "reloj.jpeg";

                case 38:
                    return "calculadora.jpeg";

                case 39:
                    return "microfono.jpeg";
                case 40:
                    return "disco duro.jpeg";

                case 41:
                    return "camiseta negra.jpeg";
                case 42:
                    return "camiseta balnca.jpeg";

                case 43:
                    return "pantalon.jpeg";

                case 44:
                    return "sudadera.jpeg";
                case 45:
                    return "chaqueta.jpeg";

                case 46:
                    return "gorra.jpeg";
                case 47:
                    return "calcetines.jpeg";

                case 48:
                    return "manga larga.jpeg";

                case 49:
                    return "manga corta.jpeg";

                case 50:
                    return "short.jpeg";

                case 51:
                    return "pantalon deportivo.jpeg";
                case 52:
                    return "vestido.jpeg";

                case 53:
                    return "blusa.jpeg";
                case 54:
                    return "sueter tejido.jpeg";
                case 55:
                    return "invierno.jpeg";

                case 56:
                    return "pijama.jpeg";
                case 57:
                    return "ropa deportiva.jpeg";
                case 58:
                    return "zandalias.jpeg";

                case 59:
                    return "tenis.jpeg";

                case 60:
                    return "mochila.jpeg";

                default:
                    return null;
            }
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarPuntosEntrega();

            lblNombre.ForeColor = ColorTranslator.FromHtml("#111111");

            lblNombre.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTipo.ForeColor = ColorTranslator.FromHtml("#F51B23");

            lblTipo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPrecio.ForeColor = ColorTranslator.FromHtml("#F51B23");

            lblPrecio.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            cmbPuntoEntrega.BorderColor = ColorTranslator.FromHtml("#D9D9D9");

            cmbPuntoEntrega.BorderRadius = 8;

            cmbPuntoEntrega.FillColor = Color.White;

            cmbPuntoEntrega.ForeColor = Color.FromArgb(50, 50, 50);
            btnMenos.FillColor = ColorTranslator.FromHtml("#F0F0F2");

            btnMenos.ForeColor = Color.FromArgb(40, 40, 40);

            btnMenos.BorderRadius = 8;

            btnMas.FillColor = ColorTranslator.FromHtml("#F0F0F2");

            btnMas.ForeColor = Color.FromArgb(40, 40, 40);

            btnMas.BorderRadius = 8;

            lblCantidadValor.Text = "1";

            lblCantidadValor.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            lblCantidadValor.ForeColor = Color.FromArgb(40, 40, 40);

            btnComprar.Text = "COMPRAR";

            btnComprar.FillColor = ColorTranslator.FromHtml("#F51B23");

            btnComprar.ForeColor = Color.White;

            btnComprar.BorderRadius = 8;

            btnComprar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            btnComprar.HoverState.FillColor = ColorTranslator.FromHtml("#D9141B");


            btnCerrar.FillColor = Color.Transparent;

            btnCerrar.ForeColor = Color.FromArgb(30, 30, 30);

            btnCerrar.HoverState.FillColor = Color.FromArgb(240, 240, 240);
            btnComprar.BorderRadius = 8;
            btnComprar.FillColor = ColorTranslator.FromHtml("#F51B23");
            btnComprar.HoverState.FillColor = ColorTranslator.FromHtml("#D9141B");
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

        private void CargarPuntosEntrega()
        {
            PuntosEntregaDB db = new PuntosEntregaDB();

            List<PuntoEntrega> puntos = db.ObtenerPuntosEntrega();

            cmbPuntoEntrega.DataSource = puntos;

            cmbPuntoEntrega.DisplayMember = "NombrePunto";
            cmbPuntoEntrega.ValueMember = "IdPunto";

            cmbPuntoEntrega.SelectedIndex = -1;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (cmbPuntoEntrega.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un punto de entrega.",
                    "Pedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (usuarioActual == null)
            {
                MessageBox.Show("No se recibió el usuario que inició sesión.");
                return;
            }

            if (!int.TryParse(lblCantidadValor.Text, out int cantidad) || cantidad < 1)
            {
                MessageBox.Show("La cantidad seleccionada no es válida.");
                return;
            }

            int idPuntoEntrega = Convert.ToInt32(cmbPuntoEntrega.SelectedValue);
            int idUsuario = usuarioActual.IdUsuario;

            try
            {
                PedidoDB db = new PedidoDB();

                bool resultado = db.CrearPedido(
                    cantidad,
                    producto.IdProducto,
                    idUsuario,
                    idPuntoEntrega
                );

                if (resultado)
                {
                    MessageBox.Show(
                        "¡Pedido realizado correctamente!",
                        "Pedido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo confirmar el pedido. Revisa el método CrearPedido.",
                        "Pedido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al realizar el pedido:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
