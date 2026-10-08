using Modelo.Navegación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


        private void frmMenuAdministradores_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            navegador.AbrirFormularioEnPanel(this.pnlPlantilla, new frmDashboardAdministrador());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            navegador.AbrirFormularioEnPanel(this.pnlPlantilla, new frmVehiculosAdministrador());
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            navegador.AbrirFormularioEnPanel(this.pnlPlantilla, new frmPedidosAdministrador());
        }

        private void btnConductores_Click(object sender, EventArgs e)
        {
            navegador.AbrirFormularioEnPanel(this.pnlPlantilla, new frmConductoresAdministrador());
        }
    }
}
