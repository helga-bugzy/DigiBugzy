global using DigiBugzy.Data.Common.xBaseObjects.FilterObjects;

namespace DigiBugzy.Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            LoadAdministrations();
        }

        public void LoadAdministrations()
        {
            using (var service = new DigiAdminService(Globals.GetConnectionString(Globals.ConnectionEnvironment)))
            {
                if (service == null) return;

                var collection = service.Get(new StandardFilter
                {
                    IncludeDeleted = false,
                    IncludeInActive = false,
                });

                cmbAdministrations.DataSource = collection;
            }

        }
    }
}