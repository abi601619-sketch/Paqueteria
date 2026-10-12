using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ConductorEntidad = Modelo.Entidades.Conductor;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class ucConductor : UserControl
    {
        public Action<ConductorEntidad> AbrirInfo;
        public ConductorEntidad Conductor;

        public ucConductor(ConductorEntidad Conductor)
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(235, 235, 235);
            this.Padding = new Padding(1);

            this.Conductor = Conductor;
            CargarDatos(Conductor);
        }

        public void CargarDatos(ConductorEntidad conductor)
        {
            lblNombre.Text = conductor.Nombre + " " + conductor.Apellido;

            if (conductor.FotoPerfil != null)
            {
                using (MemoryStream ms = new MemoryStream(conductor.FotoPerfil))
                {
                    cptbPerfil.Image = Image.FromStream(ms);
                }
            }
            else
            {
                cptbPerfil.Image = null;
            }
        }

        private void ucConductor_Click(object sender, EventArgs e)
        {
            AbrirInfo?.Invoke(Conductor);
        }

        private void cptbPerfil_Click(object sender, EventArgs e)
        {
            AbrirInfo?.Invoke(Conductor);
        }
    }
}
