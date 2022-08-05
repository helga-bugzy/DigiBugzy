﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DigiBugzy.Core.Domain.Products;
using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Core.Helpers;
using DigiBugzy.Desktop.Administration.CustomFields;
using DigiBugzy.Services.HelperClasses;
using DigiBugzy.Services.SampleData;

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
            var viewModels = ViewModelMappings.ConvertProductToView(service.Get(filter, loadProductComplete: true), Globals.GetConnectionString(), true);

            gridListing.DataSource = viewModels;
            //gvProducts.Columns["Id"].Visible = false;
            //gvProducts.Columns["ParentId"].Visible = false;
            //gvProducts.Columns["ParentName"].Visible = false;

            foreach (GridView view in gridListing.ViewCollection)
            {
                view.Columns["Id"].Visible = false;
                view.Columns["ParentId"].Visible = false;
                view.Columns["ParentName"].Visible = false;

            }

//            foreach(var row in gvProducts.ro)

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
                SelectedProduct = service.GetById(productId, true);
            }

            LoadEditor();
            LoadCategoriesSelector();
            LoadCustomFieldsSelector();
           
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

                imgProductPhoto.Image = ImageHelpers.GetImageFromByteArray(SelectedProduct.ProductImage);
            }
        }

        private void LoadCategoriesSelector()
        {
            using var service = new ProductCategoryService(Globals.GetConnectionString());
            LoadingCategories = (List<MappingViewModel>)service.GetMappingViewModels(SelectedProduct.Id);
            treeCategories.Nodes.Clear();

            var parents = LoadingCategories.Where(x => x.ParentId is null).ToList();
            foreach (var parent in parents)
            {
                var node = new TreeNode
                {
                    Text = parent.Name,
                    Tag = parent.EntityMappedToId,
                    Checked = parent.IsMapped
                };
                

                LoadCategoryNodes(node, parent.EntityMappedToId);

                node.Text = $@"{parent.Name} ({node.Nodes.Count} subs)";
                treeCategories.Nodes.Add(node);
            }


        }

        private void LoadCategoryNodes(TreeNode? parentNode, int parentId)
        {
            using var productCategoryService = new ProductCategoryService(Globals.GetConnectionString());
            LoadingCategories = (List<MappingViewModel>)productCategoryService.GetMappingViewModels(SelectedProduct.Id);

            if (parentNode == null) return;

            var children = LoadingCategories
                .Where(c => c.ParentId == parentId)
               
                .ToList();

            if (children.Count > 0)
            {

                foreach (var child in children)
                {
                    var node = new TreeNode(text: child.Name)
                    {
                        Tag = child.EntityMappedToId,
                        Checked = child.IsMapped
                    };

                    parentNode.Nodes.Add(node);

                    //LoadCategoryNodes(node, child.EntityMappedToId);
                }
            }
            
           
        }

        private void LoadCustomFieldsSelector()
        {
           

            using var productCustomFieldService = new ProductCustomFieldService(Globals.GetConnectionString());
            LoadingFields = productCustomFieldService.GetMappingViewModels(SelectedProduct.Id);

            var top = 0;

            foreach (var field in LoadingFields)
            {
                var citem = new CustomFieldItem();
                citem.CustomField = field;
                citem.Tag = citem.Name = field.Id.ToString();
                citem.Dock = DockStyle.None;
                citem.Location = new Point(0, top);
               
                top += citem.Bounds.Height;


                pnlCustomFieldsList.Controls.Add(citem);
                
            }
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
            

            if (imgProductPhoto.Image != null)
            {
                SelectedProduct.ProductImage = ImageHelpers.CopyImageToByteArray(imgProductPhoto.Image);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion

        #region Sample Data

        private void btnSampleData_Click(object sender, EventArgs e)
        {

            using var service = new SampleDataService(
                connectionString: Globals.GetConnectionString(),
                sampleDataType: SampleDataTypeEnum.Products,
                classificationId: (int)ClassificationsEnum.Product,
                digiAdminId: Globals.DigiAdministration.Id);
            service.CreateSampleData();

           

            LoadFilter(true);

            Application.DoEvents();
        }

       
        private void btnSampleDataDelete_Click(object sender, EventArgs e)
        {
            using var service = new SampleDataService(
                connectionString: Globals.GetConnectionString(),
                sampleDataType: SampleDataTypeEnum.Products,
                classificationId: (int)ClassificationsEnum.Product,
                digiAdminId: Globals.DigiAdministration.Id);
            service.DeleteSampleData();

            using var productService = new ProductService(Globals.GetConnectionString());
            var collection = productService.Get(new StandardFilter { Name = "Sample", LikeSearch = true });
            foreach (var item in collection)
            {
                productService.Delete(item.Id, true);
            }

            LoadFilter(true);

            Application.DoEvents();
        }

        #endregion

        #region Product Editor

        private void btnProductImage_Click(object sender, EventArgs e)
        {
            if (openFileProductImage.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(openFileProductImage.FileName)) return;

            lblSelectedFileName.Text = openFileProductImage.FileName;
            imgProductPhoto.Image = ImageHelpers.ResizeImage(new Bitmap(openFileProductImage.FileName),
                Globals.Settings.ProductSettings!.ImageWidth, Globals.Settings.ProductSettings.ImageHeight);
            imgProductPhoto.Visible = true;
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

      
        private void gridListing_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            var view = (GridView)e.View;
            view.Columns["Id"].Visible = false;
            view.Columns["ParentId"].Visible = false;
            view.Columns["ParentName"].Visible = false;
        }

        private void gvProducts_Click(object sender, EventArgs e)
        {

        }


        private void gvProducts_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (gvProducts?.GetRowCellValue(e.RowHandle, "Id") == null) return;
                var ok = int.TryParse(gvProducts.GetRowCellValue(e.RowHandle, "Id").ToString()!, out _);
                if(ok)
                    LoadSelectedProduct(int.Parse(gvProducts.GetRowCellValue(e.RowHandle, "Id").ToString()!));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void gvProducts_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var row = gvProducts.GetRowCellValue(e.RowHandle, "Id");
            if (row != null)
            {
                LoadSelectedProduct(int.Parse(row.ToString()!));
            }
        }
        #endregion

        #region Treeview

        #region Categories

        private void treeCategories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var service = new ProductCategoryService(Globals.GetConnectionString());
            service.HandleCategoryMapping(
                categoryId: int.Parse(e.Node!.Tag.ToString()!), 
                productId: SelectedProduct.Id, 
                isMapped: e.Node.Checked,
                digiAdminId: Globals.DigiAdministration.Id);
        }




        #endregion

        #endregion

        #endregion

       
    }
}