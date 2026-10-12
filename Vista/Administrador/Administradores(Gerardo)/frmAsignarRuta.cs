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
    public partial class frmAsignarRuta : Form
    {
        public event Action RutaAsignada;
        private Modelo.Entidades.Conductor conductorActual;
        public frmAsignarRuta(Modelo.Entidades.Conductor conductor)
        {
            InitializeComponent();
            conductorActual = conductor;
            CargarRutasEnComboBox();
        }

        private void CargarRutasEnComboBox()
        {
            Ruta ruta = new Ruta();

            List<Ruta> rutasDisponibles =
                ruta.ObtenerRutasDisponibles(conductorActual.IdUsuario);

            cmbConductor.DataSource = null;
            cmbConductor.DataSource = rutasDisponibles;
            cmbConductor.DisplayMember = "Nombre";
            cmbConductor.ValueMember = "IdRuta";

            if (rutasDisponibles.Count == 0)
            {
                MessageBox.Show(
                    "No hay rutas disponibles para asignar.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbConductor.SelectedItem == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una ruta.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Ruta rutaSeleccionada = cmbConductor.SelectedItem as Ruta;

            if (rutaSeleccionada == null)
            {
                MessageBox.Show("No se pudo obtener la ruta seleccionada.");
                return;
            }

            if (rutaSeleccionada.AgregarAConductor(conductorActual.IdUsuario))
            {
                MessageBox.Show(
                    "Ruta asignada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                RutaAsignada?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo asignar la ruta.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
