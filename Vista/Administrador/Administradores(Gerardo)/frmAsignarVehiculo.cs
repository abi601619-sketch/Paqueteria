using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmAsignarVehiculo : Form
    {
        private Modelo.Entidades.Conductor conductorActual;

        public event Action VehiculoAsignado;
        public frmAsignarVehiculo(Modelo.Entidades.Conductor conductor)
        {
            InitializeComponent();

            conductorActual = conductor;

            CargarVehiculos();
        }

        private void CargarVehiculos()
        {
            Vehiculos vehiculo = new Vehiculos();

            List<Vehiculos> lista =
                vehiculo.ObtenerVehiculosDisponiblesParaConductor(
                    conductorActual.IdUsuario);

            cmbConductor.DisplayMember = "Modelo";
            cmbConductor.ValueMember = "IdVehiculo";
            cmbConductor.DataSource = lista;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbConductor.SelectedItem == null)
            {
                MessageBox.Show("No hay vehículos disponibles para seleccionar.");
                return;
            }

            Vehiculos vehiculo = (Vehiculos)cmbConductor.SelectedItem;

            if (vehiculo.AgregarAConductor(conductorActual.IdUsuario))
            {
                MessageBox.Show("Vehículo asignado correctamente.");

                VehiculoAsignado?.Invoke();

                this.Close();
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
