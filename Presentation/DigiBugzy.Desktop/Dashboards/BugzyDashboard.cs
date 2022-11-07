using System.Drawing;
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

        private XtraForm ChildForm { get; set; } = new();
        private PageSplashScreen Splash { get; set; } = new();

        private readonly DashChild _home = new DashChild();

        #endregion

        #region Ctor

        public BugzyDashboard()
        {
            InitializeComponent();

            ImplementEnvironment();

            ShowChildForm(new DashChild(), "Home");
            
            ShowChildForm(_home, "Home");
            _home.passControl = HomeActions;
        }

        private void ImplementEnvironment()
        {
            if(Globals.ConnectionEnvironment == ConnectionEnvironment.Production)
            {
                ribbon.ApplicationCaption = "DigiBugzy Management Application (PRODUCTION)";
                statusStrip1.BackColor = Color.DarkRed;
                statusStrip1.ForeColor = Color.White;
                statusStrip1.Text = "!!!!!PRODUCTION ENVIRONMENT!!!!!";
                
            }
            else
            {
                ribbon.ApplicationCaption = "DigiBugzy Management Application (DEVELOPMENT)";
                
            }

            Application.DoEvents();
        }

        /// <inheritdoc />
        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
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
            try
            {
                UseWaitCursor = true;

                ChildForm = childForm;

                if (Splash.IsDisposed) Splash = new PageSplashScreen();
                Splash.Title = title;
                Splash.Show();
                Application.DoEvents();

                timer1.Start();
            }
            catch (Exception)
            {
                //do nothing
            }
                
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                //Load & Show page
                ChildForm.MdiParent = this;
                ChildForm.Show();

                //Hide splasher
                if (Splash.IsDisposed is false)
                    Splash.Close();
                Application.DoEvents();

                UseWaitCursor = false;
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        private void BugzyDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}