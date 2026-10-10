using Modelo.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmVehiculosAdministrador : Form
    {
        public event Action<Vehiculos> AbrirInfo;
        private List<Vehiculos> vehiculosLigeros = new List<Vehiculos>();
        private int paginaActual = 0;
        private const int vehiculosPorPagina = 3;

        private List<Vehiculos> trailers = new List<Vehiculos>();
        private int paginaTrailers = 0;

        public frmVehiculosAdministrador()
        {
            InitializeComponent();

            Vehiculos vehiculo = new Vehiculos();

            vehiculosLigeros = vehiculo.CargarVehiculosPorTipo(false);
            trailers = vehiculo.CargarVehiculosPorTipo(true);

            MostrarPaginaVehiculosLigeros();
            MostrarPaginaTrailers();
        }

        private void MostrarPaginaVehiculosLigeros()
        {
            flpCarrosLigeros.Controls.Clear();

            var vehiculosPagina = vehiculosLigeros
                .Skip(paginaActual * vehiculosPorPagina)
                .Take(vehiculosPorPagina);

            foreach (Vehiculos v in vehiculosPagina)
            {
                ucVehiculo uc = new ucVehiculo(v);

                uc.CargarDatos(v);
                uc.AbrirInfo += SeleccionarVehiculo;

                flpCarrosLigeros.Controls.Add(uc);
            }

            // Habilitar o deshabilitar los botones
            btnLeftLigeros.Enabled = paginaActual > 0;

            btnNextLigeros.Enabled =
                (paginaActual + 1) * vehiculosPorPagina < vehiculosLigeros.Count;
        }

        private void MostrarPaginaTrailers()
        {
            flpTrailers.Controls.Clear();

            var trailersPagina = trailers
                .Skip(paginaTrailers * vehiculosPorPagina)
                .Take(vehiculosPorPagina);

            foreach (Vehiculos v in trailersPagina)
            {
                ucVehiculo uc = new ucVehiculo(v);

                uc.CargarDatos(v);
                uc.AbrirInfo += SeleccionarVehiculo;

                flpTrailers.Controls.Add(uc);
            }

            btnLeftTrailers.Enabled = paginaTrailers > 0;

            btnNextTrailers.Enabled =
                (paginaTrailers + 1) * vehiculosPorPagina < trailers.Count;
        }

        private void RecargarVehiculos()
        {
            Vehiculos vehiculo = new Vehiculos();

            // Volver a consultar la base de datos
            vehiculosLigeros = vehiculo.CargarVehiculosPorTipo(false);
            trailers = vehiculo.CargarVehiculosPorTipo(true);

            // Regresar a la primera página
            paginaActual = 0;
            paginaTrailers = 0;

            // Reconstruir ambos FlowLayoutPanel
            MostrarPaginaVehiculosLigeros();
            MostrarPaginaTrailers();
        }

        private void SeleccionarVehiculo(Vehiculos vehiculo)
        {
            AbrirInfo?.Invoke(vehiculo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarVehiculo agregar = new frmAgregarVehiculo();
            agregar.ShowDialog();
            RecargarVehiculos();
        }

        private void btnNextLigeros_Click(object sender, EventArgs e)
        {
            if ((paginaActual + 1) * vehiculosPorPagina < vehiculosLigeros.Count)
            {
                paginaActual++;
                MostrarPaginaVehiculosLigeros();
            }
        }

        private void btnLeftLigeros_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                MostrarPaginaVehiculosLigeros();
            }
        }

        private void btnNextTrailers_Click(object sender, EventArgs e)
        {
            if ((paginaTrailers + 1) * vehiculosPorPagina < trailers.Count)
            {
                paginaTrailers++;
                MostrarPaginaTrailers();
            }
        }

        private void btnLeftTrailers_Click(object sender, EventArgs e)
        {
            if (paginaTrailers > 0)
            {
                paginaTrailers--;
                MostrarPaginaTrailers();
            }
        }
    }
}

