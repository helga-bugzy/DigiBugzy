namespace DigiBugzy.Desktop.Dashboards
{
    partial class BugzyDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugzyDashboard));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCategories = new DevExpress.XtraBars.BarButtonItem();
            this.bandCustomFields = new DevExpress.XtraBars.BarButtonItem();
            this.btnProducts = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjects = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductsCategories = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjectsFields = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductsFields = new DevExpress.XtraBars.BarButtonItem();
            this.bandCatalog = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bandFinance = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bandAdministration = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bargroupSettings = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnCategories,
            this.bandCustomFields,
            this.btnProducts,
            this.btnProjects,
            this.btnProductsCategories,
            this.barButtonItem1,
            this.btnProjectsFields,
            this.btnProductsFields});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 13;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.bandCatalog,
            this.bandFinance,
            this.bandAdministration});
            this.ribbon.ShowItemCaptionsInCaptionBar = true;
            this.ribbon.ShowItemCaptionsInPageHeader = true;
            this.ribbon.ShowItemCaptionsInQAT = true;
            this.ribbon.Size = new System.Drawing.Size(2036, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnCategories
            // 
            this.btnCategories.Caption = "Categories";
            this.btnCategories.Id = 1;
            this.btnCategories.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCategories.ImageOptions.Image")));
            this.btnCategories.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCategories.ImageOptions.LargeImage")));
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategories_ItemClick);
            // 
            // bandCustomFields
            // 
            this.bandCustomFields.Caption = "Fields";
            this.bandCustomFields.Id = 2;
            this.bandCustomFields.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bandCustomFields.ImageOptions.Image")));
            this.bandCustomFields.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bandCustomFields.ImageOptions.LargeImage")));
            this.bandCustomFields.Name = "bandCustomFields";
            this.bandCustomFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bandCustomFields_ItemClick);
            // 
            // btnProducts
            // 
            this.btnProducts.Caption = "Manage";
            this.btnProducts.Id = 3;
            this.btnProducts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.ImageOptions.Image")));
            this.btnProducts.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProducts.ImageOptions.LargeImage")));
            this.btnProducts.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.Z));
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProducts_ItemClick);
            // 
            // btnProjects
            // 
            this.btnProjects.Caption = "Manage";
            this.btnProjects.Id = 4;
            this.btnProjects.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjects.ImageOptions.Image")));
            this.btnProjects.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProjects.ImageOptions.LargeImage")));
            this.btnProjects.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.Q));
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjects_ItemClick);
            // 
            // btnProductsCategories
            // 
            this.btnProductsCategories.Caption = "Categories";
            this.btnProductsCategories.Id = 6;
            this.btnProductsCategories.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProductsCategories.ImageOptions.Image")));
            this.btnProductsCategories.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProductsCategories.ImageOptions.LargeImage")));
            this.btnProductsCategories.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.Z), ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.C));
            this.btnProductsCategories.Name = "btnProductsCategories";
            this.btnProductsCategories.ShortcutKeyDisplayString = "Ctrl+a,m";
            this.btnProductsCategories.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductsCategories_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Categories";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.Q), ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.C));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjectsCategories_ItemClick);
            // 
            // btnProjectsFields
            // 
            this.btnProjectsFields.Caption = "Fields";
            this.btnProjectsFields.Id = 9;
            this.btnProjectsFields.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectsFields.ImageOptions.Image")));
            this.btnProjectsFields.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProjectsFields.ImageOptions.LargeImage")));
            this.btnProjectsFields.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.Q), ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.F));
            this.btnProjectsFields.Name = "btnProjectsFields";
            this.btnProjectsFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjectsFields_ItemClick_1);
            // 
            // btnProductsFields
            // 
            this.btnProductsFields.Caption = "Fields";
            this.btnProductsFields.Id = 12;
            this.btnProductsFields.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProductsFields.ImageOptions.Image")));
            this.btnProductsFields.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProductsFields.ImageOptions.LargeImage")));
            this.btnProductsFields.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.Z), ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.F));
            this.btnProductsFields.Name = "btnProductsFields";
            this.btnProductsFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductsFields_ItemClick);
            // 
            // bandCatalog
            // 
            this.bandCatalog.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.bandCatalog.Name = "bandCatalog";
            this.bandCatalog.Text = "Catalog";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup2.ImageOptions.Image")));
            this.ribbonPageGroup2.ItemLinks.Add(this.btnProducts);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnProductsCategories);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnProductsFields);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Products";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnProjects);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnProjectsFields);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Projects";
            // 
            // bandFinance
            // 
            this.bandFinance.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.bandFinance.Name = "bandFinance";
            this.bandFinance.Text = "Finance";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // bandAdministration
            // 
            this.bandAdministration.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.bargroupSettings});
            this.bandAdministration.Name = "bandAdministration";
            this.bandAdministration.Text = "Administration";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.ImageOptions.Image")));
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCategories);
            this.ribbonPageGroup1.ItemLinks.Add(this.bandCustomFields);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "General";
            // 
            // bargroupSettings
            // 
            this.bargroupSettings.Name = "bargroupSettings";
            this.bargroupSettings.Text = "Settings";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 1099);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(2036, 24);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Categories";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // BugzyDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2036, 1123);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "BugzyDashboard";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "DigiBugzy Management Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage bandAdministration;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnCategories;
        private DevExpress.XtraBars.BarButtonItem bandCustomFields;
        private DevExpress.XtraBars.BarButtonItem btnProducts;
        private DevExpress.XtraBars.BarButtonItem btnProjects;
        private DevExpress.XtraBars.Ribbon.RibbonPage bandCatalog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage bandFinance;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnProductsCategories;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup bargroupSettings;
        private DevExpress.XtraBars.BarButtonItem btnProjectsFields;
        private DevExpress.XtraBars.BarButtonItem btnProductsFields;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}