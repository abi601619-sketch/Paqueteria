using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadConductor = Modelo.Entidades.Conductor;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmConductoresAdministrador : Form
    {
        public event Action<Modelo.Entidades.Conductor> AbrirInfo;

        private const int ConductoresPorPagina = 6;

        // Listas independientes para cada zona
        private List<EntidadConductor> conductoresOriente =
            new List<EntidadConductor>();

        private List<EntidadConductor> conductoresOccidente =
            new List<EntidadConductor>();

        private List<EntidadConductor> conductoresCentral =
            new List<EntidadConductor>();

        private List<EntidadConductor> conductoresMultizona =
            new List<EntidadConductor>();

        // Página actual de cada zona
        private int paginaOriente = 0;
        private int paginaOccidente = 0;
        private int paginaCentral = 0;
        private int paginaMultizona = 0;

        public frmConductoresAdministrador()
        {
            InitializeComponent();

            CargarConductores();
        }

        private void CargarConductores()
        {
            EntidadConductor conductor = new EntidadConductor();

            // Cargar conductores de cada zona
            conductoresOriente =
                conductor.CargarConductoresPorZona("Oriente");

            conductoresOccidente =
                conductor.CargarConductoresPorZona("Occidente");

            conductoresCentral =
                conductor.CargarConductoresPorZona("Central");

            conductoresMultizona =
                conductor.CargarConductoresPorZona("Multizonas");

            // Volver a la primera página
            paginaOriente = 0;
            paginaOccidente = 0;
            paginaCentral = 0;
            paginaMultizona = 0;

            // Mostrar los conductores
            MostrarPaginaOriente();
            MostrarPaginaOccidente();
            MostrarPaginaCentral();
            MostrarPaginaMultizona();
        }

        private void SeleccionarCondutor(EntidadConductor conductor)
        {
            AbrirInfo?.Invoke(conductor);
        }

        private void MostrarPaginaOriente()
        {
            flpZonaOriente.Controls.Clear();

            var conductoresPagina = conductoresOriente
                .Skip(paginaOriente * ConductoresPorPagina)
                .Take(ConductoresPorPagina);

            foreach (EntidadConductor c in conductoresPagina)
            {
                ucConductor uc = new ucConductor(c);

                uc.CargarDatos(c);
                uc.AbrirInfo += SeleccionarCondutor;

                flpZonaOriente.Controls.Add(uc);
            }

            btnLeftZonaOriente.Enabled = paginaOriente > 0;

            btnNextZonaOriente.Enabled =
                (paginaOriente + 1) * ConductoresPorPagina
                < conductoresOriente.Count;
        }

        private void MostrarPaginaOccidente()
        {
            flpZonaSur.Controls.Clear();

            var conductoresPagina = conductoresOccidente
                .Skip(paginaOccidente * ConductoresPorPagina)
                .Take(ConductoresPorPagina);

            foreach (EntidadConductor c in conductoresPagina)
            {
                ucConductor uc = new ucConductor(c);

                uc.CargarDatos(c);
                uc.AbrirInfo += SeleccionarCondutor;

                flpZonaSur.Controls.Add(uc);
            }

            btnLeftZonaOccidente.Enabled = paginaOccidente > 0;

            btnNextZonaOccidente.Enabled =
                (paginaOccidente + 1) * ConductoresPorPagina
                < conductoresOccidente.Count;
        }

        private void MostrarPaginaCentral()
        {
            flpZonaCentral.Controls.Clear();

            var conductoresPagina = conductoresCentral
                .Skip(paginaCentral * ConductoresPorPagina)
                .Take(ConductoresPorPagina);

            foreach (EntidadConductor c in conductoresPagina)
            {
                ucConductor uc = new ucConductor(c);

                uc.CargarDatos(c);
                uc.AbrirInfo += SeleccionarCondutor;

                flpZonaCentral.Controls.Add(uc);
            }

            btnLeftZonaCentral.Enabled = paginaCentral > 0;

            btnNextZonaCentral.Enabled =
                (paginaCentral + 1) * ConductoresPorPagina
                < conductoresCentral.Count;
        }

        private void MostrarPaginaMultizona()
        {
            flpMultizona.Controls.Clear();

            var conductoresPagina = conductoresMultizona
                .Skip(paginaMultizona * ConductoresPorPagina)
                .Take(ConductoresPorPagina);

            foreach (EntidadConductor c in conductoresPagina)
            {
                ucConductor uc = new ucConductor(c);

                uc.CargarDatos(c);
                uc.AbrirInfo += SeleccionarCondutor;

                flpMultizona.Controls.Add(uc);
            }

            btnLeftMultizona.Enabled = paginaMultizona > 0;

            btnNextMultizona.Enabled =
                (paginaMultizona + 1) * ConductoresPorPagina
                < conductoresMultizona.Count;
        }

        public void ActualizarListaConductores()
        {
            CargarConductores();
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarConductor agregar = new frmAgregarConductor();

            agregar.ConductorAgregado += () =>
            {
                CargarConductores();
            };

            agregar.ShowDialog();
        }

        private void btnLeftZonaCentral_Click_1(object sender, EventArgs e)
        {
            if (paginaCentral > 0)
            {
                paginaCentral--;

                MostrarPaginaCentral();
            }
        }

        private void btnLeftZonaOriente_Click_1(object sender, EventArgs e)
        {

            if (paginaOriente > 0)
            {
                paginaOriente--;

                MostrarPaginaOriente();
            }
        }

        private void btnLeftZonaOccidente_Click_1(object sender, EventArgs e)
        {
            if (paginaOccidente > 0)
            {
                paginaOccidente--;

                MostrarPaginaOccidente();
            }
        }

        private void btnLeftMultizona_Click_1(object sender, EventArgs e)
        {
            if (paginaMultizona > 0)
            {
                paginaMultizona--;

                MostrarPaginaMultizona();
            }
        }

        private void btnNextZonaCentral_Click_1(object sender, EventArgs e)
        {
            if ((paginaCentral + 1) * ConductoresPorPagina
              < conductoresCentral.Count)
            {
                paginaCentral++;

                MostrarPaginaCentral();
            }
        }

        private void btnNextZonaOriente_Click_1(object sender, EventArgs e)
        {
            if ((paginaOriente + 1) * ConductoresPorPagina
             < conductoresOriente.Count)
            {
                paginaOriente++;

                MostrarPaginaOriente();
            }
        }

        private void btnNextZonaOccidente_Click(object sender, EventArgs e)
        {
            if ((paginaOccidente + 1) * ConductoresPorPagina
             < conductoresOccidente.Count)
            {
                paginaOccidente++;

                MostrarPaginaOccidente();
            }
        }

        private void btnNextMultizona_Click_1(object sender, EventArgs e)
        {
            if ((paginaMultizona + 1) * ConductoresPorPagina
               < conductoresMultizona.Count)
            {
                paginaMultizona++;

                MostrarPaginaMultizona();
            }
        }
    }
}