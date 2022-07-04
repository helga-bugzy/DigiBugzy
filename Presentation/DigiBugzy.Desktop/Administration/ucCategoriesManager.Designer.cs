namespace DigiBugzy.Desktop.Administration
{
    partial class ucCategoriesManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.ctrlFilter = new DigiBugzy.Desktop.MultiFunctional.ucFilterStandard();
            this.splitData = new System.Windows.Forms.SplitContainer();
            this.pnlTreeView = new System.Windows.Forms.Panel();
            this.treeData = new System.Windows.Forms.TreeView();
            this.splitDetails = new System.Windows.Forms.SplitContainer();
            this.grdCustomFields = new System.Windows.Forms.DataGridView();
            this.grdProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitData)).BeginInit();
            this.splitData.Panel1.SuspendLayout();
            this.splitData.Panel2.SuspendLayout();
            this.splitData.SuspendLayout();
            this.pnlTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetails)).BeginInit();
            this.splitDetails.Panel1.SuspendLayout();
            this.splitDetails.Panel2.SuspendLayout();
            this.splitDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            this.SuspendLayout();
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
            this.splitMain.Panel1.Controls.Add(this.ctrlFilter);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitData);
            this.splitMain.Size = new System.Drawing.Size(1220, 797);
            this.splitMain.SplitterDistance = 129;
            this.splitMain.TabIndex = 0;
            // 
            // ctrlFilter
            // 
            this.ctrlFilter.CanFilterCategories = false;
            this.ctrlFilter.CanFilterClassifications = true;
            this.ctrlFilter.Location = new System.Drawing.Point(3, 3);
            this.ctrlFilter.Name = "ctrlFilter";
            this.ctrlFilter.Size = new System.Drawing.Size(1198, 112);
            this.ctrlFilter.TabIndex = 0;
            this.ctrlFilter.OnFilter += new DigiBugzy.Desktop.MultiFunctional.ucFilterStandard.OnFilterDelegate(this.ctrlFilter_OnFilter);
            // 
            // splitData
            // 
            this.splitData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitData.Location = new System.Drawing.Point(0, 0);
            this.splitData.Name = "splitData";
            // 
            // splitData.Panel1
            // 
            this.splitData.Panel1.Controls.Add(this.pnlTreeView);
            // 
            // splitData.Panel2
            // 
            this.splitData.Panel2.Controls.Add(this.splitDetails);
            this.splitData.Size = new System.Drawing.Size(1220, 664);
            this.splitData.SplitterDistance = 406;
            this.splitData.TabIndex = 0;
            // 
            // pnlTreeView
            // 
            this.pnlTreeView.Controls.Add(this.treeData);
            this.pnlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTreeView.Location = new System.Drawing.Point(0, 0);
            this.pnlTreeView.Name = "pnlTreeView";
            this.pnlTreeView.Size = new System.Drawing.Size(406, 664);
            this.pnlTreeView.TabIndex = 0;
            // 
            // treeData
            // 
            this.treeData.AllowDrop = true;
            this.treeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeData.HotTracking = true;
            this.treeData.Location = new System.Drawing.Point(0, 0);
            this.treeData.Name = "treeData";
            this.treeData.Size = new System.Drawing.Size(406, 664);
            this.treeData.TabIndex = 0;
            // 
            // splitDetails
            // 
            this.splitDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDetails.Location = new System.Drawing.Point(0, 0);
            this.splitDetails.Name = "splitDetails";
            this.splitDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDetails.Panel1
            // 
            this.splitDetails.Panel1.Controls.Add(this.grdCustomFields);
            // 
            // splitDetails.Panel2
            // 
            this.splitDetails.Panel2.Controls.Add(this.grdProducts);
            this.splitDetails.Size = new System.Drawing.Size(810, 664);
            this.splitDetails.SplitterDistance = 270;
            this.splitDetails.TabIndex = 0;
            // 
            // grdCustomFields
            // 
            this.grdCustomFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCustomFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomFields.Location = new System.Drawing.Point(0, 0);
            this.grdCustomFields.Name = "grdCustomFields";
            this.grdCustomFields.RowTemplate.Height = 25;
            this.grdCustomFields.Size = new System.Drawing.Size(810, 270);
            this.grdCustomFields.TabIndex = 0;
            // 
            // grdProducts
            // 
            this.grdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProducts.Location = new System.Drawing.Point(0, 0);
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.RowTemplate.Height = 25;
            this.grdProducts.Size = new System.Drawing.Size(810, 390);
            this.grdProducts.TabIndex = 0;
            // 
            // ucCategoriesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Name = "ucCategoriesManager";
            this.Size = new System.Drawing.Size(1220, 797);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitData.Panel1.ResumeLayout(false);
            this.splitData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitData)).EndInit();
            this.splitData.ResumeLayout(false);
            this.pnlTreeView.ResumeLayout(false);
            this.splitDetails.Panel1.ResumeLayout(false);
            this.splitDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDetails)).EndInit();
            this.splitDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitMain;
        private ucFilterStandard ctrlFilter;
        private SplitContainer splitData;
        private Panel pnlTreeView;
        private TreeView treeData;
        private SplitContainer splitDetails;
        private DataGridView grdCustomFields;
        private DataGridView grdProducts;
    }
}
