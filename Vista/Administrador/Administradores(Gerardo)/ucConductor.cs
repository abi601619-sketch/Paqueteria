using System;
using System.IO;
using ConductorEntidad = Modelo.Entidades.Conductor;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class ucConductor : UserControl
    {
        public Action AbrirInfo;

        public ucConductor()
        {
            InitializeComponent();
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
            AbrirInfo?.Invoke();
        }
    }
}
