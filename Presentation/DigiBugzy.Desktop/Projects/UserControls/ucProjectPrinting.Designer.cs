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
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
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
            this.splitBackground.Panel1.Controls.Add(this.progressPanel1);
            this.splitBackground.Panel1.Controls.Add(this.gridListing);
            this.splitBackground.Panel1.Text = "Panel1";
            // 
            // splitBackground.Panel2
            // 
            this.splitBackground.Panel2.Text = "Panel2";
            this.splitBackground.Size = new System.Drawing.Size(1902, 1096);
            this.splitBackground.SplitterPosition = 1431;
            this.splitBackground.TabIndex = 0;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Location = new System.Drawing.Point(584, 369);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 66);
            this.progressPanel1.TabIndex = 0;
            this.progressPanel1.Text = "progressPanel1";
            this.progressPanel1.Visible = false;
            // 
            // gridListing
            // 
            this.gridListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListing.Location = new System.Drawing.Point(0, 0);
            this.gridListing.MainView = this.gvListing;
            this.gridListing.Name = "gridListing";
            this.gridListing.Size = new System.Drawing.Size(1431, 1096);
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
            // ucProjectPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitBackground);
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
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private BindingSource bsProjects;
        private BindingSource bindingSource2;
        private BindingSource bindingSource3;
    }
}
