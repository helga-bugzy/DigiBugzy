
using System.Windows.Forms;
using DigiBugzy.Desktop.Administration.Categories;
using DigiBugzy.Desktop.Administration.CustomFields;

namespace DigiBugzy.Desktop.Dashboards
{
    public partial class MainDashboard : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void mnuCategories_Click(object sender, EventArgs e)
        {
            var categories = Startup.GetForm<CategoriesManager>();
            categories?.Show();
        }

        private void mnuCustomFields_Click(object sender, EventArgs e)
        {
            var form = Startup.GetForm<CustomFieldsManager>();
            form?.Show();
        }
    }
}
