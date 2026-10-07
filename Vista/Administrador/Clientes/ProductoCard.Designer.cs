namespace Vista.Administrador.Clientes
{
    partial class ProductoCard
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
            picProducto = new PictureBox();
            lblNombre = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblPrecio = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)picProducto).BeginInit();
            SuspendLayout();
            // 
            // picProducto
            // 
            picProducto.Location = new Point(15, 8);
            picProducto.Name = "picProducto";
            picProducto.Size = new Size(215, 172);
            picProducto.SizeMode = PictureBoxSizeMode.Zoom;
            picProducto.TabIndex = 0;
            picProducto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(19, 186);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(73, 23);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Producto";
            // 
            // lblPrecio
            // 
            lblPrecio.BackColor = Color.Transparent;
            lblPrecio.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecio.ForeColor = Color.Red;
            lblPrecio.Location = new Point(20, 216);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(88, 19);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "PRECIO: $0.00";
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.OrangeRed;
            guna2Button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(181, 244);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(49, 39);
            guna2Button1.TabIndex = 3;
            guna2Button1.Text = "\U0001f6d2";
            guna2Button1.TextOffset = new Point(0, -2);
            guna2Button1.Click += guna2Button1_Click;
            // 
            // ProductoCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Button1);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(picProducto);
            Name = "ProductoCard";
            Size = new Size(249, 300);
            ((System.ComponentModel.ISupportInitialize)picProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picProducto;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNombre;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPrecio;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
