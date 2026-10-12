using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class ucVehiculosEncargados : UserControl
    {
        private int idVehiculo;
        private string Modelo;
        private string Marca;
        public event Action<int> EliminarSolicitado;
        public ucVehiculosEncargados(int idVehiculo, string Modelo, string Marca)
        {
            InitializeComponent();
            this.idVehiculo = idVehiculo;
            lblVehiculo.Text = Modelo + " " + Marca;
        }

        private void ptbDelete_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
      "¿Deseas quitar a este conductor del vehículo?",
      "Confirmar eliminación",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                EliminarSolicitado?.Invoke(idVehiculo);
            }
        }
    }
}
