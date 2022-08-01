using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DigiBugzy.Core.Domain.Products;
using DigiBugzy.Core.Utilities;

namespace DigiBugzy.Desktop.Products
{
    public partial class ProductsManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        public Product SelectedProduct { get; set; } = new();

        public List<Product> FilteredProducts { get; set; } = new();

        #endregion

        public ProductsManager()
        {
            InitializeComponent();
        }

        #region Helper Methods

        #region Loading

        private void LoadFilter(bool clearSelectedProduct)
        {
            
            var filter = new StandardFilter(includeInActive: chkFilterInactive.Checked,
                includeDeleted: chkFilterDeleted.Checked);

            using var service = new ProductService(Globals.GetConnectionString());
            FilteredProducts = service.Get(filter);

            gridListing.DataSource = FilteredProducts;
            gvProducts.Columns["Id"].Visible = false;
            gvProducts.Columns["DigiAdminId"].Visible = false;
            gvProducts.Columns["DigiAdmin"].Visible = false;

            LoadSelectedProduct(clearSelectedProduct ? 0 : SelectedProduct.Id);
        }

        private void LoadSelectedProduct(int productId)
        {
            //Do nothing if the same
            if (productId == SelectedProduct.Id) return;


            if (productId == 0)
            {
                SelectedProduct = new Product();
            }
            else
            {
                using var service = new ProductService(Globals.GetConnectionString());
                SelectedProduct = service.GetById(productId);
            }

            LoadCustomFieldsSelector();
            LoadCategoriesSelector();
            LoadDocumentsTab();
            LoadEditor();
            LoadStockInformation();

            Application.DoEvents();
        }

        private void LoadEditor()
        {
            if (SelectedProduct.Id <= 0)
            {
                btnDelete.Visible = btnRestore.Visible = false;
                chkActive.Checked = true;
                lblSelectedFileName.Text = txtName.Text = txtDescription.Text = string.Empty;
                imgProductPhoto.Visible = false;

            }
            else
            {
                btnDelete.Visible = !SelectedProduct.IsDeleted;
                btnRestore.Visible = SelectedProduct.IsDeleted;

                chkActive.Checked = SelectedProduct.IsActive;
                txtName.Text = SelectedProduct.Name;
                txtDescription.Text = SelectedProduct.Description;

                if (SelectedProduct.ProductImage == null || SelectedProduct.ProductImage.Length <= 0)
                {
                    imgProductPhoto.Visible = false;
                    lblSelectedFileName.Text = string.Empty;
                    return;
                }

                imgProductPhoto.Image = DigiUtilities.GetImageFromByteArray(SelectedProduct.ProductImage);
            }
        }

        private void LoadCategoriesSelector()
        {

        }

        private void LoadCustomFieldsSelector()
        {

        }

        private void LoadDocumentsTab()
        {

        }

        private void LoadStockInformation()
        {

        }

        #endregion

        #region Saving

        private void SaveProduct()
        {
            SelectedProduct.Name = txtName.Text;
            SelectedProduct.Description = txtDescription.Text;
            SelectedProduct.IsActive = chkActive.Checked;
            

            if (openFileProductImage.FileName != null)
            {
                SelectedProduct.ProductImage = DigiUtilities.CopyImageToByteArray(imgProductPhoto.Image);
            }

            using var service = new ProductService(Globals.GetConnectionString());
            if (SelectedProduct.Id > 0)
            {
                service.Update(SelectedProduct);
            }
            else
            {
                SelectedProduct.DigiAdminId = Globals.DigiAdministration.Id;
                SelectedProduct.IsDeleted = false;
                SelectedProduct.CreatedOn = DateTime.Now;
                SelectedProduct.Id = service.Create(SelectedProduct);
            }

            LoadFilter(false);

        }

        #endregion

        #endregion



        #region Control Event Procedures

        #region Filter

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadFilter(true);
        }

        private void cmbFilterCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFilter(true);
        }

        private void chkFilterInactive_CheckedChanged(object sender, EventArgs e)
        {
            LoadFilter(true);
        }

        private void chkFilterDeleted_CheckedChanged(object sender, EventArgs e)
        {
            LoadFilter(true);
        }

        private void chkFilterLikeSearch_CheckedChanged(object sender, EventArgs e)
        {
            LoadFilter(true);
        }

        private void txtFilterName_Leave(object sender, EventArgs e)
        {
            LoadFilter(true);
        }

        #endregion


        #region Product Editor

        private void btnProductImage_Click(object sender, EventArgs e)
        {
            if (openFileProductImage.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openFileProductImage.FileName))
                {
                    lblSelectedFileName.Text = openFileProductImage.FileName;
                    imgProductPhoto.Image = new Bitmap(openFileProductImage.FileName);
                    imgProductPhoto.Visible = true;
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            LoadSelectedProduct(0);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (SelectedProduct.Id <= 0) return;

            SelectedProduct.IsDeleted = false;
            SelectedProduct.IsActive = true;

            using var service = new ProductService(Globals.GetConnectionString());
            service.Update(SelectedProduct);

            LoadFilter(false);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }




        #endregion

        #region Grid View


        #endregion

        #endregion

        
    }
}