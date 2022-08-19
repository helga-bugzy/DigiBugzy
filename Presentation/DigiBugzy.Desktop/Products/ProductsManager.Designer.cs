﻿namespace DigiBugzy.Desktop.Products
{
    partial class ProductsManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsManager));
            this.gridListing = new DevExpress.XtraGrid.GridControl();
            this.productGridViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBackground = new DevExpress.XtraEditors.PanelControl();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.btnSampleDataDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSampleData = new DevExpress.XtraEditors.SimpleButton();
            this.chkFilterLikeSearch = new System.Windows.Forms.CheckBox();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.chkFilterDeleted = new System.Windows.Forms.CheckBox();
            this.chkFilterInactive = new System.Windows.Forms.CheckBox();
            this.cmbFilterCategories = new System.Windows.Forms.ComboBox();
            this.lblFilterCategories = new DevExpress.XtraEditors.LabelControl();
            this.pnlContent = new DevExpress.XtraEditors.PanelControl();
            this.splitContent = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabEditor = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.txtEditorPrice = new System.Windows.Forms.TextBox();
            this.txtEditorQuantity = new DevExpress.XtraEditors.TextEdit();
            this.lblEditorValue = new DevExpress.XtraEditors.LabelControl();
            this.lblEditorPrice = new DevExpress.XtraEditors.LabelControl();
            this.lblSelectedFileName = new System.Windows.Forms.Label();
            this.imgProductPhoto = new System.Windows.Forms.PictureBox();
            this.btnProductImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.chkEditorActive = new System.Windows.Forms.CheckBox();
            this.lblEditorActive = new System.Windows.Forms.Label();
            this.txtEditorDescription = new System.Windows.Forms.TextBox();
            this.txtEditorName = new DevExpress.XtraEditors.TextEdit();
            this.lblEditorDescription = new System.Windows.Forms.Label();
            this.lblEditorName = new System.Windows.Forms.Label();
            this.tabFields = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.pnlCustomFieldsArea = new DevExpress.XtraEditors.PanelControl();
            this.pnlCustomFieldsEditor = new DevExpress.XtraEditors.PanelControl();
            this.pnlCustomFieldsList = new DevExpress.XtraEditors.PanelControl();
            this.tabOrders = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabCategories = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.pnlCategories = new DevExpress.XtraEditors.PanelControl();
            this.pnlCategoriesEditor = new DevExpress.XtraEditors.PanelControl();
            this.pnlCategoriesTree = new DevExpress.XtraEditors.PanelControl();
            this.treeCategories = new System.Windows.Forms.TreeView();
            this.tabProjects = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabDocuments = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabStock = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.openFileProductImage = new System.Windows.Forms.OpenFileDialog();
            this.bsProductsListing = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlStockTab = new DevExpress.XtraEditors.PanelControl();
            this.splitStockMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridStock = new DevExpress.XtraGrid.GridControl();
            this.gvStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bsStockListing = new System.Windows.Forms.BindingSource(this.components);
            this.splitStockEditors = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpStockEditor = new DevExpress.XtraEditors.GroupControl();
            this.grpStockProjectEditor = new DevExpress.XtraEditors.GroupControl();
            this.lblStockTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblStockDescription = new DevExpress.XtraEditors.LabelControl();
            this.lblStockPrice = new System.Windows.Forms.Label();
            this.lblStockQty = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.radStockIn = new System.Windows.Forms.RadioButton();
            this.radStockOut = new System.Windows.Forms.RadioButton();
            this.btnStockAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockReverse = new DevExpress.XtraEditors.SimpleButton();
            this.cmbStockProject = new System.Windows.Forms.ComboBox();
            this.cmbStockProjectSection = new System.Windows.Forms.ComboBox();
            this.cmbStockProjectSectionPart = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblStockProjectSection = new DevExpress.XtraEditors.LabelControl();
            this.lblStockProjectSectionPart = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridListing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGridViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).BeginInit();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel1)).BeginInit();
            this.splitContent.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel2)).BeginInit();
            this.splitContent.Panel2.SuspendLayout();
            this.splitContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditorQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProductPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditorName.Properties)).BeginInit();
            this.tabFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomFieldsArea)).BeginInit();
            this.pnlCustomFieldsArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomFieldsEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomFieldsList)).BeginInit();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCategories)).BeginInit();
            this.pnlCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCategoriesEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCategoriesTree)).BeginInit();
            this.pnlCategoriesTree.SuspendLayout();
            this.tabStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProductsListing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStockTab)).BeginInit();
            this.pnlStockTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitStockMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitStockMain.Panel1)).BeginInit();
            this.splitStockMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitStockMain.Panel2)).BeginInit();
            this.splitStockMain.Panel2.SuspendLayout();
            this.splitStockMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockListing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitStockEditors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitStockEditors.Panel1)).BeginInit();
            this.splitStockEditors.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitStockEditors.Panel2)).BeginInit();
            this.splitStockEditors.Panel2.SuspendLayout();
            this.splitStockEditors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStockEditor)).BeginInit();
            this.grpStockEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStockProjectEditor)).BeginInit();
            this.grpStockProjectEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridListing
            // 
            this.gridListing.DataSource = this.productGridViewModelBindingSource;
            this.gridListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListing.Location = new System.Drawing.Point(0, 0);
            this.gridListing.MainView = this.gvProducts;
            this.gridListing.Name = "gridListing";
            this.gridListing.Size = new System.Drawing.Size(1938, 484);
            this.gridListing.TabIndex = 0;
            this.gridListing.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducts});
            this.gridListing.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.gvProducts_ViewRegistered);
            // 
            // productGridViewModelBindingSource
            // 
            this.productGridViewModelBindingSource.DataSource = typeof(DigiBugzy.Core.ViewModels.Catalog.ProductGridViewModel);
            // 
            // gvProducts
            // 
            this.gvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colImage,
            this.colIsActive,
            this.colParentId,
            this.colParentName});
            this.gvProducts.GridControl = this.gridListing;
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.View_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colImage
            // 
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 2;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 3;
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            this.colParentId.Visible = true;
            this.colParentId.VisibleIndex = 4;
            // 
            // colParentName
            // 
            this.colParentName.FieldName = "ParentName";
            this.colParentName.Name = "colParentName";
            this.colParentName.Visible = true;
            this.colParentName.VisibleIndex = 5;
            // 
            // pnlBackground
            // 
            this.pnlBackground.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBackground.Controls.Add(this.splitMain);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1938, 1068);
            this.pnlBackground.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlFilter);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlContent);
            this.splitMain.Size = new System.Drawing.Size(1938, 1068);
            this.splitMain.SplitterDistance = 91;
            this.splitMain.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFilter.Controls.Add(this.btnSampleDataDelete);
            this.pnlFilter.Controls.Add(this.btnSampleData);
            this.pnlFilter.Controls.Add(this.chkFilterLikeSearch);
            this.pnlFilter.Controls.Add(this.txtFilterName);
            this.pnlFilter.Controls.Add(this.lblFilterName);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.chkFilterDeleted);
            this.pnlFilter.Controls.Add(this.chkFilterInactive);
            this.pnlFilter.Controls.Add(this.cmbFilterCategories);
            this.pnlFilter.Controls.Add(this.lblFilterCategories);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1938, 91);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnSampleDataDelete
            // 
            this.btnSampleDataDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSampleDataDelete.ImageOptions.Image")));
            this.btnSampleDataDelete.Location = new System.Drawing.Point(1761, 36);
            this.btnSampleDataDelete.Name = "btnSampleDataDelete";
            this.btnSampleDataDelete.Size = new System.Drawing.Size(129, 34);
            this.btnSampleDataDelete.TabIndex = 17;
            this.btnSampleDataDelete.Text = "Delete Sample Data";
            this.btnSampleDataDelete.Click += new System.EventHandler(this.btnSampleDataDelete_Click);
            // 
            // btnSampleData
            // 
            this.btnSampleData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSampleData.ImageOptions.Image")));
            this.btnSampleData.Location = new System.Drawing.Point(1626, 36);
            this.btnSampleData.Name = "btnSampleData";
            this.btnSampleData.Size = new System.Drawing.Size(129, 34);
            this.btnSampleData.TabIndex = 16;
            this.btnSampleData.Text = "Create Sample Data";
            this.btnSampleData.Click += new System.EventHandler(this.btnSampleData_Click);
            // 
            // chkFilterLikeSearch
            // 
            this.chkFilterLikeSearch.AutoSize = true;
            this.chkFilterLikeSearch.Checked = true;
            this.chkFilterLikeSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterLikeSearch.Location = new System.Drawing.Point(512, 13);
            this.chkFilterLikeSearch.Name = "chkFilterLikeSearch";
            this.chkFilterLikeSearch.Size = new System.Drawing.Size(102, 17);
            this.chkFilterLikeSearch.TabIndex = 15;
            this.chkFilterLikeSearch.Text = "Like (%) Search";
            this.chkFilterLikeSearch.UseVisualStyleBackColor = true;
            this.chkFilterLikeSearch.CheckedChanged += new System.EventHandler(this.chkFilterLikeSearch_CheckedChanged);
            // 
            // txtFilterName
            // 
            this.txtFilterName.Location = new System.Drawing.Point(87, 14);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(394, 21);
            this.txtFilterName.TabIndex = 14;
            this.txtFilterName.Leave += new System.EventHandler(this.txtFilterName_Leave);
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(30, 17);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(34, 13);
            this.lblFilterName.TabIndex = 13;
            this.lblFilterName.Text = "Name";
            // 
            // btnFilter
            // 
            this.btnFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.ImageOptions.Image")));
            this.btnFilter.Location = new System.Drawing.Point(770, 36);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(97, 38);
            this.btnFilter.TabIndex = 11;
            this.btnFilter.Text = "Filter...";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // chkFilterDeleted
            // 
            this.chkFilterDeleted.AutoSize = true;
            this.chkFilterDeleted.Location = new System.Drawing.Point(640, 57);
            this.chkFilterDeleted.Name = "chkFilterDeleted";
            this.chkFilterDeleted.Size = new System.Drawing.Size(101, 17);
            this.chkFilterDeleted.TabIndex = 10;
            this.chkFilterDeleted.Text = "Include Deleted";
            this.chkFilterDeleted.UseVisualStyleBackColor = true;
            this.chkFilterDeleted.CheckedChanged += new System.EventHandler(this.chkFilterDeleted_CheckedChanged);
            // 
            // chkFilterInactive
            // 
            this.chkFilterInactive.AutoSize = true;
            this.chkFilterInactive.Location = new System.Drawing.Point(513, 57);
            this.chkFilterInactive.Name = "chkFilterInactive";
            this.chkFilterInactive.Size = new System.Drawing.Size(103, 17);
            this.chkFilterInactive.TabIndex = 9;
            this.chkFilterInactive.Text = "Include Inactive";
            this.chkFilterInactive.UseVisualStyleBackColor = true;
            this.chkFilterInactive.CheckedChanged += new System.EventHandler(this.chkFilterInactive_CheckedChanged);
            // 
            // cmbFilterCategories
            // 
            this.cmbFilterCategories.FormattingEnabled = true;
            this.cmbFilterCategories.Location = new System.Drawing.Point(87, 55);
            this.cmbFilterCategories.Name = "cmbFilterCategories";
            this.cmbFilterCategories.Size = new System.Drawing.Size(396, 21);
            this.cmbFilterCategories.TabIndex = 8;
            this.cmbFilterCategories.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategories_SelectedIndexChanged);
            // 
            // lblFilterCategories
            // 
            this.lblFilterCategories.Location = new System.Drawing.Point(30, 60);
            this.lblFilterCategories.Name = "lblFilterCategories";
            this.lblFilterCategories.Size = new System.Drawing.Size(45, 13);
            this.lblFilterCategories.TabIndex = 7;
            this.lblFilterCategories.Text = "Category";
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlContent.Controls.Add(this.splitContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1938, 973);
            this.pnlContent.TabIndex = 0;
            // 
            // splitContent
            // 
            this.splitContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContent.Horizontal = false;
            this.splitContent.Location = new System.Drawing.Point(0, 0);
            this.splitContent.Name = "splitContent";
            // 
            // splitContent.Panel1
            // 
            this.splitContent.Panel1.Controls.Add(this.gridListing);
            this.splitContent.Panel1.Text = "Panel1";
            // 
            // splitContent.Panel2
            // 
            this.splitContent.Panel2.Controls.Add(this.tabPane1);
            this.splitContent.Panel2.Text = "Panel2";
            this.splitContent.Size = new System.Drawing.Size(1938, 973);
            this.splitContent.SplitterPosition = 484;
            this.splitContent.TabIndex = 0;
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabEditor);
            this.tabPane1.Controls.Add(this.tabFields);
            this.tabPane1.Controls.Add(this.tabOrders);
            this.tabPane1.Controls.Add(this.tabCategories);
            this.tabPane1.Controls.Add(this.tabProjects);
            this.tabPane1.Controls.Add(this.tabDocuments);
            this.tabPane1.Controls.Add(this.tabStock);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabEditor,
            this.tabFields,
            this.tabCategories,
            this.tabStock,
            this.tabOrders,
            this.tabProjects,
            this.tabDocuments});
            this.tabPane1.RegularSize = new System.Drawing.Size(1938, 479);
            this.tabPane1.SelectedPage = this.tabEditor;
            this.tabPane1.Size = new System.Drawing.Size(1938, 479);
            this.tabPane1.TabIndex = 0;
            this.tabPane1.Text = "Product Information";
            // 
            // tabEditor
            // 
            this.tabEditor.Caption = "Editor";
            this.tabEditor.Controls.Add(this.txtEditorPrice);
            this.tabEditor.Controls.Add(this.txtEditorQuantity);
            this.tabEditor.Controls.Add(this.lblEditorValue);
            this.tabEditor.Controls.Add(this.lblEditorPrice);
            this.tabEditor.Controls.Add(this.lblSelectedFileName);
            this.tabEditor.Controls.Add(this.imgProductPhoto);
            this.tabEditor.Controls.Add(this.btnProductImage);
            this.tabEditor.Controls.Add(this.btnRestore);
            this.tabEditor.Controls.Add(this.btnDelete);
            this.tabEditor.Controls.Add(this.btnSave);
            this.tabEditor.Controls.Add(this.btnAddNew);
            this.tabEditor.Controls.Add(this.chkEditorActive);
            this.tabEditor.Controls.Add(this.lblEditorActive);
            this.tabEditor.Controls.Add(this.txtEditorDescription);
            this.tabEditor.Controls.Add(this.txtEditorName);
            this.tabEditor.Controls.Add(this.lblEditorDescription);
            this.tabEditor.Controls.Add(this.lblEditorName);
            this.tabEditor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabEditor.ImageOptions.Image")));
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Size = new System.Drawing.Size(1938, 446);
            this.tabEditor.ToolTip = "Editor";
            // 
            // txtEditorPrice
            // 
            this.txtEditorPrice.Location = new System.Drawing.Point(101, 304);
            this.txtEditorPrice.Name = "txtEditorPrice";
            this.txtEditorPrice.Size = new System.Drawing.Size(100, 21);
            this.txtEditorPrice.TabIndex = 16;
            // 
            // txtEditorQuantity
            // 
            this.txtEditorQuantity.Location = new System.Drawing.Point(372, 303);
            this.txtEditorQuantity.Name = "txtEditorQuantity";
            this.txtEditorQuantity.Size = new System.Drawing.Size(125, 20);
            this.txtEditorQuantity.TabIndex = 15;
            // 
            // lblEditorValue
            // 
            this.lblEditorValue.Location = new System.Drawing.Point(295, 306);
            this.lblEditorValue.Name = "lblEditorValue";
            this.lblEditorValue.Size = new System.Drawing.Size(46, 13);
            this.lblEditorValue.TabIndex = 14;
            this.lblEditorValue.Text = "Quantity:";
            // 
            // lblEditorPrice
            // 
            this.lblEditorPrice.Location = new System.Drawing.Point(17, 306);
            this.lblEditorPrice.Name = "lblEditorPrice";
            this.lblEditorPrice.Size = new System.Drawing.Size(23, 13);
            this.lblEditorPrice.TabIndex = 13;
            this.lblEditorPrice.Text = "Price";
            // 
            // lblSelectedFileName
            // 
            this.lblSelectedFileName.AutoSize = true;
            this.lblSelectedFileName.Location = new System.Drawing.Point(511, 338);
            this.lblSelectedFileName.Name = "lblSelectedFileName";
            this.lblSelectedFileName.Size = new System.Drawing.Size(15, 13);
            this.lblSelectedFileName.TabIndex = 12;
            this.lblSelectedFileName.Text = "..";
            // 
            // imgProductPhoto
            // 
            this.imgProductPhoto.Location = new System.Drawing.Point(510, 66);
            this.imgProductPhoto.Name = "imgProductPhoto";
            this.imgProductPhoto.Size = new System.Drawing.Size(465, 257);
            this.imgProductPhoto.TabIndex = 11;
            this.imgProductPhoto.TabStop = false;
            // 
            // btnProductImage
            // 
            this.btnProductImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProductImage.ImageOptions.Image")));
            this.btnProductImage.Location = new System.Drawing.Point(391, 333);
            this.btnProductImage.Name = "btnProductImage";
            this.btnProductImage.Size = new System.Drawing.Size(104, 23);
            this.btnProductImage.TabIndex = 10;
            this.btnProductImage.Text = "Select Image";
            this.btnProductImage.Click += new System.EventHandler(this.btnProductImage_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.ImageOptions.Image")));
            this.btnRestore.Location = new System.Drawing.Point(242, 387);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(101, 34);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(99, 387);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(392, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.ImageOptions.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(12, 12);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(104, 32);
            this.btnAddNew.TabIndex = 8;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // chkEditorActive
            // 
            this.chkEditorActive.AutoSize = true;
            this.chkEditorActive.Checked = true;
            this.chkEditorActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEditorActive.Location = new System.Drawing.Point(99, 338);
            this.chkEditorActive.Name = "chkEditorActive";
            this.chkEditorActive.Size = new System.Drawing.Size(15, 14);
            this.chkEditorActive.TabIndex = 5;
            this.chkEditorActive.UseVisualStyleBackColor = true;
            // 
            // lblEditorActive
            // 
            this.lblEditorActive.AutoSize = true;
            this.lblEditorActive.Location = new System.Drawing.Point(12, 338);
            this.lblEditorActive.Name = "lblEditorActive";
            this.lblEditorActive.Size = new System.Drawing.Size(41, 13);
            this.lblEditorActive.TabIndex = 4;
            this.lblEditorActive.Text = "Active:";
            // 
            // txtEditorDescription
            // 
            this.txtEditorDescription.Location = new System.Drawing.Point(99, 97);
            this.txtEditorDescription.MaxLength = 255;
            this.txtEditorDescription.Multiline = true;
            this.txtEditorDescription.Name = "txtEditorDescription";
            this.txtEditorDescription.Size = new System.Drawing.Size(398, 200);
            this.txtEditorDescription.TabIndex = 3;
            // 
            // txtEditorName
            // 
            this.txtEditorName.Location = new System.Drawing.Point(99, 63);
            this.txtEditorName.Name = "txtEditorName";
            this.txtEditorName.Size = new System.Drawing.Size(398, 20);
            this.txtEditorName.TabIndex = 2;
            // 
            // lblEditorDescription
            // 
            this.lblEditorDescription.AutoSize = true;
            this.lblEditorDescription.Location = new System.Drawing.Point(12, 101);
            this.lblEditorDescription.Name = "lblEditorDescription";
            this.lblEditorDescription.Size = new System.Drawing.Size(64, 13);
            this.lblEditorDescription.TabIndex = 1;
            this.lblEditorDescription.Text = "Description:";
            // 
            // lblEditorName
            // 
            this.lblEditorName.AutoSize = true;
            this.lblEditorName.Location = new System.Drawing.Point(12, 66);
            this.lblEditorName.Name = "lblEditorName";
            this.lblEditorName.Size = new System.Drawing.Size(38, 13);
            this.lblEditorName.TabIndex = 0;
            this.lblEditorName.Text = "Name:";
            // 
            // tabFields
            // 
            this.tabFields.Caption = "Fields";
            this.tabFields.Controls.Add(this.pnlCustomFieldsArea);
            this.tabFields.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabFields.ImageOptions.Image")));
            this.tabFields.Name = "tabFields";
            this.tabFields.Size = new System.Drawing.Size(1938, 446);
            this.tabFields.ToolTip = "Custom Fields";
            // 
            // pnlCustomFieldsArea
            // 
            this.pnlCustomFieldsArea.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCustomFieldsArea.Controls.Add(this.pnlCustomFieldsEditor);
            this.pnlCustomFieldsArea.Controls.Add(this.pnlCustomFieldsList);
            this.pnlCustomFieldsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomFieldsArea.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomFieldsArea.Name = "pnlCustomFieldsArea";
            this.pnlCustomFieldsArea.Size = new System.Drawing.Size(1938, 446);
            this.pnlCustomFieldsArea.TabIndex = 0;
            // 
            // pnlCustomFieldsEditor
            // 
            this.pnlCustomFieldsEditor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCustomFieldsEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomFieldsEditor.Location = new System.Drawing.Point(737, 0);
            this.pnlCustomFieldsEditor.Name = "pnlCustomFieldsEditor";
            this.pnlCustomFieldsEditor.Size = new System.Drawing.Size(1201, 446);
            this.pnlCustomFieldsEditor.TabIndex = 1;
            // 
            // pnlCustomFieldsList
            // 
            this.pnlCustomFieldsList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCustomFieldsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCustomFieldsList.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomFieldsList.Name = "pnlCustomFieldsList";
            this.pnlCustomFieldsList.Size = new System.Drawing.Size(737, 446);
            this.pnlCustomFieldsList.TabIndex = 0;
            // 
            // tabOrders
            // 
            this.tabOrders.Caption = "Orders";
            this.tabOrders.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabOrders.ImageOptions.Image")));
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Size = new System.Drawing.Size(1938, 479);
            // 
            // tabCategories
            // 
            this.tabCategories.Caption = "Categories";
            this.tabCategories.Controls.Add(this.pnlCategories);
            this.tabCategories.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabCategories.ImageOptions.Image")));
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Size = new System.Drawing.Size(1938, 446);
            this.tabCategories.ToolTip = "Categories";
            // 
            // pnlCategories
            // 
            this.pnlCategories.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCategories.Controls.Add(this.pnlCategoriesEditor);
            this.pnlCategories.Controls.Add(this.pnlCategoriesTree);
            this.pnlCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategories.Location = new System.Drawing.Point(0, 0);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(1938, 446);
            this.pnlCategories.TabIndex = 0;
            // 
            // pnlCategoriesEditor
            // 
            this.pnlCategoriesEditor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCategoriesEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategoriesEditor.Location = new System.Drawing.Point(612, 0);
            this.pnlCategoriesEditor.Name = "pnlCategoriesEditor";
            this.pnlCategoriesEditor.Size = new System.Drawing.Size(1326, 446);
            this.pnlCategoriesEditor.TabIndex = 1;
            // 
            // pnlCategoriesTree
            // 
            this.pnlCategoriesTree.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCategoriesTree.Controls.Add(this.treeCategories);
            this.pnlCategoriesTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCategoriesTree.Location = new System.Drawing.Point(0, 0);
            this.pnlCategoriesTree.Name = "pnlCategoriesTree";
            this.pnlCategoriesTree.Size = new System.Drawing.Size(612, 446);
            this.pnlCategoriesTree.TabIndex = 0;
            // 
            // treeCategories
            // 
            this.treeCategories.CheckBoxes = true;
            this.treeCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategories.Location = new System.Drawing.Point(0, 0);
            this.treeCategories.Name = "treeCategories";
            this.treeCategories.Size = new System.Drawing.Size(612, 446);
            this.treeCategories.TabIndex = 0;
            this.treeCategories.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeCategories_AfterCheck);
            // 
            // tabProjects
            // 
            this.tabProjects.Caption = "Projects";
            this.tabProjects.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabProjects.ImageOptions.Image")));
            this.tabProjects.Name = "tabProjects";
            this.tabProjects.PageText = "Projects";
            this.tabProjects.Size = new System.Drawing.Size(1938, 479);
            // 
            // tabDocuments
            // 
            this.tabDocuments.Caption = "Documents";
            this.tabDocuments.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabDocuments.ImageOptions.Image")));
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Size = new System.Drawing.Size(1938, 479);
            // 
            // tabStock
            // 
            this.tabStock.Caption = "Stock";
            this.tabStock.Controls.Add(this.pnlStockTab);
            this.tabStock.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabStock.ImageOptions.Image")));
            this.tabStock.Name = "tabStock";
            this.tabStock.Size = new System.Drawing.Size(1938, 446);
            // 
            // openFileProductImage
            // 
            this.openFileProductImage.DefaultExt = "\"png\"";
            this.openFileProductImage.FileName = "openFileDialog1";
            this.openFileProductImage.Filter = "\"png files (*.png)|*.png|All files (*.*)|*.*\"";
            this.openFileProductImage.Title = "\"Browse image files\"";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(576, 466);
            this.splitContainerControl1.SplitterPosition = 166;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // pnlStockTab
            // 
            this.pnlStockTab.Controls.Add(this.splitStockMain);
            this.pnlStockTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStockTab.Location = new System.Drawing.Point(0, 0);
            this.pnlStockTab.Name = "pnlStockTab";
            this.pnlStockTab.Size = new System.Drawing.Size(1938, 446);
            this.pnlStockTab.TabIndex = 0;
            // 
            // splitStockMain
            // 
            this.splitStockMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitStockMain.Location = new System.Drawing.Point(2, 2);
            this.splitStockMain.Name = "splitStockMain";
            // 
            // splitStockMain.splitStockMain_Panel1
            // 
            this.splitStockMain.Panel1.Controls.Add(this.gridStock);
            this.splitStockMain.Panel1.Text = "Panel1";
            // 
            // splitStockMain.splitStockMain_Panel2
            // 
            this.splitStockMain.Panel2.Controls.Add(this.splitStockEditors);
            this.splitStockMain.Panel2.Text = "Panel2";
            this.splitStockMain.Size = new System.Drawing.Size(1934, 442);
            this.splitStockMain.SplitterPosition = 670;
            this.splitStockMain.TabIndex = 0;
            // 
            // gridStock
            // 
            this.gridStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStock.Location = new System.Drawing.Point(0, 0);
            this.gridStock.MainView = this.gvStock;
            this.gridStock.Name = "gridStock";
            this.gridStock.Size = new System.Drawing.Size(670, 442);
            this.gridStock.TabIndex = 0;
            this.gridStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStock});
            this.gridStock.Click += new System.EventHandler(this.gridStock_Click);
            // 
            // gvStock
            // 
            this.gvStock.GridControl = this.gridStock;
            this.gvStock.Name = "gvStock";
            // 
            // splitStockEditors
            // 
            this.splitStockEditors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitStockEditors.Horizontal = false;
            this.splitStockEditors.Location = new System.Drawing.Point(0, 0);
            this.splitStockEditors.Name = "splitStockEditors";
            // 
            // splitStockEditors.splitStockEditors_Panel1
            // 
            this.splitStockEditors.Panel1.Controls.Add(this.grpStockEditor);
            this.splitStockEditors.Panel1.Text = "Panel1";
            // 
            // splitStockEditors.splitStockEditors_Panel2
            // 
            this.splitStockEditors.Panel2.Controls.Add(this.grpStockProjectEditor);
            this.splitStockEditors.Panel2.Text = "Panel2";
            this.splitStockEditors.Size = new System.Drawing.Size(1254, 442);
            this.splitStockEditors.SplitterPosition = 255;
            this.splitStockEditors.TabIndex = 0;
            // 
            // grpStockEditor
            // 
            this.grpStockEditor.Controls.Add(this.btnStockReverse);
            this.grpStockEditor.Controls.Add(this.btnStockSave);
            this.grpStockEditor.Controls.Add(this.btnStockAddNew);
            this.grpStockEditor.Controls.Add(this.radStockOut);
            this.grpStockEditor.Controls.Add(this.radStockIn);
            this.grpStockEditor.Controls.Add(this.textBox3);
            this.grpStockEditor.Controls.Add(this.textBox2);
            this.grpStockEditor.Controls.Add(this.textBox1);
            this.grpStockEditor.Controls.Add(this.textEdit1);
            this.grpStockEditor.Controls.Add(this.lblStockQty);
            this.grpStockEditor.Controls.Add(this.lblStockPrice);
            this.grpStockEditor.Controls.Add(this.lblStockDescription);
            this.grpStockEditor.Controls.Add(this.lblStockTotal);
            this.grpStockEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStockEditor.Location = new System.Drawing.Point(0, 0);
            this.grpStockEditor.Name = "grpStockEditor";
            this.grpStockEditor.Size = new System.Drawing.Size(1254, 255);
            this.grpStockEditor.TabIndex = 0;
            this.grpStockEditor.Text = "Stock Journal Editor";
            // 
            // grpStockProjectEditor
            // 
            this.grpStockProjectEditor.Controls.Add(this.lblStockProjectSectionPart);
            this.grpStockProjectEditor.Controls.Add(this.lblStockProjectSection);
            this.grpStockProjectEditor.Controls.Add(this.labelControl1);
            this.grpStockProjectEditor.Controls.Add(this.cmbStockProjectSectionPart);
            this.grpStockProjectEditor.Controls.Add(this.cmbStockProjectSection);
            this.grpStockProjectEditor.Controls.Add(this.cmbStockProject);
            this.grpStockProjectEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStockProjectEditor.Location = new System.Drawing.Point(0, 0);
            this.grpStockProjectEditor.Name = "grpStockProjectEditor";
            this.grpStockProjectEditor.Size = new System.Drawing.Size(1254, 177);
            this.grpStockProjectEditor.TabIndex = 0;
            this.grpStockProjectEditor.Text = "Stock Project Editor";
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.Location = new System.Drawing.Point(14, 77);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(24, 13);
            this.lblStockTotal.TabIndex = 0;
            this.lblStockTotal.Text = "Title:";
            // 
            // lblStockDescription
            // 
            this.lblStockDescription.Location = new System.Drawing.Point(14, 104);
            this.lblStockDescription.Name = "lblStockDescription";
            this.lblStockDescription.Size = new System.Drawing.Size(57, 13);
            this.lblStockDescription.TabIndex = 1;
            this.lblStockDescription.Text = "Description:";
            // 
            // lblStockPrice
            // 
            this.lblStockPrice.AutoSize = true;
            this.lblStockPrice.Location = new System.Drawing.Point(14, 133);
            this.lblStockPrice.Name = "lblStockPrice";
            this.lblStockPrice.Size = new System.Drawing.Size(34, 13);
            this.lblStockPrice.TabIndex = 2;
            this.lblStockPrice.Text = "Price:";
            // 
            // lblStockQty
            // 
            this.lblStockQty.Location = new System.Drawing.Point(14, 160);
            this.lblStockQty.Name = "lblStockQty";
            this.lblStockQty.Size = new System.Drawing.Size(46, 13);
            this.lblStockQty.TabIndex = 3;
            this.lblStockQty.Text = "Quantity:";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(92, 71);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(386, 20);
            this.textEdit1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 21);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(92, 157);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 7;
            // 
            // radStockIn
            // 
            this.radStockIn.AutoSize = true;
            this.radStockIn.Checked = true;
            this.radStockIn.Location = new System.Drawing.Point(207, 160);
            this.radStockIn.Name = "radStockIn";
            this.radStockIn.Size = new System.Drawing.Size(35, 17);
            this.radStockIn.TabIndex = 8;
            this.radStockIn.TabStop = true;
            this.radStockIn.Text = "In";
            this.radStockIn.UseVisualStyleBackColor = true;
            // 
            // radStockOut
            // 
            this.radStockOut.AutoSize = true;
            this.radStockOut.Location = new System.Drawing.Point(252, 160);
            this.radStockOut.Name = "radStockOut";
            this.radStockOut.Size = new System.Drawing.Size(43, 17);
            this.radStockOut.TabIndex = 9;
            this.radStockOut.TabStop = true;
            this.radStockOut.Text = "Out";
            this.radStockOut.UseVisualStyleBackColor = true;
            // 
            // btnStockAddNew
            // 
            this.btnStockAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnStockAddNew.Location = new System.Drawing.Point(14, 33);
            this.btnStockAddNew.Name = "btnStockAddNew";
            this.btnStockAddNew.Size = new System.Drawing.Size(94, 32);
            this.btnStockAddNew.TabIndex = 10;
            this.btnStockAddNew.Text = "Add New";
            // 
            // btnStockSave
            // 
            this.btnStockSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStockSave.ImageOptions.Image")));
            this.btnStockSave.Location = new System.Drawing.Point(14, 201);
            this.btnStockSave.Name = "btnStockSave";
            this.btnStockSave.Size = new System.Drawing.Size(94, 33);
            this.btnStockSave.TabIndex = 11;
            this.btnStockSave.Text = "Save";
            // 
            // btnStockReverse
            // 
            this.btnStockReverse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStockReverse.ImageOptions.Image")));
            this.btnStockReverse.Location = new System.Drawing.Point(114, 201);
            this.btnStockReverse.Name = "btnStockReverse";
            this.btnStockReverse.Size = new System.Drawing.Size(95, 33);
            this.btnStockReverse.TabIndex = 12;
            this.btnStockReverse.Text = "Reverse";
            // 
            // cmbStockProject
            // 
            this.cmbStockProject.FormattingEnabled = true;
            this.cmbStockProject.Location = new System.Drawing.Point(138, 60);
            this.cmbStockProject.Name = "cmbStockProject";
            this.cmbStockProject.Size = new System.Drawing.Size(234, 21);
            this.cmbStockProject.TabIndex = 0;
            // 
            // cmbStockProjectSection
            // 
            this.cmbStockProjectSection.FormattingEnabled = true;
            this.cmbStockProjectSection.Location = new System.Drawing.Point(138, 93);
            this.cmbStockProjectSection.Name = "cmbStockProjectSection";
            this.cmbStockProjectSection.Size = new System.Drawing.Size(234, 21);
            this.cmbStockProjectSection.TabIndex = 1;
            // 
            // cmbStockProjectSectionPart
            // 
            this.cmbStockProjectSectionPart.FormattingEnabled = true;
            this.cmbStockProjectSectionPart.Location = new System.Drawing.Point(138, 122);
            this.cmbStockProjectSectionPart.Name = "cmbStockProjectSectionPart";
            this.cmbStockProjectSectionPart.Size = new System.Drawing.Size(234, 21);
            this.cmbStockProjectSectionPart.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Project:";
            // 
            // lblStockProjectSection
            // 
            this.lblStockProjectSection.Location = new System.Drawing.Point(11, 101);
            this.lblStockProjectSection.Name = "lblStockProjectSection";
            this.lblStockProjectSection.Size = new System.Drawing.Size(76, 13);
            this.lblStockProjectSection.TabIndex = 4;
            this.lblStockProjectSection.Text = "Project Section:";
            // 
            // lblStockProjectSectionPart
            // 
            this.lblStockProjectSectionPart.Location = new System.Drawing.Point(9, 130);
            this.lblStockProjectSectionPart.Name = "lblStockProjectSectionPart";
            this.lblStockProjectSectionPart.Size = new System.Drawing.Size(99, 13);
            this.lblStockProjectSectionPart.TabIndex = 5;
            this.lblStockProjectSectionPart.Text = "Project Section Part:";
            // 
            // ProductsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1938, 1068);
            this.Controls.Add(this.pnlBackground);
            this.Name = "ProductsManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridListing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGridViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel1)).EndInit();
            this.splitContent.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel2)).EndInit();
            this.splitContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContent)).EndInit();
            this.splitContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabEditor.ResumeLayout(false);
            this.tabEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditorQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProductPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditorName.Properties)).EndInit();
            this.tabFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomFieldsArea)).EndInit();
            this.pnlCustomFieldsArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomFieldsEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomFieldsList)).EndInit();
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCategories)).EndInit();
            this.pnlCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCategoriesEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCategoriesTree)).EndInit();
            this.pnlCategoriesTree.ResumeLayout(false);
            this.tabStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsProductsListing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlStockTab)).EndInit();
            this.pnlStockTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitStockMain.Panel1)).EndInit();
            this.splitStockMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitStockMain.Panel2)).EndInit();
            this.splitStockMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitStockMain)).EndInit();
            this.splitStockMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockListing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitStockEditors.Panel1)).EndInit();
            this.splitStockEditors.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitStockEditors.Panel2)).EndInit();
            this.splitStockEditors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitStockEditors)).EndInit();
            this.splitStockEditors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpStockEditor)).EndInit();
            this.grpStockEditor.ResumeLayout(false);
            this.grpStockEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStockProjectEditor)).EndInit();
            this.grpStockProjectEditor.ResumeLayout(false);
            this.grpStockProjectEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBackground;
        private SplitContainer splitMain;
        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.SplitContainerControl splitContent;

        
        
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabEditor;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabFields;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabOrders;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabCategories;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabProjects;
        private TextBox txtEditorDescription;
        private DevExpress.XtraEditors.TextEdit txtEditorName;
        private Label lblEditorDescription;
        private Label lblEditorName;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabDocuments;
        private Label lblEditorActive;
        private CheckBox chkEditorActive;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private CheckBox chkFilterDeleted;
        private CheckBox chkFilterInactive;
        private ComboBox cmbFilterCategories;
        private DevExpress.XtraEditors.LabelControl lblFilterCategories;
        private OpenFileDialog openFileProductImage;
        private DevExpress.XtraEditors.SimpleButton btnProductImage;
        private PictureBox imgProductPhoto;
        private Label lblSelectedFileName;
        private CheckBox chkFilterLikeSearch;
        private TextBox txtFilterName;
        private Label lblFilterName;

        private DevExpress.XtraEditors.PanelControl pnlCategories;
        private DevExpress.XtraEditors.PanelControl pnlCategoriesEditor;
        private DevExpress.XtraEditors.PanelControl pnlCategoriesTree;

        private TreeView treeCategories;
        private DevExpress.XtraEditors.PanelControl pnlCustomFieldsArea;
        private DevExpress.XtraEditors.PanelControl pnlCustomFieldsEditor;
        private DevExpress.XtraEditors.PanelControl pnlCustomFieldsList;
        private DevExpress.XtraEditors.SimpleButton btnSampleDataDelete;
        private DevExpress.XtraEditors.SimpleButton btnSampleData;

        private DevExpress.XtraGrid.GridControl gridListing;

        private DevExpress.XtraGrid.Views.Grid.GridView gvProducts;
        private BindingSource bsProductsListing;
        private BindingSource productGridViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colParentId;
        private DevExpress.XtraGrid.Columns.GridColumn colParentName;
        private TextBox txtEditorPrice;
        private DevExpress.XtraEditors.TextEdit txtEditorQuantity;
        private DevExpress.XtraEditors.LabelControl lblEditorValue;
        private DevExpress.XtraEditors.LabelControl lblEditorPrice;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabStock;
        private DevExpress.XtraEditors.PanelControl pnlStockTab;
        private DevExpress.XtraEditors.SplitContainerControl splitStockMain;
        private DevExpress.XtraGrid.GridControl gridStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStock;
        private BindingSource bsStockListing;
        private DevExpress.XtraEditors.SplitContainerControl splitStockEditors;
        private DevExpress.XtraEditors.GroupControl grpStockEditor;
        private DevExpress.XtraEditors.GroupControl grpStockProjectEditor;
        private DevExpress.XtraEditors.LabelControl lblStockQty;
        private Label lblStockPrice;
        private DevExpress.XtraEditors.LabelControl lblStockDescription;
        private DevExpress.XtraEditors.LabelControl lblStockTotal;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private RadioButton radStockOut;
        private RadioButton radStockIn;
        private DevExpress.XtraEditors.SimpleButton btnStockReverse;
        private DevExpress.XtraEditors.SimpleButton btnStockSave;
        private DevExpress.XtraEditors.SimpleButton btnStockAddNew;
        private DevExpress.XtraEditors.LabelControl lblStockProjectSectionPart;
        private DevExpress.XtraEditors.LabelControl lblStockProjectSection;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ComboBox cmbStockProjectSectionPart;
        private ComboBox cmbStockProjectSection;
        private ComboBox cmbStockProject;
    }
}