namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class frmPedidosAdministrador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlZonaOriente = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // pnlZonaOriente
            // 
            pnlZonaOriente.BackColor = SystemColors.ActiveCaption;
            pnlZonaOriente.Location = new Point(28, 38);
            pnlZonaOriente.Name = "pnlZonaOriente";
            pnlZonaOriente.Size = new Size(433, 918);
            pnlZonaOriente.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(1177, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(433, 918);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Location = new Point(611, 38);
            panel2.Name = "panel2";
            panel2.Size = new Size(433, 918);
            panel2.TabIndex = 0;
            // 
            // frmPedidosAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1015);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pnlZonaOriente);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmPedidosAdministrador";
            Text = "frmPedidosAdministrador";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlZonaOriente;
        private Panel panel1;
        private Panel panel2;
    }
}