using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmInformacionVehiculo : Form
    {
        private Vehiculos vehiculo;
        public Action volver;
        public Action VehiculoEliminado;

        public frmInformacionVehiculo(Vehiculos vehiculo)
        {
            InitializeComponent();

            this.vehiculo = vehiculo;
            CargarConductoresEnFLP();
            CargarDatos();
        }

        private void CargarDatos()
        {
            lblModelo.Text = vehiculo.Modelo;
            lblMarca.Text = vehiculo.Marca;
            lblCapacidad.Text = vehiculo.Capacidad;
            lblEstado.Text = vehiculo.Estado;
            lblKilometraje.Text = vehiculo.Kilometraje;

            if (vehiculo.TipoCarro == true)
            {
                lblTitulo.Text = "Trailer";
            }
            else if (vehiculo.TipoCarro == false)
            {
                lblTitulo.Text = "Vehículo Ligero";
            }


            if (vehiculo.FotoCarro != null &&
                vehiculo.FotoCarro.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(vehiculo.FotoCarro))
                using (Image imagen = Image.FromStream(ms))
                {
                    ptbFoto.Image = new Bitmap(imagen);
                }

                ptbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }


        private void CargarConductoresEnFLP()
        {
            flpPersonasEncargadas.Controls.Clear();

            List<Modelo.Entidades.Conductor> conductores =
                vehiculo.ObtenerConductoresPorVehiculo();

            foreach (Modelo.Entidades.Conductor conductor in conductores)
            {
                ucPersonasEncargadas uc =
                    new ucPersonasEncargadas(
                        conductor.Nombre + " " + conductor.Apellido,
                        conductor.IdUsuario);

                uc.EliminarSolicitado += EliminarConductorAsignado;

                flpPersonasEncargadas.Controls.Add(uc);
            }
        }


        private void EliminarConductorAsignado(int idUsuario)
        {
            if (vehiculo.EliminarConductor(idUsuario))
            {
                CargarConductoresEnFLP();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo quitar al conductor del vehículo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }




        private void lblModelo_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAsignarCondutctor asignar = new frmAsignarCondutctor(vehiculo);
            asignar.ConductorAsignado += CargarConductoresEnFLP;
            asignar.ShowDialog();
        }

        private void ptbBack_Click(object sender, EventArgs e)
        {
            volver?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEditarVehiculo editar = new frmEditarVehiculo(vehiculo);
            editar.VehiculoActualizado += () =>
            {
                CargarDatos();
            };
            editar.VehiculoEliminado += () =>
            {
                volver?.Invoke();
            };
            editar.ShowDialog();
        }
    }
}
