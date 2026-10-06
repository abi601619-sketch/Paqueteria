using Vista.Administrador.Clientes;

namespace Vista
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            ApplicationConfiguration.Initialize();

            Application.Run(new Dashboard());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(
                e.Exception.ToString(),
                "ERROR DE WINDOWS FORMS",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(
                e.ExceptionObject?.ToString() ?? "Error desconocido",
                "ERROR NO CONTROLADO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}