using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmInformacionVehiculo : Form
    {
        public frmInformacionVehiculo()
        {
            InitializeComponent();
        }

        private void lblModelo_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAsignarCondutctor asignar = new frmAsignarCondutctor();
            asignar.ShowDialog();
        }
    }
}
