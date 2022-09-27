using System.Threading;

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

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Event Handling
            Initialize_ExeptionsHandler();

            Startup.ConfigureService();

           

            Application.Run(Startup.GetForm<LoginForm>());
        }

        #region Exception Handlers

        static void Initialize_ExeptionsHandler()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Add handler for UI thread exceptions
            Application.ThreadException += UiThreadException;

            // Force all WinForms errors to go through handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // This handler is for catching non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                MessageBox.Show("Unhadled domain exception:\n\n" + ex.Message);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UnhadledExceptionHandler: \n\n"
                                    + exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // It should terminate our main thread so Application.Exit() is unnecessary here
        }

        private static void UiThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                var stackTrace = t.Exception.StackTrace == null ? "No Stacktrace found" 
                    : t.Exception.StackTrace.Length > 1000 ? 
                        $"{t.Exception.StackTrace?.Substring(1, 1000)}..." : 
                        t.Exception.StackTrace;
                MessageBox.Show($"Unhandled exception catched. {Environment.NewLine} {t.Exception.Message} {Environment.NewLine} {stackTrace}");
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UIThreadException handler",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Here we can decide if we want to end our application or do something else
            //Application.Exit();
        }

        #endregion
    }
}