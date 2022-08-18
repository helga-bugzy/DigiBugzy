﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DigiBugzy.Core.Domain.Products;
using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Core.Helpers;
using DigiBugzy.Core.ViewModels.Administration;
using DigiBugzy.Core.ViewModels.Catalog;
using DigiBugzy.Desktop.Administration.CustomFields;
using DigiBugzy.Services.HelperClasses;
using DigiBugzy.Services.SampleData;

namespace DigiBugzy.Desktop.Products
{
    public partial class ProductsManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        public Product SelectedProduct { get; set; } = new();

        public ProductGridViewModel SelectedProductModel { get; set; } = new();

        public List<Product> FilteredProducts { get; set; } = new();

        private List<MappingViewModel> LoadingCategories { get; set; } = new();

        private List<MappingViewModel> LoadingFields { get; set; } = new();

        private bool _isLoading;

        private int _currentProductRowHandle { get; set; }

        #endregion

        public ProductsManager()
        {
            _isLoading = true;

            InitializeComponent();

            LoadFilterCategories();

            LoadFilter(true);

            _isLoading = false;
        }

        #region Helper Methods

        #region Loading

        private void LoadFilterCategories()
        {
            cmbFilterCategories.DataSource = null;
            cmbFilterCategories.Items.Clear();

            using var categoryService = new CategoryService(Globals.GetConnectionString());
            var collection = categoryService.Get(new StandardFilter{ClassificationId = (int)ClassificationsEnum.Product}).OrderBy(c => c.Name).ToList();

            var viewModels = ViewModelMappings.CreateCategoryComboItems(collection);
            viewModels.Insert(0, new CategoryComboViewModel { Id = 0, Name = "<Select a category>" });

            cmbFilterCategories.DataSource = viewModels;
            cmbFilterCategories.DisplayMember = "Name";
            cmbFilterCategories.ValueMember = "Id";

            cmbFilterCategories.SelectedIndex = -1;

            Application.DoEvents();
        }
        

        private void LoadFilter(bool clearSelectedProduct)
        {
           // UseWaitCursor = true;

            var filter = new StandardFilter(
                includeInActive: chkFilterInactive.Checked,
                includeDeleted: chkFilterDeleted.Checked);

            if(cmbFilterCategories.SelectedIndex > 0)
            {
                var cat = (CategoryComboViewModel)cmbFilterCategories.SelectedItem;
                filter.CategoryId = cat.Id;
            }

            //Bind the products to the grid
            
            using var service = new ProductService(Globals.GetConnectionString());
            var viewModels = ViewModelMappings.ConvertProductToView(service.Get(filter, loadProductComplete: true), Globals.GetConnectionString(), true);
            bsProductsListing.DataSource = viewModels;
            gvProducts.DataController.AllowIEnumerableDetails = true;
            gridListing.DataSource = bsProductsListing;

            var gridFormatRule = new GridFormatRule();
            var formatConditionRuleValue = new FormatConditionRuleValue();
            gridFormatRule.Column = gvProducts.Columns["IsActive"];
            formatConditionRuleValue.PredefinedName = "Grey Text";
            formatConditionRuleValue.Condition = FormatCondition.Equal;
            formatConditionRuleValue.Value1 = false;
            gridFormatRule.ApplyToRow = true;
            gvProducts.FormatRules.Add(gridFormatRule);

            gvProducts.CollapseAllDetails();
            gvProducts.BestFitColumns();
            



            LoadSelectedProduct();

            if (!_isLoading) UseWaitCursor = false;
        }

        private void LoadSelectedProduct()
        {
            try
            {
                if (SelectedProductModel.Id == SelectedProduct.Id) return;


                if (SelectedProductModel.Id == 0)
                {
                    SelectedProduct = new Product();
                }
                else
                {
                    using var service = new ProductService(Globals.GetConnectionString());
                    SelectedProduct = service.GetById(SelectedProductModel.Id, true);
                }

                LoadEditor();
                LoadCategoriesSelector();
                LoadCustomFieldsSelector();

                LoadDocumentsTab();

                LoadStockInformation();

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
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
           ClearCustomFieldControls();

           using var productCustomFieldService = new ProductCustomFieldService(Globals.GetConnectionString());
           LoadingFields = productCustomFieldService.GetMappingViewModels(SelectedProduct.Id);

            var top = 0;

            foreach (var field in LoadingFields)
            {
                var citem = new CustomFieldItem(mappingType:SampleDataTypeEnum.Products, customField: field)
                {
                    CustomField = field,
                    Tag = Name = field.Id.ToString(),
                    Dock = DockStyle.None,
                    Location = new Point(0, top)
            };
            top += citem.Bounds.Height;

            pnlCustomFieldsList.Controls.Add(citem);
                
            }
        }

        private void ClearCustomFieldControls()
        {
            for (var i = 0; i < pnlCustomFieldsList.Controls.Count + 10; i++)
            {
                foreach (UserControl control in pnlCustomFieldsList.Controls)
                {
                    if (control != null)
                    {
                        pnlCustomFieldsList.Controls.Remove(control);
                    }

                }

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
            LoadSelectedProduct();
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

      
        private void gvProducts_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            var view = (GridView)e.View;
            view.Columns["Id"].Visible = false;
            view.Columns["ParentId"].Visible = false;
            view.Columns["ParentName"].Visible = false;

            view.FocusedRowChanged += View_FocusedRowChanged;
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var gridView = sender as GridView;
            SelectedProductModel = (ProductGridViewModel)gridView?.GetRow(gridView.FocusedRowHandle)!;
            LoadSelectedProduct();
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

            LoadCustomFieldsSelector();
            Application.DoEvents();
        }


        #endregion

        #endregion

        #endregion

        
    }
}