namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class frmDashboardAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboardAdministrador));
            ptbDashboard = new PictureBox();
            lblBienvenido = new Label();
            lblNombre = new Label();
            lblTexto = new Label();
            tlpTexto = new TableLayoutPanel();
            pnlDecoracion = new Panel();
            pnlConductores = new Panel();
            pnlConductoresInfo = new Panel();
            btnConductores = new Button();
            lblConductoresText = new Label();
            lblConductores = new Label();
            ptbConductores = new PictureBox();
            pnlVehiculos = new Panel();
            pnlVehiculosInfo = new Panel();
            btnVehiculos = new Button();
            lblVehiculosText = new Label();
            lblVehiculos = new Label();
            ptbVehiculos = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ptbDashboard).BeginInit();
            tlpTexto.SuspendLayout();
            pnlConductoresInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbConductores).BeginInit();
            pnlVehiculosInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbVehiculos).BeginInit();
            SuspendLayout();
            // 
            // ptbDashboard
            // 
            ptbDashboard.Image = (Image)resources.GetObject("ptbDashboard.Image");
            ptbDashboard.Location = new Point(27, 24);
            ptbDashboard.Name = "ptbDashboard";
            ptbDashboard.Size = new Size(1588, 312);
            ptbDashboard.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbDashboard.TabIndex = 0;
            ptbDashboard.TabStop = false;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.BackColor = Color.FromArgb(235, 227, 217);
            lblBienvenido.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenido.Location = new Point(52, 44);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(172, 40);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.FromArgb(235, 227, 217);
            lblNombre.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.OrangeRed;
            lblNombre.Location = new Point(52, 100);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(349, 65);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Juan Vásquez";
            // 
            // lblTexto
            // 
            lblTexto.AutoSize = true;
            lblTexto.BackColor = Color.FromArgb(235, 227, 217);
            lblTexto.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTexto.Location = new Point(3, 0);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(576, 80);
            lblTexto.TabIndex = 2;
            lblTexto.Text = "Gestiona pedidos, conductores y vehículos de manera eficiente.";
            // 
            // tlpTexto
            // 
            tlpTexto.BackColor = Color.FromArgb(235, 227, 217);
            tlpTexto.ColumnCount = 1;
            tlpTexto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTexto.Controls.Add(lblTexto, 0, 0);
            tlpTexto.Location = new Point(52, 193);
            tlpTexto.Name = "tlpTexto";
            tlpTexto.RowCount = 1;
            tlpTexto.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTexto.Size = new Size(584, 87);
            tlpTexto.TabIndex = 3;
            // 
            // pnlDecoracion
            // 
            pnlDecoracion.BackColor = Color.OrangeRed;
            pnlDecoracion.Location = new Point(52, 295);
            pnlDecoracion.Name = "pnlDecoracion";
            pnlDecoracion.Size = new Size(124, 10);
            pnlDecoracion.TabIndex = 4;
            // 
            // pnlConductores
            // 
            pnlConductores.BackColor = Color.OrangeRed;
            pnlConductores.Location = new Point(24, 387);
            pnlConductores.Name = "pnlConductores";
            pnlConductores.Size = new Size(734, 233);
            pnlConductores.TabIndex = 5;
            // 
            // pnlConductoresInfo
            // 
            pnlConductoresInfo.BackColor = SystemColors.Control;
            pnlConductoresInfo.Controls.Add(btnConductores);
            pnlConductoresInfo.Controls.Add(lblConductoresText);
            pnlConductoresInfo.Controls.Add(lblConductores);
            pnlConductoresInfo.Controls.Add(ptbConductores);
            pnlConductoresInfo.Location = new Point(27, 390);
            pnlConductoresInfo.Name = "pnlConductoresInfo";
            pnlConductoresInfo.Size = new Size(728, 213);
            pnlConductoresInfo.TabIndex = 5;
            // 
            // btnConductores
            // 
            btnConductores.BackColor = Color.OrangeRed;
            btnConductores.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConductores.ForeColor = SystemColors.Control;
            btnConductores.Location = new Point(420, 58);
            btnConductores.Name = "btnConductores";
            btnConductores.Size = new Size(270, 91);
            btnConductores.TabIndex = 8;
            btnConductores.Text = "Ver Más →";
            btnConductores.UseVisualStyleBackColor = false;
            btnConductores.Click += btnConductores_Click;
            // 
            // lblConductoresText
            // 
            lblConductoresText.AutoSize = true;
            lblConductoresText.BackColor = SystemColors.Control;
            lblConductoresText.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConductoresText.Location = new Point(202, 119);
            lblConductoresText.Name = "lblConductoresText";
            lblConductoresText.Size = new Size(163, 30);
            lblConductoresText.TabIndex = 6;
            lblConductoresText.Text = "CONDUCTORES";
            // 
            // lblConductores
            // 
            lblConductores.AutoSize = true;
            lblConductores.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConductores.Location = new Point(192, 23);
            lblConductores.Name = "lblConductores";
            lblConductores.Size = new Size(111, 86);
            lblConductores.TabIndex = 7;
            lblConductores.Text = "67";
            // 
            // ptbConductores
            // 
            ptbConductores.Image = Properties.Resources.driving;
            ptbConductores.Location = new Point(25, 43);
            ptbConductores.Name = "ptbConductores";
            ptbConductores.Size = new Size(137, 120);
            ptbConductores.SizeMode = PictureBoxSizeMode.Zoom;
            ptbConductores.TabIndex = 6;
            ptbConductores.TabStop = false;
            // 
            // pnlVehiculos
            // 
            pnlVehiculos.BackColor = Color.OrangeRed;
            pnlVehiculos.Location = new Point(884, 387);
            pnlVehiculos.Name = "pnlVehiculos";
            pnlVehiculos.Size = new Size(734, 233);
            pnlVehiculos.TabIndex = 5;
            // 
            // pnlVehiculosInfo
            // 
            pnlVehiculosInfo.BackColor = SystemColors.Control;
            pnlVehiculosInfo.Controls.Add(btnVehiculos);
            pnlVehiculosInfo.Controls.Add(lblVehiculosText);
            pnlVehiculosInfo.Controls.Add(lblVehiculos);
            pnlVehiculosInfo.Controls.Add(ptbVehiculos);
            pnlVehiculosInfo.Location = new Point(887, 390);
            pnlVehiculosInfo.Name = "pnlVehiculosInfo";
            pnlVehiculosInfo.Size = new Size(728, 213);
            pnlVehiculosInfo.TabIndex = 5;
            // 
            // btnVehiculos
            // 
            btnVehiculos.BackColor = Color.OrangeRed;
            btnVehiculos.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVehiculos.ForeColor = SystemColors.Control;
            btnVehiculos.Location = new Point(416, 58);
            btnVehiculos.Name = "btnVehiculos";
            btnVehiculos.Size = new Size(270, 91);
            btnVehiculos.TabIndex = 8;
            btnVehiculos.Text = "Ver Más →";
            btnVehiculos.UseVisualStyleBackColor = false;
            btnVehiculos.Click += btnVehiculos_Click;
            // 
            // lblVehiculosText
            // 
            lblVehiculosText.AutoSize = true;
            lblVehiculosText.BackColor = SystemColors.Control;
            lblVehiculosText.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehiculosText.Location = new Point(211, 119);
            lblVehiculosText.Name = "lblVehiculosText";
            lblVehiculosText.Size = new Size(122, 30);
            lblVehiculosText.TabIndex = 6;
            lblVehiculosText.Text = "VEHICULOS";
            // 
            // lblVehiculos
            // 
            lblVehiculos.AutoSize = true;
            lblVehiculos.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehiculos.Location = new Point(194, 23);
            lblVehiculos.Name = "lblVehiculos";
            lblVehiculos.Size = new Size(111, 86);
            lblVehiculos.TabIndex = 7;
            lblVehiculos.Text = "76";
            // 
            // ptbVehiculos
            // 
            ptbVehiculos.Image = Properties.Resources.van;
            ptbVehiculos.Location = new Point(30, 43);
            ptbVehiculos.Name = "ptbVehiculos";
            ptbVehiculos.Size = new Size(137, 120);
            ptbVehiculos.SizeMode = PictureBoxSizeMode.Zoom;
            ptbVehiculos.TabIndex = 6;
            ptbVehiculos.TabStop = false;
            // 
            // frmDashboardAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1015);
            Controls.Add(pnlVehiculosInfo);
            Controls.Add(pnlVehiculos);
            Controls.Add(pnlConductoresInfo);
            Controls.Add(pnlConductores);
            Controls.Add(pnlDecoracion);
            Controls.Add(tlpTexto);
            Controls.Add(lblNombre);
            Controls.Add(lblBienvenido);
            Controls.Add(ptbDashboard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDashboardAdministrador";
            Text = "frmDashboardAdministrador";
            ((System.ComponentModel.ISupportInitialize)ptbDashboard).EndInit();
            tlpTexto.ResumeLayout(false);
            tlpTexto.PerformLayout();
            pnlConductoresInfo.ResumeLayout(false);
            pnlConductoresInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbConductores).EndInit();
            pnlVehiculosInfo.ResumeLayout(false);
            pnlVehiculosInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptbDashboard;
        private Label lblBienvenido;
        private Label lblNombre;
        private Label lblTexto;
        private TableLayoutPanel tlpTexto;
        private Panel pnlDecoracion;
        private Panel pnlConductores;
        private Panel pnlConductoresInfo;
        private PictureBox ptbConductores;
        private Panel pnlVehiculos;
        private Panel pnlVehiculosInfo;
        private PictureBox ptbVehiculos;
        private Label lblConductoresText;
        private Label lblConductores;
        private Label lblVehiculos;
        private Button btnConductores;
        private Label lblVehiculosText;
        private Button btnVehiculos;
    }
}