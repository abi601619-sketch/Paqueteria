using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Navegación
{
    public class Navegacion
    {
        public void AbrirFormularioEnPanel(
  Panel panelContenedor,
  Form formularioHijo)
        {
            if (panelContenedor.Tag is Form formularioActual &&
                formularioActual.GetType() == formularioHijo.GetType())
            {
                formularioHijo.Dispose();
                formularioActual.BringToFront();
                return;
            }

            if (panelContenedor.Tag is Form formularioAnterior)
            {
                panelContenedor.Controls.Remove(formularioAnterior);

                formularioAnterior.Close();
                formularioAnterior.Dispose();
            }

            panelContenedor.Controls.Clear();

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;

            formularioHijo.Show();
            formularioHijo.BringToFront();
        }
    }
}
