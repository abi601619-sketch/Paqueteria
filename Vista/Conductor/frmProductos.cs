using Modelo.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Conductor
{
    public partial class frmProductos : Form
    {

        private readonly int idProgramacion;
        private readonly frmMenu menuPrincipal;

        public frmProductos(int idProgramacion, frmMenu menuPrincipal)
        {
            InitializeComponent();

            this.idProgramacion = idProgramacion;
            this.menuPrincipal = menuPrincipal;

            Load += frmProductosRuta_Load;

            btnCerrar.Click += (s, e) =>
            {
                menuPrincipal.MostrarRutas();
            };
        }




        private void frmProductosRuta_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable productos =
                    new ConductorDAO()
                    .ObtenerProductosSolicitadosPorRuta(idProgramacion);

                // Cargar los productos
                dgvProductos.DataSource = productos;
                bool rutaHoy = new ConductorDAO().EsRutaDelDia(idProgramacion);

                // Conectar eventos para guardar el estado de entrega
                dgvProductos.CurrentCellDirtyStateChanged -=
                    dgvProductos_CurrentCellDirtyStateChanged;

                dgvProductos.CurrentCellDirtyStateChanged +=
                    dgvProductos_CurrentCellDirtyStateChanged;

                dgvProductos.CellValueChanged -=
                    dgvProductos_CellValueChanged;

                dgvProductos.CellValueChanged +=
                    dgvProductos_CellValueChanged;

                dgvProductos.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvProductos.AllowUserToAddRows = false;
                dgvProductos.AllowUserToDeleteRows = false;
                dgvProductos.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvProductos.MultiSelect = false;

                // Ocultar columnas internas
                string[] columnasOcultar =
{
    "idAsignacion",
    "idPedido",
    "idProducto",
    "Subtotal",
    "EstadoAsignacion",
    "FechaAsignacion",
    "EstadoPedido"
};

                foreach (string columna in columnasOcultar)
                {
                    if (dgvProductos.Columns.Contains(columna))
                        dgvProductos.Columns[columna].Visible = false;
                }

                // Personalizar encabezados
                if (dgvProductos.Columns.Contains("NombreProducto"))
                    dgvProductos.Columns["NombreProducto"].HeaderText = "Nombre";

                if (dgvProductos.Columns.Contains("Precio"))
                    dgvProductos.Columns["Precio"].HeaderText = "Precio";

                if (dgvProductos.Columns.Contains("Cantidad"))
                    dgvProductos.Columns["Cantidad"].HeaderText = "Cantidad";

                if (dgvProductos.Columns.Contains("PuntoEntrega"))
                    dgvProductos.Columns["PuntoEntrega"].HeaderText =
                        "Lugar de entrega";

                // Configurar la columna Entregado
                if (dgvProductos.Columns.Contains("Entregado"))
                {
                    dgvProductos.Columns["Entregado"].HeaderText = "Entregado";
                    dgvProductos.Columns["Entregado"].ReadOnly = false;
                }
                else
                {
                    DataGridViewCheckBoxColumn columnaEntregado =
                        new DataGridViewCheckBoxColumn();

                    columnaEntregado.Name = "Entregado";
                    columnaEntregado.HeaderText = "Entregado";
                    columnaEntregado.DataPropertyName = "Entregado";
                    columnaEntregado.TrueValue = true;
                    columnaEntregado.FalseValue = false;
                    columnaEntregado.ReadOnly = false;

                    dgvProductos.Columns.Add(columnaEntregado);
                }

                // Bloquear todas las columnas excepto Entregado
                foreach (DataGridViewColumn columna in dgvProductos.Columns)
                {
                    columna.ReadOnly =
                        columna.Name != "Entregado" || !rutaHoy;
                }

                // Permitir editar únicamente la casilla
                dgvProductos.ReadOnly = false;

                if (productos.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Esta ruta todavía no tiene productos asignados.",
                        "Productos solicitados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los productos: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void dgvProductos_CurrentCellDirtyStateChanged(
            object sender, EventArgs e)
        {
            if (dgvProductos.IsCurrentCellDirty &&
                dgvProductos.CurrentCell is DataGridViewCheckBoxCell &&
                dgvProductos.Columns[dgvProductos.CurrentCell.ColumnIndex].Name == "Entregado")
            {
                dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvProductos_CellValueChanged(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvProductos.Columns[e.ColumnIndex].Name != "Entregado")
                return;

            try
            {
                object valorId = dgvProductos.Rows[e.RowIndex]
                    .Cells["idAsignacion"].Value;

                if (valorId == null || valorId == DBNull.Value)
                    throw new Exception("No se encontró el identificador de la asignación.");

                int idAsignacion = Convert.ToInt32(valorId);

                object valorEntregado = dgvProductos.Rows[e.RowIndex]
                    .Cells["Entregado"].Value;

                bool entregado =
                    valorEntregado != null &&
                    valorEntregado != DBNull.Value &&
                    Convert.ToBoolean(valorEntregado);

                new ConductorDAO().ActualizarEntregaProducto(
                    idAsignacion, entregado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el estado de entrega: " + ex.Message,
                    "MyPickup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void lblRutasC_Click(object sender, EventArgs e)
        {

        }
    }
}
