using Modelo.Entidades;
using Modelo.Navegación;
using Conductor = Modelo.Entidades.Conductor;
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
        private frmConductoresAdministrador adminConductores;
        private Usuario usuario;

        public frmMenuAdministradores(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        public Panel panelPlantilla
        {
            get { return pnlPlantilla; }
        }

        private void AbrirDashboard(Usuario usuario)
        {
            if (usuario == null)
            {
                MessageBox.Show("No se recibió ningún usuario.");
                return;
            }

            frmDashboardAdministrador dash =
                new frmDashboardAdministrador(usuario);

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


        private void AbrirConductores()
        {
            adminConductores = new frmConductoresAdministrador();

            adminConductores.AbrirInfo += AbrirInformacionConductor;

            navegador.AbrirFormularioEnPanel(
                this.panelPlantilla,
                adminConductores
            );
        }


        private void AbrirInformacionVehiculo(Vehiculos vehiculo)
        {
            frmInformacionVehiculo form = new frmInformacionVehiculo(vehiculo);
            form.volver += AbrirVehiculos;
            form.VehiculoEliminado += AbrirVehiculos;
            navegador.AbrirFormularioEnPanel(this.pnlPlantilla, form);
        }


        private void AbrirInformacionConductor(
            Modelo.Entidades.Conductor conductor)
        {
            frmInformacionConductor form =
                new frmInformacionConductor(conductor);

            form.volver += AbrirConductores;

            form.ConductorEliminado += () =>
            {
                adminConductores?.ActualizarListaConductores();

                AbrirConductores();
            };

            navegador.AbrirFormularioEnPanel(
                this.panelPlantilla,
                form
            );
        }





        private void frmMenuAdministradores_Load(object sender, EventArgs e)
        {
            AbrirDashboard(usuario);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirDashboard(usuario);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            AbrirVehiculos();
        }

        private void btnConductores_Click(object sender, EventArgs e)
        {
            AbrirConductores();
        }
    }
}
