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

        public frmInformacionVehiculo(Vehiculos vehiculo)
        {
            InitializeComponent();

            this.vehiculo = vehiculo;
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

            if (vehiculo.FotoCarro != null)
            {
                using (MemoryStream ms = new MemoryStream(vehiculo.FotoCarro))
                {
                    ptbFoto.Image = Image.FromStream(ms);
                }
            }
        }


        private void lblModelo_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAsignarCondutctor asignar = new frmAsignarCondutctor();
            asignar.ShowDialog();
        }

        private void ptbBack_Click(object sender, EventArgs e)
        {
            volver?.Invoke();
        }
    }
}
