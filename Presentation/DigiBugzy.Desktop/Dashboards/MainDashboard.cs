
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
          
            using var frm = new CategoriesManager();
            frm.ShowDialog();


        }

        private void mnuCustomFields_Click(object sender, EventArgs e)
        {

            using var frm = new CustomFieldsManager();
            frm.ShowDialog();
        }
    }
}
