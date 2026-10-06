namespace Vista.Administrador.Clientes
{
    partial class Carretilla
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flpPedidos = new FlowLayoutPanel();
            btnEtregados = new Guna.UI2.WinForms.Guna2Button();
            btnEnProceso = new Guna.UI2.WinForms.Guna2Button();
            btnPendientes = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // flpPedidos
            // 
            flpPedidos.Location = new Point(12, 215);
            flpPedidos.Name = "flpPedidos";
            flpPedidos.Size = new Size(1603, 779);
            flpPedidos.TabIndex = 13;
            // 
            // btnEtregados
            // 
            btnEtregados.CustomizableEdges = customizableEdges1;
            btnEtregados.DisabledState.BorderColor = Color.DarkGray;
            btnEtregados.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEtregados.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEtregados.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEtregados.Font = new Font("Segoe UI", 9F);
            btnEtregados.ForeColor = Color.White;
            btnEtregados.Location = new Point(913, 91);
            btnEtregados.Name = "btnEtregados";
            btnEtregados.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEtregados.Size = new Size(434, 44);
            btnEtregados.TabIndex = 12;
            btnEtregados.Text = "Entregados";
            btnEtregados.Click += btnEtregados_Click;
            // 
            // btnEnProceso
            // 
            btnEnProceso.CustomizableEdges = customizableEdges3;
            btnEnProceso.DisabledState.BorderColor = Color.DarkGray;
            btnEnProceso.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEnProceso.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEnProceso.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEnProceso.Font = new Font("Segoe UI", 9F);
            btnEnProceso.ForeColor = Color.White;
            btnEnProceso.Location = new Point(471, 91);
            btnEnProceso.Name = "btnEnProceso";
            btnEnProceso.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEnProceso.Size = new Size(434, 44);
            btnEnProceso.TabIndex = 11;
            btnEnProceso.Text = "En proceso";
            btnEnProceso.Click += btnEnProceso_Click;
            // 
            // btnPendientes
            // 
            btnPendientes.CustomizableEdges = customizableEdges5;
            btnPendientes.DisabledState.BorderColor = Color.DarkGray;
            btnPendientes.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPendientes.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPendientes.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPendientes.Font = new Font("Segoe UI", 9F);
            btnPendientes.ForeColor = Color.White;
            btnPendientes.Location = new Point(28, 91);
            btnPendientes.Name = "btnPendientes";
            btnPendientes.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPendientes.Size = new Size(434, 44);
            btnPendientes.TabIndex = 10;
            btnPendientes.Text = "Pendientes";
            btnPendientes.Click += btnPendientes_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(28, 154);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(214, 52);
            guna2HtmlLabel2.TabIndex = 9;
            guna2HtmlLabel2.Text = "Mis Pedidos";
            guna2HtmlLabel2.Click += guna2HtmlLabel2_Click;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.CustomizableEdges = customizableEdges7;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(27, 20);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2TextBox1.Size = new Size(890, 42);
            guna2TextBox1.TabIndex = 7;
            // 
            // Carretilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1640, 1015);
            Controls.Add(flpPedidos);
            Controls.Add(btnEtregados);
            Controls.Add(btnEnProceso);
            Controls.Add(btnPendientes);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2TextBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Carretilla";
            Text = "Carretilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpPedidos;
        private Guna.UI2.WinForms.Guna2Button btnEtregados;
        private Guna.UI2.WinForms.Guna2Button btnEnProceso;
        private Guna.UI2.WinForms.Guna2Button btnPendientes;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}