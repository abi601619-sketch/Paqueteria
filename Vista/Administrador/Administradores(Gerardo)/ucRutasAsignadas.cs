using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class ucRutasAsignadas : UserControl
    {
        private int idRuta;

        public event Action<int> EliminarSolicitado;

        public ucRutasAsignadas(int idRuta, string nombreRuta, string zona)
        {
            InitializeComponent();

            this.idRuta = idRuta;
            lblVehiculo.Text = nombreRuta + " - " + zona;
        }

        private void ptbDelete_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Deseas quitar esta ruta del conductor?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                EliminarSolicitado?.Invoke(idRuta);
            }
        }
    }
}
