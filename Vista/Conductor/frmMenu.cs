using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Conductor
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboardC_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarS_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea salir?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
