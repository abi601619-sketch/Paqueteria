namespace Vista.Administrador.Clientes
{
    partial class PedidoCard
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            picProducto = new Guna.UI2.WinForms.Guna2PictureBox();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblCantidad = new Label();
            lblFecha = new Label();
            lblEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)picProducto).BeginInit();
            SuspendLayout();
            // 
            // picProducto
            // 
            picProducto.CustomizableEdges = customizableEdges1;
            picProducto.ImageRotate = 0F;
            picProducto.Location = new Point(16, 18);
            picProducto.Name = "picProducto";
            picProducto.ShadowDecoration.CustomizableEdges = customizableEdges2;
            picProducto.Size = new Size(307, 194);
            picProducto.SizeMode = PictureBoxSizeMode.Zoom;
            picProducto.TabIndex = 0;
            picProducto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(32, 215);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Producto";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(33, 275);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 15);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Producto";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(32, 249);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(56, 15);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Producto";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(33, 311);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(56, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Producto";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(220, 325);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(56, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Producto";
            // 
            // PedidoCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblEstado);
            Controls.Add(lblFecha);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(picProducto);
            Name = "PedidoCard";
            Size = new Size(348, 384);
            ((System.ComponentModel.ISupportInitialize)picProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox picProducto;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblCantidad;
        private Label lblFecha;
        private Label lblEstado;
    }
}
