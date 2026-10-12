using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class ucVehiculo : UserControl
    {
        public event Action<Vehiculos> AbrirInfo;

        private Vehiculos vehiculo;

        public ucVehiculo(Vehiculos vehiculo)
        {
            InitializeComponent();
            this.vehiculo = vehiculo;
        }

        public void CargarDatos(Vehiculos vehiculo)
        {
            lblNombre.Text = vehiculo.Modelo;
            lblPeso.Text = vehiculo.Capacidad;
            lblCapacidad.Text = vehiculo.Kilometraje;

            if (vehiculo.FotoCarro != null)
            {
                using (MemoryStream ms = new MemoryStream(vehiculo.FotoCarro))
                {
                    ptbVehiculo.Image = Image.FromStream(ms);
                }
            }
        }

        private void pnlMain_Click(object sender, EventArgs e)
        {
            AbrirInfo?.Invoke(vehiculo);
        }

        private void ucVehiculo_Click(object sender, EventArgs e)
        {
            AbrirInfo?.Invoke(vehiculo);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void ptbVehiculo_Click(object sender, EventArgs e)
        {
            AbrirInfo?.Invoke(vehiculo);
        }
    }
}
