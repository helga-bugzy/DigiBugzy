namespace DigiBugzy.Desktop.Administration.Categories
{
    partial class CategoriesManager
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
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.cmbClassifications = new System.Windows.Forms.ComboBox();
            this.lblClassification = new DevExpress.XtraEditors.LabelControl();
            this.pnlContent = new DevExpress.XtraEditors.PanelControl();
            this.splitContent = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeCategories = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
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
            this.splitContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Horizontal = false;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlFilter);
            this.splitMain.Panel1.Text = "Panel1";
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlContent);
            this.splitMain.Panel2.Text = "Panel2";
            this.splitMain.Size = new System.Drawing.Size(1507, 852);
            this.splitMain.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.cmbClassifications);
            this.pnlFilter.Controls.Add(this.lblClassification);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1507, 100);
            this.pnlFilter.TabIndex = 0;
            // 
            // cmbClassifications
            // 
            this.cmbClassifications.FormattingEnabled = true;
            this.cmbClassifications.Location = new System.Drawing.Point(82, 13);
            this.cmbClassifications.Name = "cmbClassifications";
            this.cmbClassifications.Size = new System.Drawing.Size(396, 21);
            this.cmbClassifications.TabIndex = 1;
            this.cmbClassifications.SelectedIndexChanged += new System.EventHandler(this.cmbClassifications_SelectedIndexChanged);
            // 
            // lblClassification
            // 
            this.lblClassification.Location = new System.Drawing.Point(5, 12);
            this.lblClassification.Name = "lblClassification";
            this.lblClassification.Size = new System.Drawing.Size(62, 13);
            this.lblClassification.TabIndex = 0;
            this.lblClassification.Text = "Classification";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.splitContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1507, 742);
            this.pnlContent.TabIndex = 0;
            // 
            // splitContent
            // 
            this.splitContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContent.Location = new System.Drawing.Point(2, 2);
            this.splitContent.Name = "splitContent";
            // 
            // splitContent.Panel1
            // 
            this.splitContent.Panel1.Controls.Add(this.treeCategories);
            this.splitContent.Panel1.Text = "Panel1";
            // 
            // splitContent.Panel2
            // 
            this.splitContent.Panel2.Text = "Panel2";
            this.splitContent.Size = new System.Drawing.Size(1503, 738);
            this.splitContent.SplitterPosition = 313;
            this.splitContent.TabIndex = 0;
            // 
            // treeCategories
            // 
            this.treeCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategories.Location = new System.Drawing.Point(0, 0);
            this.treeCategories.Name = "treeCategories";
            this.treeCategories.Size = new System.Drawing.Size(313, 738);
            this.treeCategories.TabIndex = 0;
            // 
            // CategoriesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 852);
            this.Controls.Add(this.splitMain);
            this.Name = "CategoriesManager";
            this.Text = "Categories Manager";
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContent)).EndInit();
            this.splitContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.SplitContainerControl splitContent;
        private DevExpress.XtraTreeList.TreeList treeCategories;
        private ComboBox cmbClassifications;
        private DevExpress.XtraEditors.LabelControl lblClassification;
    }
}