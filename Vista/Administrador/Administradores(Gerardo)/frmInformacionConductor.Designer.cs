namespace Vista.Administrador.Administradores_Gerardo_
{
    partial class frmInformacionConductor
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
            ptbFotoPerfil = new PictureBox();
            pnlRutas = new Panel();
            btnAgregarRuta = new Button();
            flpRutas = new FlowLayoutPanel();
            lblRutas = new Label();
            tlpZona = new TableLayoutPanel();
            lblZona = new Label();
            pnlVehiculos = new Panel();
            btnAgregarVehiculo = new Button();
            flpVehiculos = new FlowLayoutPanel();
            lblVehiculos = new Label();
            lblCorreo = new Label();
            lblDui = new Label();
            lblCorreoUsuario = new Label();
            tlpCorreo = new TableLayoutPanel();
            tlpDui = new TableLayoutPanel();
            lblDuiUsuario = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)ptbBack).BeginInit();
            tlpTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbFotoPerfil).BeginInit();
            pnlRutas.SuspendLayout();
            tlpZona.SuspendLayout();
            pnlVehiculos.SuspendLayout();
            tlpCorreo.SuspendLayout();
            tlpDui.SuspendLayout();
            SuspendLayout();
            // 
            // ptbBack
            // 
            ptbBack.Image = Properties.Resources.iconback;
            ptbBack.Location = new Point(12, 12);
            ptbBack.Name = "ptbBack";
            ptbBack.Size = new Size(82, 70);
            ptbBack.SizeMode = PictureBoxSizeMode.Zoom;
            ptbBack.TabIndex = 2;
            ptbBack.TabStop = false;
            ptbBack.Click += ptbBack_Click;
            // 
            // tlpTitulo
            // 
            tlpTitulo.ColumnCount = 1;
            tlpTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTitulo.Controls.Add(lblTitulo, 0, 0);
            tlpTitulo.Location = new Point(115, 12);
            tlpTitulo.Name = "tlpTitulo";
            tlpTitulo.RowCount = 1;
            tlpTitulo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTitulo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpTitulo.Size = new Size(1513, 70);
            tlpTitulo.TabIndex = 3;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.SaddleBrown;
            lblTitulo.Location = new Point(449, 2);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(615, 65);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Información de conductor";
            // 
            // pnlDecoracion
            // 
            pnlDecoracion.BackColor = Color.OrangeRed;
            pnlDecoracion.ForeColor = Color.OrangeRed;
            pnlDecoracion.Location = new Point(115, 82);
            pnlDecoracion.Name = "pnlDecoracion";
            pnlDecoracion.Size = new Size(1513, 8);
            pnlDecoracion.TabIndex = 4;
            // 
            // ptbFotoPerfil
            // 
            ptbFotoPerfil.BorderStyle = BorderStyle.FixedSingle;
            ptbFotoPerfil.Location = new Point(39, 154);
            ptbFotoPerfil.Name = "ptbFotoPerfil";
            ptbFotoPerfil.Size = new Size(583, 364);
            ptbFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            ptbFotoPerfil.TabIndex = 5;
            ptbFotoPerfil.TabStop = false;
            // 
            // pnlRutas
            // 
            pnlRutas.BackColor = SystemColors.ControlLight;
            pnlRutas.BorderStyle = BorderStyle.FixedSingle;
            pnlRutas.Controls.Add(btnAgregarRuta);
            pnlRutas.Controls.Add(flpRutas);
            pnlRutas.Controls.Add(lblRutas);
            pnlRutas.Location = new Point(796, 583);
            pnlRutas.Name = "pnlRutas";
            pnlRutas.Size = new Size(832, 401);
            pnlRutas.TabIndex = 6;
            // 
            // btnAgregarRuta
            // 
            btnAgregarRuta.BackColor = Color.OrangeRed;
            btnAgregarRuta.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarRuta.ForeColor = SystemColors.Control;
            btnAgregarRuta.Location = new Point(639, 9);
            btnAgregarRuta.Name = "btnAgregarRuta";
            btnAgregarRuta.Size = new Size(177, 50);
            btnAgregarRuta.TabIndex = 3;
            btnAgregarRuta.Text = "Agregar";
            btnAgregarRuta.UseVisualStyleBackColor = false;
            btnAgregarRuta.Click += btnAgregarRuta_Click;
            // 
            // flpRutas
            // 
            flpRutas.AutoScroll = true;
            flpRutas.Location = new Point(12, 73);
            flpRutas.Name = "flpRutas";
            flpRutas.Size = new Size(804, 308);
            flpRutas.TabIndex = 2;
            // 
            // lblRutas
            // 
            lblRutas.AutoSize = true;
            lblRutas.BackColor = SystemColors.ControlLight;
            lblRutas.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRutas.ForeColor = Color.SaddleBrown;
            lblRutas.Location = new Point(3, 9);
            lblRutas.Name = "lblRutas";
            lblRutas.Size = new Size(305, 50);
            lblRutas.TabIndex = 1;
            lblRutas.Text = "Rutas Asignadas";
            // 
            // tlpZona
            // 
            tlpZona.ColumnCount = 1;
            tlpZona.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpZona.Controls.Add(lblZona, 0, 0);
            tlpZona.Location = new Point(39, 524);
            tlpZona.Name = "tlpZona";
            tlpZona.RowCount = 1;
            tlpZona.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpZona.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpZona.Size = new Size(583, 70);
            tlpZona.TabIndex = 8;
            // 
            // lblZona
            // 
            lblZona.Anchor = AnchorStyles.None;
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblZona.ForeColor = Color.DarkSlateGray;
            lblZona.Location = new Point(74, 2);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(434, 65);
            lblZona.TabIndex = 4;
            lblZona.Text = "Vehículo Mediano";
            // 
            // pnlVehiculos
            // 
            pnlVehiculos.BackColor = SystemColors.ControlLight;
            pnlVehiculos.BorderStyle = BorderStyle.FixedSingle;
            pnlVehiculos.Controls.Add(btnAgregarVehiculo);
            pnlVehiculos.Controls.Add(flpVehiculos);
            pnlVehiculos.Controls.Add(lblVehiculos);
            pnlVehiculos.Location = new Point(796, 154);
            pnlVehiculos.Name = "pnlVehiculos";
            pnlVehiculos.Size = new Size(832, 401);
            pnlVehiculos.TabIndex = 9;
            // 
            // btnAgregarVehiculo
            // 
            btnAgregarVehiculo.BackColor = Color.OrangeRed;
            btnAgregarVehiculo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarVehiculo.ForeColor = SystemColors.Control;
            btnAgregarVehiculo.Location = new Point(639, 9);
            btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            btnAgregarVehiculo.Size = new Size(177, 50);
            btnAgregarVehiculo.TabIndex = 3;
            btnAgregarVehiculo.Text = "Agregar";
            btnAgregarVehiculo.UseVisualStyleBackColor = false;
            btnAgregarVehiculo.Click += btnAgregarVehiculo_Click;
            // 
            // flpVehiculos
            // 
            flpVehiculos.AutoScroll = true;
            flpVehiculos.Location = new Point(12, 73);
            flpVehiculos.Name = "flpVehiculos";
            flpVehiculos.Size = new Size(804, 307);
            flpVehiculos.TabIndex = 2;
            // 
            // lblVehiculos
            // 
            lblVehiculos.AutoSize = true;
            lblVehiculos.BackColor = SystemColors.ControlLight;
            lblVehiculos.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehiculos.ForeColor = Color.SaddleBrown;
            lblVehiculos.Location = new Point(3, 9);
            lblVehiculos.Name = "lblVehiculos";
            lblVehiculos.Size = new Size(378, 50);
            lblVehiculos.TabIndex = 1;
            lblVehiculos.Text = "Vehículos Asignados";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(39, 648);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(112, 37);
            lblCorreo.TabIndex = 10;
            lblCorreo.Text = "Correo:";
            // 
            // lblDui
            // 
            lblDui.AutoSize = true;
            lblDui.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDui.Location = new Point(39, 768);
            lblDui.Name = "lblDui";
            lblDui.Size = new Size(68, 37);
            lblDui.TabIndex = 10;
            lblDui.Text = "Dui:";
            // 
            // lblCorreoUsuario
            // 
            lblCorreoUsuario.AutoSize = true;
            lblCorreoUsuario.Dock = DockStyle.Left;
            lblCorreoUsuario.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorreoUsuario.Location = new Point(3, 0);
            lblCorreoUsuario.Name = "lblCorreoUsuario";
            lblCorreoUsuario.Size = new Size(280, 41);
            lblCorreoUsuario.TabIndex = 11;
            lblCorreoUsuario.Text = "Noseque@gmail.com";
            // 
            // tlpCorreo
            // 
            tlpCorreo.ColumnCount = 1;
            tlpCorreo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCorreo.Controls.Add(lblCorreoUsuario, 0, 0);
            tlpCorreo.Location = new Point(39, 688);
            tlpCorreo.Name = "tlpCorreo";
            tlpCorreo.RowCount = 1;
            tlpCorreo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCorreo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpCorreo.Size = new Size(573, 41);
            tlpCorreo.TabIndex = 8;
            // 
            // tlpDui
            // 
            tlpDui.ColumnCount = 1;
            tlpDui.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDui.Controls.Add(lblDuiUsuario, 0, 0);
            tlpDui.Location = new Point(42, 808);
            tlpDui.Name = "tlpDui";
            tlpDui.RowCount = 1;
            tlpDui.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDui.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpDui.Size = new Size(573, 41);
            tlpDui.TabIndex = 8;
            // 
            // lblDuiUsuario
            // 
            lblDuiUsuario.AutoSize = true;
            lblDuiUsuario.Dock = DockStyle.Left;
            lblDuiUsuario.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuiUsuario.Location = new Point(3, 0);
            lblDuiUsuario.Name = "lblDuiUsuario";
            lblDuiUsuario.Size = new Size(163, 41);
            lblDuiUsuario.TabIndex = 11;
            lblDuiUsuario.Text = "00000000-0";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkRed;
            button1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(39, 892);
            button1.Name = "button1";
            button1.Size = new Size(386, 92);
            button1.TabIndex = 11;
            button1.Text = "Actualizar Información";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // frmInformacionConductor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1015);
            Controls.Add(button1);
            Controls.Add(lblDui);
            Controls.Add(lblCorreo);
            Controls.Add(pnlRutas);
            Controls.Add(pnlVehiculos);
            Controls.Add(tlpDui);
            Controls.Add(tlpCorreo);
            Controls.Add(tlpZona);
            Controls.Add(ptbFotoPerfil);
            Controls.Add(pnlDecoracion);
            Controls.Add(tlpTitulo);
            Controls.Add(ptbBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInformacionConductor";
            Text = "frmInformacionConductor";
            ((System.ComponentModel.ISupportInitialize)ptbBack).EndInit();
            tlpTitulo.ResumeLayout(false);
            tlpTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbFotoPerfil).EndInit();
            pnlRutas.ResumeLayout(false);
            pnlRutas.PerformLayout();
            tlpZona.ResumeLayout(false);
            tlpZona.PerformLayout();
            pnlVehiculos.ResumeLayout(false);
            pnlVehiculos.PerformLayout();
            tlpCorreo.ResumeLayout(false);
            tlpCorreo.PerformLayout();
            tlpDui.ResumeLayout(false);
            tlpDui.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptbBack;
        private TableLayoutPanel tlpTitulo;
        private Label lblTitulo;
        private Panel pnlDecoracion;
        private PictureBox ptbFotoPerfil;
        private Panel pnlRutas;
        private TableLayoutPanel tlpZona;
        private Label lblZona;
        private Button btnAgregarRuta;
        private FlowLayoutPanel flpRutas;
        private Label lblRutas;
        private Panel pnlVehiculos;
        private Button btnAgregarVehiculo;
        private FlowLayoutPanel flpVehiculos;
        private Label lblVehiculos;
        private Label lblCorreo;
        private Label lblDui;
        private Label lblCorreoUsuario;
        private TableLayoutPanel tlpCorreo;
        private TableLayoutPanel tlpDui;
        private Label lblDuiUsuario;
        private Button button1;
    }
}