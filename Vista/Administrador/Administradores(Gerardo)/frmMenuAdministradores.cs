using Modelo.Entidades;
using Modelo.Navegación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmMenuAdministradores : Form
    {

        private Navegacion navegador = new Navegacion();

        public frmMenuAdministradores()
        {
            InitializeComponent();
        }

        public Panel panelPlantilla
        {
            get { return pnlPlantilla; }
        }

        private void AbrirDashboard()
        {
            frmDashboardAdministrador dash = new frmDashboardAdministrador();
            dash.IrAConductores += AbrirConductores;
            dash.IrAVehiculos += AbrirVehiculos;
            navegador.AbrirFormularioEnPanel(this.panelPlantilla, dash);
        }

        private void AbrirVehiculos()
        {
            frmVehiculosAdministrador vehiculo = new frmVehiculosAdministrador();
            vehiculo.AbrirInfo += AbrirInformacionVehiculo;
            navegador.AbrirFormularioEnPanel(this.panelPlantilla, vehiculo);
        }

        private void AbrirPedidos()
        {
            frmPedidosAdministrador pedido = new frmPedidosAdministrador();
            navegador.AbrirFormularioEnPanel(this.panelPlantilla, pedido);
        }

        private void AbrirConductores()
        {
            frmConductoresAdministrador conductor = new frmConductoresAdministrador();
            navegador.AbrirFormularioEnPanel(this.panelPlantilla, conductor);
        }

        private void AbrirInformacionVehiculo(Vehiculos vehiculo)
        {
            frmInformacionVehiculo form = new frmInformacionVehiculo(vehiculo);
            form.volver += AbrirVehiculos;
            navegador.AbrirFormularioEnPanel(this.pnlPlantilla, form);
        }



        private void frmMenuAdministradores_Load(object sender, EventArgs e)
        {
            AbrirDashboard();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirDashboard();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            AbrirVehiculos();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirPedidos();
        }

        private void btnConductores_Click(object sender, EventArgs e)
        {
            AbrirConductores();
        }
    }
}
