namespace Vista.Conductor
{
    partial class frmVehiculos
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pnlRutasC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // pnlRutasC
            // 
            pnlRutasC.BackColor = Color.Gainsboro;
            pnlRutasC.Controls.Add(lblRutasC);
            pnlRutasC.Location = new Point(42, 32);
            pnlRutasC.Name = "pnlRutasC";
            pnlRutasC.Size = new Size(1504, 82);
            pnlRutasC.TabIndex = 1;
            // 
            // lblRutasC
            // 
            lblRutasC.AutoSize = true;
            lblRutasC.BackColor = Color.Gainsboro;
            lblRutasC.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRutasC.ForeColor = SystemColors.ActiveCaptionText;
            lblRutasC.Location = new Point(39, 17);
            lblRutasC.Name = "lblRutasC";
            lblRutasC.Size = new Size(217, 50);
            lblRutasC.TabIndex = 1;
            lblRutasC.Text = "VEHÍCULOS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.camion_ligero;
            pictureBox1.Location = new Point(42, 151);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(488, 313);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.van_mediana;
            pictureBox2.Location = new Point(550, 151);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(488, 313);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.van_grande;
            pictureBox3.Location = new Point(1058, 151);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(488, 313);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.van_compacta;
            pictureBox4.Location = new Point(42, 516);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(488, 313);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.camion_mediano;
            pictureBox5.Location = new Point(550, 516);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(488, 313);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 6;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.camion_mediano_lona;
            pictureBox6.Location = new Point(1058, 516);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(488, 313);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 7;
            pictureBox6.TabStop = false;
            // 
            // frmVehiculos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1610, 880);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pnlRutasC);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmVehiculos";
            Text = "frmVehiculos";
            pnlRutasC.ResumeLayout(false);
            pnlRutasC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRutasC;
        private Label lblRutasC;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
    }
}