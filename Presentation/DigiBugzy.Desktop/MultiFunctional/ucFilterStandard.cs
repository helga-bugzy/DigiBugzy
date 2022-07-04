global using DigiBugzy.Core.Domain.Administration.Classifications;
global using System.Windows.Forms;
global using DigiBugzy.Core.Domain.Administration.Categories;

namespace DigiBugzy.Desktop.MultiFunctional
{
    public partial class ucFilterStandard : UserControl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>")]

        #region Delegates & Events

        public delegate void OnFilterDelegate(StandardFilter filter);
        public event OnFilterDelegate OnFilter;

        #endregion

        #region Properties
        #pragma warning disable CS8604 // Possible null reference argument.
        
        private int SelectedClassificationId =>
                    cmbClassification == null ? 0 :
                        cmbClassification.SelectedValue == null ? 0 :
                        int.Parse(cmbClassification.SelectedValue.ToString());

        
        private int SelectedCategoryId =>
                cmbCategory == null ? 0 :
                    cmbCategory.SelectedValue == null ? 0 :
                    int.Parse(cmbCategory.SelectedValue.ToString());

       #pragma warning restore CS8604 // Possible null reference argument.


        #endregion

        #region Ctor

        public ucFilterStandard()
        {
            InitializeComponent();

            LoadClassifications();
        }

        #endregion

        #region Data Loading

        private void LoadClassifications()
        {
            using (var service = new ClassificationService(Globals.GetConnectionString()))
            {                
                cmbClassification.DataSource = service.Get(new StandardFilter() 
                { 
                    DigiAdminId = Globals.DigiAdministration.Id
                });
                cmbClassification.ValueMember = nameof(Classification.Id);
                cmbClassification.DisplayMember = nameof(Classification.Name);
            }

            Application.DoEvents();
            
        }

        private void LoadCategories()
        {
            if(SelectedClassificationId > 0)
            {
                cmbCategory.Enabled = true;
                using (var service = new CategoryService(Globals.GetConnectionString()))
                {
                    cmbCategory.DataSource = service.Get(new StandardFilter()
                    {
                        DigiAdminId = Globals.DigiAdministration.Id,
                        ClassificationId = SelectedClassificationId
                    });
                    cmbCategory.ValueMember = nameof(Category.Id);
                    cmbCategory.DisplayMember = nameof(Category.Name);
                }

            }
            else
            {
                cmbCategory.Enabled = false;
            }

            Application.DoEvents();
        }

        #endregion

        #region Control Event Procedure(s)

        private void cmbClassification_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadCategories();
        }

        private void btnFilter_Click(object sender, System.EventArgs e)
        {
            OnFilter?.Invoke(CreateFilter());
        }

        #endregion

        #region Helper Methods

        private StandardFilter CreateFilter() => new()
        {
            IncludeDeleted = chkIncludeDeleted.Checked,
            IncludeInActive = chkIncludeInactive.Checked,
            LikeSearch = chkLikeSearch.Checked,
            Name = txtName.Text.Trim(),
            Description = txtDescription.Text.Trim(),
            DigiAdminId = Globals.DigiAdministration.Id,
            ClassificationId = SelectedClassificationId,
            CategoryId = SelectedCategoryId
        };

        #endregion



    }
}
