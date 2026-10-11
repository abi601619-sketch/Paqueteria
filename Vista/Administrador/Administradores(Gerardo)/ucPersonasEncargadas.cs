using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class ucPersonasEncargadas : UserControl
    {
        public event Action<int> EliminarSolicitado;

        private int idUsuario;
        public ucPersonasEncargadas(string nombre, int idUsuario)
        {
            InitializeComponent();
            lblPersona.Text = nombre;
            this.idUsuario = idUsuario;
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
                EliminarSolicitado?.Invoke(idUsuario);
            }
        }
    }
}
