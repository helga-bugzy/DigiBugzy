namespace DigiBugzy.Desktop.Projects.UserControls
{
    partial class ucProjectPrinting
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
            this.components = new System.ComponentModel.Container();
            this.splitBackground = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridListing = new DevExpress.XtraGrid.GridControl();
            this.gvListing = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbProjectInfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gbFileInfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgPrintingInfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gbFilamentInfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gbPrintingSettings = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gbTimeINfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bsListing = new System.Windows.Forms.BindingSource(this.components);
            this.bsProjects = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.splitContent = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitBackground.Panel1)).BeginInit();
            this.splitBackground.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBackground.Panel2)).BeginInit();
            this.splitBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel1)).BeginInit();
            this.splitContent.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel2)).BeginInit();
            this.splitContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitBackground
            // 
            this.splitBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBackground.Location = new System.Drawing.Point(0, 0);
            this.splitBackground.Name = "splitBackground";
            // 
            // splitBackground.Panel1
            // 
            this.splitBackground.Panel1.Controls.Add(this.gridListing);
            this.splitBackground.Panel1.Text = "Panel1";
            // 
            // splitBackground.Panel2
            // 
            this.splitBackground.Panel2.Text = "Panel2";
            this.splitBackground.Size = new System.Drawing.Size(1902, 818);
            this.splitBackground.SplitterPosition = 1155;
            this.splitBackground.TabIndex = 0;
            // 
            // gridListing
            // 
            this.gridListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListing.Location = new System.Drawing.Point(0, 0);
            this.gridListing.MainView = this.gvListing;
            this.gridListing.Name = "gridListing";
            this.gridListing.Size = new System.Drawing.Size(1155, 818);
            this.gridListing.TabIndex = 0;
            this.gridListing.UseEmbeddedNavigator = true;
            this.gridListing.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListing});
            // 
            // gvListing
            // 
            this.gvListing.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbProjectInfo,
            this.gbFileInfo,
            this.bgPrintingInfo,
            this.gbFilamentInfo,
            this.gbPrintingSettings,
            this.gbTimeINfo});
            this.gvListing.GridControl = this.gridListing;
            this.gvListing.Name = "gvListing";
            this.gvListing.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvListing.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvListing.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gvListing.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvListing.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvListing_RowUpdated);
            // 
            // gbProjectInfo
            // 
            this.gbProjectInfo.Caption = "Project Info";
            this.gbProjectInfo.Name = "gbProjectInfo";
            this.gbProjectInfo.VisibleIndex = 0;
            // 
            // gbFileInfo
            // 
            this.gbFileInfo.Caption = "File Info";
            this.gbFileInfo.Name = "gbFileInfo";
            this.gbFileInfo.VisibleIndex = 1;
            // 
            // bgPrintingInfo
            // 
            this.bgPrintingInfo.Caption = "Printing Info";
            this.bgPrintingInfo.Name = "bgPrintingInfo";
            this.bgPrintingInfo.VisibleIndex = 2;
            // 
            // gbFilamentInfo
            // 
            this.gbFilamentInfo.Caption = "Filament Info";
            this.gbFilamentInfo.Name = "gbFilamentInfo";
            this.gbFilamentInfo.VisibleIndex = 3;
            // 
            // gbPrintingSettings
            // 
            this.gbPrintingSettings.Caption = "Printing Settings";
            this.gbPrintingSettings.Name = "gbPrintingSettings";
            this.gbPrintingSettings.VisibleIndex = 4;
            // 
            // gbTimeINfo
            // 
            this.gbTimeINfo.Caption = "Time Info";
            this.gbTimeINfo.Name = "gbTimeINfo";
            this.gbTimeINfo.VisibleIndex = 5;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Horizontal = false;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.splitMain_Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlFilter);
            this.splitMain.Panel1.Text = "Panel1";
            // 
            // splitMain.splitMain_Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitContent);
            this.splitMain.Panel2.Text = "Panel2";
            this.splitMain.Size = new System.Drawing.Size(1902, 1096);
            this.splitMain.SplitterPosition = 54;
            this.splitMain.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.checkEdit3);
            this.pnlFilter.Controls.Add(this.checkEdit2);
            this.pnlFilter.Controls.Add(this.checkEdit1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1902, 54);
            this.pnlFilter.TabIndex = 0;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(22, 19);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "checkEdit1";
            this.checkEdit1.Size = new System.Drawing.Size(75, 20);
            this.checkEdit1.TabIndex = 0;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(111, 18);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "checkEdit2";
            this.checkEdit2.Size = new System.Drawing.Size(75, 20);
            this.checkEdit2.TabIndex = 1;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(203, 19);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "checkEdit3";
            this.checkEdit3.Size = new System.Drawing.Size(75, 20);
            this.checkEdit3.TabIndex = 2;
            // 
            // splitContent
            // 
            this.splitContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContent.Horizontal = false;
            this.splitContent.Location = new System.Drawing.Point(0, 0);
            this.splitContent.Name = "splitContent";
            // 
            // splitContent.splitContent_Panel1
            // 
            this.splitContent.Panel1.Controls.Add(this.splitBackground);
            this.splitContent.Panel1.Text = "Panel1";
            // 
            // splitContent.splitContent_Panel2
            // 
            this.splitContent.Panel2.Text = "Panel2";
            this.splitContent.Size = new System.Drawing.Size(1902, 1032);
            this.splitContent.SplitterPosition = 818;
            this.splitContent.TabIndex = 0;
            // 
            // ucProjectPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Name = "ucProjectPrinting";
            this.Size = new System.Drawing.Size(1902, 1096);
            ((System.ComponentModel.ISupportInitialize)(this.splitBackground.Panel1)).EndInit();
            this.splitBackground.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBackground.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitBackground)).EndInit();
            this.splitBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel1)).EndInit();
            this.splitContent.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContent.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContent)).EndInit();
            this.splitContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitBackground;
        private DevExpress.XtraGrid.GridControl gridListing;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvListing;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbProjectInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbFileInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bgPrintingInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbFilamentInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbPrintingSettings;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbTimeINfo;
        private BindingSource bsListing;
        private BindingSource bsProjects;
        private BindingSource bindingSource2;
        private BindingSource bindingSource3;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.SplitContainerControl splitContent;
    }
}
