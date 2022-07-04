global using DigiBugzy.Data.Common.xBaseObjects.FilterObjects;
global using DigiBugzy.Core.Domain.Administration.DigiAdmins;

namespace DigiBugzy.Desktop
{
    public partial class LoginForm : Form
    {
        private int SelectedAdminId { get
            {
                if (cmbAdministrations == null || cmbAdministrations.SelectedValue == null) return 0;
                else return int.Parse(cmbAdministrations.SelectedValue.ToString());
            } }

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
                cmbAdministrations.DisplayMember = nameof(DigiAdmin.Name);
                cmbAdministrations.ValueMember = nameof(DigiAdmin.Id);
                

                if(collection.Count == 1)
                {
                    cmbAdministrations.SelectedValue = collection[0].Id;
                    cmbAdministrations.SelectedText = collection[0].Name;

                    SelectAdministration();
                }
            }

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            SelectAdministration();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Helper Methods

        private void SelectAdministration()
        {
            if (SelectedAdminId <= 0)
            {
                MessageBox.Show("Please select a valid administration");
                return;
            }
            else
            {
                using (var service = new DigiAdminService(Globals.GetConnectionString(Globals.ConnectionEnvironment)))
                {
                    Globals.DigiAdministration = service.GetById(SelectedAdminId);
                }

                using (var dashboard = Startup.GetForm<MainDashboard>())
                {
                    if (dashboard != null)
                    {
                        dashboard.ShowDialog();
                      //  Close();
                    }
                    else
                    {
                        MessageBox.Show("Could not find/load the dashboard");
                    }
                }
            }
        }

        #endregion
    }
}