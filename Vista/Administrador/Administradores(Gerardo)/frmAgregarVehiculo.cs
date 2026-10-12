using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Vista.Administrador.Administradores_Gerardo_
{
    public partial class frmAgregarVehiculo : Form
    {
        private bool fotoSeleccionada = false;
        public frmAgregarVehiculo()
        {
            InitializeComponent();
            txtCapacidad.KeyPress += SoloNumeros_KeyPress;
            txtKilometraje.KeyPress += SoloNumeros_KeyPress;
        }

        private byte[] ObtenerImagen()
        {
            if (ptbFotoVehiculo.Image == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                ptbFotoVehiculo.Image.Save(
                    ms,
                    System.Drawing.Imaging.ImageFormat.Jpeg
                );

                return ms.ToArray();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(cmbMarca.Text))
            {
                MessageBox.Show("Ingrese la marca del vehículo.");
                cmbMarca.Focus();
                return false;
            }

            if (!fotoSeleccionada)
            {
                MessageBox.Show(
                    "Debes seleccionar una foto del vehículo.",
                    "Foto obligatoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                ptbFotoVehiculo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("Ingrese la capacidad del vehículo.");
                txtCapacidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Ingrese el modelo del vehículo.");
                txtModelo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKilometraje.Text))
            {
                MessageBox.Show("Ingrese el kilometraje.");
                txtKilometraje.Focus();
                return false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado del vehículo.");
                cmbEstado.Focus();
                return false;
            }

            if (cmbTipoCarro.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de vehículo.");
                cmbTipoCarro.Focus();
                return false;
            }

            return true;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números y teclas de control, como borrar
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptbFotoVehiculo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter =
                    "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                dialogo.Title = "Seleccionar foto del vehículo";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    ptbFotoVehiculo.Image = Image.FromFile(dialogo.FileName);
                    ptbFotoVehiculo.SizeMode = PictureBoxSizeMode.Zoom;
                    fotoSeleccionada = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Vehiculos vehiculo = new Vehiculos();

            vehiculo.Marca = cmbMarca.Text.Trim();
            vehiculo.Capacidad = txtCapacidad.Text.Trim();
            vehiculo.Modelo = txtModelo.Text.Trim();
            vehiculo.Kilometraje = txtKilometraje.Text.Trim() + " km";

            vehiculo.Estado = cmbEstado.Text;

            vehiculo.Disponibilidad = chkDisponibilidad.Checked;

            vehiculo.FotoCarro = ObtenerImagen();

            vehiculo.TipoCarro = cmbTipoCarro.SelectedIndex == 1;

            if (vehiculo.AgregarVehiculo())
            {
                MessageBox.Show(
                    "Vehículo agregado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo agregar el vehículo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
