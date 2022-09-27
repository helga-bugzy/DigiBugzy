using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
using DigiBugzy.Services.Catalog.Stock;
using DigiBugzy.Services.HelperClasses;
using DigiBugzy.Services.SampleData;
using static System.Double;

namespace DigiBugzy.Desktop.Products
{
    public partial class ProductsManager : XtraForm
    {
        #region Properties

        public Product SelectedProduct { get; set; } = new();

        public ProductGridViewModel SelectedProductModel { get; set; } = new();

        public StockJournalViewModel SelectedStockJournalModel { get; set; } = new();

        public StockJournal SelectedStockJournal { get; set; } = new();

        private List<MappingViewModel> LoadingCategories { get; set; } = new();

        private List<MappingViewModel> LoadingFields { get; set; } = new();

        private readonly bool _isLoading;

        private bool _isInStockAddNew = false;

        private bool _isInProductAddNew = false;

        #endregion

        #region Ctor

        public ProductsManager()
        {
            _isLoading = true;
            
            InitializeComponent();

            ApplySettings();

            LoadFilterCategories();

            LoadFilter();

            _isLoading = false;
        }

        #endregion

        #region Helper Methods

        #region Loading

        #region Products

        private void ApplySettings()
        {
            btnSampleData.Visible = btnSampleDataDelete.Visible = Globals.ConnectionEnvironment == ConnectionEnvironment.Development;
        }

        private void LoadFilter()
        {
            try
            {
                // UseWaitCursor = true;
                
                var filter = new StandardFilter(
                    includeInActive: chkFilterInactive.Checked,
                    includeDeleted: chkFilterDeleted.Checked);

                if (cmbFilterCategories.SelectedIndex > 0)
                {
                    var cat = (CategoryComboViewModel)cmbFilterCategories.SelectedItem;
                    filter.CategoryId = cat.Id;
                }

                //Bind the products to the grid
                bsProductsListing.Clear();

                using var service = new ProductService(Globals.GetConnectionString());
                var viewModels = ViewModelMappings.ConvertProductToView(service.Get(filter, loadProductComplete: true), Globals.GetConnectionString(), false);
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

                gvProducts.Columns[nameof(ProductGridViewModel.Id)].Visible = false;
                gvProducts.Columns[nameof(ProductGridViewModel.ParentId)].Visible = false;
                gvProducts.Columns[nameof(ProductGridViewModel.ParentName)].Visible = false;

                gvProducts.Columns[nameof(ProductGridViewModel.Image)].Width = 15;
                //gvProducts.BestFitColumns();
                
                LoadSelectedProduct();


            }
            finally
            {
                if (!_isLoading) UseWaitCursor = false;
            }
        }

        private void LoadSelectedProduct()
        {
            switch (SelectedProductModel.Id)
            {
                case > 0 when SelectedProductModel.Id == SelectedProduct.Id:
                    return;
                case 0:
                    SelectedProduct = new Product();
                    break;
                default:
                {
                    using var service = new ProductService(Globals.GetConnectionString());
                    SelectedProduct = service.GetById(SelectedProductModel.Id, true);
                    break;
                }
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

            txtProductEditor_Quantity.Enabled = false;
            txtEditorPrice.Enabled = false;
            if (SelectedProduct.Id <= 0)
            {
                lblEditorPrice.Visible = lblQuantity.Visible = txtEditorPrice.Visible = txtProductEditor_Quantity.Enabled = true;
                btnDelete.Visible = btnRestore.Visible = false;
                chkEditorActive.Checked = true;
                lblSelectedFileName.Text = txtEditorName.Text = txtEditorDescription.Text =  txtEditorPrice.Text = txtProductEditor_Quantity.Text = string.Empty;
                
                imgProductPhoto.Visible = false;
                txtProductEditor_Quantity.Enabled = true;
                txtEditorPrice.Enabled = true;
            }
            else
            {
                lblEditorPrice.Visible = lblQuantity.Visible = txtEditorPrice.Visible = txtProductEditor_Quantity.Visible = false;
                btnDelete.Visible = !SelectedProduct.IsDeleted;
                btnRestore.Visible = SelectedProduct.IsDeleted;

                chkEditorActive.Checked = SelectedProduct.IsActive;
                txtEditorName.Text = SelectedProduct.Name;
                txtEditorDescription.Text = SelectedProduct.Description;

                if (SelectedProduct.ProductImage is not { Length: > 0 })
                {
                    imgProductPhoto.Visible = false;
                    lblSelectedFileName.Text = string.Empty;
                    return;
                }

                imgProductPhoto.Image = ImageHelpers.GetImageFromByteArray(SelectedProduct.ProductImage);
            }
        }

       

        #endregion
        
        #region Categories

        private void LoadFilterCategories()
        {
            cmbFilterCategories.DataSource = null;
            cmbFilterCategories.Items.Clear();

            using var categoryService = new CategoryService(Globals.GetConnectionString());
            var collection = categoryService.Get(new StandardFilter { ClassificationId = (int)ClassificationsEnum.Product }).OrderBy(c => c.Name).ToList();

            var viewModels = ViewModelMappings.CreateCategoryComboItems(collection);
            viewModels.Insert(0, new CategoryComboViewModel { Id = 0, Name = "<Select a category>" });

            cmbFilterCategories.DataSource = viewModels;
            cmbFilterCategories.DisplayMember = "Name";
            cmbFilterCategories.ValueMember = "Id";

            cmbFilterCategories.SelectedIndex = -1;

            Application.DoEvents();
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

                node.Text = $"{parent.Name} ({node.Nodes.Count} subs)";
                node.ExpandAll();
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

            if (children.Count <= 0) return;
            foreach (var node in children.Select(child => new TreeNode(text: child.Name)
                     {
                         Tag = child.EntityMappedToId,
                         Checked = child.IsMapped
                     }))
            {
                parentNode.Nodes.Add(node);
            }


        }

        #endregion

        #region Custom Fields

        private void LoadCustomFieldsSelector()
        {
            ClearCustomFieldControls();

            using var productCustomFieldService = new ProductCustomFieldService(Globals.GetConnectionString());
            LoadingFields = productCustomFieldService.GetMappingViewModels(SelectedProduct.Id);

            var top = 0;


            foreach (var citem in LoadingFields.Select(field => new CustomFieldItem(mappingType: SampleDataTypeEnum.Products, customField: field)
                     {
                         Tag = Name = field.Id.ToString(),
                         Dock = DockStyle.None,
                         Location = new Point(0, top)
                     }))
            {
                top += citem.Bounds.Height;

                pnlCustomFieldsList.Controls.Add(citem);

                pnlCustomFieldsList.BringToFront();
                pnlCustomFieldsList.Visible = true;
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

        #endregion

        #region Documents

        private void LoadDocumentsTab()
        {

        }

        #endregion
        
        #region Stock

        /// <summary>
        /// Bind stock to relevant grid control
        /// </summary>
        private void LoadStockInformation()
        {
            if (bsStockListing == null) return;
            if(SelectedProduct.Id <= 0)
            {
                bsStockListing.Clear();
                gridStock.DataSource = bsStockListing;
            }
            
            using var service = new StockJournalService(Globals.GetConnectionString());
            var collection = service.GetStockJournalViewModel(new StockJournalSelectOptions(SelectedProduct.Id));
            bsStockListing.Clear();
            bsStockListing.DataSource = collection;
            gvStock.DataController.AllowIEnumerableDetails = true;
            gridStock.DataSource = bsStockListing;
            

            if (gvStock.Columns[nameof(StockJournalViewModel.Id)] != null) gvStock.Columns[nameof(StockJournalViewModel.Id)].Visible = false;
            if (gvStock.Columns[nameof(StockJournalViewModel.ProductId)] != null) gvStock.Columns[nameof(StockJournalViewModel.ProductId)].Visible = false;
            if (gvStock.Columns[nameof(StockJournalViewModel.ProductId)] != null) gvStock.Columns[nameof(StockJournalViewModel.ProductName)].Visible = false;
            if (gvStock.Columns[nameof(StockJournalViewModel.ProjectSectionPartId)] != null) gvStock.Columns[nameof(StockJournal.ProjectSectionPartId)].Visible = false;
            if (gvStock.Columns[nameof(StockJournalViewModel.ProductId)] != null) gvStock.Columns[nameof(StockJournalViewModel.ProjectSectionPartName)].Visible = false;
            if (gvStock.Columns[nameof(StockJournalViewModel.SupplierId)] != null) gvStock.Columns[nameof(StockJournal.SupplierId)].Visible = false;
            if (gvStock.Columns[nameof(StockJournalViewModel.ProductId)] != null) gvStock.Columns[nameof(StockJournalViewModel.SupplierName)].Visible = false;

        }

      
        private void LoadStockJournalEditor()
        {
            txtStockJournal_Title.Enabled = txtStockJournal_Description.Enabled = txtStockJournal_Price.Enabled = txtStockJournal_Quantity.Enabled = txtStockJournal_Price.Enabled = false;
            radStockIn.Enabled = radStockOut.Enabled = false;
            txtStockJournal_Description.Text = txtStockJournal_Title.Text = txtStockJournal_Price.Text = txtStockJournal_Quantity.Text = string.Empty;
            btnStockAddNew.Enabled = btnStockReverse.Enabled = false;


            if (SelectedStockJournalModel.Id <= 0 || _isInStockAddNew)
            {
                radStockIn.Checked = true;
                radStockOut.Checked = false;
                btnStockReverse.Enabled = false;
                btnStockSave.Enabled = true;

                txtStockJournal_Title.Enabled = txtStockJournal_Description.Enabled = txtStockJournal_Price.Enabled = txtStockJournal_Quantity.Enabled = txtStockJournal_Price.Enabled = true;
                radStockIn.Enabled = radStockOut.Enabled = true;
            }
            else
            {
                
                btnStockAddNew.Enabled = true;
                btnStockSave.Enabled = false;                                   //can not change existing entry, must do new
                btnStockReverse.Enabled = CanReverseStockJournalEntry(SelectedStockJournal.Id);     
                txtStockJournal_Title.Text = SelectedStockJournal.Name;
                txtStockJournal_Description.Text = SelectedStockJournal.Description;
                txtStockJournal_Price.Text = SelectedStockJournal.Price.ToString(CultureInfo.InvariantCulture);
                txtStockJournal_Quantity.Text = SelectedStockJournalModel.QuantityIn > 0 ?
                    SelectedStockJournalModel.QuantityIn.ToString(CultureInfo.InvariantCulture) :
                    SelectedStockJournalModel.QuantityOut.ToString(CultureInfo.InvariantCulture);
                radStockIn.Checked = SelectedStockJournalModel.QuantityIn > 0;
                radStockOut.Checked = SelectedStockJournalModel.QuantityOut > 0;
            }
        }

        /// <summary>
        /// Validates if the stock journal entry can/may be reversed
        /// </summary>
        /// <param name="id">Journal entry to be validated</param>
        /// <returns></returns>
        private bool CanReverseStockJournalEntry(int id)
        {
            var service = new StockJournalService(Globals.GetConnectionString());
            return service.CanReverseJournal(id);
        }

        #endregion

        #endregion

        #region Saving

        private void SaveProduct()
        {
            SelectedProduct.Name = txtEditorName.Text;
            SelectedProduct.Description = txtEditorDescription.Text;
            SelectedProduct.IsActive = chkEditorActive.Checked;

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

                //Stock entry
                var stockJournalService = new StockJournalService(Globals.GetConnectionString());
                stockJournalService.Create(new StockJournal
                {
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    EntryDate = DateTime.Now,
                    DigiAdminId = Globals.DigiAdministration.Id,
                    Name = "Journal Entry",
                    Description = "Opening stock balance",
                    QuantityIn = Parse(txtProductEditor_Quantity.Text),
                    QuantityOnOrder = 0D,
                    QuantityOut = 0D,
                    QuantityReserved = 0D,
                    TotalInStock = 0D,
                    TotalValue = 0D,
                    ProductId = SelectedProduct.Id,
                    Price = Parse(txtProductEditor_Quantity.Text),
                    ProjectSectionPartId = null,
                    Supplier = null
                });
            }

            _isInProductAddNew = false;

            LoadFilter();

        }

        private void SaveJournalEntry()
        {
            //Validate = can not log out more than stock value (use reserve for that)
            var service = new StockJournalService(Globals.GetConnectionString());
            var lastEntry = service.GetLastEntry(SelectedProduct.Id);
            double currentStockInTotal = 0;
            double currentStockValue = 0;
            var journalQuantity = Parse(txtStockJournal_Quantity.EditValue?.ToString() ?? "0");
            var journalPrice = Parse(txtStockJournal_Price.EditValue?.ToString() ?? "0");

            if (lastEntry != null)
            {
                currentStockInTotal = lastEntry.TotalInStock;
                currentStockValue = lastEntry.TotalValue;
            }

            if (radStockOut.Checked)
            {
                if (journalQuantity > currentStockInTotal)
                {
                    MessageBox.Show($"Current stock total is {currentStockInTotal}. {Environment.NewLine}You can not book more out than the amount in stock.");
                    return;
                }

                if (journalQuantity * journalPrice > currentStockValue)
                {
                    MessageBox.Show($"Current stock value is {currentStockValue}. {Environment.NewLine}You can not book more ({journalQuantity * journalPrice}) out than the amount in stock.");
                    return;
                }
            }

            //All fine, now update
            var journal = new StockJournal
            {
                Name = txtStockJournal_Title.EditValue.ToString(),
                Price = Parse(txtStockJournal_Price.Text),
                Description = txtStockJournal_Description.EditValue.ToString(),
                QuantityIn = !radStockIn.Checked ? 0 : Parse(txtStockJournal_Quantity.EditValue?.ToString() ?? "0"),
                QuantityOut = !radStockOut.Checked ? 0 : Parse(txtStockJournal_Quantity.EditValue?.ToString() ?? "0"),
                DigiAdminId = Globals.DigiAdministration.Id,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ProductId = SelectedProduct.Id,
                IsReversed = false
            };

            service.Create(journal, lastEntry);
        }

        #endregion

        #endregion

        #region Control Event Procedures

        #region Stock

        private void bsStockListing_PositionChanged(object sender, EventArgs e)
        {
            if (sender is not BindingSource { Position: > -1 }) return;
            if (bsStockListing.Count <= 0) return;
            SelectedStockJournalModel = (StockJournalViewModel)bsStockListing.Current;
            using var service = new StockJournalService(Globals.GetConnectionString());
            SelectedStockJournal = service.GetById(SelectedStockJournalModel.Id);
            LoadStockJournalEditor();
        }

        private void btnStockAddNew_Click(object sender, EventArgs e)
        {
            SelectedStockJournal = new StockJournal();
            _isInStockAddNew = true;
            LoadStockJournalEditor();
        }

        private void btnStockSave_Click(object sender, EventArgs e)
        {
            //Validate input
            if (txtStockJournal_Quantity.EditValue == null)
            {
                MessageBox.Show("Quantity must be provided");
                return;
            }

            //Set default value
            if (string.IsNullOrEmpty(txtStockJournal_Description.Text)) txtStockJournal_Description.Text = txtStockJournal_Title.Text;

            //Validate and save
            SaveJournalEntry();

            //Set Interface
            _isInStockAddNew = false;
            LoadStockInformation();
            Application.DoEvents();


        }

        

        private void btnStockReverse_Click(object sender, EventArgs e)
        {
            if(SelectedStockJournal.Id <= 0) return;


            var service = new StockJournalService(Globals.GetConnectionString());
            service.ReverseEntry(SelectedStockJournal.Id);
            LoadStockInformation();
            Application.DoEvents();
        }
        
        private void txtStockJournal_Description_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStockJournal_Description.Text)) txtStockJournal_Description.Text = txtStockJournal_Title.Text;
        }

        #endregion
        
        #region Filter

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadFilter();
        }

        private void cmbFilterCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFilter();
        }

        private void chkFilterInactive_CheckedChanged(object sender, EventArgs e)
        {
            LoadFilter();
        }

        private void chkFilterDeleted_CheckedChanged(object sender, EventArgs e)
        {
            LoadFilter();
        }

        private void chkFilterLikeSearch_CheckedChanged(object sender, EventArgs e)
        {
            LoadFilter();
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
            LoadFilter();

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

            SelectedProduct = new Product();
            SelectedProductModel = new ProductGridViewModel();

            LoadFilter();

            Application.DoEvents();
        }

        #endregion

        #region Product Editor]

        private void bsProductsListing_PositionChanged(object sender, EventArgs e)
        {
            if (sender is not BindingSource { Position: > -1 }) return;
            SelectedProductModel = (ProductGridViewModel)bsProductsListing.Current;
            LoadSelectedProduct();
        }

       
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
            _isInProductAddNew = true;
            SelectedProduct = new Product();
            SelectedProductModel = new ProductGridViewModel();
            LoadSelectedProduct();
            
            Application.DoEvents();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (SelectedProduct.Id <= 0) return;

            SelectedProduct.IsDeleted = false;
            SelectedProduct.IsActive = true;

            using var service = new ProductService(Globals.GetConnectionString());
            service.Update(SelectedProduct);

            LoadFilter();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedProduct.Id <= 0) return;
            var service = new ProductService(Globals.GetConnectionString());
            service.Delete(SelectedProduct.Id, false);
        }

        private void txtEditorName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditorName.Text)) txtEditorName.Text = txtEditorName.Text;
        }


        #endregion

        #region Grid View


        private void gvProducts_RowClick(object sender, RowClickEventArgs e)
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
            try
            {
                var service = new ProductCategoryService(Globals.GetConnectionString());
                service.HandleCategoryMapping(
                    categoryId: int.Parse(e.Node!.Tag.ToString()!),
                    productId: SelectedProduct.Id,
                    isMapped: e.Node.Checked,
                    digiAdminId: Globals.DigiAdministration.Id,
                    applyToChildCategories: chkAutoAssignChildCategories.Checked);

                LoadCustomFieldsSelector();
                LoadCategoriesSelector();
                Application.DoEvents();
            }
            finally 
            {
                Application.DoEvents();
            }
        }



        #endregion

        #endregion

        #endregion

       
    }
}