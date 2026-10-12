namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class ucVehiculo
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
            pnlMain = new Panel();
            tlpInfoCapacidad = new TableLayoutPanel();
            lblCapacidad = new Label();
            ptbInfoCapacidad = new PictureBox();
            tlpInfoPeso = new TableLayoutPanel();
            lblPeso = new Label();
            ptbInfoPeso = new PictureBox();
            tlpNombre = new TableLayoutPanel();
            lblNombre = new Label();
            ptbVehiculo = new PictureBox();
            pnlMain.SuspendLayout();
            tlpInfoCapacidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbInfoCapacidad).BeginInit();
            tlpInfoPeso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbInfoPeso).BeginInit();
            tlpNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbVehiculo).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.Linen;
            pnlMain.Controls.Add(tlpInfoCapacidad);
            pnlMain.Controls.Add(tlpInfoPeso);
            pnlMain.Controls.Add(tlpNombre);
            pnlMain.Controls.Add(ptbVehiculo);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(428, 325);
            pnlMain.TabIndex = 0;
            pnlMain.Click += pnlMain_Click;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // tlpInfoCapacidad
            // 
            tlpInfoCapacidad.ColumnCount = 2;
            tlpInfoCapacidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0904522F));
            tlpInfoCapacidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.9095459F));
            tlpInfoCapacidad.Controls.Add(lblCapacidad, 1, 0);
            tlpInfoCapacidad.Controls.Add(ptbInfoCapacidad, 0, 0);
            tlpInfoCapacidad.Location = new Point(212, 276);
            tlpInfoCapacidad.Name = "tlpInfoCapacidad";
            tlpInfoCapacidad.RowCount = 1;
            tlpInfoCapacidad.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInfoCapacidad.Size = new Size(199, 33);
            tlpInfoCapacidad.TabIndex = 2;
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCapacidad.Location = new Point(39, 0);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(25, 30);
            lblCapacidad.TabIndex = 3;
            lblCapacidad.Text = "2";
            // 
            // ptbInfoCapacidad
            // 
            ptbInfoCapacidad.Dock = DockStyle.Fill;
            ptbInfoCapacidad.Image = Properties.Resources.user;
            ptbInfoCapacidad.Location = new Point(3, 3);
            ptbInfoCapacidad.Name = "ptbInfoCapacidad";
            ptbInfoCapacidad.Size = new Size(30, 27);
            ptbInfoCapacidad.TabIndex = 3;
            ptbInfoCapacidad.TabStop = false;
            // 
            // tlpInfoPeso
            // 
            tlpInfoPeso.ColumnCount = 2;
            tlpInfoPeso.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0904522F));
            tlpInfoPeso.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.9095459F));
            tlpInfoPeso.Controls.Add(lblPeso, 1, 0);
            tlpInfoPeso.Controls.Add(ptbInfoPeso, 0, 0);
            tlpInfoPeso.Location = new Point(13, 276);
            tlpInfoPeso.Name = "tlpInfoPeso";
            tlpInfoPeso.RowCount = 1;
            tlpInfoPeso.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInfoPeso.Size = new Size(199, 33);
            tlpInfoPeso.TabIndex = 2;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPeso.Location = new Point(39, 0);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(79, 30);
            lblPeso.TabIndex = 3;
            lblPeso.Text = "800 kg";
            // 
            // ptbInfoPeso
            // 
            ptbInfoPeso.Dock = DockStyle.Fill;
            ptbInfoPeso.Image = Properties.Resources.box__1_;
            ptbInfoPeso.Location = new Point(3, 3);
            ptbInfoPeso.Name = "ptbInfoPeso";
            ptbInfoPeso.Size = new Size(30, 27);
            ptbInfoPeso.SizeMode = PictureBoxSizeMode.Zoom;
            ptbInfoPeso.TabIndex = 3;
            ptbInfoPeso.TabStop = false;
            // 
            // tlpNombre
            // 
            tlpNombre.ColumnCount = 1;
            tlpNombre.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpNombre.Controls.Add(lblNombre, 0, 0);
            tlpNombre.Location = new Point(13, 216);
            tlpNombre.Name = "tlpNombre";
            tlpNombre.RowCount = 1;
            tlpNombre.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpNombre.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpNombre.Size = new Size(398, 32);
            tlpNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.None;
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(123, 1);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(151, 30);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Van Compacta";
            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ptbVehiculo
            // 
            ptbVehiculo.Image = Properties.Resources.CARRO_removebg_preview;
            ptbVehiculo.Location = new Point(13, 13);
            ptbVehiculo.Name = "ptbVehiculo";
            ptbVehiculo.Size = new Size(398, 197);
            ptbVehiculo.SizeMode = PictureBoxSizeMode.Zoom;
            ptbVehiculo.TabIndex = 0;
            ptbVehiculo.TabStop = false;
            ptbVehiculo.Click += ptbVehiculo_Click;
            // 
            // ucVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Coral;
            Controls.Add(pnlMain);
            Name = "ucVehiculo";
            Size = new Size(428, 337);
            Load += ucVehiculo_Load;
            Click += ucVehiculo_Click;
            pnlMain.ResumeLayout(false);
            tlpInfoCapacidad.ResumeLayout(false);
            tlpInfoCapacidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbInfoCapacidad).EndInit();
            tlpInfoPeso.ResumeLayout(false);
            tlpInfoPeso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbInfoPeso).EndInit();
            tlpNombre.ResumeLayout(false);
            tlpNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbVehiculo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TableLayoutPanel tlpNombre;
        private PictureBox ptbVehiculo;
        private TableLayoutPanel tlpInfoCapacidad;
        private TableLayoutPanel tlpInfoPeso;
        private Label lblNombre;
        private PictureBox ptbInfoCapacidad;
        private PictureBox ptbInfoPeso;
        private Label lblCapacidad;
        private Label lblPeso;
    }
}
