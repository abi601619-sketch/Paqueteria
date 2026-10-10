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
        public Action IrAConductores;
        public Action IrAVehiculos;

        public frmDashboardAdministrador()
        {
            InitializeComponent();

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
