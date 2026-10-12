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
    public partial class frmInformacionConductor : Form
    {
        public Action volver;
        public event Action ConductorEliminado;
        public Modelo.Entidades.Conductor conductor;

        public frmInformacionConductor(Modelo.Entidades.Conductor conductor)
        {
            InitializeComponent();
            this.conductor = conductor;
            lblTitulo.Text = conductor.Nombre + " " + conductor.Apellido;
            lblCorreoUsuario.Text = conductor.Correo;
            lblDuiUsuario.Text = conductor.Dui;
            lblZona.Text = conductor.ZonaEncargada;
            if (conductor.FotoPerfil != null)
            {
                using (MemoryStream ms = new MemoryStream(conductor.FotoPerfil))
                {
                    ptbFotoPerfil.Image = Image.FromStream(ms);
                }
            }
            CargarVehiculosEnFLP();
            CargarRutasEnFLP();
        }

        private void CargarVehiculosEnFLP()
        {
            flpVehiculos.Controls.Clear();

            List<Vehiculos> vehiculos =
                conductor.ObtenerVehiculosAsignados();

            foreach (Vehiculos vehiculo in vehiculos)
            {
                ucVehiculosEncargados uc =
                    new ucVehiculosEncargados(vehiculo.IdVehiculo, vehiculo.Modelo, vehiculo.Marca);

                uc.EliminarSolicitado += EliminarVehiculoAsignado;

                flpVehiculos.Controls.Add(uc);
            }
        }

        private void CargarRutasEnFLP()
        {
            flpRutas.Controls.Clear();

            Ruta ruta = new Ruta();

            List<Ruta> rutas =
                ruta.ObtenerRutasAsignadas(conductor.IdUsuario);

            foreach (Ruta r in rutas)
            {
                ucRutasAsignadas uc = new ucRutasAsignadas(
                    r.IdRuta,
                    r.Nombre,
                    r.Zona
                );

                uc.EliminarSolicitado += EliminarRutaAsignada;

                flpRutas.Controls.Add(uc);
            }
        }

        private void EliminarVehiculoAsignado(int idVehiculo)
        {
            Vehiculos vehiculo = new Vehiculos();
            vehiculo.IdVehiculo = idVehiculo;

            if (vehiculo.EliminarVehiculoDeConductor(conductor.IdUsuario))
            {
                CargarVehiculosEnFLP();

                MessageBox.Show(
                    "Vehículo quitado de las asignaciones del conductor.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "No se pudo quitar el vehículo del conductor.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EliminarRutaAsignada(int idRuta)
        {
            Ruta ruta = new Ruta();
            ruta.IdRuta = idRuta;

            if (ruta.EliminarDeConductor(conductor.IdUsuario))
            {
                CargarRutasEnFLP();

                MessageBox.Show(
                    "Ruta quitada de las asignaciones del conductor.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "No se pudo quitar la ruta del conductor.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ActualizarInformacion()
        {
            lblTitulo.Text = conductor.Nombre + " " + conductor.Apellido;
            lblCorreoUsuario.Text = conductor.Correo;
            lblDuiUsuario.Text = conductor.Dui;
            lblZona.Text = conductor.ZonaEncargada;

            if (conductor.FotoPerfil != null &&
                conductor.FotoPerfil.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(conductor.FotoPerfil))
                using (Image imagen = Image.FromStream(ms))
                {
                    ptbFotoPerfil.Image = new Bitmap(imagen);
                }

                ptbFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void ptbBack_Click(object sender, EventArgs e)
        {
            volver?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEditarConductor editar =
      new frmEditarConductor(conductor);

            editar.ConductorActualizado += () =>
            {
                ActualizarInformacion();
            };

            editar.ConductorEliminado += () =>
            {
                ConductorEliminado?.Invoke();
                this.Close();
            };

            editar.ShowDialog();
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            frmAsignarVehiculo asignar = new frmAsignarVehiculo(conductor);
            asignar.VehiculoAsignado += CargarVehiculosEnFLP;
            asignar.ShowDialog();
        }

        private void btnAgregarRuta_Click(object sender, EventArgs e)
        {
            frmAsignarRuta asignar = new frmAsignarRuta(conductor);

            asignar.RutaAsignada += CargarRutasEnFLP;

            asignar.ShowDialog();
        }
    }
}
