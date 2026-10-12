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
    public partial class frmDashboardConductor : Form
    {
        private int idUsuario;
        private Modelo.Entidades.Conductor conductor;
        private DataTable programacionesRutas;
        private int idProgramacionSeleccionada = 0;
        private int idProgramacionDelDia = 0;
        private System.Windows.Forms.Timer timerEstadosRuta;
        private bool mostrandoRutaCalendario = false;
        private System.Windows.Forms.Timer timerCalendario;
        private DateTime mesCalendarioMostrado = DateTime.MinValue;

        public frmDashboardConductor(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            CargarProgramacionRutas();
            CargarDatosConductor();
            CrearCalendario();
            CargarRutas();
            CargarEstadosRutaDelDia();

            // Verificar periódicamente si cambió el mes
            timerCalendario = new System.Windows.Forms.Timer();
            timerCalendario.Interval = 60000; // Cada minuto

            timerCalendario.Tick += (s, e) =>
            {
                DateTime ahora = DateTime.Now;

                if (ahora.Year != mesCalendarioMostrado.Year ||
                    ahora.Month != mesCalendarioMostrado.Month)
                {
                    CargarProgramacionRutas();
                    CrearCalendario();
                }
            };

            timerCalendario.Start();

            // Actualizar los estados periódicamente
            timerEstadosRuta = new System.Windows.Forms.Timer();

            timerEstadosRuta.Interval = 3000; // 3 segundos

            timerEstadosRuta.Tick += (s, e) =>
            {
                CargarEstadosRutaDelDia();
            };

            timerEstadosRuta.Start();

            lblFecha.Text = DateTime.Now.ToString(
                 "dddd, dd 'de' MMMM 'de' yyyy",
                  new System.Globalization.CultureInfo("es-SV"));
        }


        private void AsignarClickATarjeta(Control control, EventHandler evento)
        {
            control.Click += evento;

            foreach (Control hijo in control.Controls)
            {
                AsignarClickATarjeta(hijo, evento);
            }
        }

        //Calendario ---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void CrearCalendario()
        {
            tlpCalendario.Controls.Clear();

            DateTime fechaActual = DateTime.Now;

            int mes = fechaActual.Month;
            int año = fechaActual.Year;


            mesCalendarioMostrado = new DateTime(año, mes, 1);

            lblMesCalendario.Text = fechaActual.ToString("MMMM yyyy", new System.Globalization.CultureInfo("es-SV"));

            lblMesCalendario.Text =
                char.ToUpper(lblMesCalendario.Text[0]) +
                lblMesCalendario.Text.Substring(1);

            string[] diasSemana =
            {
        "LUN", "MAR", "MIÉ", "JUE",
        "VIE", "SÁB", "DOM"
    };

            // ==========================
            // CONFIGURACIÓN DEL CALENDARIO
            // ==========================

            tlpCalendario.ColumnCount = 7;
            tlpCalendario.RowCount = 7;

            tlpCalendario.ColumnStyles.Clear();
            tlpCalendario.RowStyles.Clear();

            // Columnas
            for (int i = 0; i < 7; i++)
            {
                tlpCalendario.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 14.2857f)
                );
            }

            // Filas
            tlpCalendario.RowStyles.Add(
                new RowStyle(SizeType.Percent, 12f)
            );

            for (int i = 1; i < 7; i++)
            {
                tlpCalendario.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 14.6667f)
                );
            }

            // ==========================
            // ENCABEZADO
            // ==========================

            for (int i = 0; i < diasSemana.Length; i++)
            {
                Label lblDia = new Label();

                lblDia.Text = diasSemana[i];
                lblDia.Dock = DockStyle.Fill;
                lblDia.TextAlign = ContentAlignment.MiddleCenter;

                lblDia.Font = new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

                tlpCalendario.Controls.Add(
                    lblDia,
                    i,
                    0
                );
            }

            // ==========================
            // PRIMER DÍA DEL MES
            // ==========================

            DateTime primerDia =
                new DateTime(año, mes, 1);

            int posicionPrimerDia =
                ((int)primerDia.DayOfWeek + 6) % 7;

            int diasDelMes =
                DateTime.DaysInMonth(año, mes);

            // ==========================
            // CREAR LOS DÍAS
            // ==========================

            for (int dia = 1; dia <= diasDelMes; dia++)
            {
                int posicion =
                    posicionPrimerDia + dia - 1;

                int fila =
                    (posicion / 7) + 1;

                int columna =
                    posicion % 7;

                // --------------------------
                // PANEL DE LA CELDA
                // --------------------------

                Panel panelDia = new Panel();
                panelDia.Cursor = Cursors.Hand;

                panelDia.Dock = DockStyle.Fill;

                // --------------------------
                // NÚMERO DEL DÍA
                // --------------------------

                Label lblFecha = new Label();

                lblFecha.Text = dia.ToString();

                lblFecha.Dock = DockStyle.Top;

                lblFecha.Height = 25;

                lblFecha.TextAlign =
                    ContentAlignment.MiddleCenter;

                lblFecha.Font = new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Regular
                );

                // --------------------------
                // DÍA ACTUAL
                // --------------------------

                if (dia == fechaActual.Day)
                {
                    lblFecha.Font = new Font(
                        "Segoe UI",
                        9,
                        FontStyle.Bold
                    );
                }

                // --------------------------
                // AGREGAR NÚMERO AL PANEL
                // --------------------------

                panelDia.Controls.Add(lblFecha);

                // --------------------------
                // PUNTO DE RUTA
                // --------------------------

                DateTime fechaRuta = new DateTime(año, mes, dia);
                // Permitir seleccionar el día del calendario.
                panelDia.Tag = fechaRuta;

                panelDia.Click += (sender, e) =>
                {
                    SeleccionarFechaCalendario(fechaRuta);
                };

                lblFecha.Cursor = Cursors.Hand;

                lblFecha.Click += (sender, e) =>
                {
                    SeleccionarFechaCalendario(fechaRuta);
                };

                bool tieneRuta = false;

                if (programacionesRutas != null)
                {
                    foreach (DataRow filaRuta in programacionesRutas.Rows)
                    {
                        DateTime fechaProgramada =
                            Convert.ToDateTime(filaRuta["FechaRuta"]);

                        if (fechaProgramada.Date == fechaRuta.Date)
                        {
                            tieneRuta = true;
                            break;
                        }
                    }
                }

                if (tieneRuta)
                {
                    Label punto = new Label();

                    punto.Text = "●";

                    punto.ForeColor = Color.Brown;

                    punto.Font = new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold
                    );

                    punto.Dock = DockStyle.None;
                    punto.Height = 20;

                    punto.Location = new Point(
                        25,
                        20
                    );

                    punto.TextAlign =
                        ContentAlignment.MiddleCenter;

                    punto.Cursor = Cursors.Hand;

                    punto.Click += (sender, e) =>
                    {
                        SeleccionarFechaCalendario(fechaRuta);
                    };

                    panelDia.Controls.Add(punto);
                    punto.BringToFront();
                }

                // --------------------------
                // AGREGAR CELDA AL CALENDARIO
                // --------------------------

                tlpCalendario.Controls.Add(
                    panelDia,
                    columna,
                    fila
                );
            }
        }

        private void CargarProgramacionRutas()
        {
            ConductorDAO conductorDAO = new ConductorDAO();

            programacionesRutas = conductorDAO.ObtenerProgramacionRutas(idUsuario);
        }


        private void SeleccionarFechaCalendario(DateTime fecha)
        {
            mostrandoRutaCalendario = fecha.Date != DateTime.Today;
            ConductorDAO conductorDAO = new ConductorDAO();

            DataTable rutas = conductorDAO.ObtenerRutas(
                idUsuario,
                fecha.Date
            );

            if (rutas.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay rutas programadas para el " +
                    fecha.ToString("dd/MM/yyyy") + ".",
                    "Calendario de rutas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                pnlRutas.Controls.Clear();
                MostrarEstadoRutas(false);
                return;
            }

            // Cargar las tarjetas de las rutas de la fecha elegida.
            MostrarRutasDeFecha(rutas, fecha);
        }


        private void MostrarRutasDeFecha(DataTable rutas, DateTime fecha)
        {
            pnlRutas.SuspendLayout();

            try
            {
                pnlRutas.Controls.Clear();
                pnlRutas.AutoScroll = true;

                int posicionY = 5;

                foreach (DataRow fila in rutas.Rows)
                {
                    Panel tarjeta = CrearTarjetaRuta(fila);

                    tarjeta.Left = 5;
                    tarjeta.Top = posicionY;
                    tarjeta.Width = pnlRutas.ClientSize.Width - 25;

                    pnlRutas.Controls.Add(tarjeta);

                    posicionY += tarjeta.Height + 10;
                }

                MostrarEstadoRutas(true);
            }
            finally
            {
                pnlRutas.ResumeLayout();
            }
        }

        //Tarjetas de Rutas ----------------------------------------------------------------------------------------------------------------------------------------

        private void CargarDatosConductor()
        {
            ConductorDAO conductorDAO = new ConductorDAO();

            conductor = conductorDAO.ObtenerConductor(idUsuario);

            if (conductor == null)
            {
                MessageBox.Show(
                    "No se encontró el conductor con ID: " + idUsuario,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            lblNombre.Text = conductor.Nombre + " " + conductor.Apellido;
        }





        private void CargarRutas()
        {
            ConductorDAO conductorDAO = new ConductorDAO();

            // Obtener las rutas asignadas al conductor por el administrador
            DataTable tabla = conductorDAO.ObtenerRutas(
    idUsuario,
    DateTime.Today
);
            MostrarEstadoRutas(tabla.Rows.Count > 0);

            pnlRutas.SuspendLayout();
            pnlRutas.Controls.Clear();
            pnlRutas.AutoScroll = true;

            int posicionY = 5;

            foreach (DataRow fila in tabla.Rows)
            {
                Panel tarjeta = CrearTarjetaRuta(fila);

                tarjeta.Left = 5;
                tarjeta.Top = posicionY;
                tarjeta.Width = pnlRutas.ClientSize.Width - 25;

                pnlRutas.Controls.Add(tarjeta);

                posicionY += tarjeta.Height + 10;
            }

            pnlRutas.ResumeLayout();
        }




        private Panel CrearTarjetaRuta(DataRow fila)
        {
            // ==========================
            // TARJETA
            // ==========================

            Panel tarjeta = new Panel();

            int idProgramacion =
                Convert.ToInt32(fila["idProgramacion"]);

            tarjeta.Cursor = Cursors.Hand;

            tarjeta.Width = pnlRutas.ClientSize.Width - 20;
            tarjeta.Height = 150;

            tarjeta.Margin = new Padding(5);
            tarjeta.BackColor = Color.White;

            tarjeta.BorderStyle = BorderStyle.FixedSingle;

            // ==========================
            // COLOR DE LA RUTA
            // ==========================

            Color colorRuta = Color.DodgerBlue;

            string nombreRuta =
    fila["Nombre"].ToString().ToUpper();

            if (nombreRuta.Contains("01"))
            {
                colorRuta = Color.MediumPurple;
            }
            else if (nombreRuta.Contains("02"))
            {
                colorRuta = Color.Red;
            }
            else if (nombreRuta.Contains("03"))
            {
                colorRuta = Color.DodgerBlue;
            }

            // ==========================
            // BARRA LATERAL
            // ==========================

            Panel barra = new Panel();

            barra.Width = 6;
            barra.Height = tarjeta.Height;
            barra.Left = 0;
            barra.Top = 0;
            barra.BackColor = colorRuta;

            tarjeta.Controls.Add(barra);

            // ==========================
            // TÍTULO
            // ==========================

            Label lblRuta = new Label();

            lblRuta.Text =
    fila["Nombre"].ToString().ToUpper();

            lblRuta.Font = new Font(
                "Arial",
                12,
                FontStyle.Bold
            );

            lblRuta.ForeColor = colorRuta;

            lblRuta.Left = 20;
            lblRuta.Top = 15;

            lblRuta.Width = tarjeta.Width - 35;
            lblRuta.Height = 25;

            tarjeta.Controls.Add(lblRuta);

            // ==========================
            // RECORRIDO
            // ==========================

            string origen =
                fila["PuntoOrigen"].ToString()
                .Replace("Punto de entrega - ", "");

            string destinoA =
                fila["DestinoA"] == DBNull.Value
                ? ""
                : fila["DestinoA"].ToString()
                    .Replace("Punto de entrega - ", "");

            string puntoFinal =
                fila["PuntoFinal"].ToString()
                .Replace("Punto de entrega - ", "");

            string recorrido = origen + " -\n";

            if (!string.IsNullOrWhiteSpace(destinoA))
            {
                recorrido += destinoA + " -\n";
            }

            recorrido += puntoFinal;

            Label lblRecorrido = new Label();

            lblRecorrido.Text = recorrido;

            lblRecorrido.Font = new Font(
                "Arial",
                9,
                FontStyle.Regular
            );

            lblRecorrido.ForeColor =
                Color.FromArgb(40, 40, 40);

            lblRecorrido.Left = 20;
            lblRecorrido.Top = 45;

            lblRecorrido.Width =
                tarjeta.Width - 40;

            lblRecorrido.Height = 55;

            tarjeta.Controls.Add(lblRecorrido);

            // ==========================
            // LÍNEA
            // ==========================

            Panel linea = new Panel();

            linea.Height = 1;
            linea.Width = tarjeta.Width - 40;

            linea.Left = 20;
            linea.Top = 105;

            linea.BackColor =
                Color.LightGray;

            tarjeta.Controls.Add(linea);

            // ==========================
            // ESTADO
            // ==========================

            Label lblEstado = new Label();

            string estado =
                fila["Estado"].ToString().ToUpper();

            lblEstado.Text =
                "  " + estado + "  ";

            lblEstado.Font = new Font(
                "Arial",
                8,
                FontStyle.Bold
            );

            lblEstado.TextAlign =
                ContentAlignment.MiddleCenter;

            lblEstado.AutoSize = true;

            lblEstado.Left = 20;
            lblEstado.Top = 115;

            if (estado.Contains("ACTIVA"))
            {
                // Mismo color de la ruta, pero suave
                lblEstado.ForeColor = colorRuta;

                lblEstado.BackColor =
                    Color.FromArgb(
                        230,
                        235,
                        250
                    );
            }
            else
            {
                // También conserva el color de la ruta
                lblEstado.ForeColor = colorRuta;

                lblEstado.BackColor =
                    Color.FromArgb(
                        240,
                        240,
                        245
                    );
            }

            tarjeta.Controls.Add(lblEstado);


            EventHandler seleccionarRuta = (sender, e) =>
            {
                idProgramacionSeleccionada = idProgramacion;
                CargarProgresoRuta();
            };

            AsignarClickATarjeta(tarjeta, seleccionarRuta);

            return tarjeta;
        }

        //Puntos -------------------------------------------------------------------------------------------------------------------------


        private void CargarProgresoRuta()
        {
            CargarProgresoProgramacion(idProgramacionSeleccionada);
        }

        private void CargarProgresoProgramacion(int idProgramacion)
        {
            if (idProgramacion <= 0)
            {
                MostrarSinRutaDelDia();
                return;
            }

            ConductorDAO conductorDAO = new ConductorDAO();

            DataTable tabla =
                conductorDAO.ObtenerProgresoProgramacion(idProgramacion);

            if (tabla.Rows.Count == 0)
            {
                MostrarSinRutaDelDia();
                return;
            }

            DataRow ruta = tabla.Rows[0];

            // Nombres de los puntos
            label1.Text = ruta["PuntoOrigen"].ToString()
                .Replace("Punto de entrega - ", "");

            label2.Text = ruta["DestinoA"] != DBNull.Value
                ? ruta["DestinoA"].ToString()
                    .Replace("Punto de entrega - ", "")
                : "Sin parada";

            label3.Text = ruta["PuntoFinal"].ToString()
                .Replace("Punto de entrega - ", "");

            // Estados guardados en la base de datos
            string estado1 = ruta["EstadoPunto1"].ToString();
            string estado2 = ruta["EstadoPunto2"].ToString();
            string estado3 = ruta["EstadoPunto3"].ToString();

            CambiarEstadoPunto(
                pictureBox1, label4, panel5, estado1);

            CambiarEstadoPunto(
                pictureBox2, label5, panel6, estado2);

            CambiarEstadoPunto(
                pictureBox3, label6, panel7, estado3);
        }





        private void CambiarEstadoPunto(
            PictureBox pictureBox,
            Label labelEstado,
            Panel panelEstado,
            string estado)
        {
            switch (estado)
            {
                case "PENDIENTE":

                    pictureBox.Image =
                        Properties.Resources.r_removebg_preview;

                    labelEstado.Text = "PENDIENTE";
                    labelEstado.ForeColor = Color.Red;

                    panelEstado.BackColor =
                        Color.FromArgb(251, 226, 227);

                    break;

                case "EN CAMINO":

                    pictureBox.Image =
                        Properties.Resources.n_removebg_preview;

                    labelEstado.Text = "EN CAMINO";
                    labelEstado.ForeColor = Color.Goldenrod;

                    panelEstado.BackColor =
                        Color.FromArgb(255, 242, 204);

                    break;

                case "COMPLETADO":

                    pictureBox.Image =
                        Properties.Resources.circulo_verde_removebg_preview;

                    labelEstado.Text = "COMPLETADO";
                    labelEstado.ForeColor = Color.Green;

                    panelEstado.BackColor =
                        Color.FromArgb(212, 241, 213);

                    break;
            }
        }


        private void MostrarEstadoRutas(bool hayRutas)
        {
            // Mostrar siempre los paneles de los tres puntos
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;

            // Mostrar u ocultar el mensaje de rutas
            pnlSinR.Visible = !hayRutas;

            // Mostrar u ocultar las tarjetas de rutas
            pnlRutas.Visible = hayRutas;

            if (!hayRutas)
            {
                pnlSinR.Text = "No hay ruta";
                pnlSinR.BringToFront();
            }
        }



        private void tlpCalendario_Paint(object sender, PaintEventArgs e)
        {

        }




        private void MostrarSinRutaDelDia()
        {
            // Nombres de los puntos
            label1.Text = "No hay ruta";
            label2.Text = "No hay ruta";
            label3.Text = "No hay ruta";

            // Estados pendientes
            CambiarEstadoPunto(
                pictureBox1, label4, panel5, "PENDIENTE");

            CambiarEstadoPunto(
                pictureBox2, label5, panel6, "PENDIENTE");

            CambiarEstadoPunto(
                pictureBox3, label6, panel7, "PENDIENTE");

        }



        private void CargarEstadosRutaDelDia()
        {
            if (mostrandoRutaCalendario)
                return;

            ConductorDAO conductorDAO = new ConductorDAO();

            // Buscar las rutas programadas para hoy
            DataTable rutasHoy =
                conductorDAO.ObtenerRutasDelDia(idUsuario);

            if (rutasHoy == null || rutasHoy.Rows.Count == 0)
            {
                idProgramacionDelDia = 0;
                MostrarSinRutaDelDia();
                return;
            }

            // Identificar la programación de hoy
            idProgramacionDelDia =
                Convert.ToInt32(rutasHoy.Rows[0]["idProgramacion"]);

            // Cargar nombres y estados guardados en SQL
            CargarProgresoProgramacion(idProgramacionDelDia);
        }

        private void btnAccionRuta_Click(object sender, EventArgs e)
        {

        }

        private void lblSinRutas_Click(object sender, EventArgs e)
        {

        }
    }
}
