namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class ucConductoresEncargados
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
            ptbFotoPerfil = new PictureBox();
            lblNombre = new Label();
            ptbBorrar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ptbFotoPerfil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbBorrar).BeginInit();
            SuspendLayout();
            // 
            // ptbFotoPerfil
            // 
            ptbFotoPerfil.Image = Properties.Resources.profile_con;
            ptbFotoPerfil.Location = new Point(10, 10);
            ptbFotoPerfil.Name = "ptbFotoPerfil";
            ptbFotoPerfil.Size = new Size(75, 64);
            ptbFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            ptbFotoPerfil.TabIndex = 0;
            ptbFotoPerfil.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(103, 19);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(536, 47);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Luis Gerardo Martínez Zavaleta";
            // 
            // ptbBorrar
            // 
            ptbBorrar.Image = Properties.Resources.iconTrash;
            ptbBorrar.Location = new Point(791, 10);
            ptbBorrar.Name = "ptbBorrar";
            ptbBorrar.Size = new Size(75, 64);
            ptbBorrar.SizeMode = PictureBoxSizeMode.Zoom;
            ptbBorrar.TabIndex = 2;
            ptbBorrar.TabStop = false;
            // 
            // ucConductoresEncargados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ptbBorrar);
            Controls.Add(lblNombre);
            Controls.Add(ptbFotoPerfil);
            Name = "ucConductoresEncargados";
            Size = new Size(878, 82);
            ((System.ComponentModel.ISupportInitialize)ptbFotoPerfil).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbBorrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptbFotoPerfil;
        private Label lblNombre;
        private PictureBox ptbBorrar;
    }
}
