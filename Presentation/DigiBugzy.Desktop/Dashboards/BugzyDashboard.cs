using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DigiBugzy.Desktop.Administration.Categories;
using DigiBugzy.Desktop.Administration.CustomFields;
using DigiBugzy.Desktop.Products;

namespace DigiBugzy.Desktop.Dashboards
{
    public partial class BugzyDashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public BugzyDashboard()
        {
            InitializeComponent();
        }



        #region Control Event Produdure(s)

        #region Administration

        private void btnCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CategoriesManager());
        }


        private void bandCustomFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager(0));
        }

        #endregion

        #region Catalog

        private void btnProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new ProductsManager());
        }

        private void btnProductsCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CategoriesManager((int)ClassificationsEnum.Product));
        }

        private void btnProductsFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Product));
        }

        private void btnProjects_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new ProductsManager());
        }

        private void btnProjectsCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CategoriesManager((int)ClassificationsEnum.Project));
        }

        private void btnProjectsFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Project));
        }

        #endregion


        #endregion

        
        #region Helper Forms

        private void ShowChildForm(XtraForm childForm)
        {
            
            childForm.MdiParent = this;
            childForm.Show();
                
        }


        #endregion

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Product));
        }

        private void btnProjectsFields_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Project));
        }
    }
}