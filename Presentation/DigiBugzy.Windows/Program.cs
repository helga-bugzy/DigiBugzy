


namespace DigiBugzy.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Startup.ConfigureService();

            Application.Run(Startup.GetForm<MainShell>());

            //if (!Startup.HasAdministrations())
            //{
            //    Application.Run(Startup.GetForm<InstallationWizard>());
            //}
            //else
            //{
                
            //}
        }
    }
}