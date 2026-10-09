namespace Vista.Conductor
{
    partial class frmDashboardConductor
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
            pnlBienvenida = new Panel();
            lblFecha = new Label();
            lblNombre = new Label();
            lblBienvenid = new Label();
            panel1 = new Panel();
            lblSinRutas = new Label();
            btnAccionRuta = new Button();
            panel4 = new Panel();
            panel6 = new Panel();
            label5 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            panel7 = new Panel();
            label6 = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            panel5 = new Panel();
            label4 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pnlRutas = new Panel();
            pnlCalendario = new Panel();
            tlpCalendario = new TableLayoutPanel();
            lblCalendario = new Label();
            pnlBienvenida.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlCalendario.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBienvenida
            // 
            pnlBienvenida.BackColor = Color.LightGray;
            pnlBienvenida.Controls.Add(lblFecha);
            pnlBienvenida.Controls.Add(lblNombre);
            pnlBienvenida.Controls.Add(lblBienvenid);
            pnlBienvenida.Location = new Point(50, 41);
            pnlBienvenida.Name = "pnlBienvenida";
            pnlBienvenida.Size = new Size(1524, 154);
            pnlBienvenida.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(1202, 100);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(289, 23);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "20 ENERO, 2026";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(42, 73);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(240, 50);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Leslie Lemus";
            // 
            // lblBienvenid
            // 
            lblBienvenid.AutoSize = true;
            lblBienvenid.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenid.ForeColor = SystemColors.ControlDarkDark;
            lblBienvenid.Location = new Point(50, 43);
            lblBienvenid.Name = "lblBienvenid";
            lblBienvenid.Size = new Size(140, 30);
            lblBienvenid.TabIndex = 0;
            lblBienvenid.Text = "BIENVENID@";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblSinRutas);
            panel1.Controls.Add(btnAccionRuta);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(50, 222);
            panel1.Name = "panel1";
            panel1.Size = new Size(1153, 234);
            panel1.TabIndex = 1;
            // 
            // lblSinRutas
            // 
            lblSinRutas.Dock = DockStyle.Fill;
            lblSinRutas.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSinRutas.Location = new Point(0, 0);
            lblSinRutas.Name = "lblSinRutas";
            lblSinRutas.Size = new Size(1151, 232);
            lblSinRutas.TabIndex = 4;
            lblSinRutas.Text = "No hay rutas programadas para el día de hoy";
            lblSinRutas.TextAlign = ContentAlignment.MiddleCenter;
            lblSinRutas.Visible = false;
            // 
            // btnAccionRuta
            // 
            btnAccionRuta.BackColor = Color.FromArgb(78, 35, 14);
            btnAccionRuta.FlatAppearance.BorderSize = 0;
            btnAccionRuta.FlatStyle = FlatStyle.Flat;
            btnAccionRuta.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccionRuta.ForeColor = Color.White;
            btnAccionRuta.Location = new Point(946, 80);
            btnAccionRuta.Name = "btnAccionRuta";
            btnAccionRuta.Size = new Size(165, 68);
            btnAccionRuta.TabIndex = 3;
            btnAccionRuta.Text = "Iniciar Ruta";
            btnAccionRuta.UseVisualStyleBackColor = false;
            btnAccionRuta.Click += btnAccionRuta_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(pictureBox2);
            panel4.Location = new Point(372, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 177);
            panel4.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(255, 242, 204);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(41, 123);
            panel6.Name = "panel6";
            panel6.Size = new Size(128, 39);
            panel6.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(230, 158, 0);
            label5.Location = new Point(27, 13);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 3;
            label5.Text = "EN CAMINO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 96);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 4;
            label2.Text = "San Salvador";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.n_removebg_preview;
            pictureBox2.Location = new Point(56, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(95, 89);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(691, 24);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 177);
            panel3.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(251, 226, 227);
            panel7.Controls.Add(label6);
            panel7.Location = new Point(40, 123);
            panel7.Name = "panel7";
            panel7.Size = new Size(128, 39);
            panel7.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(222, 29, 34);
            label6.Location = new Point(29, 13);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 3;
            label6.Text = "PENDIENTE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(40, 96);
            label3.Name = "label3";
            label3.Size = new Size(128, 25);
            label3.TabIndex = 2;
            label3.Text = "San Salvador";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.r_removebg_preview;
            pictureBox3.Location = new Point(53, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 89);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(49, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 177);
            panel2.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(212, 241, 213);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(37, 123);
            panel5.Name = "panel5";
            panel5.Size = new Size(128, 39);
            panel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 143, 17);
            label4.Location = new Point(20, 13);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 3;
            label4.Text = "COMPLETADO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 95);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 1;
            label1.Text = "San Salvador";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.circulo_verde_removebg_preview;
            pictureBox1.Location = new Point(53, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlRutas
            // 
            pnlRutas.Location = new Point(1234, 259);
            pnlRutas.Name = "pnlRutas";
            pnlRutas.Size = new Size(340, 672);
            pnlRutas.TabIndex = 2;
            // 
            // pnlCalendario
            // 
            pnlCalendario.BorderStyle = BorderStyle.FixedSingle;
            pnlCalendario.Controls.Add(tlpCalendario);
            pnlCalendario.Controls.Add(lblCalendario);
            pnlCalendario.Location = new Point(49, 486);
            pnlCalendario.Name = "pnlCalendario";
            pnlCalendario.Size = new Size(1153, 445);
            pnlCalendario.TabIndex = 3;
            // 
            // tlpCalendario
            // 
            tlpCalendario.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpCalendario.ColumnCount = 7;
            tlpCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857113F));
            tlpCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tlpCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tlpCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tlpCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tlpCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tlpCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tlpCalendario.Location = new Point(46, 68);
            tlpCalendario.Name = "tlpCalendario";
            tlpCalendario.RowCount = 6;
            tlpCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tlpCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tlpCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tlpCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tlpCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tlpCalendario.Size = new Size(1055, 314);
            tlpCalendario.TabIndex = 1;
            tlpCalendario.Paint += tlpCalendario_Paint;
            // 
            // lblCalendario
            // 
            lblCalendario.AutoSize = true;
            lblCalendario.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCalendario.Location = new Point(42, 28);
            lblCalendario.Name = "lblCalendario";
            lblCalendario.Size = new Size(182, 37);
            lblCalendario.TabIndex = 0;
            lblCalendario.Text = "CALENDARIO";
            // 
            // frmDashboardConductor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1642, 958);
            Controls.Add(pnlCalendario);
            Controls.Add(pnlRutas);
            Controls.Add(panel1);
            Controls.Add(pnlBienvenida);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDashboardConductor";
            Text = "frmDashboardConductor";
            pnlBienvenida.ResumeLayout(false);
            pnlBienvenida.PerformLayout();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlCalendario.ResumeLayout(false);
            pnlCalendario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBienvenida;
        private Label lblFecha;
        private Label lblNombre;
        private Label lblBienvenid;
        private Panel panel1;
        private Panel pnlRutas;
        private Panel pnlCalendario;
        private TableLayoutPanel tlpCalendario;
        private Label lblCalendario;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Panel panel3;
        private PictureBox pictureBox3;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel panel6;
        private Label label5;
        private Label label2;
        private Panel panel7;
        private Label label6;
        private Label label3;
        private Panel panel5;
        private Label label4;
        private Label label1;
        private Button btnAccionRuta;
        private Label lblSinRutas;
    }
}