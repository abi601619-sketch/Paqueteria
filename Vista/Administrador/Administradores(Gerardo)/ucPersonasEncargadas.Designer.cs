namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class ucPersonasEncargadas
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
            ptbFoto = new PictureBox();
            lblPersona = new Label();
            ptbDelete = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ptbFoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbDelete).BeginInit();
            SuspendLayout();
            // 
            // ptbFoto
            // 
            ptbFoto.Image = Properties.Resources.profile_con;
            ptbFoto.Location = new Point(3, 3);
            ptbFoto.Name = "ptbFoto";
            ptbFoto.Size = new Size(98, 85);
            ptbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            ptbFoto.TabIndex = 0;
            ptbFoto.TabStop = false;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersona.Location = new Point(119, 22);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(564, 50);
            lblPersona.TabIndex = 1;
            lblPersona.Text = "Luis Gerardo Martínez Zavaleta";
            // 
            // ptbDelete
            // 
            ptbDelete.Image = Properties.Resources.iconTrash;
            ptbDelete.Location = new Point(777, 3);
            ptbDelete.Name = "ptbDelete";
            ptbDelete.Size = new Size(98, 85);
            ptbDelete.SizeMode = PictureBoxSizeMode.Zoom;
            ptbDelete.TabIndex = 0;
            ptbDelete.TabStop = false;
            ptbDelete.Click += ptbDelete_Click;
            // 
            // ucPersonasEncargadas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPersona);
            Controls.Add(ptbDelete);
            Controls.Add(ptbFoto);
            Name = "ucPersonasEncargadas";
            Size = new Size(878, 91);
            ((System.ComponentModel.ISupportInitialize)ptbFoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbDelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptbFoto;
        private Label lblPersona;
        private PictureBox ptbDelete;
    }
}
