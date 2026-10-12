using Modelo.Entidades;
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
        private int idUsuario;

        public frmMenu(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
            this.TopMost = false;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

            AbrirFormularioEnPanel(new frmDashboardConductor(idUsuario));
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

        private void AbrirFormularioEnPanel(Form formulario)
        {
            pnlInformacion.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlInformacion.Controls.Add(formulario);
            formulario.Show();
        }




        public void MostrarProductos(int idProgramacion)
        {
            AbrirFormularioEnPanel(
                new frmProductos(idProgramacion, this)
            );
        }

        public void MostrarRutas()
        {
            AbrirFormularioEnPanel(
                new frmRutasC(idUsuario, this)
            );
        }



        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmDashboardConductor(idUsuario));
        }

        private void pnlParteA_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRutasC_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmRutasC(idUsuario, this));
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmVehiculos());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
        }

        
    }
}
