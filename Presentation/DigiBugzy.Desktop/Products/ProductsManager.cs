using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DigiBugzy.Core.Domain.Products;
using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Core.Utilities;

namespace DigiBugzy.Desktop.Products
{
    public partial class ProductsManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        public Product SelectedProduct { get; set; } = new();

        public List<Product> FilteredProducts { get; set; } = new();

        private List<MappingViewModel> LoadingCategories { get; set; } = new();

        private List<MappingViewModel> LoadingFields { get; set; } = new();

        #endregion

        public ProductsManager()
        {
            InitializeComponent();

            LoadFilter(true);
        }

        #region Helper Methods

        #region Loading

        private void LoadFilter(bool clearSelectedProduct)
        {
            
            var filter = new StandardFilter(includeInActive: chkFilterInactive.Checked,
                includeDeleted: chkFilterDeleted.Checked);

            using var service = new ProductService(Globals.GetConnectionString());
            FilteredProducts = service.Get(filter,loadProductComplete:true);

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

            LoadEditor();
            LoadCustomFieldsSelector();
            LoadCategoriesSelector();
            LoadDocumentsTab();
            
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

                if (SelectedProduct.ProductImage is not { Length: > 0 })
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
            using var service = new ProductService(Globals.GetConnectionString());
            LoadingCategories = service.GetCategoryMappings(SelectedProduct.Id, (int)ClassificationsEnum.Product);
            treeCategories.Nodes.Clear();

            var parents = LoadingCategories.Where(x => x.ParentId.HasValue && x.ParentId.Value > 0).ToList();
            foreach (var parent in parents)
            {
                var node = new TreeNode
                {
                    Text = parent.Name,
                    Tag = parent.Id
                };

                LoadCategoryNodes(node);

                node.Text = $@"{parent.Name} ({node.Nodes.Count} subs)";
                treeCategories.Nodes.Add(node);
            }


        }

        private void LoadCategoryNodes(TreeNode? parentNode)
        {
            if (parentNode == null) return;
            var children = LoadingCategories
                .Where(c => c.ParentId == int.Parse(parentNode.Tag.ToString()!))
                .Select(c => new Category
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    IsDeleted = c.IsDeleted
                })
                .ToList();

            if (children.Count <= 0) return;
            foreach (var node in children.Select(child => new TreeNode(text: child.Name)
                     {
                         Tag = child.Id
                     }))
            {
                parentNode.Nodes.Add(node);

                LoadCategoryNodes(node);
            }
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
        private void gvProducts_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            LoadSelectedProduct(int.Parse(gvProducts.GetRowCellValue(e.RowHandle, "Id").ToString()!));
        }

        #endregion

        #endregion


    }
}