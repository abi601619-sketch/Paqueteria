using Modelo.Entidades;
using Modelo.Navegación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Conductor;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmDashboardAdministrador : Form
    {
        private Usuario usuario;
        public Action IrAConductores;
        public Action IrAVehiculos;

        public frmDashboardAdministrador(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            lblCorreoInsertar.Text = this.usuario.Correo;
            lblDuiInsertar.Text = this.usuario.Dui;

            CargarEstadisticas();

        }

        private void CargarEstadisticas()
        {
            Modelo.Entidades.Conductor conductor = new Modelo.Entidades.Conductor();
            Vehiculos vehiculo = new Vehiculos();

            lblConductores.Text =
                conductor.ObtenerCantidadConductores().ToString();

            lblVehiculos.Text =
                vehiculo.ObtenerCantidadVehiculos().ToString();
        }

        private void btnConductores_Click(object sender, EventArgs e)
        {
            IrAConductores?.Invoke();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            IrAVehiculos?.Invoke();
        }
    }
}
