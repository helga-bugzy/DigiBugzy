using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DigiBugzy.Core.Constants;
using DigiBugzy.Desktop.Administration.Categories;
using DigiBugzy.Desktop.Administration.CustomFields;
using DigiBugzy.Desktop.MultiFunctional;
using DigiBugzy.Desktop.Products;
using DigiBugzy.Desktop.Projects;

namespace DigiBugzy.Desktop.Dashboards
{
    public partial class BugzyDashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Properties

        private XtraForm _childForm { get; set; } = new();
        private PageSplashScreen _splash { get; set; } = new();

        private DashChild home = new DashChild();

        #endregion

        #region Ctor

        public BugzyDashboard()
        {
            InitializeComponent();
            ShowChildForm(new DashChild(), "Home");
            
            ShowChildForm(home, "Home");
            home.passControl = HomeActions;
        }

        private void HomeActions(string? option, string? section)
        {
            switch (section)
            {
                case EventStringConstants.Options.Products:
                    if (option != null && option.Contains(EventStringConstants.Sections.Manage))
                    {
                        ShowChildForm(new ProductsManager(), "Products Management");
                    }
                    else if (option != null && option.Contains(EventStringConstants.Sections.Categories))
                    {
                        ShowChildForm(new CategoriesManager((int)ClassificationsEnum.Product), "Product Categories Management");
                    }
                    else if(option != null && option.Contains(EventStringConstants.Sections.CustomFields))
                    {
                        ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Product), "Product Custom Fields Management");
                    }
                    break;
                case EventStringConstants.Options.Projects:
                    if (option != null && option.Contains(EventStringConstants.Sections.Manage))
                    {
                        ShowChildForm(new ProjectsManager(), "Projects Management");
                    }
                    else if (option != null && option.Contains(EventStringConstants.Sections.Categories))
                    {
                        ShowChildForm(new CategoriesManager((int)ClassificationsEnum.Project), "Project Categories Management");
                    }
                    else if (option != null && option.Contains(EventStringConstants.Sections.CustomFields))
                    {
                        ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Project), "Project Custom Fields Management");
                    }
                    break;

            }
        }



        #endregion


        #region Control Event Produdure(s)

        #region Administration

        private void btnCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CategoriesManager(), "Categories Management");
        }


        private void bandCustomFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager(0), "Custom Fields Management");
        }

        #endregion

        #region Catalog

        private void btnProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            ShowChildForm(new ProductsManager(), "Products Management");
        }

        private void btnProductsCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CategoriesManager((int)ClassificationsEnum.Product), "Product Categories Management");
        }

        private void btnProductsFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Product), "Product Custom Fields Management");
        }

        private void btnProjects_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new ProjectsManager(), "Projects Management");
        }

        private void btnProjectsCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CategoriesManager((int)ClassificationsEnum.Project), "Project Categories Management");
        }

        private void btnProjectsFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Project), "Project Custom Fields Management");
        }

        private void btnProjectsFields_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ShowChildForm(new CustomFieldsManager((int)ClassificationsEnum.Project), "Project Management");
        }

        #endregion


        #endregion


        #region Helper Forms

        private void ShowChildForm(XtraForm childForm, string title)
        {
            UseWaitCursor = true;

            _childForm = childForm;

            if (_splash.IsDisposed) _splash = new PageSplashScreen();
            _splash.Title = title;
            _splash.Show();
            Application.DoEvents();

            timer1.Start();
                
        }


        #endregion


       

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //Load & Show page
            _childForm.MdiParent = this;
            _childForm.Show();

            //Hide splasher
            if(_splash.IsDisposed is false)
                _splash.Close();
            Application.DoEvents();

            UseWaitCursor = false;
        }
    }
}