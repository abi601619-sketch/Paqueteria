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
    public partial class frmEditarVehiculo : Form
    {
        private bool fotoSeleccionada = false;
        public event Action VehiculoActualizado;
        public event Action VehiculoEliminado;
        private Vehiculos vehiculoActual;

        public frmEditarVehiculo(Vehiculos vehiculo)
        {
            InitializeComponent();
            vehiculoActual = vehiculo;

            txtCapacidad.KeyPress += SoloNumeros_KeyPress;
            txtKilometraje.KeyPress += SoloNumeros_KeyPress;

            CargarDatosVehiculo();
        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(cmbMarca.Text))
            {
                MessageBox.Show("Ingrese la marca del vehículo.");
                cmbMarca.Focus();
                return false;
            }

            // Al editar, no es obligatorio seleccionar otra foto.
            if (ptbFotoVehiculo.Image == null)
            {
                MessageBox.Show(
                    "El vehículo debe tener una foto.",
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void CargarDatosVehiculo()
        {
            if (vehiculoActual == null)
            {
                MessageBox.Show("No se recibió información del vehículo.");
                Close();
                return;
            }

            cmbMarca.Text = vehiculoActual.Marca;
            txtCapacidad.Text = vehiculoActual.Capacidad;
            txtModelo.Text = vehiculoActual.Modelo;

            // Quitamos " km" para que el campo contenga solo números.
            txtKilometraje.Text = vehiculoActual.Kilometraje?
                .Replace(" km", "").Trim();

            cmbEstado.Text = vehiculoActual.Estado;

            // Restauramos el tipo de vehículo.
            cmbTipoCarro.SelectedIndex = vehiculoActual.TipoCarro ? 1 : 0;

            chkDisponibilidad.Checked = vehiculoActual.Disponibilidad;

            // Mostramos la fotografía guardada.
            if (vehiculoActual.FotoCarro != null &&
                vehiculoActual.FotoCarro.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(vehiculoActual.FotoCarro))
                using (Image imagen = Image.FromStream(ms))
                {
                    ptbFotoVehiculo.Image = new Bitmap(imagen);
                }

                ptbFotoVehiculo.SizeMode = PictureBoxSizeMode.Zoom;
            }

            // No obligamos a seleccionar una foto nueva.
            fotoSeleccionada = false;
        }




        private void frmEditarVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptbFotoVehiculo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                dialogo.Title = "Seleccionar foto del vehículo";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(
                        dialogo.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            ms.Position = 0;

                            using (Image imagenTemporal = Image.FromStream(ms))
                            {
                                ptbFotoVehiculo.Image = new Bitmap(imagenTemporal);
                            }
                        }
                    }

                    ptbFotoVehiculo.SizeMode = PictureBoxSizeMode.Zoom;
                    fotoSeleccionada = true;
                }
            }
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


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            // Actualizar los datos del vehículo seleccionado.
            vehiculoActual.Marca = cmbMarca.Text.Trim();
            vehiculoActual.Capacidad = txtCapacidad.Text.Trim();
            vehiculoActual.Modelo = txtModelo.Text.Trim();
            vehiculoActual.Kilometraje = txtKilometraje.Text.Trim() + " km";
            vehiculoActual.Estado = cmbEstado.Text;
            vehiculoActual.Disponibilidad = chkDisponibilidad.Checked;
            vehiculoActual.TipoCarro = cmbTipoCarro.SelectedIndex == 1;

            // Solo reemplazar la foto si el usuario seleccionó una nueva.
            if (fotoSeleccionada)
            {
                vehiculoActual.FotoCarro = ObtenerImagen();
            }

            // Ejecutar la actualización en SQL Server.
            if (vehiculoActual.ActualizarVehiculo())
            {
                MessageBox.Show(
                    "Vehículo actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                VehiculoActualizado?.Invoke();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar el vehículo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
        "¿Estás seguro de que deseas eliminar este vehículo? " +
        "También se eliminarán sus registros relacionados.",
        "Confirmar eliminación",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

            if (respuesta != DialogResult.Yes)
                return;

            if (vehiculoActual.EliminarVehiculo())
            {
                MessageBox.Show(
                    "Vehículo eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                VehiculoEliminado?.Invoke();
                this.Close();
            }
        }
    }
}
