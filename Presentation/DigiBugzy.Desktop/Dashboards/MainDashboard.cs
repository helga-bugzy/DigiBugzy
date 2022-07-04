

namespace DigiBugzy.Desktop.Dashboards
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();

            Text = $@"{Globals.DigiAdministration.Name} Dashboard";
            Application.DoEvents();
        }
    }
}
