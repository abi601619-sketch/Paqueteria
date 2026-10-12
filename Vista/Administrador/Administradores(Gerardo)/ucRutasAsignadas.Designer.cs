namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class ucRutasAsignadas
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
            lblVehiculo = new Label();
            ptbDelete = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ptbDelete).BeginInit();
            SuspendLayout();
            // 
            // lblVehiculo
            // 
            lblVehiculo.AutoSize = true;
            lblVehiculo.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehiculo.Location = new Point(8, 14);
            lblVehiculo.Name = "lblVehiculo";
            lblVehiculo.Size = new Size(600, 47);
            lblVehiculo.TabIndex = 3;
            lblVehiculo.Text = "Furgoneta ligera - Furgoneta ligera";
            // 
            // ptbDelete
            // 
            ptbDelete.Image = Properties.Resources.iconTrash;
            ptbDelete.Location = new Point(697, 3);
            ptbDelete.Name = "ptbDelete";
            ptbDelete.Size = new Size(100, 70);
            ptbDelete.SizeMode = PictureBoxSizeMode.Zoom;
            ptbDelete.TabIndex = 2;
            ptbDelete.TabStop = false;
            ptbDelete.Click += ptbDelete_Click;
            // 
            // ucRutasAsignadas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblVehiculo);
            Controls.Add(ptbDelete);
            Name = "ucRutasAsignadas";
            Size = new Size(804, 76);
            ((System.ComponentModel.ISupportInitialize)ptbDelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVehiculo;
        private PictureBox ptbDelete;
    }
}
