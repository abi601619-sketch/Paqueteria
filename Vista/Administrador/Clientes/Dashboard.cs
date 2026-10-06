namespace Vista.Administrador.Clientes
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

        }

        private void AbrirFormulario(Form formulario)
        {
            panelContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);
            panelContenido.Tag = formulario;

            formulario.Show();
            formulario.BringToFront();
        }
        private Inicio inicioForm = new Inicio();

        private Carretilla CarretillaForm = new Carretilla();
        private Principal PantallaInicio = new Principal();



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(inicioForm);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(PantallaInicio);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario(CarretillaForm);

        }

        private void ConfigurarBotonMenu(Guna.UI2.WinForms.Guna2Button boton)
        {
            boton.FillColor = Color.Transparent;
            boton.BackColor = Color.Transparent;

            boton.ForeColor = Color.White;

            boton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            boton.BorderRadius = 0;
            boton.BorderThickness = 0;

            boton.HoverState.FillColor = Color.FromArgb(95, 42, 20);
            boton.HoverState.ForeColor = Color.White;

            boton.PressedColor = Color.FromArgb(110, 48, 22);

            boton.TextAlign = HorizontalAlignment.Center;

            boton.Cursor = Cursors.Hand;
        }
        private void ConfigurarCerrarSesion()
        {
            btnCerrarSesion.FillColor = Color.Transparent;
            btnCerrarSesion.BackColor = Color.Transparent;

            btnCerrarSesion.ForeColor = Color.White;

            btnCerrarSesion.Font = new Font("Segoe UI", 8F, FontStyle.Bold);

            btnCerrarSesion.BorderRadius = 0;
            btnCerrarSesion.BorderThickness = 0;

            btnCerrarSesion.HoverState.FillColor = Color.FromArgb(95, 42, 20);

            btnCerrarSesion.HoverState.ForeColor = Color.White;

            btnCerrarSesion.Cursor = Cursors.Hand;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ConfigurarBotonMenu(btnDashboard);
            ConfigurarBotonMenu(btnProductos);
            ConfigurarBotonMenu(btnCarretilla);
            ConfigurarCerrarSesion();
        }
    }
}
