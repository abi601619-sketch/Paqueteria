namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class ucConductor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConductor));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblNombre = new Label();
            tlpNombre = new TableLayoutPanel();
            tlpVehiculo = new TableLayoutPanel();
            lblVehiculo = new Label();
            tlpEstado = new TableLayoutPanel();
            lblEstado = new Label();
            cptbPerfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            tlpNombre.SuspendLayout();
            tlpVehiculo.SuspendLayout();
            tlpEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cptbPerfil).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.None;
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(55, 3);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(117, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Alejandro Pérez";
            // 
            // tlpNombre
            // 
            tlpNombre.ColumnCount = 1;
            tlpNombre.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpNombre.Controls.Add(lblNombre, 0, 0);
            tlpNombre.Location = new Point(3, 107);
            tlpNombre.Name = "tlpNombre";
            tlpNombre.RowCount = 1;
            tlpNombre.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpNombre.Size = new Size(227, 27);
            tlpNombre.TabIndex = 2;
            // 
            // tlpVehiculo
            // 
            tlpVehiculo.BackColor = SystemColors.ControlLight;
            tlpVehiculo.ColumnCount = 1;
            tlpVehiculo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpVehiculo.Controls.Add(lblVehiculo, 0, 0);
            tlpVehiculo.Location = new Point(14, 173);
            tlpVehiculo.Name = "tlpVehiculo";
            tlpVehiculo.RowCount = 1;
            tlpVehiculo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpVehiculo.Size = new Size(202, 27);
            tlpVehiculo.TabIndex = 2;
            // 
            // lblVehiculo
            // 
            lblVehiculo.Anchor = AnchorStyles.None;
            lblVehiculo.AutoSize = true;
            lblVehiculo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehiculo.Location = new Point(45, 3);
            lblVehiculo.Name = "lblVehiculo";
            lblVehiculo.Size = new Size(112, 20);
            lblVehiculo.TabIndex = 1;
            lblVehiculo.Text = "Vehículo ligero";
            // 
            // tlpEstado
            // 
            tlpEstado.ColumnCount = 1;
            tlpEstado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEstado.Controls.Add(lblEstado, 0, 0);
            tlpEstado.Location = new Point(55, 140);
            tlpEstado.Name = "tlpEstado";
            tlpEstado.RowCount = 1;
            tlpEstado.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpEstado.Size = new Size(120, 27);
            tlpEstado.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.None;
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(19, 3);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(82, 20);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Disponible";
            // 
            // cptbPerfil
            // 
            cptbPerfil.ImageRotate = 0F;
            cptbPerfil.InitialImage = (Image)resources.GetObject("cptbPerfil.InitialImage");
            cptbPerfil.Location = new Point(63, 3);
            cptbPerfil.Name = "cptbPerfil";
            cptbPerfil.ShadowDecoration.CustomizableEdges = customizableEdges1;
            cptbPerfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            cptbPerfil.Size = new Size(112, 98);
            cptbPerfil.TabIndex = 3;
            cptbPerfil.TabStop = false;
            // 
            // ucConductor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cptbPerfil);
            Controls.Add(tlpVehiculo);
            Controls.Add(tlpEstado);
            Controls.Add(tlpNombre);
            Name = "ucConductor";
            Size = new Size(233, 203);
            tlpNombre.ResumeLayout(false);
            tlpNombre.PerformLayout();
            tlpVehiculo.ResumeLayout(false);
            tlpVehiculo.PerformLayout();
            tlpEstado.ResumeLayout(false);
            tlpEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cptbPerfil).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblNombre;
        private TableLayoutPanel tlpNombre;
        private TableLayoutPanel tlpVehiculo;
        private Label lblVehiculo;
        private TableLayoutPanel tlpEstado;
        private Label lblEstado;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cptbPerfil;
    }
}
