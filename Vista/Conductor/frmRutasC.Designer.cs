namespace Vista.Conductor
{
    partial class frmRutasC
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
            pnlRutasC = new Panel();
            lblRutasC = new Label();
            pnlTarjeta = new Panel();
            lstLugaresRuta = new ListBox();
            lblFecha = new Label();
            pnlEstado = new Panel();
            lblEstado = new Label();
            lblNombreR = new Label();
            pnlTarjetaColor = new Panel();
            pnlListaProductos = new Panel();
            btnVerMasProductos = new Button();
            lblTituloProductos = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            comboBox3 = new ComboBox();
            label2 = new Label();
            panel2 = new Panel();
            comboBox2 = new ComboBox();
            lblLugar2 = new Label();
            panel5 = new Panel();
            label1 = new Label();
            comboBox1 = new ComboBox();
            lblPuntos = new Label();
            pnlContenedorRutas = new Panel();
            panel4 = new Panel();
            label4 = new Label();
            label3 = new Label();
            pnlRutasC.SuspendLayout();
            pnlTarjeta.SuspendLayout();
            pnlEstado.SuspendLayout();
            pnlListaProductos.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRutasC
            // 
            pnlRutasC.BackColor = Color.Gainsboro;
            pnlRutasC.Controls.Add(lblRutasC);
            pnlRutasC.Location = new Point(58, 32);
            pnlRutasC.Name = "pnlRutasC";
            pnlRutasC.Size = new Size(1504, 82);
            pnlRutasC.TabIndex = 0;
            // 
            // lblRutasC
            // 
            lblRutasC.AutoSize = true;
            lblRutasC.BackColor = Color.Gainsboro;
            lblRutasC.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRutasC.ForeColor = SystemColors.ActiveCaptionText;
            lblRutasC.Location = new Point(39, 17);
            lblRutasC.Name = "lblRutasC";
            lblRutasC.Size = new Size(133, 50);
            lblRutasC.TabIndex = 1;
            lblRutasC.Text = "RUTAS";
            // 
            // pnlTarjeta
            // 
            pnlTarjeta.BackColor = Color.FromArgb(240, 246, 255);
            pnlTarjeta.Controls.Add(lstLugaresRuta);
            pnlTarjeta.Controls.Add(lblFecha);
            pnlTarjeta.Controls.Add(pnlEstado);
            pnlTarjeta.Controls.Add(lblNombreR);
            pnlTarjeta.Controls.Add(pnlTarjetaColor);
            pnlTarjeta.Location = new Point(58, 136);
            pnlTarjeta.Name = "pnlTarjeta";
            pnlTarjeta.Size = new Size(228, 272);
            pnlTarjeta.TabIndex = 1;
            pnlTarjeta.Visible = false;
            // 
            // lstLugaresRuta
            // 
            lstLugaresRuta.BackColor = Color.FromArgb(240, 246, 255);
            lstLugaresRuta.BorderStyle = BorderStyle.None;
            lstLugaresRuta.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstLugaresRuta.ForeColor = SystemColors.ControlDarkDark;
            lstLugaresRuta.FormattingEnabled = true;
            lstLugaresRuta.IntegralHeight = false;
            lstLugaresRuta.Items.AddRange(new object[] { "SAN SALVADOR", "CHALATENANGO", "LA PALMA" });
            lstLugaresRuta.Location = new Point(39, 172);
            lstLugaresRuta.Name = "lstLugaresRuta";
            lstLugaresRuta.Size = new Size(171, 58);
            lstLugaresRuta.TabIndex = 4;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = SystemColors.ControlDarkDark;
            lblFecha.Location = new Point(39, 134);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(89, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "20 ENERO, 2026";
            // 
            // pnlEstado
            // 
            pnlEstado.BackColor = Color.FromArgb(75, 169, 245);
            pnlEstado.Controls.Add(lblEstado);
            pnlEstado.ForeColor = SystemColors.ControlDark;
            pnlEstado.Location = new Point(39, 72);
            pnlEstado.Name = "pnlEstado";
            pnlEstado.Size = new Size(123, 43);
            pnlEstado.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = SystemColors.ButtonFace;
            lblEstado.Location = new Point(28, 10);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(66, 21);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "ACTIVA";
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;
            lblEstado.Click += label1_Click;
            // 
            // lblNombreR
            // 
            lblNombreR.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreR.Location = new Point(31, 21);
            lblNombreR.Name = "lblNombreR";
            lblNombreR.Size = new Size(102, 37);
            lblNombreR.TabIndex = 2;
            lblNombreR.Text = "RUTA 1";
            // 
            // pnlTarjetaColor
            // 
            pnlTarjetaColor.BackColor = Color.FromArgb(75, 169, 245);
            pnlTarjetaColor.Dock = DockStyle.Left;
            pnlTarjetaColor.Location = new Point(0, 0);
            pnlTarjetaColor.Name = "pnlTarjetaColor";
            pnlTarjetaColor.Size = new Size(16, 272);
            pnlTarjetaColor.TabIndex = 2;
            // 
            // pnlListaProductos
            // 
            pnlListaProductos.AutoScroll = true;
            pnlListaProductos.BorderStyle = BorderStyle.FixedSingle;
            pnlListaProductos.Controls.Add(btnVerMasProductos);
            pnlListaProductos.Controls.Add(lblTituloProductos);
            pnlListaProductos.Location = new Point(353, 136);
            pnlListaProductos.Name = "pnlListaProductos";
            pnlListaProductos.Size = new Size(720, 272);
            pnlListaProductos.TabIndex = 2;
            // 
            // btnVerMasProductos
            // 
            btnVerMasProductos.BackColor = Color.Gainsboro;
            btnVerMasProductos.FlatAppearance.BorderSize = 0;
            btnVerMasProductos.FlatStyle = FlatStyle.Flat;
            btnVerMasProductos.Location = new Point(594, 212);
            btnVerMasProductos.Name = "btnVerMasProductos";
            btnVerMasProductos.Size = new Size(101, 47);
            btnVerMasProductos.TabIndex = 1;
            btnVerMasProductos.Text = "VER MÁS";
            btnVerMasProductos.UseVisualStyleBackColor = false;
            btnVerMasProductos.Click += btnVerMasProductos_Click;
            // 
            // lblTituloProductos
            // 
            lblTituloProductos.AutoSize = true;
            lblTituloProductos.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloProductos.Location = new Point(35, 26);
            lblTituloProductos.Name = "lblTituloProductos";
            lblTituloProductos.Size = new Size(269, 30);
            lblTituloProductos.TabIndex = 0;
            lblTituloProductos.Text = "PRODUCTOS SOLICITADOS";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(lblPuntos);
            panel1.Location = new Point(1124, 136);
            panel1.Name = "panel1";
            panel1.Size = new Size(438, 272);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(212, 241, 213);
            panel3.Controls.Add(comboBox3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(25, 197);
            panel3.Name = "panel3";
            panel3.Size = new Size(389, 52);
            panel3.TabIndex = 4;
            // 
            // comboBox3
            // 
            comboBox3.BackColor = Color.White;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "COMPLETADO", "EN CAMINO", "PENDIENTE" });
            comboBox3.Location = new Point(255, 15);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(15, 16);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 4;
            label2.Text = "LA PALMA";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(212, 241, 213);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(lblLugar2);
            panel2.Location = new Point(25, 134);
            panel2.Name = "panel2";
            panel2.Size = new Size(389, 52);
            panel2.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.White;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "COMPLETADO", "EN CAMINO", "PENDIENTE" });
            comboBox2.Location = new Point(255, 15);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 5;
            // 
            // lblLugar2
            // 
            lblLugar2.AutoSize = true;
            lblLugar2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLugar2.ForeColor = SystemColors.ActiveCaptionText;
            lblLugar2.Location = new Point(15, 16);
            lblLugar2.Name = "lblLugar2";
            lblLugar2.Size = new Size(111, 17);
            lblLugar2.TabIndex = 4;
            lblLugar2.Text = "CHALATENANGO";
            lblLugar2.Click += label1_Click_1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(212, 241, 213);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(comboBox1);
            panel5.Location = new Point(25, 63);
            panel5.Name = "panel5";
            panel5.Size = new Size(389, 52);
            panel5.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(111, 17);
            label1.TabIndex = 6;
            label1.Text = "CHALATENANGO";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "COMPLETADO", "EN CAMINO", "PENDIENTE" });
            comboBox1.Location = new Point(255, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            // 
            // lblPuntos
            // 
            lblPuntos.AutoSize = true;
            lblPuntos.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPuntos.Location = new Point(25, 27);
            lblPuntos.Name = "lblPuntos";
            lblPuntos.Size = new Size(94, 30);
            lblPuntos.TabIndex = 1;
            lblPuntos.Text = "PUNTOS";
            // 
            // pnlContenedorRutas
            // 
            pnlContenedorRutas.AutoScroll = true;
            pnlContenedorRutas.Location = new Point(58, 136);
            pnlContenedorRutas.Name = "pnlContenedorRutas";
            pnlContenedorRutas.Size = new Size(261, 777);
            pnlContenedorRutas.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(353, 437);
            panel4.Name = "panel4";
            panel4.Size = new Size(720, 86);
            panel4.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(36, 49);
            label4.Name = "label4";
            label4.Size = new Size(275, 15);
            label4.TabIndex = 3;
            label4.Text = "Presiona un ruta para ver los productos solicitados.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 19);
            label3.Name = "label3";
            label3.Size = new Size(142, 30);
            label3.TabIndex = 1;
            label3.Text = "IMPORTANTE";
            // 
            // frmRutasC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1626, 919);
            Controls.Add(panel4);
            Controls.Add(pnlTarjeta);
            Controls.Add(panel1);
            Controls.Add(pnlListaProductos);
            Controls.Add(pnlRutasC);
            Controls.Add(pnlContenedorRutas);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRutasC";
            Text = "frmRutasC";
            pnlRutasC.ResumeLayout(false);
            pnlRutasC.PerformLayout();
            pnlTarjeta.ResumeLayout(false);
            pnlTarjeta.PerformLayout();
            pnlEstado.ResumeLayout(false);
            pnlEstado.PerformLayout();
            pnlListaProductos.ResumeLayout(false);
            pnlListaProductos.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRutasC;
        private Label lblRutasC;
        private Panel pnlTarjeta;
        private Panel pnlTarjetaColor;
        private Label lblNombreR;
        private Panel pnlEstado;
        private Label lblEstado;
        private Label lblFecha;
        private Panel pnlListaProductos;
        private Label lblTituloProductos;
        private Button btnVerMasProductos;
        private Panel panel1;
        private Label lblPuntos;
        private Panel panel5;
        private ComboBox comboBox1;
        private Label lblLugar;
        private Panel panel3;
        private ComboBox comboBox3;
        private Label label2;
        private Panel panel2;
        private ComboBox comboBox2;
        private Label lblLugar2;
        private ListBox lstLugaresRuta;
        private Panel pnlContenedorRutas;
        private Panel panel4;
        private Label label4;
        private Label label3;
        private Label label1;
    }
}