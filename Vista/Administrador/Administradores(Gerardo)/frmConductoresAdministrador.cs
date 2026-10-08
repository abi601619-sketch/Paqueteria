using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmConductoresAdministrador : Form
    {
        public frmConductoresAdministrador()
        {
            InitializeComponent();
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
