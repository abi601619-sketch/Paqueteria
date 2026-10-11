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
    public partial class frmAsignarCondutctor : Form
    {
        private Vehiculos vehiculoActual;

        public event Action ConductorAsignado;

        public frmAsignarCondutctor(Vehiculos vehiculo)
        {
            InitializeComponent();

            vehiculoActual = vehiculo;

            CargarConductores();
        }

        private void CargarConductores()
        {
            Modelo.Entidades.Conductor entidad = new Modelo.Entidades.Conductor();

            List<Modelo.Entidades.Conductor> conductores =
                entidad.ObtenerConductoresDisponibles(
                    vehiculoActual.IdVehiculo);

            cmbConductor.DataSource = null;
            cmbConductor.DisplayMember = "NombreCompleto";
            cmbConductor.ValueMember = "IdUsuario";
            cmbConductor.DataSource = conductores;

            if (conductores.Count == 0)
            {
                cmbConductor.Enabled = false;
                btnAgregar.Enabled = false;

                MessageBox.Show(
                    "No hay conductores disponibles para asignar.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                cmbConductor.Enabled = true;
                btnAgregar.Enabled = true;
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void cmbConductor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbConductor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un conductor.");
                return;
            }

            int idUsuario = Convert.ToInt32(
                cmbConductor.SelectedValue);

            if (vehiculoActual.AgregarConductor(idUsuario))
            {
                MessageBox.Show(
                    "Conductor asignado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ConductorAsignado?.Invoke();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo asignar el conductor. " +
                    "Es posible que ya esté asignado a este vehículo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
