namespace Vista.Conductor
{
    partial class frmProductos
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
            dgvProductos = new DataGridView();
            btnCerrar = new Button();
            pnlRutasC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // pnlRutasC
            // 
            pnlRutasC.BackColor = Color.Gainsboro;
            pnlRutasC.Controls.Add(lblRutasC);
            pnlRutasC.Location = new Point(40, 34);
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
            lblRutasC.Size = new Size(475, 50);
            lblRutasC.TabIndex = 1;
            lblRutasC.Text = "PRODUCTOS SOLICITADOS";
            lblRutasC.Click += lblRutasC_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(40, 139);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(1504, 511);
            dgvProductos.TabIndex = 2;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gainsboro;
            btnCerrar.Location = new Point(1355, 687);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(189, 66);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Volver a rutas";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1610, 880);
            Controls.Add(btnCerrar);
            Controls.Add(dgvProductos);
            Controls.Add(pnlRutasC);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProductos";
            Text = "frmProdcutos";
            pnlRutasC.ResumeLayout(false);
            pnlRutasC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRutasC;
        private Label lblRutasC;
        private DataGridView dgvProductos;
        private Button btnCerrar;
    }
}