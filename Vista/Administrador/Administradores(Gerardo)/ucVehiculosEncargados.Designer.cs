namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class ucVehiculosEncargados
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
            ptbDelete = new PictureBox();
            lblVehiculo = new Label();
            ((System.ComponentModel.ISupportInitialize)ptbDelete).BeginInit();
            SuspendLayout();
            // 
            // ptbDelete
            // 
            ptbDelete.Image = Properties.Resources.iconTrash;
            ptbDelete.Location = new Point(701, 3);
            ptbDelete.Name = "ptbDelete";
            ptbDelete.Size = new Size(100, 70);
            ptbDelete.SizeMode = PictureBoxSizeMode.Zoom;
            ptbDelete.TabIndex = 0;
            ptbDelete.TabStop = false;
            ptbDelete.Click += ptbDelete_Click;
            // 
            // lblVehiculo
            // 
            lblVehiculo.AutoSize = true;
            lblVehiculo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVehiculo.Location = new Point(12, 14);
            lblVehiculo.Name = "lblVehiculo";
            lblVehiculo.Size = new Size(547, 45);
            lblVehiculo.TabIndex = 1;
            lblVehiculo.Text = "Furgoneta ligera - Furgoneta ligera";
            // 
            // ucVehiculosEncargados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblVehiculo);
            Controls.Add(ptbDelete);
            Name = "ucVehiculosEncargados";
            Size = new Size(804, 76);
            ((System.ComponentModel.ISupportInitialize)ptbDelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptbDelete;
        private Label lblVehiculo;
    }
}
