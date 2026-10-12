using Modelo.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Conductor
{
    public partial class frmRutasC : Form
    {
        private int idUsuario;
        private int idProgramacionSeleccionada = -1;
        private int idProgramacionDelDia = -1;
        private DataTable productosRutaActual;
        private bool mostrarTodosLosProductos = false;
        private Panel pnlContenidoProductos;
        private frmMenu menuPrincipal;
        private bool cargandoEstados = false;
        private bool esRutaDelDia = false;
        private string estadoAnterior1 = "PENDIENTE";
        private string estadoAnterior2 = "PENDIENTE";
        private string estadoAnterior3 = "PENDIENTE";

        public frmRutasC(int idUsuario, frmMenu menuPrincipal)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.menuPrincipal = menuPrincipal;

            ConfigurarComboEstados();
            PrepararPanelProductos();
            CargarRutas();
            CargarRutaDelDia();
        }

        //Tarjetas Rutas --------------------------------------


        private void CrearTarjetaRuta(
    string nombreRuta,
    string estado,
    string fecha,
    string[] lugares,
    Color colorRuta,
    int idProgramacion)
        {
            // Panel principal de la tarjeta
            Panel tarjeta = new Panel();
            tarjeta.Size = pnlTarjeta.Size;
            tarjeta.BackColor = ObtenerColorPastel(colorRuta);
            tarjeta.BorderStyle = pnlTarjeta.BorderStyle;
            tarjeta.Margin = new Padding(10);
            tarjeta.Location = new Point(10, 10 + (pnlContenedorRutas.Controls.Count * (tarjeta.Height + 15)));

            // Franja de color
            Panel franja = new Panel();
            franja.BackColor = colorRuta;
            franja.Size = pnlTarjetaColor.Size;
            franja.Location = pnlTarjetaColor.Location;

            // Nombre de la ruta


            Label titulo = new Label();

            titulo.Text = nombreRuta;
            titulo.Font = new Font("Arial", 12, FontStyle.Bold);
            titulo.ForeColor = Color.Black;
            titulo.BackColor = Color.Transparent;
            titulo.Location = new Point(20, 15);
            titulo.Size = new Size(
                tarjeta.ClientSize.Width - 40,
                35
            );
            titulo.AutoSize = false;
            titulo.Visible = true;
            titulo.TextAlign = ContentAlignment.MiddleLeft;
            titulo.BringToFront();

            // Darle más espacio al título
            titulo.Size = new Size(
                tarjeta.ClientSize.Width - titulo.Left - 20,
                35
            );

            titulo.AutoSize = false;
            titulo.Visible = true;
            titulo.TextAlign = ContentAlignment.MiddleLeft;
            titulo.BringToFront();


            // Estado
            Panel panelEstado = new Panel();
            panelEstado.BackColor = colorRuta;
            panelEstado.Size = pnlEstado.Size;
            panelEstado.Location = pnlEstado.Location;

            Label textoEstado = new Label();
            textoEstado.Text = estado;
            textoEstado.Font = lblEstado.Font;
            textoEstado.ForeColor = lblEstado.ForeColor;
            textoEstado.TextAlign = lblEstado.TextAlign;
            textoEstado.Dock = DockStyle.Fill;

            panelEstado.Controls.Add(textoEstado);

            // Fecha
            Label textoFecha = new Label();
            textoFecha.Text = fecha;
            textoFecha.Font = lblFecha.Font;
            textoFecha.ForeColor = lblFecha.ForeColor;
            textoFecha.Location = lblFecha.Location;
            textoFecha.Size = new Size(
                tarjeta.ClientSize.Width - lblFecha.Left - 10,
                lblFecha.Height + 20
            );
            textoFecha.AutoSize = false;

            // Lista de lugares

            ListBox listaLugares = new ListBox();

            listaLugares.Location = lstLugaresRuta.Location;
            listaLugares.Size = lstLugaresRuta.Size;
            listaLugares.Font = lstLugaresRuta.Font;

            listaLugares.SelectionMode = SelectionMode.None;
            listaLugares.TabStop = false;
            // Fondo pastel igual al de la tarjeta
            listaLugares.BackColor = tarjeta.BackColor;

            // Color de letra configurado en el diseñador
            listaLugares.ForeColor = lstLugaresRuta.ForeColor;

            listaLugares.BorderStyle = BorderStyle.None;
            listaLugares.IntegralHeight = false;
            listaLugares.ScrollAlwaysVisible = false;
            listaLugares.FormattingEnabled = true;

            listaLugares.Items.AddRange(lugares);




            // Agregar elementos a la tarjeta
            tarjeta.Controls.Add(franja);
            tarjeta.Controls.Add(titulo);
            tarjeta.Controls.Add(panelEstado);
            tarjeta.Controls.Add(textoFecha);
            tarjeta.Controls.Add(listaLugares);


            tarjeta.Cursor = Cursors.Hand;

            tarjeta.Click += (sender, e) =>
            {
                CargarProductosRuta(idProgramacion);
            };

            foreach (Control control in tarjeta.Controls)
            {
                control.Cursor = Cursors.Hand;

                control.Click += (sender, e) =>
                {
                    CargarProductosRuta(idProgramacion);
                };
            }

            // Agregar tarjeta al contenedor
            pnlContenedorRutas.Controls.Add(tarjeta);
        }




        private Color ObtenerColorPastel(Color color)
        {
            if (color == Color.DodgerBlue)
                return ColorTranslator.FromHtml("#f0f6ff"); // Azul pastel

            if (color == Color.Crimson)
                return ColorTranslator.FromHtml("#fff5f6"); // Rojo pastel

            if (color == Color.BlueViolet)
                return ColorTranslator.FromHtml("#f7f4fe"); // Violeta pastel

            if (color == Color.SeaGreen)
                return ColorTranslator.FromHtml("#E8F5E9"); // Verde pastel

            return ColorTranslator.FromHtml("#F5F5F5");
        }




        private void CargarRutas()
        {
            pnlContenedorRutas.Controls.Clear();
            pnlContenedorRutas.AutoScroll = true;

            try
            {
                DataTable rutas =
                    new ConductorDAO().ObtenerCuatroRutas(idUsuario);

                Color[] colores =
                {
            Color.DodgerBlue,
            Color.Crimson,
            Color.BlueViolet,
            Color.SeaGreen
        };

                int posicionY = 10;
                int rutasMostradas = 0;

                foreach (DataRow fila in rutas.Rows)
                {
                    int idProgramacion =
                        Convert.ToInt32(fila["idProgramacion"]);

                    DateTime fechaRuta =
                        Convert.ToDateTime(fila["FechaRuta"]);

                    string nombre =
                        Convert.ToString(fila["NombreRuta"]);

                    string estadoBD =
                        Convert.ToString(fila["EstadoRuta"]);

                    string estado;

                    if (fechaRuta.Date == DateTime.Today)
                        estado = "ACTIVA";
                    else
                        estado = "PROGRAMADA";

                    if (fechaRuta.DayOfWeek == DayOfWeek.Sunday)
                        estado = "INACTIVA";

                    if (!string.IsNullOrWhiteSpace(estadoBD) &&
                        estadoBD.Equals(
                            "INACTIVA",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        estado = "INACTIVA";
                    }

                    string fecha = fechaRuta.ToString("dd/MM/yyyy");

                    string origen =
                        Convert.ToString(fila["PuntoOrigen"]);

                    string destinoA = fila["DestinoA"] == DBNull.Value
                        ? ""
                        : Convert.ToString(fila["DestinoA"]);

                    string puntoFinal =
                        Convert.ToString(fila["PuntoFinal"]);

                    List<string> lugares = new List<string>();

                    if (!string.IsNullOrWhiteSpace(origen))
                        lugares.Add(origen.Replace("Punto de entrega - ", ""));

                    if (!string.IsNullOrWhiteSpace(destinoA))
                        lugares.Add(destinoA.Replace("Punto de entrega - ", ""));

                    if (!string.IsNullOrWhiteSpace(puntoFinal))
                        lugares.Add(puntoFinal.Replace("Punto de entrega - ", ""));

                    Color colorRuta = colores[
                        rutasMostradas % colores.Length];

                    CrearTarjetaRuta(
                        nombre,
                        estado,
                        fecha,
                        lugares.ToArray(),
                        colorRuta,
                        idProgramacion
                    );

                    Control tarjetaCreada =
                        pnlContenedorRutas.Controls[
                            pnlContenedorRutas.Controls.Count - 1];

                    int posicionX = Math.Max(
                        0,
                        (pnlContenedorRutas.ClientSize.Width -
                         tarjetaCreada.Width) / 2);

                    tarjetaCreada.Location =
                        new Point(posicionX, posicionY);

                    posicionY += tarjetaCreada.Height + 15;
                    rutasMostradas++;
                }

                if (rutasMostradas == 0)
                {
                    Label mensaje = new Label();

                    mensaje.Text = "No hay rutas programadas próximamente.";
                    mensaje.AutoSize = true;
                    mensaje.Font = new Font(
                        "Arial", 11, FontStyle.Regular);
                    mensaje.ForeColor = Color.DimGray;
                    mensaje.Location = new Point(20, 20);

                    pnlContenedorRutas.Controls.Add(mensaje);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las rutas: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //Productos Solicitados -----------------------------------------------

        private void PrepararPanelProductos()
        {
            pnlContenidoProductos = new Panel();

            pnlContenidoProductos.Location = new Point(35, 70);
            pnlContenidoProductos.Size = new Size(
                pnlListaProductos.ClientSize.Width - 55,
                160
            );

            pnlContenidoProductos.AutoScroll = false;
            pnlContenidoProductos.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlListaProductos.Controls.Add(pnlContenidoProductos);

            btnVerMasProductos.Visible = false;
        }


        private void CargarProductosRuta(int idProgramacion)
        {
            try
            {
                idProgramacionSeleccionada = idProgramacion;
                mostrarTodosLosProductos = false;

                productosRutaActual =
                    new ConductorDAO().ObtenerProductosSolicitadosPorRuta(idProgramacion);

                pnlContenidoProductos.Controls.Clear();

                if (productosRutaActual.Rows.Count == 0)
                {
                    Label mensaje = new Label();
                    mensaje.Text = "Esta ruta todavía no tiene productos asignados.";
                    mensaje.AutoSize = true;
                    mensaje.Location = new Point(0, 0);

                    pnlContenidoProductos.Controls.Add(mensaje);
                    btnVerMasProductos.Visible = false;
                    return;
                }

                MostrarProductos(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los productos: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void MostrarProductos(bool mostrarTodos)
        {
            pnlContenidoProductos.Controls.Clear();

            int cantidadVisible = mostrarTodos
                ? productosRutaActual.Rows.Count
                : Math.Min(2, productosRutaActual.Rows.Count);

            int posicionY = 0;

            for (int i = 0; i < cantidadVisible; i++)
            {
                DataRow fila = productosRutaActual.Rows[i];

                Label producto = new Label();
                producto.AutoSize = false;
                producto.Location = new Point(0, posicionY);
                producto.Size = new Size(
                    pnlContenidoProductos.ClientSize.Width - 10, 55);

                producto.Text =
                    fila["NombreProducto"] +
                    " | Cantidad: " + fila["Cantidad"] +
                    " | Subtotal: $" +
                    Convert.ToDecimal(fila["Subtotal"]).ToString("0.00") +
                    " | Punto: " + fila["PuntoEntrega"];

                producto.Font = new Font("Segoe UI", 10);
                producto.TextAlign = ContentAlignment.MiddleLeft;
                producto.BorderStyle = BorderStyle.FixedSingle;

                pnlContenidoProductos.Controls.Add(producto);

                posicionY += 60;
            }

            pnlContenidoProductos.Height = Math.Max(160, posicionY + 10);

            pnlListaProductos.AutoScrollMinSize = new Size(
                0,
                pnlContenidoProductos.Bottom + 10
            );

            mostrarTodosLosProductos = mostrarTodos;

            btnVerMasProductos.Visible =
                productosRutaActual.Rows.Count > 2;

            btnVerMasProductos.Text = mostrarTodos
                ? "VER MENOS"
                : "VER MÁS";

            if (mostrarTodos)
            {
                pnlListaProductos.ScrollControlIntoView(pnlContenidoProductos);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnVerMasProductos_Click(object sender, EventArgs e)
        {
            if (idProgramacionSeleccionada == -1)
            {
                MessageBox.Show(
                    "Primero seleccioná una ruta.",
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            menuPrincipal.MostrarProductos(idProgramacionSeleccionada);
        }

        //Estados de Rutas ---------------------------------------------------


        private void GuardarEstadoPunto(int numeroPunto, ComboBox combo)
        {
            if (cargandoEstados ||
                idProgramacionSeleccionada == -1 ||
                combo.SelectedItem == null)
                return;

            try
            {
                new ConductorDAO().ActualizarEstadoPunto(
                    idProgramacionSeleccionada,
                    numeroPunto,
                    combo.SelectedItem.ToString()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el estado: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void ConfigurarComboEstados()
        {
            string[] estados =
            {
        "PENDIENTE",
        "EN CAMINO",
        "COMPLETADO"
    };

            ComboBox[] combos = { comboBox1, comboBox2, comboBox3 };

            foreach (ComboBox combo in combos)
            {
                combo.Items.Clear();
                combo.Items.AddRange(estados);
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.SelectedItem = "PENDIENTE";
            }

            comboBox1.SelectedIndexChanged += (s, e) =>
                CambiarEstadoPunto(1, comboBox1, panel5);

            comboBox2.SelectedIndexChanged += (s, e) =>
                CambiarEstadoPunto(2, comboBox2, panel2);

            comboBox3.SelectedIndexChanged += (s, e) =>
                CambiarEstadoPunto(3, comboBox3, panel3);

            ActualizarColorPanel(panel5, comboBox1);
            ActualizarColorPanel(panel2, comboBox2);
            ActualizarColorPanel(panel3, comboBox3);
        }




        private void CargarEstadosPuntos(int idProgramacion)
        {
            try
            {
                idProgramacionDelDia = idProgramacion;

                DataTable tabla =
                    new ConductorDAO().ObtenerEstadosPuntos(idProgramacion);

                if (tabla.Rows.Count == 0)
                    return;

                DataRow fila = tabla.Rows[0];

                esRutaDelDia =
                    Convert.ToDateTime(fila["FechaRuta"]).Date == DateTime.Today;

                estadoAnterior1 = fila["EstadoPunto1"].ToString();
                estadoAnterior2 = fila["EstadoPunto2"].ToString();
                estadoAnterior3 = fila["EstadoPunto3"].ToString();

                cargandoEstados = true;

                comboBox1.SelectedItem = estadoAnterior1;
                comboBox2.SelectedItem = estadoAnterior2;
                comboBox3.SelectedItem = estadoAnterior3;

                ActualizarColorPanel(panel5, comboBox1);
                ActualizarColorPanel(panel2, comboBox2);
                ActualizarColorPanel(panel3, comboBox3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los estados: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargandoEstados = false;
            }
        }



        private void ActualizarColorPanel(
            Panel panel,
            ComboBox combo)
        {
            if (combo.SelectedItem == null)
            {
                panel.BackColor = Color.MistyRose;
                return;
            }

            string estado = combo.SelectedItem.ToString();

            switch (estado)
            {
                case "PENDIENTE":
                    panel.BackColor = Color.MistyRose;
                    break;

                case "EN CAMINO":
                    panel.BackColor = Color.LemonChiffon;
                    break;

                case "COMPLETADO":
                    panel.BackColor = Color.Honeydew;
                    break;

                default:
                    panel.BackColor = Color.MistyRose;
                    break;
            }
        }


        private void CambiarEstadoPunto(
            int numeroPunto,
            ComboBox combo,
            Panel panel)
        {
            if (cargandoEstados || combo.SelectedItem == null)
                return;

            string estadoAnterior;

            switch (numeroPunto)
            {
                case 1:
                    estadoAnterior = estadoAnterior1;
                    break;
                case 2:
                    estadoAnterior = estadoAnterior2;
                    break;
                default:
                    estadoAnterior = estadoAnterior3;
                    break;
            }

            if (idProgramacionDelDia == -1 || !esRutaDelDia)
            {
                MessageBox.Show(
                    "No podés modificar los estados porque esta ruta no corresponde al día de hoy.",
                    "Ruta fuera de fecha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                cargandoEstados = true;
                combo.SelectedItem = estadoAnterior;
                cargandoEstados = false;
                return;
            }

            string nuevoEstado = combo.SelectedItem.ToString();

            try
            {
                new ConductorDAO().ActualizarEstadoPunto(
                     idProgramacionDelDia,
                     numeroPunto,
                     nuevoEstado);
    
                switch (numeroPunto)
                {
                    case 1:
                        estadoAnterior1 = nuevoEstado;
                        break;
                    case 2:
                        estadoAnterior2 = nuevoEstado;
                        break;
                    case 3:
                        estadoAnterior3 = nuevoEstado;
                        break;
                }

                ActualizarColorPanel(panel, combo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el estado: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                cargandoEstados = true;
                combo.SelectedItem = estadoAnterior;
                cargandoEstados = false;
            }
        }


        private void ActualizarLabelsPuntos(
            string origen,
            string destinoA,
            string puntoFinal)
        {
            label1.Text = LimpiarNombrePunto(origen);
            lblLugar2.Text = LimpiarNombrePunto(destinoA);
            label2.Text = LimpiarNombrePunto(puntoFinal);
        }

        private string LimpiarNombrePunto(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "Sin punto asignado";

            return nombre.Replace("Punto de entrega - ", "").Trim();
        }




        private void CargarLabelsPuntos(int idProgramacion)
        {
            DataTable rutas =
                new ConductorDAO().ObtenerCuatroRutas(idUsuario);

            DataRow[] rutaSeleccionada = rutas.Select(
                "idProgramacion = " + idProgramacion);

            if (rutaSeleccionada.Length == 0)
            {
                ActualizarLabelsPuntos("", "", "");
                return;
            }

            DataRow fila = rutaSeleccionada[0];

            DateTime fechaRuta = Convert.ToDateTime(fila["FechaRuta"]);

            // Si la ruta es futura, mostrar la fecha disponible.
            if (fechaRuta.Date > DateTime.Today)
            {
                string mensaje = "Disponible el " +
                                 fechaRuta.ToString("dd/MM/yyyy");

                label1.Text = mensaje;
                lblLugar2.Text = mensaje;
                label2.Text = mensaje;

                return;
            }

            // Si corresponde a hoy o es una ruta pasada,
            // mostrar los nombres reales de los lugares.
            string origen = Convert.ToString(fila["PuntoOrigen"]);
            string destinoA = Convert.ToString(fila["DestinoA"]);
            string puntoFinal = Convert.ToString(fila["PuntoFinal"]);

            ActualizarLabelsPuntos(origen, destinoA, puntoFinal);
        }


        private void CargarRutaDelDia()
        {
            try
            {
                DataTable rutas = new ConductorDAO().ObtenerCuatroRutas(idUsuario);
                DataRow[] rutasHoy = rutas.AsEnumerable()
                    .Where(fila =>
                        Convert.ToDateTime(fila["FechaRuta"]).Date == DateTime.Today)
                    .ToArray();

                if (rutasHoy.Length == 0)
                {
                    idProgramacionDelDia = -1;
                    ActualizarLabelsPuntos("No hay ruta", "No hay ruta", "No hay ruta");

                    cargandoEstados = true;

                    comboBox1.SelectedItem = "PENDIENTE";
                    comboBox2.SelectedItem = "PENDIENTE";
                    comboBox3.SelectedItem = "PENDIENTE";

                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;

                    cargandoEstados = false;
                    esRutaDelDia = false;

                    return;
                }

                int idProgramacionHoy =
                    Convert.ToInt32(rutasHoy[0]["idProgramacion"]);

                idProgramacionDelDia = idProgramacionHoy;

                CargarLabelsPuntos(idProgramacionHoy);
                CargarEstadosPuntos(idProgramacionHoy);

                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la ruta del día: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}
