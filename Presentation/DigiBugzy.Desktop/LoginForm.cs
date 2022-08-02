global using DigiBugzy.Data.Common.xBaseObjects.FilterObjects;
global using DigiBugzy.Core.Domain.Administration.DigiAdmins;
global using System;

namespace DigiBugzy.Desktop
{
    public partial class LoginForm : Form
    {
        private int SelectedAdminId { get
            {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CA1305 // Specify IFormatProvider
                if (cmbAdministrations == null || cmbAdministrations.SelectedValue == null) return 0;
                else return int.Parse(cmbAdministrations.SelectedValue.ToString());
#pragma warning restore CA1305 // Specify IFormatProvider
#pragma warning restore CS8604 // Possible null reference argument.
            } }

        public LoginForm()
        {
            InitializeComponent();

            LoadAdministrations();
        }

        public void LoadAdministrations()
        {
            using var service = new DigiAdminService(Globals.GetConnectionString());

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
                MessageBox.Show(@"Please select a valid administration");
                return;
            }
            else
            {
                using var service = new DigiAdminService(Globals.GetConnectionString());
                Globals.DigiAdministration = service.GetById(SelectedAdminId);

                Globals.Settings.Refresh();

                using var dash = new BugzyDashboard();
                dash.ShowDialog();
            }
        }

        #endregion
    }
}