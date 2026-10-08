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

        public frmDashboardConductor(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            CargarProgramacionRutas();
            CargarDatosConductor();
            CrearCalendario();
            CargarRutas();
        }

        //Calendario ---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void CrearCalendario()
        {
            tlpCalendario.Controls.Clear();

            DateTime fechaActual = DateTime.Now;

            int mes = fechaActual.Month;
            int año = fechaActual.Year;

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

        //Tarjetas de Rutas ----------------------------------------------------------------------------------------------------------------------------------------
        private void CargarDatosConductor()
        {
            ConductorDAO conductorDAO = new ConductorDAO();

            conductor = conductorDAO.ObtenerConductor(idUsuario);

            if (conductor != null)
            {
                MessageBox.Show(
                    "Nombre: " + conductor.Nombre + " " + conductor.Apellido +
                    "\nZona: " + conductor.ZonaEncargada +
                    "\nCorreo: " + conductor.Correo,
                    "Datos del conductor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "No se encontró la información del conductor.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarRutas()
        {
            ConductorDAO conductorDAO = new ConductorDAO();

            DataTable rutas =
                conductorDAO.ObtenerRutas(idUsuario);

            pnlRutas.Controls.Clear();

            foreach (DataRow fila in rutas.Rows)
            {
                Panel tarjeta = CrearTarjetaRuta(fila);

                pnlRutas.Controls.Add(tarjeta);
            }
        }

        //private void CargarProgresoRuta()
        //{
        //    ConductorDAO conductorDAO = new ConductorDAO();

        //    DataTable tabla = conductorDAO.ObtenerRutaProgreso(idUsuario);

        //    if (tabla.Rows.Count == 0)
        //    {
        //        return;
        //    }

        //    DataRow ruta = tabla.Rows[0];

        //    lblPunto1.Text = ruta["PuntoOrigen"].ToString();

        //    if (ruta["DestinoA"] != DBNull.Value)
        //        lblPunto2.Text = ruta["DestinoA"].ToString();
        //    else
        //        lblPunto2.Text = "Sin parada";

        //    lblPunto3.Text = ruta["PuntoFinal"].ToString();

        //    lblEstado1.Text = "COMPLETADO";
        //    lblEstado2.Text = "EN CAMINO";
        //    lblEstado3.Text = "PENDIENTE";
        //}

        private Panel CrearTarjetaRuta(DataRow fila)
        {
            // ==========================
            // TARJETA
            // ==========================

            Panel tarjeta = new Panel();

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

            return tarjeta;
        }
    }
}
