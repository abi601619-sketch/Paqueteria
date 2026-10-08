namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class frmVehiculosAdministrador
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
            lblCarros1 = new Label();
            btnAgregar = new Button();
            pnlDecoracion = new Panel();
            flpCarrosLigeros = new FlowLayoutPanel();
            pnlDecoracion2 = new Panel();
            lblTrailers = new Label();
            flpTrailers = new FlowLayoutPanel();
            btnNextLigeros = new Button();
            btnNextTrailers = new Button();
            SuspendLayout();
            // 
            // lblCarros1
            // 
            lblCarros1.AutoSize = true;
            lblCarros1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarros1.Location = new Point(12, 19);
            lblCarros1.Name = "lblCarros1";
            lblCarros1.Size = new Size(609, 65);
            lblCarros1.TabIndex = 0;
            lblCarros1.Text = "Carros medianos y ligeros";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Tomato;
            btnAgregar.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = SystemColors.Control;
            btnAgregar.Location = new Point(1385, 22);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(243, 74);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "+ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // pnlDecoracion
            // 
            pnlDecoracion.BackColor = Color.OrangeRed;
            pnlDecoracion.ForeColor = SystemColors.ControlDarkDark;
            pnlDecoracion.Location = new Point(627, 54);
            pnlDecoracion.Name = "pnlDecoracion";
            pnlDecoracion.Size = new Size(740, 10);
            pnlDecoracion.TabIndex = 2;
            // 
            // flpCarrosLigeros
            // 
            flpCarrosLigeros.Location = new Point(12, 102);
            flpCarrosLigeros.Name = "flpCarrosLigeros";
            flpCarrosLigeros.Size = new Size(1481, 373);
            flpCarrosLigeros.TabIndex = 3;
            // 
            // pnlDecoracion2
            // 
            pnlDecoracion2.BackColor = Color.OrangeRed;
            pnlDecoracion2.ForeColor = SystemColors.ControlDarkDark;
            pnlDecoracion2.Location = new Point(209, 561);
            pnlDecoracion2.Name = "pnlDecoracion2";
            pnlDecoracion2.Size = new Size(1419, 10);
            pnlDecoracion2.TabIndex = 5;
            // 
            // lblTrailers
            // 
            lblTrailers.AutoSize = true;
            lblTrailers.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrailers.Location = new Point(12, 526);
            lblTrailers.Name = "lblTrailers";
            lblTrailers.Size = new Size(191, 65);
            lblTrailers.TabIndex = 4;
            lblTrailers.Text = "Trailers\r\n";
            // 
            // flpTrailers
            // 
            flpTrailers.Location = new Point(12, 604);
            flpTrailers.Name = "flpTrailers";
            flpTrailers.Size = new Size(1481, 373);
            flpTrailers.TabIndex = 6;
            // 
            // btnNextLigeros
            // 
            btnNextLigeros.BackColor = Color.Sienna;
            btnNextLigeros.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextLigeros.ForeColor = SystemColors.Control;
            btnNextLigeros.Location = new Point(1522, 155);
            btnNextLigeros.Name = "btnNextLigeros";
            btnNextLigeros.Size = new Size(68, 250);
            btnNextLigeros.TabIndex = 7;
            btnNextLigeros.Text = ">";
            btnNextLigeros.UseVisualStyleBackColor = false;
            // 
            // btnNextTrailers
            // 
            btnNextTrailers.BackColor = Color.Sienna;
            btnNextTrailers.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextTrailers.ForeColor = SystemColors.Control;
            btnNextTrailers.Location = new Point(1522, 675);
            btnNextTrailers.Name = "btnNextTrailers";
            btnNextTrailers.Size = new Size(68, 250);
            btnNextTrailers.TabIndex = 8;
            btnNextTrailers.Text = ">";
            btnNextTrailers.UseVisualStyleBackColor = false;
            // 
            // frmVehiculosAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1015);
            Controls.Add(btnNextTrailers);
            Controls.Add(btnNextLigeros);
            Controls.Add(flpTrailers);
            Controls.Add(pnlDecoracion2);
            Controls.Add(lblTrailers);
            Controls.Add(flpCarrosLigeros);
            Controls.Add(pnlDecoracion);
            Controls.Add(btnAgregar);
            Controls.Add(lblCarros1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmVehiculosAdministrador";
            Text = "frmConductoresAdministrador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCarros1;
        private Button btnAgregar;
        private Panel pnlDecoracion;
        private FlowLayoutPanel flpCarrosLigeros;
        private Panel pnlDecoracion2;
        private Label lblTrailers;
        private FlowLayoutPanel flpTrailers;
        private Button btnNextLigeros;
        private Button btnNextTrailers;
    }
}