namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class frmInformacionVehiculo
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
            ptbBack = new PictureBox();
            tlpTitulo = new TableLayoutPanel();
            lblTitulo = new Label();
            pnlDecoracion = new Panel();
            ptbFoto = new PictureBox();
            pnlInformacion = new Panel();
            lblCapacidad = new Label();
            lblTituloModelo = new Label();
            lblTituloKilometraje = new Label();
            lblTituloMarca = new Label();
            lblTituloCapacidad = new Label();
            pnlDecoracion3 = new Panel();
            pnlDecoracion2 = new Panel();
            lblDetalles = new Label();
            flpPersonasEncargadas = new FlowLayoutPanel();
            btnAgregar = new Button();
            lblPersonas = new Label();
            lblModelo = new Label();
            lblMarca = new Label();
            lblKilometraje = new Label();
            panel1 = new Panel();
            lblEstado = new Label();
            lblTituloEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)ptbBack).BeginInit();
            tlpTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbFoto).BeginInit();
            pnlInformacion.SuspendLayout();
            SuspendLayout();
            // 
            // ptbBack
            // 
            ptbBack.Image = Properties.Resources.iconback;
            ptbBack.Location = new Point(12, 12);
            ptbBack.Name = "ptbBack";
            ptbBack.Size = new Size(82, 70);
            ptbBack.SizeMode = PictureBoxSizeMode.Zoom;
            ptbBack.TabIndex = 1;
            ptbBack.TabStop = false;
            // 
            // tlpTitulo
            // 
            tlpTitulo.ColumnCount = 1;
            tlpTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTitulo.Controls.Add(lblTitulo, 0, 0);
            tlpTitulo.Location = new Point(121, 12);
            tlpTitulo.Name = "tlpTitulo";
            tlpTitulo.RowCount = 1;
            tlpTitulo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTitulo.Size = new Size(1507, 70);
            tlpTitulo.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.SaddleBrown;
            lblTitulo.Location = new Point(536, 2);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(434, 65);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Vehículo Mediano";
            // 
            // pnlDecoracion
            // 
            pnlDecoracion.BackColor = Color.OrangeRed;
            pnlDecoracion.ForeColor = Color.OrangeRed;
            pnlDecoracion.Location = new Point(121, 82);
            pnlDecoracion.Name = "pnlDecoracion";
            pnlDecoracion.Size = new Size(1507, 8);
            pnlDecoracion.TabIndex = 3;
            // 
            // ptbFoto
            // 
            ptbFoto.BorderStyle = BorderStyle.FixedSingle;
            ptbFoto.Location = new Point(12, 145);
            ptbFoto.Name = "ptbFoto";
            ptbFoto.Size = new Size(645, 616);
            ptbFoto.TabIndex = 4;
            ptbFoto.TabStop = false;
            // 
            // pnlInformacion
            // 
            pnlInformacion.Controls.Add(lblEstado);
            pnlInformacion.Controls.Add(lblTituloEstado);
            pnlInformacion.Controls.Add(lblKilometraje);
            pnlInformacion.Controls.Add(lblMarca);
            pnlInformacion.Controls.Add(lblModelo);
            pnlInformacion.Controls.Add(lblCapacidad);
            pnlInformacion.Controls.Add(lblTituloModelo);
            pnlInformacion.Controls.Add(lblTituloKilometraje);
            pnlInformacion.Controls.Add(lblTituloMarca);
            pnlInformacion.Controls.Add(lblTituloCapacidad);
            pnlInformacion.Controls.Add(panel1);
            pnlInformacion.Controls.Add(pnlDecoracion3);
            pnlInformacion.Controls.Add(pnlDecoracion2);
            pnlInformacion.Controls.Add(lblDetalles);
            pnlInformacion.Controls.Add(flpPersonasEncargadas);
            pnlInformacion.Controls.Add(btnAgregar);
            pnlInformacion.Controls.Add(lblPersonas);
            pnlInformacion.Location = new Point(726, 145);
            pnlInformacion.Name = "pnlInformacion";
            pnlInformacion.Size = new Size(902, 841);
            pnlInformacion.TabIndex = 5;
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCapacidad.Location = new Point(136, 555);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(74, 30);
            lblCapacidad.TabIndex = 7;
            lblCapacidad.Text = "800kg";
            // 
            // lblTituloModelo
            // 
            lblTituloModelo.AutoSize = true;
            lblTituloModelo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloModelo.Location = new Point(13, 655);
            lblTituloModelo.Name = "lblTituloModelo";
            lblTituloModelo.Size = new Size(83, 25);
            lblTituloModelo.TabIndex = 6;
            lblTituloModelo.Text = "Modelo:";
            // 
            // lblTituloKilometraje
            // 
            lblTituloKilometraje.AutoSize = true;
            lblTituloKilometraje.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloKilometraje.Location = new Point(446, 655);
            lblTituloKilometraje.Name = "lblTituloKilometraje";
            lblTituloKilometraje.Size = new Size(116, 25);
            lblTituloKilometraje.TabIndex = 6;
            lblTituloKilometraje.Text = "Kilometraje:";
            // 
            // lblTituloMarca
            // 
            lblTituloMarca.AutoSize = true;
            lblTituloMarca.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloMarca.Location = new Point(446, 555);
            lblTituloMarca.Name = "lblTituloMarca";
            lblTituloMarca.Size = new Size(71, 25);
            lblTituloMarca.TabIndex = 6;
            lblTituloMarca.Text = "Marca:";
            // 
            // lblTituloCapacidad
            // 
            lblTituloCapacidad.AutoSize = true;
            lblTituloCapacidad.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloCapacidad.Location = new Point(13, 555);
            lblTituloCapacidad.Name = "lblTituloCapacidad";
            lblTituloCapacidad.Size = new Size(106, 25);
            lblTituloCapacidad.TabIndex = 6;
            lblTituloCapacidad.Text = "Capacidad:";
            // 
            // pnlDecoracion3
            // 
            pnlDecoracion3.BackColor = Color.SaddleBrown;
            pnlDecoracion3.Location = new Point(13, 525);
            pnlDecoracion3.Name = "pnlDecoracion3";
            pnlDecoracion3.Size = new Size(877, 10);
            pnlDecoracion3.TabIndex = 5;
            // 
            // pnlDecoracion2
            // 
            pnlDecoracion2.BackColor = Color.SaddleBrown;
            pnlDecoracion2.Location = new Point(13, 76);
            pnlDecoracion2.Name = "pnlDecoracion2";
            pnlDecoracion2.Size = new Size(877, 10);
            pnlDecoracion2.TabIndex = 4;
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.BackColor = SystemColors.Control;
            lblDetalles.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetalles.ForeColor = Color.SaddleBrown;
            lblDetalles.Location = new Point(13, 472);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(382, 50);
            lblDetalles.TabIndex = 3;
            lblDetalles.Text = "Detalles del vehículo";
            // 
            // flpPersonasEncargadas
            // 
            flpPersonasEncargadas.Location = new Point(12, 92);
            flpPersonasEncargadas.Name = "flpPersonasEncargadas";
            flpPersonasEncargadas.Size = new Size(878, 367);
            flpPersonasEncargadas.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Sienna;
            btnAgregar.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = SystemColors.Control;
            btnAgregar.Location = new Point(699, 8);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(191, 65);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblPersonas
            // 
            lblPersonas.AutoSize = true;
            lblPersonas.BackColor = SystemColors.Control;
            lblPersonas.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersonas.ForeColor = Color.SaddleBrown;
            lblPersonas.Location = new Point(12, 17);
            lblPersonas.Name = "lblPersonas";
            lblPersonas.Size = new Size(383, 50);
            lblPersonas.TabIndex = 0;
            lblPersonas.Text = "Personas encargadas";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModelo.Location = new Point(102, 653);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(171, 30);
            lblModelo.TabIndex = 7;
            lblModelo.Text = "Renault Kangoo";
            lblModelo.Click += lblModelo_Click;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMarca.Location = new Point(523, 553);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(88, 30);
            lblMarca.TabIndex = 7;
            lblMarca.Text = "Renault";
            // 
            // lblKilometraje
            // 
            lblKilometraje.AutoSize = true;
            lblKilometraje.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKilometraje.Location = new Point(568, 653);
            lblKilometraje.Name = "lblKilometraje";
            lblKilometraje.Size = new Size(116, 30);
            lblKilometraje.TabIndex = 7;
            lblKilometraje.Text = "45,000 km";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SaddleBrown;
            panel1.Location = new Point(13, 702);
            panel1.Name = "panel1";
            panel1.Size = new Size(877, 10);
            panel1.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(102, 767);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(236, 30);
            lblEstado.TabIndex = 9;
            lblEstado.Text = "En buenas condiciones";
            // 
            // lblTituloEstado
            // 
            lblTituloEstado.AutoSize = true;
            lblTituloEstado.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloEstado.Location = new Point(22, 769);
            lblTituloEstado.Name = "lblTituloEstado";
            lblTituloEstado.Size = new Size(74, 25);
            lblTituloEstado.TabIndex = 8;
            lblTituloEstado.Text = "Estado:";
            // 
            // frmInformacionVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1015);
            Controls.Add(pnlInformacion);
            Controls.Add(ptbFoto);
            Controls.Add(pnlDecoracion);
            Controls.Add(tlpTitulo);
            Controls.Add(ptbBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInformacionVehiculo";
            Text = "frmInformacionVehiculo";
            ((System.ComponentModel.ISupportInitialize)ptbBack).EndInit();
            tlpTitulo.ResumeLayout(false);
            tlpTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbFoto).EndInit();
            pnlInformacion.ResumeLayout(false);
            pnlInformacion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ptbBack;
        private TableLayoutPanel tlpTitulo;
        private Label lblTitulo;
        private Panel pnlDecoracion;
        private PictureBox ptbFoto;
        private Panel pnlInformacion;
        private Label lblPersonas;
        private Panel pnlDecoracion2;
        private Label lblDetalles;
        private FlowLayoutPanel flpPersonasEncargadas;
        private Button btnAgregar;
        private Label lblCapacidad;
        private Label lblTituloModelo;
        private Label lblTituloKilometraje;
        private Label lblTituloMarca;
        private Label lblTituloCapacidad;
        private Panel pnlDecoracion3;
        private Label lblMarca;
        private Label lblModelo;
        private Label lblEstado;
        private Label lblTituloEstado;
        private Label lblKilometraje;
        private Panel panel1;
    }
}