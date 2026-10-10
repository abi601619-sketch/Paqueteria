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
            cptbPerfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            tlpNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cptbPerfil).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.None;
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(39, 3);
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
            tlpNombre.Location = new Point(16, 89);
            tlpNombre.Name = "tlpNombre";
            tlpNombre.RowCount = 1;
            tlpNombre.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpNombre.Size = new Size(196, 27);
            tlpNombre.TabIndex = 2;
            // 
            // cptbPerfil
            // 
            cptbPerfil.ImageRotate = 0F;
            cptbPerfil.InitialImage = (Image)resources.GetObject("cptbPerfil.InitialImage");
            cptbPerfil.Location = new Point(66, 3);
            cptbPerfil.Name = "cptbPerfil";
            cptbPerfil.ShadowDecoration.CustomizableEdges = customizableEdges1;
            cptbPerfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            cptbPerfil.Size = new Size(97, 80);
            cptbPerfil.TabIndex = 3;
            cptbPerfil.TabStop = false;
            // 
            // ucConductor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cptbPerfil);
            Controls.Add(tlpNombre);
            Name = "ucConductor";
            Size = new Size(233, 130);
            Click += ucConductor_Click;
            tlpNombre.ResumeLayout(false);
            tlpNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cptbPerfil).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblNombre;
        private TableLayoutPanel tlpNombre;
        private Guna.UI2.WinForms.Guna2CirclePictureBox cptbPerfil;
    }
}
