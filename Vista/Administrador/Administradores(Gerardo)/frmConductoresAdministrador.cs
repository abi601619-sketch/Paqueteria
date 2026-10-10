using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntidadConductor = Modelo.Entidades.Conductor;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmConductoresAdministrador : Form
    {
        public frmConductoresAdministrador()
        {
            InitializeComponent();
            CargarTodosLosFLP();
        }

        private void CargarTodosLosFLP()
        {
            CargarConductoresEnFLP(flpZonaOriente, "Oriente");
            CargarConductoresEnFLP(flpZonaSur, "Occidente");
            CargarConductoresEnFLP(flpZonaCentral, "Central");
            CargarConductoresEnFLP(flpMultizona, "Multizonas");
        }

        private void CargarConductoresEnFLP(FlowLayoutPanel flp, string zona)
        {
            flp.Controls.Clear();

            EntidadConductor conductor = new EntidadConductor();

            List<EntidadConductor> conductores =
                conductor.CargarConductoresPorZona(zona);

            foreach (EntidadConductor c in conductores)
            {
                ucConductor uc = new ucConductor();

                uc.CargarDatos(c);

                flp.Controls.Add(uc);
            }
        }

        private void CargarConductores()
        {
            ucConductor conductor = new ucConductor();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarConductor agregar = new frmAgregarConductor();
            agregar.ShowDialog();
        }
    }
}
