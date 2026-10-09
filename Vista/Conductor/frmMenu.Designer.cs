namespace Vista.Conductor
{
    partial class frmMenu
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMenu = new Panel();
            btnProductos = new Button();
            btnVehiculos = new Button();
            btnRutasC = new Button();
            btnDashboardC = new Button();
            ptbLogo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            btnCerrarS = new Button();
            pnlParteA = new Panel();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            pnlInformacion = new Panel();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(78, 35, 14);
            pnlMenu.Controls.Add(btnProductos);
            pnlMenu.Controls.Add(btnVehiculos);
            pnlMenu.Controls.Add(btnRutasC);
            pnlMenu.Controls.Add(btnDashboardC);
            pnlMenu.Controls.Add(ptbLogo);
            pnlMenu.Controls.Add(btnCerrarS);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(262, 1041);
            pnlMenu.TabIndex = 0;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(78, 35, 14);
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(0, 525);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(262, 108);
            btnProductos.TabIndex = 6;
            btnProductos.Text = "PRODUCTOS";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnVehiculos
            // 
            btnVehiculos.BackColor = Color.FromArgb(78, 35, 14);
            btnVehiculos.Dock = DockStyle.Top;
            btnVehiculos.FlatAppearance.BorderSize = 0;
            btnVehiculos.FlatStyle = FlatStyle.Flat;
            btnVehiculos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVehiculos.ForeColor = Color.White;
            btnVehiculos.Location = new Point(0, 417);
            btnVehiculos.Name = "btnVehiculos";
            btnVehiculos.Size = new Size(262, 108);
            btnVehiculos.TabIndex = 7;
            btnVehiculos.Text = "VEHICULOS";
            btnVehiculos.UseVisualStyleBackColor = false;
            btnVehiculos.Click += btnVehiculos_Click;
            // 
            // btnRutasC
            // 
            btnRutasC.BackColor = Color.FromArgb(78, 35, 14);
            btnRutasC.Dock = DockStyle.Top;
            btnRutasC.FlatAppearance.BorderSize = 0;
            btnRutasC.FlatStyle = FlatStyle.Flat;
            btnRutasC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRutasC.ForeColor = Color.White;
            btnRutasC.Location = new Point(0, 309);
            btnRutasC.Name = "btnRutasC";
            btnRutasC.Size = new Size(262, 108);
            btnRutasC.TabIndex = 8;
            btnRutasC.Text = "RUTAS";
            btnRutasC.UseVisualStyleBackColor = false;
            btnRutasC.Click += btnRutasC_Click;
            // 
            // btnDashboardC
            // 
            btnDashboardC.BackColor = Color.FromArgb(78, 35, 14);
            btnDashboardC.Dock = DockStyle.Top;
            btnDashboardC.FlatAppearance.BorderSize = 0;
            btnDashboardC.FlatStyle = FlatStyle.Flat;
            btnDashboardC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboardC.ForeColor = Color.White;
            btnDashboardC.Location = new Point(0, 201);
            btnDashboardC.Name = "btnDashboardC";
            btnDashboardC.Size = new Size(262, 108);
            btnDashboardC.TabIndex = 5;
            btnDashboardC.Text = "DASHBOARD";
            btnDashboardC.UseVisualStyleBackColor = false;
            btnDashboardC.Click += btnDashboard_Click;
            // 
            // ptbLogo
            // 
            ptbLogo.Dock = DockStyle.Top;
            ptbLogo.Image = Properties.Resources._2d01e215a07cdd5f57d39b2c23eb12e479073242;
            ptbLogo.ImageRotate = 0F;
            ptbLogo.InitialImage = null;
            ptbLogo.Location = new Point(0, 0);
            ptbLogo.Name = "ptbLogo";
            ptbLogo.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ptbLogo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            ptbLogo.Size = new Size(262, 201);
            ptbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            ptbLogo.TabIndex = 5;
            ptbLogo.TabStop = false;
            // 
            // btnCerrarS
            // 
            btnCerrarS.BackColor = Color.FromArgb(78, 35, 14);
            btnCerrarS.Dock = DockStyle.Bottom;
            btnCerrarS.FlatAppearance.BorderSize = 0;
            btnCerrarS.FlatStyle = FlatStyle.Flat;
            btnCerrarS.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarS.ForeColor = Color.White;
            btnCerrarS.Location = new Point(0, 933);
            btnCerrarS.Name = "btnCerrarS";
            btnCerrarS.Size = new Size(262, 108);
            btnCerrarS.TabIndex = 4;
            btnCerrarS.Text = "CERRAR SESIÓN";
            btnCerrarS.UseVisualStyleBackColor = false;
            btnCerrarS.Click += btnCerrarS_Click;
            // 
            // pnlParteA
            // 
            pnlParteA.BackColor = Color.FromArgb(78, 35, 14);
            pnlParteA.Dock = DockStyle.Top;
            pnlParteA.Location = new Point(262, 0);
            pnlParteA.Name = "pnlParteA";
            pnlParteA.Size = new Size(1642, 83);
            pnlParteA.TabIndex = 1;
            pnlParteA.Paint += pnlParteA_Paint;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // pnlInformacion
            // 
            pnlInformacion.Dock = DockStyle.Fill;
            pnlInformacion.Location = new Point(262, 83);
            pnlInformacion.Name = "pnlInformacion";
            pnlInformacion.Size = new Size(1642, 958);
            pnlInformacion.TabIndex = 2;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(pnlInformacion);
            Controls.Add(pnlParteA);
            Controls.Add(pnlMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMenu";
            Text = "frmMenu";
            Load += frmMenu_Load;
            pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlParteA;
        private Button btnCerrarS;
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptbLogo;
        private Button btnProductos;
        private Button btnVehiculos;
        private Button btnRutasC;
        private Button btnDashboardC;
        private Panel pnlInformacion;
        private PictureBox pictureBox1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnRutas;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}