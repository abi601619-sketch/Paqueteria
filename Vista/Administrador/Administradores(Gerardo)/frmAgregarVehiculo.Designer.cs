namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class frmAgregarVehiculo
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
            ptbExit = new PictureBox();
            lblTitulo = new Label();
            lblFotoVehiculo = new Label();
            lblMarca = new Label();
            ptbFotoVehiculo = new PictureBox();
            cmbMarca = new ComboBox();
            lblModelo = new Label();
            cmbModelo = new ComboBox();
            lblCapacidad = new Label();
            txtCapacidad = new TextBox();
            txtKilometraje = new TextBox();
            lblKilometraje = new Label();
            btnAgregar = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            pnlMain = new Panel();
            ((System.ComponentModel.ISupportInitialize)ptbExit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbFotoVehiculo).BeginInit();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // ptbExit
            // 
            ptbExit.BackColor = SystemColors.Control;
            ptbExit.Image = Properties.Resources.close;
            ptbExit.Location = new Point(1262, 3);
            ptbExit.Name = "ptbExit";
            ptbExit.Size = new Size(56, 55);
            ptbExit.SizeMode = PictureBoxSizeMode.Zoom;
            ptbExit.TabIndex = 0;
            ptbExit.TabStop = false;
            ptbExit.Click += ptbExit_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = SystemColors.Control;
            lblTitulo.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(418, 65);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Vehículo";
            // 
            // lblFotoVehiculo
            // 
            lblFotoVehiculo.AutoSize = true;
            lblFotoVehiculo.BackColor = SystemColors.Control;
            lblFotoVehiculo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFotoVehiculo.Location = new Point(24, 126);
            lblFotoVehiculo.Name = "lblFotoVehiculo";
            lblFotoVehiculo.Size = new Size(183, 30);
            lblFotoVehiculo.TabIndex = 2;
            lblFotoVehiculo.Text = "Foto del vehículo";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.BackColor = SystemColors.Control;
            lblMarca.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMarca.Location = new Point(728, 126);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(73, 30);
            lblMarca.TabIndex = 2;
            lblMarca.Text = "Marca";
            // 
            // ptbFotoVehiculo
            // 
            ptbFotoVehiculo.BackColor = SystemColors.Control;
            ptbFotoVehiculo.BorderStyle = BorderStyle.FixedSingle;
            ptbFotoVehiculo.Image = Properties.Resources.iconCamara;
            ptbFotoVehiculo.Location = new Point(24, 177);
            ptbFotoVehiculo.Name = "ptbFotoVehiculo";
            ptbFotoVehiculo.Size = new Size(537, 388);
            ptbFotoVehiculo.SizeMode = PictureBoxSizeMode.Zoom;
            ptbFotoVehiculo.TabIndex = 3;
            ptbFotoVehiculo.TabStop = false;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(728, 177);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(578, 33);
            cmbMarca.TabIndex = 4;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.BackColor = SystemColors.Control;
            lblModelo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModelo.Location = new Point(728, 227);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(89, 30);
            lblModelo.TabIndex = 2;
            lblModelo.Text = "Modelo";
            // 
            // cmbModelo
            // 
            cmbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbModelo.FormattingEnabled = true;
            cmbModelo.Location = new Point(728, 273);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(578, 33);
            cmbModelo.TabIndex = 4;
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.BackColor = SystemColors.Control;
            lblCapacidad.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCapacidad.Location = new Point(728, 327);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(237, 30);
            lblCapacidad.TabIndex = 2;
            lblCapacidad.Text = "Capacidad de personas";
            // 
            // txtCapacidad
            // 
            txtCapacidad.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCapacidad.Location = new Point(728, 371);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(578, 35);
            txtCapacidad.TabIndex = 5;
            // 
            // txtKilometraje
            // 
            txtKilometraje.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtKilometraje.Location = new Point(728, 476);
            txtKilometraje.Name = "txtKilometraje";
            txtKilometraje.Size = new Size(578, 35);
            txtKilometraje.TabIndex = 7;
            // 
            // lblKilometraje
            // 
            lblKilometraje.AutoSize = true;
            lblKilometraje.BackColor = SystemColors.Control;
            lblKilometraje.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKilometraje.Location = new Point(728, 432);
            lblKilometraje.Name = "lblKilometraje";
            lblKilometraje.Size = new Size(179, 30);
            lblKilometraje.TabIndex = 6;
            lblKilometraje.Text = "Kilometraje (km)";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.OrangeRed;
            btnAgregar.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = SystemColors.Control;
            btnAgregar.Location = new Point(945, 611);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(354, 89);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar Vehículo";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = SystemColors.Control;
            pnlMain.Controls.Add(btnAgregar);
            pnlMain.Controls.Add(ptbExit);
            pnlMain.Location = new Point(7, 12);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1321, 712);
            pnlMain.TabIndex = 9;
            // 
            // frmAgregarVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1339, 736);
            Controls.Add(txtKilometraje);
            Controls.Add(lblKilometraje);
            Controls.Add(txtCapacidad);
            Controls.Add(cmbModelo);
            Controls.Add(cmbMarca);
            Controls.Add(ptbFotoVehiculo);
            Controls.Add(lblCapacidad);
            Controls.Add(lblModelo);
            Controls.Add(lblMarca);
            Controls.Add(lblFotoVehiculo);
            Controls.Add(lblTitulo);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAgregarVehiculo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAgregarVehiculo";
            ((System.ComponentModel.ISupportInitialize)ptbExit).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbFotoVehiculo).EndInit();
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptbExit;
        private Label lblTitulo;
        private Label lblFotoVehiculo;
        private Label lblMarca;
        private PictureBox ptbFotoVehiculo;
        private ComboBox cmbMarca;
        private Label lblModelo;
        private ComboBox cmbModelo;
        private Label lblCapacidad;
        private TextBox txtCapacidad;
        private TextBox txtKilometraje;
        private Label lblKilometraje;
        private Button btnAgregar;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Panel pnlMain;
    }
}