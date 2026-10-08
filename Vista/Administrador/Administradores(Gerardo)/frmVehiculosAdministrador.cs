using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmVehiculosAdministrador : Form
    {
        public frmVehiculosAdministrador()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarVehiculo agregar = new frmAgregarVehiculo();
            agregar.ShowDialog();
        }
    }
}
