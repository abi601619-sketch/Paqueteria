namespace Vista.Administrador.Clientes
{
    partial class Principal
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            flpProductos = new FlowLayoutPanel();
            btnVerMas = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(31, 17);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(171, 47);
            guna2HtmlLabel1.TabIndex = 5;
            guna2HtmlLabel1.Text = "Bienvenido";
            // 
            // txtBuscar
            // 
            txtBuscar.CustomizableEdges = customizableEdges1;
            txtBuscar.DefaultText = "";
            txtBuscar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBuscar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBuscar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Location = new Point(17, 73);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "";
            txtBuscar.SelectedText = "";
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtBuscar.Size = new Size(749, 38);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // flpProductos
            // 
            flpProductos.AutoScroll = true;
            flpProductos.Location = new Point(9, 139);
            flpProductos.Name = "flpProductos";
            flpProductos.Size = new Size(1622, 798);
            flpProductos.TabIndex = 3;
            // 
            // btnVerMas
            // 
            btnVerMas.BorderRadius = 8;
            btnVerMas.CustomizableEdges = customizableEdges3;
            btnVerMas.DisabledState.BorderColor = Color.DarkGray;
            btnVerMas.DisabledState.CustomBorderColor = Color.DarkGray;
            btnVerMas.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnVerMas.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnVerMas.FillColor = Color.Red;
            btnVerMas.Font = new Font("Segoe UI", 9F);
            btnVerMas.ForeColor = Color.White;
            btnVerMas.Location = new Point(661, 955);
            btnVerMas.Name = "btnVerMas";
            btnVerMas.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnVerMas.Size = new Size(451, 38);
            btnVerMas.TabIndex = 6;
            btnVerMas.Text = "Ver más productos";
            btnVerMas.Click += btnVerMas_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1640, 1015);
            Controls.Add(btnVerMas);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(txtBuscar);
            Controls.Add(flpProductos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Principal";
            Text = "Principal";
            Load += Principal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private FlowLayoutPanel flpProductos;
        private Guna.UI2.WinForms.Guna2Button btnVerMas;
    }
}