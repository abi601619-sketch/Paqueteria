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
            pnlRutas = new Panel();
            pnlCalendario = new Panel();
            tlpCalendario = new TableLayoutPanel();
            lblCalendario = new Label();
            pnlBienvenida.SuspendLayout();
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
            pnlBienvenida.Size = new Size(1488, 114);
            pnlBienvenida.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(1281, 73);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(153, 23);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "20 ENERO, 2026";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(43, 46);
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
            lblBienvenid.Location = new Point(47, 16);
            lblBienvenid.Name = "lblBienvenid";
            lblBienvenid.Size = new Size(140, 30);
            lblBienvenid.TabIndex = 0;
            lblBienvenid.Text = "BIENVENID@";
            // 
            // panel1
            // 
            panel1.Location = new Point(50, 180);
            panel1.Name = "panel1";
            panel1.Size = new Size(1153, 197);
            panel1.TabIndex = 1;
            // 
            // pnlRutas
            // 
            pnlRutas.Location = new Point(1234, 180);
            pnlRutas.Name = "pnlRutas";
            pnlRutas.Size = new Size(304, 197);
            pnlRutas.TabIndex = 2;
            // 
            // pnlCalendario
            // 
            pnlCalendario.BorderStyle = BorderStyle.FixedSingle;
            pnlCalendario.Controls.Add(tlpCalendario);
            pnlCalendario.Controls.Add(lblCalendario);
            pnlCalendario.Location = new Point(50, 410);
            pnlCalendario.Name = "pnlCalendario";
            pnlCalendario.Size = new Size(1153, 400);
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
            ClientSize = new Size(1594, 841);
            Controls.Add(pnlCalendario);
            Controls.Add(pnlRutas);
            Controls.Add(panel1);
            Controls.Add(pnlBienvenida);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDashboardConductor";
            Text = "frmDashboardConductor";
            pnlBienvenida.ResumeLayout(false);
            pnlBienvenida.PerformLayout();
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
    }
}