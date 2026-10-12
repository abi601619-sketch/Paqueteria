namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class frmAsignarVehiculo
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
            ptbIcono = new PictureBox();
            lblDescripcion = new Label();
            lblConductor = new Label();
            lblTitulo = new Label();
            ptbExit = new PictureBox();
            cmbConductor = new ComboBox();
            btnAgregar = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)ptbIcono).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbExit).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ptbIcono
            // 
            ptbIcono.Image = Properties.Resources.front_car;
            ptbIcono.Location = new Point(9, 12);
            ptbIcono.Name = "ptbIcono";
            ptbIcono.Size = new Size(113, 87);
            ptbIcono.SizeMode = PictureBoxSizeMode.Zoom;
            ptbIcono.TabIndex = 0;
            ptbIcono.TabStop = false;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblDescripcion.Location = new Point(128, 69);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(583, 30);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Seleccione el vehículo al que se entregará este conductor";
            // 
            // lblConductor
            // 
            lblConductor.AutoSize = true;
            lblConductor.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConductor.Location = new Point(9, 144);
            lblConductor.Name = "lblConductor";
            lblConductor.Size = new Size(172, 50);
            lblConductor.TabIndex = 4;
            lblConductor.Text = "Vehículo";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(128, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(315, 50);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Asignar Vehiculo";
            // 
            // ptbExit
            // 
            ptbExit.Image = Properties.Resources.close;
            ptbExit.Location = new Point(889, 12);
            ptbExit.Name = "ptbExit";
            ptbExit.Size = new Size(55, 50);
            ptbExit.SizeMode = PictureBoxSizeMode.Zoom;
            ptbExit.TabIndex = 2;
            ptbExit.TabStop = false;
            ptbExit.Click += ptbExit_Click;
            // 
            // cmbConductor
            // 
            cmbConductor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConductor.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbConductor.FormattingEnabled = true;
            cmbConductor.Location = new Point(21, 209);
            cmbConductor.Name = "cmbConductor";
            cmbConductor.Size = new Size(910, 40);
            cmbConductor.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.OrangeRed;
            btnAgregar.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = SystemColors.Control;
            btnAgregar.Location = new Point(703, 373);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(241, 84);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(ptbIcono);
            panel1.Controls.Add(lblDescripcion);
            panel1.Controls.Add(lblConductor);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(ptbExit);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(961, 471);
            panel1.TabIndex = 9;
            // 
            // frmAsignarVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(985, 495);
            Controls.Add(cmbConductor);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAsignarVehiculo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAsignarVehiculo";
            ((System.ComponentModel.ISupportInitialize)ptbIcono).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbExit).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ptbIcono;
        private Label lblDescripcion;
        private Label lblConductor;
        private Label lblTitulo;
        private PictureBox ptbExit;
        private ComboBox cmbConductor;
        private Button btnAgregar;
        private Panel panel1;
    }
}