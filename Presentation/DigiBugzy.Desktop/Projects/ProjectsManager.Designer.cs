namespace DigiBugzy.Desktop.Projects
{
    partial class ProjectsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectsManager));
            DigiBugzy.Data.Common.xBaseObjects.FilterObjects.ProjectDocumentFilter projectDocumentFilter4 = new DigiBugzy.Data.Common.xBaseObjects.FilterObjects.ProjectDocumentFilter();
            DigiBugzy.Core.Domain.Projects.ProjectDocument projectDocument4 = new DigiBugzy.Core.Domain.Projects.ProjectDocument();
            this.pnlManager = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitGridsMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.pgProject = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridProjects = new DevExpress.XtraGrid.GridControl();
            this.gvProjects = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.butProjectsFilter = new DevExpress.XtraEditors.SimpleButton();
            this.txtFilterProjectName = new DevExpress.XtraEditors.TextEdit();
            this.lblProjects = new System.Windows.Forms.Label();
            this.splitGridsSubs = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.pgSection = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridProjectSections = new DevExpress.XtraGrid.GridControl();
            this.gvProjectSections = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnProjectsSectionsFilter = new DevExpress.XtraEditors.SimpleButton();
            this.txtFilterProjectSectionName = new DevExpress.XtraEditors.TextEdit();
            this.lblProjectSections = new System.Windows.Forms.Label();
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.pgParts = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridProjectSectionParts = new DevExpress.XtraGrid.GridControl();
            this.gvProjectSectionParts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.butProjectsSectionPartsFilter = new DevExpress.XtraEditors.SimpleButton();
            this.txtFilterProjectSectionPartName = new DevExpress.XtraEditors.TextEdit();
            this.lblProjectSectionParts = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tabEditors = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabProjectEditors = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panelControl10 = new DevExpress.XtraEditors.PanelControl();
            this.tabPane2 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabProjectEditor = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.pnlProject_Editor = new DevExpress.XtraEditors.PanelControl();
            this.txtProjectDescription = new System.Windows.Forms.TextBox();
            this.lblProjectSelectedFileName = new System.Windows.Forms.Label();
            this.imgProjectPhoto = new System.Windows.Forms.PictureBox();
            this.btnProjectImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnProjectRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnProjectDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnProjectSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnProjectAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.chkProjectActive = new System.Windows.Forms.CheckBox();
            this.lblProjectActive = new System.Windows.Forms.Label();
            this.txtProject_Name = new DevExpress.XtraEditors.TextEdit();
            this.lblProjectDescription = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnSampleDataDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSampleData = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabSectionEditors = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panelControl12 = new DevExpress.XtraEditors.PanelControl();
            this.tabPane3 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabSectionEditor = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.pnlSectionEditor = new DevExpress.XtraEditors.PanelControl();
            this.lblSectopmActive = new System.Windows.Forms.Label();
            this.lblSectionSelectedFileName = new System.Windows.Forms.Label();
            this.imgSectionPhoto = new System.Windows.Forms.PictureBox();
            this.btnSectionvImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnSectionRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnSectionDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSectionSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSectionAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.chkSectionActive = new System.Windows.Forms.CheckBox();
            this.txtSectionDescription = new System.Windows.Forms.TextBox();
            this.txtSectionName = new DevExpress.XtraEditors.TextEdit();
            this.lblSectionDescription = new System.Windows.Forms.Label();
            this.lblSectionName = new System.Windows.Forms.Label();
            this.panelControl11 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tabPartsEditors = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panelControl14 = new DevExpress.XtraEditors.PanelControl();
            this.tabPane4 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabPartsEditor = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.pnlPartsEdtior = new DevExpress.XtraEditors.PanelControl();
            this.lblPartSelectedFileName = new System.Windows.Forms.Label();
            this.imgPartPhoto = new System.Windows.Forms.PictureBox();
            this.btnPartImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnPartRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnPartDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnPartSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnPartAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.chkPartActive = new System.Windows.Forms.CheckBox();
            this.lblPartvActive = new System.Windows.Forms.Label();
            this.txtPartDescription = new System.Windows.Forms.TextBox();
            this.txtPartName = new DevExpress.XtraEditors.TextEdit();
            this.lblPartDescription = new System.Windows.Forms.Label();
            this.lblPartName = new System.Windows.Forms.Label();
            this.tabPartsProducts = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panelControl13 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tabDocumentsManager = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.ucProjectDocs1 = new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocs();
            this.dlgProjectImage = new System.Windows.Forms.OpenFileDialog();
            this.dlgProjectSectionPhoto = new System.Windows.Forms.OpenFileDialog();
            this.dlgProjectSectionPartPhoto = new System.Windows.Forms.OpenFileDialog();
            this.bsProjects = new System.Windows.Forms.BindingSource(this.components);
            this.bsSections = new System.Windows.Forms.BindingSource(this.components);
            this.bsParts = new System.Windows.Forms.BindingSource(this.components);
            this.bsProjectPartDocuments = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlManager)).BeginInit();
            this.pnlManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsMain.Panel1)).BeginInit();
            this.splitGridsMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsMain.Panel2)).BeginInit();
            this.splitGridsMain.Panel2.SuspendLayout();
            this.splitGridsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsSubs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsSubs.Panel1)).BeginInit();
            this.splitGridsSubs.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsSubs.Panel2)).BeginInit();
            this.splitGridsSubs.Panel2.SuspendLayout();
            this.splitGridsSubs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectSections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjectSections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterProjectSectionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            this.panelControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectSectionParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjectSectionParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterProjectSectionPartName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabEditors)).BeginInit();
            this.tabEditors.SuspendLayout();
            this.tabProjectEditors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl10)).BeginInit();
            this.panelControl10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane2)).BeginInit();
            this.tabPane2.SuspendLayout();
            this.tabProjectEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProject_Editor)).BeginInit();
            this.pnlProject_Editor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProjectPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).BeginInit();
            this.panelControl9.SuspendLayout();
            this.tabSectionEditors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).BeginInit();
            this.panelControl12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane3)).BeginInit();
            this.tabPane3.SuspendLayout();
            this.tabSectionEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSectionEditor)).BeginInit();
            this.pnlSectionEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSectionPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSectionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).BeginInit();
            this.panelControl11.SuspendLayout();
            this.tabPartsEditors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).BeginInit();
            this.panelControl14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane4)).BeginInit();
            this.tabPane4.SuspendLayout();
            this.tabPartsEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPartsEdtior)).BeginInit();
            this.pnlPartsEdtior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPartPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl13)).BeginInit();
            this.panelControl13.SuspendLayout();
            this.tabDocumentsManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjectPartDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlManager
            // 
            this.pnlManager.Controls.Add(this.panelControl1);
            this.pnlManager.Controls.Add(this.panelControl2);
            this.pnlManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlManager.Location = new System.Drawing.Point(0, 0);
            this.pnlManager.Name = "pnlManager";
            this.pnlManager.Size = new System.Drawing.Size(2250, 1144);
            this.pnlManager.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitGridsMain);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(2246, 634);
            this.panelControl1.TabIndex = 2;
            // 
            // splitGridsMain
            // 
            this.splitGridsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitGridsMain.Location = new System.Drawing.Point(2, 2);
            this.splitGridsMain.Name = "splitGridsMain";
            // 
            // splitGridsMain.Panel1
            // 
            this.splitGridsMain.Panel1.Controls.Add(this.panelControl6);
            this.splitGridsMain.Panel1.Controls.Add(this.panelControl3);
            this.splitGridsMain.Panel1.Text = "Panel1";
            // 
            // splitGridsMain.Panel2
            // 
            this.splitGridsMain.Panel2.Controls.Add(this.splitGridsSubs);
            this.splitGridsMain.Panel2.Text = "Panel2";
            this.splitGridsMain.Size = new System.Drawing.Size(2242, 630);
            this.splitGridsMain.SplitterPosition = 637;
            this.splitGridsMain.TabIndex = 0;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.pgProject);
            this.panelControl6.Controls.Add(this.gridProjects);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl6.Location = new System.Drawing.Point(0, 37);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(637, 593);
            this.panelControl6.TabIndex = 2;
            // 
            // pgProject
            // 
            this.pgProject.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pgProject.Appearance.Options.UseBackColor = true;
            this.pgProject.Location = new System.Drawing.Point(205, 146);
            this.pgProject.Name = "pgProject";
            this.pgProject.Size = new System.Drawing.Size(245, 70);
            this.pgProject.TabIndex = 36;
            this.pgProject.Text = "progressPanel1";
            this.pgProject.Visible = false;
            // 
            // gridProjects
            // 
            this.gridProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProjects.Location = new System.Drawing.Point(2, 2);
            this.gridProjects.MainView = this.gvProjects;
            this.gridProjects.Name = "gridProjects";
            this.gridProjects.Size = new System.Drawing.Size(633, 589);
            this.gridProjects.TabIndex = 0;
            this.gridProjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProjects});
            // 
            // gvProjects
            // 
            this.gvProjects.GridControl = this.gridProjects;
            this.gvProjects.Name = "gvProjects";
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.LightSlateGray;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.butProjectsFilter);
            this.panelControl3.Controls.Add(this.txtFilterProjectName);
            this.panelControl3.Controls.Add(this.lblProjects);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(637, 37);
            this.panelControl3.TabIndex = 1;
            // 
            // butProjectsFilter
            // 
            this.butProjectsFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("butProjectsFilter.ImageOptions.Image")));
            this.butProjectsFilter.Location = new System.Drawing.Point(261, 10);
            this.butProjectsFilter.Name = "butProjectsFilter";
            this.butProjectsFilter.Size = new System.Drawing.Size(25, 23);
            this.butProjectsFilter.TabIndex = 2;
            this.butProjectsFilter.Click += new System.EventHandler(this.butProjectsFilter_Click);
            // 
            // txtFilterProjectName
            // 
            this.txtFilterProjectName.Location = new System.Drawing.Point(55, 10);
            this.txtFilterProjectName.Name = "txtFilterProjectName";
            this.txtFilterProjectName.Size = new System.Drawing.Size(200, 20);
            this.txtFilterProjectName.TabIndex = 1;
            // 
            // lblProjects
            // 
            this.lblProjects.AutoSize = true;
            this.lblProjects.ForeColor = System.Drawing.Color.White;
            this.lblProjects.Location = new System.Drawing.Point(2, 8);
            this.lblProjects.Name = "lblProjects";
            this.lblProjects.Size = new System.Drawing.Size(46, 13);
            this.lblProjects.TabIndex = 0;
            this.lblProjects.Text = "Projects";
            // 
            // splitGridsSubs
            // 
            this.splitGridsSubs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitGridsSubs.Location = new System.Drawing.Point(0, 0);
            this.splitGridsSubs.Name = "splitGridsSubs";
            // 
            // splitGridsSubs.Panel1
            // 
            this.splitGridsSubs.Panel1.Controls.Add(this.panelControl7);
            this.splitGridsSubs.Panel1.Controls.Add(this.panelControl4);
            this.splitGridsSubs.Panel1.Text = "Panel1";
            // 
            // splitGridsSubs.Panel2
            // 
            this.splitGridsSubs.Panel2.Controls.Add(this.panelControl8);
            this.splitGridsSubs.Panel2.Controls.Add(this.panelControl5);
            this.splitGridsSubs.Panel2.Text = "Panel2";
            this.splitGridsSubs.Size = new System.Drawing.Size(1595, 630);
            this.splitGridsSubs.SplitterPosition = 866;
            this.splitGridsSubs.TabIndex = 0;
            // 
            // panelControl7
            // 
            this.panelControl7.Controls.Add(this.pgSection);
            this.panelControl7.Controls.Add(this.gridProjectSections);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl7.Location = new System.Drawing.Point(0, 37);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(866, 593);
            this.panelControl7.TabIndex = 2;
            // 
            // pgSection
            // 
            this.pgSection.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pgSection.Appearance.Options.UseBackColor = true;
            this.pgSection.Location = new System.Drawing.Point(226, 146);
            this.pgSection.Name = "pgSection";
            this.pgSection.Size = new System.Drawing.Size(259, 70);
            this.pgSection.TabIndex = 36;
            this.pgSection.Text = "progressPanel1";
            this.pgSection.Visible = false;
            // 
            // gridProjectSections
            // 
            this.gridProjectSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProjectSections.Location = new System.Drawing.Point(2, 2);
            this.gridProjectSections.MainView = this.gvProjectSections;
            this.gridProjectSections.Name = "gridProjectSections";
            this.gridProjectSections.Size = new System.Drawing.Size(862, 589);
            this.gridProjectSections.TabIndex = 0;
            this.gridProjectSections.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProjectSections});
            // 
            // gvProjectSections
            // 
            this.gvProjectSections.GridControl = this.gridProjectSections;
            this.gvProjectSections.Name = "gvProjectSections";
            this.gvProjectSections.Click += new System.EventHandler(this.bsProjects_PositionChanged);
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.Color.CadetBlue;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.btnProjectsSectionsFilter);
            this.panelControl4.Controls.Add(this.txtFilterProjectSectionName);
            this.panelControl4.Controls.Add(this.lblProjectSections);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(866, 37);
            this.panelControl4.TabIndex = 1;
            // 
            // btnProjectsSectionsFilter
            // 
            this.btnProjectsSectionsFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectsSectionsFilter.ImageOptions.Image")));
            this.btnProjectsSectionsFilter.Location = new System.Drawing.Point(299, 7);
            this.btnProjectsSectionsFilter.Name = "btnProjectsSectionsFilter";
            this.btnProjectsSectionsFilter.Size = new System.Drawing.Size(25, 23);
            this.btnProjectsSectionsFilter.TabIndex = 3;
            this.btnProjectsSectionsFilter.Click += new System.EventHandler(this.btnProjectsSectionsFilter_Click);
            // 
            // txtFilterProjectSectionName
            // 
            this.txtFilterProjectSectionName.Location = new System.Drawing.Point(93, 8);
            this.txtFilterProjectSectionName.Name = "txtFilterProjectSectionName";
            this.txtFilterProjectSectionName.Size = new System.Drawing.Size(200, 20);
            this.txtFilterProjectSectionName.TabIndex = 1;
            // 
            // lblProjectSections
            // 
            this.lblProjectSections.AutoSize = true;
            this.lblProjectSections.ForeColor = System.Drawing.Color.White;
            this.lblProjectSections.Location = new System.Drawing.Point(2, 8);
            this.lblProjectSections.Name = "lblProjectSections";
            this.lblProjectSections.Size = new System.Drawing.Size(84, 13);
            this.lblProjectSections.TabIndex = 0;
            this.lblProjectSections.Text = "Project Sections";
            // 
            // panelControl8
            // 
            this.panelControl8.Controls.Add(this.pgParts);
            this.panelControl8.Controls.Add(this.gridProjectSectionParts);
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl8.Location = new System.Drawing.Point(0, 37);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Size = new System.Drawing.Size(719, 593);
            this.panelControl8.TabIndex = 1;
            // 
            // pgParts
            // 
            this.pgParts.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pgParts.Appearance.Options.UseBackColor = true;
            this.pgParts.Location = new System.Drawing.Point(173, 146);
            this.pgParts.Name = "pgParts";
            this.pgParts.Size = new System.Drawing.Size(246, 66);
            this.pgParts.TabIndex = 36;
            this.pgParts.Text = "progressPanel1";
            this.pgParts.Visible = false;
            // 
            // gridProjectSectionParts
            // 
            this.gridProjectSectionParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProjectSectionParts.Location = new System.Drawing.Point(2, 2);
            this.gridProjectSectionParts.MainView = this.gvProjectSectionParts;
            this.gridProjectSectionParts.Name = "gridProjectSectionParts";
            this.gridProjectSectionParts.Size = new System.Drawing.Size(715, 589);
            this.gridProjectSectionParts.TabIndex = 0;
            this.gridProjectSectionParts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProjectSectionParts});
            // 
            // gvProjectSectionParts
            // 
            this.gvProjectSectionParts.GridControl = this.gridProjectSectionParts;
            this.gvProjectSectionParts.Name = "gvProjectSectionParts";
            // 
            // panelControl5
            // 
            this.panelControl5.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelControl5.Appearance.Options.UseBackColor = true;
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.butProjectsSectionPartsFilter);
            this.panelControl5.Controls.Add(this.txtFilterProjectSectionPartName);
            this.panelControl5.Controls.Add(this.lblProjectSectionParts);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(719, 37);
            this.panelControl5.TabIndex = 0;
            // 
            // butProjectsSectionPartsFilter
            // 
            this.butProjectsSectionPartsFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("butProjectsSectionPartsFilter.ImageOptions.Image")));
            this.butProjectsSectionPartsFilter.Location = new System.Drawing.Point(327, 11);
            this.butProjectsSectionPartsFilter.Name = "butProjectsSectionPartsFilter";
            this.butProjectsSectionPartsFilter.Size = new System.Drawing.Size(25, 23);
            this.butProjectsSectionPartsFilter.TabIndex = 3;
            this.butProjectsSectionPartsFilter.Click += new System.EventHandler(this.butProjectsSectionPartsFilter_Click);
            // 
            // txtFilterProjectSectionPartName
            // 
            this.txtFilterProjectSectionPartName.Location = new System.Drawing.Point(121, 11);
            this.txtFilterProjectSectionPartName.Name = "txtFilterProjectSectionPartName";
            this.txtFilterProjectSectionPartName.Size = new System.Drawing.Size(200, 20);
            this.txtFilterProjectSectionPartName.TabIndex = 1;
            // 
            // lblProjectSectionParts
            // 
            this.lblProjectSectionParts.AutoSize = true;
            this.lblProjectSectionParts.ForeColor = System.Drawing.Color.White;
            this.lblProjectSectionParts.Location = new System.Drawing.Point(2, 10);
            this.lblProjectSectionParts.Name = "lblProjectSectionParts";
            this.lblProjectSectionParts.Size = new System.Drawing.Size(107, 13);
            this.lblProjectSectionParts.TabIndex = 0;
            this.lblProjectSectionParts.Text = "Project Section Parts";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tabEditors);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 636);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(2246, 506);
            this.panelControl2.TabIndex = 1;
            // 
            // tabEditors
            // 
            this.tabEditors.Controls.Add(this.tabProjectEditors);
            this.tabEditors.Controls.Add(this.tabSectionEditors);
            this.tabEditors.Controls.Add(this.tabPartsEditors);
            this.tabEditors.Controls.Add(this.tabDocumentsManager);
            this.tabEditors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEditors.Location = new System.Drawing.Point(2, 2);
            this.tabEditors.Name = "tabEditors";
            this.tabEditors.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabProjectEditors,
            this.tabSectionEditors,
            this.tabPartsEditors,
            this.tabDocumentsManager});
            this.tabEditors.RegularSize = new System.Drawing.Size(2242, 502);
            this.tabEditors.SelectedPage = this.tabProjectEditors;
            this.tabEditors.Size = new System.Drawing.Size(2242, 502);
            this.tabEditors.TabIndex = 2;
            this.tabEditors.Text = "tabPane1";
            // 
            // tabProjectEditors
            // 
            this.tabProjectEditors.Appearance.Options.UseTextOptions = true;
            this.tabProjectEditors.Caption = "Project Editors";
            this.tabProjectEditors.Controls.Add(this.panelControl10);
            this.tabProjectEditors.Controls.Add(this.panelControl9);
            this.tabProjectEditors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabProjectEditors.ImageOptions.Image")));
            this.tabProjectEditors.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabProjectEditors.Name = "tabProjectEditors";
            this.tabProjectEditors.Properties.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.tabProjectEditors.Properties.AppearanceCaption.Options.UseFont = true;
            this.tabProjectEditors.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabProjectEditors.Size = new System.Drawing.Size(2242, 469);
            // 
            // panelControl10
            // 
            this.panelControl10.Controls.Add(this.tabPane2);
            this.panelControl10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl10.Location = new System.Drawing.Point(0, 38);
            this.panelControl10.Name = "panelControl10";
            this.panelControl10.Size = new System.Drawing.Size(2242, 431);
            this.panelControl10.TabIndex = 2;
            // 
            // tabPane2
            // 
            this.tabPane2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tabPane2.Appearance.Options.UseBackColor = true;
            this.tabPane2.Controls.Add(this.tabProjectEditor);
            this.tabPane2.Location = new System.Drawing.Point(2, 2);
            this.tabPane2.Name = "tabPane2";
            this.tabPane2.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabProjectEditor});
            this.tabPane2.RegularSize = new System.Drawing.Size(2238, 427);
            this.tabPane2.SelectedPage = this.tabProjectEditor;
            this.tabPane2.Size = new System.Drawing.Size(2238, 427);
            this.tabPane2.TabIndex = 0;
            this.tabPane2.Text = "tabPane2";
            // 
            // tabProjectEditor
            // 
            this.tabProjectEditor.Caption = "Project Editor";
            this.tabProjectEditor.Controls.Add(this.pnlProject_Editor);
            this.tabProjectEditor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabProjectEditor.ImageOptions.Image")));
            this.tabProjectEditor.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabProjectEditor.Name = "tabProjectEditor";
            this.tabProjectEditor.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabProjectEditor.Size = new System.Drawing.Size(2238, 394);
            // 
            // pnlProject_Editor
            // 
            this.pnlProject_Editor.Appearance.BackColor = System.Drawing.Color.LightSlateGray;
            this.pnlProject_Editor.Appearance.Options.UseBackColor = true;
            this.pnlProject_Editor.Controls.Add(this.txtProjectDescription);
            this.pnlProject_Editor.Controls.Add(this.lblProjectSelectedFileName);
            this.pnlProject_Editor.Controls.Add(this.imgProjectPhoto);
            this.pnlProject_Editor.Controls.Add(this.btnProjectImage);
            this.pnlProject_Editor.Controls.Add(this.btnProjectRestore);
            this.pnlProject_Editor.Controls.Add(this.btnProjectDelete);
            this.pnlProject_Editor.Controls.Add(this.btnProjectSave);
            this.pnlProject_Editor.Controls.Add(this.btnProjectAddNew);
            this.pnlProject_Editor.Controls.Add(this.chkProjectActive);
            this.pnlProject_Editor.Controls.Add(this.lblProjectActive);
            this.pnlProject_Editor.Controls.Add(this.txtProject_Name);
            this.pnlProject_Editor.Controls.Add(this.lblProjectDescription);
            this.pnlProject_Editor.Controls.Add(this.lblProjectName);
            this.pnlProject_Editor.Controls.Add(this.btnSampleDataDelete);
            this.pnlProject_Editor.Controls.Add(this.btnSampleData);
            this.pnlProject_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProject_Editor.Location = new System.Drawing.Point(0, 0);
            this.pnlProject_Editor.Name = "pnlProject_Editor";
            this.pnlProject_Editor.Size = new System.Drawing.Size(2238, 394);
            this.pnlProject_Editor.TabIndex = 2;
            // 
            // txtProjectDescription
            // 
            this.txtProjectDescription.Location = new System.Drawing.Point(115, 54);
            this.txtProjectDescription.MaxLength = 255;
            this.txtProjectDescription.Multiline = true;
            this.txtProjectDescription.Name = "txtProjectDescription";
            this.txtProjectDescription.Size = new System.Drawing.Size(364, 116);
            this.txtProjectDescription.TabIndex = 35;
            // 
            // lblProjectSelectedFileName
            // 
            this.lblProjectSelectedFileName.AutoSize = true;
            this.lblProjectSelectedFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectSelectedFileName.Location = new System.Drawing.Point(529, 294);
            this.lblProjectSelectedFileName.Name = "lblProjectSelectedFileName";
            this.lblProjectSelectedFileName.Size = new System.Drawing.Size(15, 13);
            this.lblProjectSelectedFileName.TabIndex = 34;
            this.lblProjectSelectedFileName.Text = "..";
            // 
            // imgProjectPhoto
            // 
            this.imgProjectPhoto.BackColor = System.Drawing.Color.Transparent;
            this.imgProjectPhoto.Location = new System.Drawing.Point(531, 24);
            this.imgProjectPhoto.Name = "imgProjectPhoto";
            this.imgProjectPhoto.Size = new System.Drawing.Size(465, 256);
            this.imgProjectPhoto.TabIndex = 33;
            this.imgProjectPhoto.TabStop = false;
            // 
            // btnProjectImage
            // 
            this.btnProjectImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectImage.ImageOptions.Image")));
            this.btnProjectImage.Location = new System.Drawing.Point(389, 291);
            this.btnProjectImage.Name = "btnProjectImage";
            this.btnProjectImage.Size = new System.Drawing.Size(104, 30);
            this.btnProjectImage.TabIndex = 32;
            this.btnProjectImage.Text = "Select Image";
            this.btnProjectImage.Click += new System.EventHandler(this.btnProjectImage_Click);
            // 
            // btnProjectRestore
            // 
            this.btnProjectRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectRestore.ImageOptions.Image")));
            this.btnProjectRestore.Location = new System.Drawing.Point(305, 338);
            this.btnProjectRestore.Name = "btnProjectRestore";
            this.btnProjectRestore.Size = new System.Drawing.Size(88, 32);
            this.btnProjectRestore.TabIndex = 31;
            this.btnProjectRestore.Text = "Restore";
            this.btnProjectRestore.Click += new System.EventHandler(this.btnProjectRestore_Click);
            // 
            // btnProjectDelete
            // 
            this.btnProjectDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectDelete.ImageOptions.Image")));
            this.btnProjectDelete.Location = new System.Drawing.Point(203, 339);
            this.btnProjectDelete.Name = "btnProjectDelete";
            this.btnProjectDelete.Size = new System.Drawing.Size(88, 32);
            this.btnProjectDelete.TabIndex = 29;
            this.btnProjectDelete.Text = "Delete";
            this.btnProjectDelete.Click += new System.EventHandler(this.btnProjectDelete_Click);
            // 
            // btnProjectSave
            // 
            this.btnProjectSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectSave.ImageOptions.Image")));
            this.btnProjectSave.Location = new System.Drawing.Point(407, 339);
            this.btnProjectSave.Name = "btnProjectSave";
            this.btnProjectSave.Size = new System.Drawing.Size(88, 32);
            this.btnProjectSave.TabIndex = 28;
            this.btnProjectSave.Text = "Save";
            this.btnProjectSave.Click += new System.EventHandler(this.btnProjectSave_Click);
            // 
            // btnProjectAddNew
            // 
            this.btnProjectAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectAddNew.ImageOptions.Image")));
            this.btnProjectAddNew.Location = new System.Drawing.Point(101, 338);
            this.btnProjectAddNew.Name = "btnProjectAddNew";
            this.btnProjectAddNew.Size = new System.Drawing.Size(88, 32);
            this.btnProjectAddNew.TabIndex = 30;
            this.btnProjectAddNew.Text = "Add New";
            this.btnProjectAddNew.Click += new System.EventHandler(this.btnProjectAddNew_Click);
            // 
            // chkProjectActive
            // 
            this.chkProjectActive.AutoSize = true;
            this.chkProjectActive.Location = new System.Drawing.Point(95, 294);
            this.chkProjectActive.Name = "chkProjectActive";
            this.chkProjectActive.Size = new System.Drawing.Size(15, 14);
            this.chkProjectActive.TabIndex = 27;
            this.chkProjectActive.UseVisualStyleBackColor = true;
            // 
            // lblProjectActive
            // 
            this.lblProjectActive.AutoSize = true;
            this.lblProjectActive.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectActive.ForeColor = System.Drawing.Color.Black;
            this.lblProjectActive.Location = new System.Drawing.Point(8, 294);
            this.lblProjectActive.Name = "lblProjectActive";
            this.lblProjectActive.Size = new System.Drawing.Size(41, 13);
            this.lblProjectActive.TabIndex = 26;
            this.lblProjectActive.Text = "Active:";
            // 
            // txtProject_Name
            // 
            this.txtProject_Name.Location = new System.Drawing.Point(115, 21);
            this.txtProject_Name.Name = "txtProject_Name";
            this.txtProject_Name.Size = new System.Drawing.Size(364, 20);
            this.txtProject_Name.TabIndex = 24;
            // 
            // lblProjectDescription
            // 
            this.lblProjectDescription.AutoSize = true;
            this.lblProjectDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectDescription.ForeColor = System.Drawing.Color.Black;
            this.lblProjectDescription.Location = new System.Drawing.Point(8, 57);
            this.lblProjectDescription.Name = "lblProjectDescription";
            this.lblProjectDescription.Size = new System.Drawing.Size(101, 13);
            this.lblProjectDescription.TabIndex = 23;
            this.lblProjectDescription.Text = "Project Description:";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectName.ForeColor = System.Drawing.Color.Black;
            this.lblProjectName.Location = new System.Drawing.Point(8, 22);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(75, 13);
            this.lblProjectName.TabIndex = 22;
            this.lblProjectName.Text = "Project Name:";
            // 
            // btnSampleDataDelete
            // 
            this.btnSampleDataDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSampleDataDelete.ImageOptions.Image")));
            this.btnSampleDataDelete.Location = new System.Drawing.Point(666, 339);
            this.btnSampleDataDelete.Name = "btnSampleDataDelete";
            this.btnSampleDataDelete.Size = new System.Drawing.Size(129, 34);
            this.btnSampleDataDelete.TabIndex = 21;
            this.btnSampleDataDelete.Text = "Delete Sample Data";
            this.btnSampleDataDelete.Click += new System.EventHandler(this.btnSampleDataDelete_Click);
            // 
            // btnSampleData
            // 
            this.btnSampleData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSampleData.ImageOptions.Image")));
            this.btnSampleData.Location = new System.Drawing.Point(531, 339);
            this.btnSampleData.Name = "btnSampleData";
            this.btnSampleData.Size = new System.Drawing.Size(129, 34);
            this.btnSampleData.TabIndex = 20;
            this.btnSampleData.Text = "Create Sample Data";
            this.btnSampleData.Click += new System.EventHandler(this.btnSampleData_Click);
            // 
            // panelControl9
            // 
            this.panelControl9.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.panelControl9.Appearance.Options.UseBackColor = true;
            this.panelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl9.Controls.Add(this.labelControl1);
            this.panelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl9.Location = new System.Drawing.Point(0, 0);
            this.panelControl9.Name = "panelControl9";
            this.panelControl9.Size = new System.Drawing.Size(2242, 38);
            this.panelControl9.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Project Editors";
            // 
            // tabSectionEditors
            // 
            this.tabSectionEditors.Caption = "Section Editors";
            this.tabSectionEditors.Controls.Add(this.panelControl12);
            this.tabSectionEditors.Controls.Add(this.panelControl11);
            this.tabSectionEditors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabSectionEditors.ImageOptions.Image")));
            this.tabSectionEditors.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabSectionEditors.Name = "tabSectionEditors";
            this.tabSectionEditors.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabSectionEditors.Size = new System.Drawing.Size(2242, 469);
            // 
            // panelControl12
            // 
            this.panelControl12.Controls.Add(this.tabPane3);
            this.panelControl12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl12.Location = new System.Drawing.Point(0, 38);
            this.panelControl12.Name = "panelControl12";
            this.panelControl12.Size = new System.Drawing.Size(2242, 431);
            this.panelControl12.TabIndex = 3;
            // 
            // tabPane3
            // 
            this.tabPane3.Controls.Add(this.tabSectionEditor);
            this.tabPane3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane3.Location = new System.Drawing.Point(2, 2);
            this.tabPane3.Name = "tabPane3";
            this.tabPane3.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabSectionEditor});
            this.tabPane3.RegularSize = new System.Drawing.Size(2238, 427);
            this.tabPane3.SelectedPage = this.tabSectionEditor;
            this.tabPane3.Size = new System.Drawing.Size(2238, 427);
            this.tabPane3.TabIndex = 0;
            this.tabPane3.Text = "tabPane3";
            // 
            // tabSectionEditor
            // 
            this.tabSectionEditor.Caption = "Section Editor";
            this.tabSectionEditor.Controls.Add(this.pnlSectionEditor);
            this.tabSectionEditor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage6.ImageOptions.Image")));
            this.tabSectionEditor.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabSectionEditor.Name = "tabSectionEditor";
            this.tabSectionEditor.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabSectionEditor.Size = new System.Drawing.Size(2238, 394);
            // 
            // pnlSectionEditor
            // 
            this.pnlSectionEditor.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.pnlSectionEditor.Appearance.Options.UseBackColor = true;
            this.pnlSectionEditor.Controls.Add(this.lblSectopmActive);
            this.pnlSectionEditor.Controls.Add(this.lblSectionSelectedFileName);
            this.pnlSectionEditor.Controls.Add(this.imgSectionPhoto);
            this.pnlSectionEditor.Controls.Add(this.btnSectionvImage);
            this.pnlSectionEditor.Controls.Add(this.btnSectionRestore);
            this.pnlSectionEditor.Controls.Add(this.btnSectionDelete);
            this.pnlSectionEditor.Controls.Add(this.btnSectionSave);
            this.pnlSectionEditor.Controls.Add(this.btnSectionAddNew);
            this.pnlSectionEditor.Controls.Add(this.chkSectionActive);
            this.pnlSectionEditor.Controls.Add(this.txtSectionDescription);
            this.pnlSectionEditor.Controls.Add(this.txtSectionName);
            this.pnlSectionEditor.Controls.Add(this.lblSectionDescription);
            this.pnlSectionEditor.Controls.Add(this.lblSectionName);
            this.pnlSectionEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSectionEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlSectionEditor.Name = "pnlSectionEditor";
            this.pnlSectionEditor.Size = new System.Drawing.Size(2238, 394);
            this.pnlSectionEditor.TabIndex = 2;
            // 
            // lblSectopmActive
            // 
            this.lblSectopmActive.AutoSize = true;
            this.lblSectopmActive.BackColor = System.Drawing.Color.Transparent;
            this.lblSectopmActive.Location = new System.Drawing.Point(6, 290);
            this.lblSectopmActive.Name = "lblSectopmActive";
            this.lblSectopmActive.Size = new System.Drawing.Size(41, 13);
            this.lblSectopmActive.TabIndex = 25;
            this.lblSectopmActive.Text = "Active:";
            // 
            // lblSectionSelectedFileName
            // 
            this.lblSectionSelectedFileName.AutoSize = true;
            this.lblSectionSelectedFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionSelectedFileName.Location = new System.Drawing.Point(504, 337);
            this.lblSectionSelectedFileName.Name = "lblSectionSelectedFileName";
            this.lblSectionSelectedFileName.Size = new System.Drawing.Size(15, 13);
            this.lblSectionSelectedFileName.TabIndex = 24;
            this.lblSectionSelectedFileName.Text = "..";
            // 
            // imgSectionPhoto
            // 
            this.imgSectionPhoto.BackColor = System.Drawing.Color.Transparent;
            this.imgSectionPhoto.Location = new System.Drawing.Point(506, 20);
            this.imgSectionPhoto.Name = "imgSectionPhoto";
            this.imgSectionPhoto.Size = new System.Drawing.Size(465, 257);
            this.imgSectionPhoto.TabIndex = 23;
            this.imgSectionPhoto.TabStop = false;
            // 
            // btnSectionvImage
            // 
            this.btnSectionvImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSectionvImage.ImageOptions.Image")));
            this.btnSectionvImage.Location = new System.Drawing.Point(387, 287);
            this.btnSectionvImage.Name = "btnSectionvImage";
            this.btnSectionvImage.Size = new System.Drawing.Size(104, 23);
            this.btnSectionvImage.TabIndex = 22;
            this.btnSectionvImage.Text = "Select Image";
            // 
            // btnSectionRestore
            // 
            this.btnSectionRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSectionRestore.ImageOptions.Image")));
            this.btnSectionRestore.Location = new System.Drawing.Point(297, 331);
            this.btnSectionRestore.Name = "btnSectionRestore";
            this.btnSectionRestore.Size = new System.Drawing.Size(94, 34);
            this.btnSectionRestore.TabIndex = 21;
            this.btnSectionRestore.Text = "Restore";
            // 
            // btnSectionDelete
            // 
            this.btnSectionDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSectionDelete.ImageOptions.Image")));
            this.btnSectionDelete.Location = new System.Drawing.Point(196, 331);
            this.btnSectionDelete.Name = "btnSectionDelete";
            this.btnSectionDelete.Size = new System.Drawing.Size(94, 34);
            this.btnSectionDelete.TabIndex = 19;
            this.btnSectionDelete.Text = "Delete";
            // 
            // btnSectionSave
            // 
            this.btnSectionSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSectionSave.ImageOptions.Image")));
            this.btnSectionSave.Location = new System.Drawing.Point(398, 331);
            this.btnSectionSave.Name = "btnSectionSave";
            this.btnSectionSave.Size = new System.Drawing.Size(94, 34);
            this.btnSectionSave.TabIndex = 18;
            this.btnSectionSave.Text = "Save";
            // 
            // btnSectionAddNew
            // 
            this.btnSectionAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSectionAddNew.ImageOptions.Image")));
            this.btnSectionAddNew.Location = new System.Drawing.Point(95, 331);
            this.btnSectionAddNew.Name = "btnSectionAddNew";
            this.btnSectionAddNew.Size = new System.Drawing.Size(94, 34);
            this.btnSectionAddNew.TabIndex = 20;
            this.btnSectionAddNew.Text = "Add New";
            // 
            // chkSectionActive
            // 
            this.chkSectionActive.AutoSize = true;
            this.chkSectionActive.Location = new System.Drawing.Point(93, 290);
            this.chkSectionActive.Name = "chkSectionActive";
            this.chkSectionActive.Size = new System.Drawing.Size(15, 14);
            this.chkSectionActive.TabIndex = 17;
            this.chkSectionActive.UseVisualStyleBackColor = true;
            // 
            // txtSectionDescription
            // 
            this.txtSectionDescription.Location = new System.Drawing.Point(114, 51);
            this.txtSectionDescription.MaxLength = 255;
            this.txtSectionDescription.Multiline = true;
            this.txtSectionDescription.Name = "txtSectionDescription";
            this.txtSectionDescription.Size = new System.Drawing.Size(379, 226);
            this.txtSectionDescription.TabIndex = 16;
            // 
            // txtSectionName
            // 
            this.txtSectionName.Location = new System.Drawing.Point(114, 17);
            this.txtSectionName.Name = "txtSectionName";
            this.txtSectionName.Size = new System.Drawing.Size(379, 20);
            this.txtSectionName.TabIndex = 15;
            // 
            // lblSectionDescription
            // 
            this.lblSectionDescription.AutoSize = true;
            this.lblSectionDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionDescription.Location = new System.Drawing.Point(6, 53);
            this.lblSectionDescription.Name = "lblSectionDescription";
            this.lblSectionDescription.Size = new System.Drawing.Size(102, 13);
            this.lblSectionDescription.TabIndex = 14;
            this.lblSectionDescription.Text = "Section Description:";
            // 
            // lblSectionName
            // 
            this.lblSectionName.AutoSize = true;
            this.lblSectionName.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionName.Location = new System.Drawing.Point(6, 18);
            this.lblSectionName.Name = "lblSectionName";
            this.lblSectionName.Size = new System.Drawing.Size(76, 13);
            this.lblSectionName.TabIndex = 13;
            this.lblSectionName.Text = "Section Name:";
            // 
            // panelControl11
            // 
            this.panelControl11.Appearance.BackColor = System.Drawing.Color.CadetBlue;
            this.panelControl11.Appearance.Options.UseBackColor = true;
            this.panelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl11.Controls.Add(this.labelControl2);
            this.panelControl11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl11.Location = new System.Drawing.Point(0, 0);
            this.panelControl11.Name = "panelControl11";
            this.panelControl11.Size = new System.Drawing.Size(2242, 38);
            this.panelControl11.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Section Editors";
            // 
            // tabPartsEditors
            // 
            this.tabPartsEditors.Caption = "Part Editors";
            this.tabPartsEditors.Controls.Add(this.panelControl14);
            this.tabPartsEditors.Controls.Add(this.panelControl13);
            this.tabPartsEditors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabPartsEditors.ImageOptions.Image")));
            this.tabPartsEditors.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPartsEditors.Name = "tabPartsEditors";
            this.tabPartsEditors.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPartsEditors.Size = new System.Drawing.Size(2242, 469);
            // 
            // panelControl14
            // 
            this.panelControl14.Controls.Add(this.tabPane4);
            this.panelControl14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl14.Location = new System.Drawing.Point(0, 38);
            this.panelControl14.Name = "panelControl14";
            this.panelControl14.Size = new System.Drawing.Size(2242, 431);
            this.panelControl14.TabIndex = 4;
            // 
            // tabPane4
            // 
            this.tabPane4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tabPane4.Appearance.Options.UseBackColor = true;
            this.tabPane4.Controls.Add(this.tabPartsEditor);
            this.tabPane4.Controls.Add(this.tabPartsProducts);
            this.tabPane4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane4.Location = new System.Drawing.Point(2, 2);
            this.tabPane4.Name = "tabPane4";
            this.tabPane4.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabPartsEditor,
            this.tabPartsProducts});
            this.tabPane4.RegularSize = new System.Drawing.Size(2238, 427);
            this.tabPane4.SelectedPage = this.tabPartsEditor;
            this.tabPane4.Size = new System.Drawing.Size(2238, 427);
            this.tabPane4.TabIndex = 0;
            this.tabPane4.Text = "tabPane4";
            // 
            // tabPartsEditor
            // 
            this.tabPartsEditor.Caption = "Part Editor";
            this.tabPartsEditor.Controls.Add(this.pnlPartsEdtior);
            this.tabPartsEditor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage8.ImageOptions.Image")));
            this.tabPartsEditor.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPartsEditor.Name = "tabPartsEditor";
            this.tabPartsEditor.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPartsEditor.Size = new System.Drawing.Size(2238, 394);
            // 
            // pnlPartsEdtior
            // 
            this.pnlPartsEdtior.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlPartsEdtior.Appearance.Options.UseBackColor = true;
            this.pnlPartsEdtior.Controls.Add(this.lblPartSelectedFileName);
            this.pnlPartsEdtior.Controls.Add(this.imgPartPhoto);
            this.pnlPartsEdtior.Controls.Add(this.btnPartImage);
            this.pnlPartsEdtior.Controls.Add(this.btnPartRestore);
            this.pnlPartsEdtior.Controls.Add(this.btnPartDelete);
            this.pnlPartsEdtior.Controls.Add(this.btnPartSave);
            this.pnlPartsEdtior.Controls.Add(this.btnPartAddNew);
            this.pnlPartsEdtior.Controls.Add(this.chkPartActive);
            this.pnlPartsEdtior.Controls.Add(this.lblPartvActive);
            this.pnlPartsEdtior.Controls.Add(this.txtPartDescription);
            this.pnlPartsEdtior.Controls.Add(this.txtPartName);
            this.pnlPartsEdtior.Controls.Add(this.lblPartDescription);
            this.pnlPartsEdtior.Controls.Add(this.lblPartName);
            this.pnlPartsEdtior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPartsEdtior.Location = new System.Drawing.Point(0, 0);
            this.pnlPartsEdtior.Name = "pnlPartsEdtior";
            this.pnlPartsEdtior.Size = new System.Drawing.Size(2238, 394);
            this.pnlPartsEdtior.TabIndex = 2;
            // 
            // lblPartSelectedFileName
            // 
            this.lblPartSelectedFileName.AutoSize = true;
            this.lblPartSelectedFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblPartSelectedFileName.Location = new System.Drawing.Point(505, 289);
            this.lblPartSelectedFileName.Name = "lblPartSelectedFileName";
            this.lblPartSelectedFileName.Size = new System.Drawing.Size(15, 13);
            this.lblPartSelectedFileName.TabIndex = 25;
            this.lblPartSelectedFileName.Text = "..";
            // 
            // imgPartPhoto
            // 
            this.imgPartPhoto.BackColor = System.Drawing.Color.Transparent;
            this.imgPartPhoto.Location = new System.Drawing.Point(506, 19);
            this.imgPartPhoto.Name = "imgPartPhoto";
            this.imgPartPhoto.Size = new System.Drawing.Size(465, 257);
            this.imgPartPhoto.TabIndex = 24;
            this.imgPartPhoto.TabStop = false;
            // 
            // btnPartImage
            // 
            this.btnPartImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPartImage.ImageOptions.Image")));
            this.btnPartImage.Location = new System.Drawing.Point(387, 286);
            this.btnPartImage.Name = "btnPartImage";
            this.btnPartImage.Size = new System.Drawing.Size(104, 23);
            this.btnPartImage.TabIndex = 23;
            this.btnPartImage.Text = "Select Image";
            // 
            // btnPartRestore
            // 
            this.btnPartRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPartRestore.ImageOptions.Image")));
            this.btnPartRestore.Location = new System.Drawing.Point(303, 325);
            this.btnPartRestore.Name = "btnPartRestore";
            this.btnPartRestore.Size = new System.Drawing.Size(84, 34);
            this.btnPartRestore.TabIndex = 22;
            this.btnPartRestore.Text = "Restore";
            // 
            // btnPartDelete
            // 
            this.btnPartDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPartDelete.ImageOptions.Image")));
            this.btnPartDelete.Location = new System.Drawing.Point(199, 325);
            this.btnPartDelete.Name = "btnPartDelete";
            this.btnPartDelete.Size = new System.Drawing.Size(84, 34);
            this.btnPartDelete.TabIndex = 20;
            this.btnPartDelete.Text = "Delete";
            // 
            // btnPartSave
            // 
            this.btnPartSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPartSave.ImageOptions.Image")));
            this.btnPartSave.Location = new System.Drawing.Point(407, 325);
            this.btnPartSave.Name = "btnPartSave";
            this.btnPartSave.Size = new System.Drawing.Size(84, 34);
            this.btnPartSave.TabIndex = 19;
            this.btnPartSave.Text = "Save";
            // 
            // btnPartAddNew
            // 
            this.btnPartAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPartAddNew.ImageOptions.Image")));
            this.btnPartAddNew.Location = new System.Drawing.Point(95, 325);
            this.btnPartAddNew.Name = "btnPartAddNew";
            this.btnPartAddNew.Size = new System.Drawing.Size(84, 34);
            this.btnPartAddNew.TabIndex = 21;
            this.btnPartAddNew.Text = "Add New";
            // 
            // chkPartActive
            // 
            this.chkPartActive.AutoSize = true;
            this.chkPartActive.Location = new System.Drawing.Point(93, 289);
            this.chkPartActive.Name = "chkPartActive";
            this.chkPartActive.Size = new System.Drawing.Size(15, 14);
            this.chkPartActive.TabIndex = 18;
            this.chkPartActive.UseVisualStyleBackColor = true;
            // 
            // lblPartvActive
            // 
            this.lblPartvActive.AutoSize = true;
            this.lblPartvActive.BackColor = System.Drawing.Color.Transparent;
            this.lblPartvActive.Location = new System.Drawing.Point(6, 289);
            this.lblPartvActive.Name = "lblPartvActive";
            this.lblPartvActive.Size = new System.Drawing.Size(41, 13);
            this.lblPartvActive.TabIndex = 17;
            this.lblPartvActive.Text = "Active:";
            // 
            // txtPartDescription
            // 
            this.txtPartDescription.Location = new System.Drawing.Point(95, 50);
            this.txtPartDescription.MaxLength = 255;
            this.txtPartDescription.Multiline = true;
            this.txtPartDescription.Name = "txtPartDescription";
            this.txtPartDescription.Size = new System.Drawing.Size(398, 226);
            this.txtPartDescription.TabIndex = 16;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(95, 16);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(398, 20);
            this.txtPartName.TabIndex = 15;
            // 
            // lblPartDescription
            // 
            this.lblPartDescription.AutoSize = true;
            this.lblPartDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblPartDescription.Location = new System.Drawing.Point(6, 52);
            this.lblPartDescription.Name = "lblPartDescription";
            this.lblPartDescription.Size = new System.Drawing.Size(83, 13);
            this.lblPartDescription.TabIndex = 14;
            this.lblPartDescription.Text = "Part Description";
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.BackColor = System.Drawing.Color.Transparent;
            this.lblPartName.Location = new System.Drawing.Point(6, 17);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(61, 13);
            this.lblPartName.TabIndex = 13;
            this.lblPartName.Text = "Part Name:";
            // 
            // tabPartsProducts
            // 
            this.tabPartsProducts.Caption = "Part Products";
            this.tabPartsProducts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage1.ImageOptions.Image")));
            this.tabPartsProducts.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPartsProducts.Name = "tabPartsProducts";
            this.tabPartsProducts.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPartsProducts.Size = new System.Drawing.Size(2238, 427);
            // 
            // panelControl13
            // 
            this.panelControl13.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelControl13.Appearance.Options.UseBackColor = true;
            this.panelControl13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl13.Controls.Add(this.labelControl3);
            this.panelControl13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl13.Location = new System.Drawing.Point(0, 0);
            this.panelControl13.Name = "panelControl13";
            this.panelControl13.Size = new System.Drawing.Size(2242, 38);
            this.panelControl13.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(6, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(82, 19);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Part Editors";
            // 
            // tabDocumentsManager
            // 
            this.tabDocumentsManager.Caption = "Documents Manager";
            this.tabDocumentsManager.Controls.Add(this.ucProjectDocs1);
            this.tabDocumentsManager.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabDocumentsManager.ImageOptions.Image")));
            this.tabDocumentsManager.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabDocumentsManager.Name = "tabDocumentsManager";
            this.tabDocumentsManager.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabDocumentsManager.Size = new System.Drawing.Size(2242, 469);
            // 
            // ucProjectDocs1
            // 
            this.ucProjectDocs1.Dock = System.Windows.Forms.DockStyle.Fill;
            projectDocumentFilter4.CategoryId = null;
            projectDocumentFilter4.ClassificationId = null;
            projectDocumentFilter4.CustomFieldId = null;
            projectDocumentFilter4.Description = null;
            projectDocumentFilter4.DigiAdminId = null;
            projectDocumentFilter4.Id = null;
            projectDocumentFilter4.IncludeDeleted = false;
            projectDocumentFilter4.IncludeInActive = false;
            projectDocumentFilter4.IncludePartSearch = false;
            projectDocumentFilter4.IncludeProjectSearch = true;
            projectDocumentFilter4.IncludeSectionSearch = false;
            projectDocumentFilter4.LikeSearch = false;
            projectDocumentFilter4.Name = null;
            projectDocumentFilter4.Only3DPrintingDocument = false;
            projectDocumentFilter4.OnlyInstructions = false;
            projectDocumentFilter4.OnlyParents = false;
            projectDocumentFilter4.OnlyPlans = false;
            projectDocumentFilter4.OnlySpecifications = false;
            projectDocumentFilter4.ParentId = null;
            projectDocumentFilter4.ParentName = null;
            projectDocumentFilter4.Part = null;
            projectDocumentFilter4.Project = null;
            projectDocumentFilter4.ProjectId = 0;
            projectDocumentFilter4.ProjectSectionId = 0;
            projectDocumentFilter4.ProjectSectionPartId = 0;
            projectDocumentFilter4.Section = null;
            this.ucProjectDocs1.Filter = projectDocumentFilter4;
            this.ucProjectDocs1.Location = new System.Drawing.Point(0, 0);
            this.ucProjectDocs1.Name = "ucProjectDocs1";
            projectDocument4.CreatedOn = new System.DateTime(((long)(0)));
            projectDocument4.Description = null;
            projectDocument4.DigiAdmin = null;
            projectDocument4.DigiAdminId = 0;
            projectDocument4.DocumentData = null;
            projectDocument4.DocumentFileType = null;
            projectDocument4.DocumentFileTypeId = 0;
            projectDocument4.DocumentType = null;
            projectDocument4.DocumentTypeId = 0;
            projectDocument4.Id = 0;
            projectDocument4.Is3DPrintingDocument = false;
            projectDocument4.IsActive = false;
            projectDocument4.IsDeleted = false;
            projectDocument4.IsInstructions = false;
            projectDocument4.IsPlans = false;
            projectDocument4.IsSpecifications = false;
            projectDocument4.Name = null;
            projectDocument4.Project = null;
            projectDocument4.ProjectId = 0;
            projectDocument4.ProjectSection = null;
            projectDocument4.ProjectSectionId = null;
            projectDocument4.ProjectSectionPart = null;
            projectDocument4.ProjectSectionPartId = null;
            this.ucProjectDocs1.SelectedDocument = projectDocument4;
            this.ucProjectDocs1.Size = new System.Drawing.Size(2242, 469);
            this.ucProjectDocs1.TabIndex = 0;
            // 
            // dlgProjectImage
            // 
            this.dlgProjectImage.FileName = "openFileDialog1";
            // 
            // dlgProjectSectionPhoto
            // 
            this.dlgProjectSectionPhoto.FileName = "openFileDialog2";
            // 
            // dlgProjectSectionPartPhoto
            // 
            this.dlgProjectSectionPartPhoto.FileName = "openFileDialog3";
            // 
            // bsProjects
            // 
            this.bsProjects.PositionChanged += new System.EventHandler(this.bsProjects_PositionChanged);
            // 
            // bsSections
            // 
            this.bsSections.PositionChanged += new System.EventHandler(this.bsSections_PositionChanged);
            // 
            // bsParts
            // 
            this.bsParts.PositionChanged += new System.EventHandler(this.bsParts_PositionChanged);
            // 
            // ProjectsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2250, 1144);
            this.Controls.Add(this.pnlManager);
            this.Name = "ProjectsManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projects Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pnlManager)).EndInit();
            this.pnlManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsMain.Panel1)).EndInit();
            this.splitGridsMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsMain.Panel2)).EndInit();
            this.splitGridsMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsMain)).EndInit();
            this.splitGridsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsSubs.Panel1)).EndInit();
            this.splitGridsSubs.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsSubs.Panel2)).EndInit();
            this.splitGridsSubs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGridsSubs)).EndInit();
            this.splitGridsSubs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectSections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjectSections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterProjectSectionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            this.panelControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectSectionParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjectSectionParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterProjectSectionPartName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabEditors)).EndInit();
            this.tabEditors.ResumeLayout(false);
            this.tabProjectEditors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl10)).EndInit();
            this.panelControl10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane2)).EndInit();
            this.tabPane2.ResumeLayout(false);
            this.tabProjectEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlProject_Editor)).EndInit();
            this.pnlProject_Editor.ResumeLayout(false);
            this.pnlProject_Editor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProjectPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).EndInit();
            this.panelControl9.ResumeLayout(false);
            this.panelControl9.PerformLayout();
            this.tabSectionEditors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).EndInit();
            this.panelControl12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane3)).EndInit();
            this.tabPane3.ResumeLayout(false);
            this.tabSectionEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSectionEditor)).EndInit();
            this.pnlSectionEditor.ResumeLayout(false);
            this.pnlSectionEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSectionPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSectionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).EndInit();
            this.panelControl11.ResumeLayout(false);
            this.panelControl11.PerformLayout();
            this.tabPartsEditors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).EndInit();
            this.panelControl14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane4)).EndInit();
            this.tabPane4.ResumeLayout(false);
            this.tabPartsEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPartsEdtior)).EndInit();
            this.pnlPartsEdtior.ResumeLayout(false);
            this.pnlPartsEdtior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPartPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl13)).EndInit();
            this.panelControl13.ResumeLayout(false);
            this.panelControl13.PerformLayout();
            this.tabDocumentsManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjectPartDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlManager;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitGridsMain;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private Label lblProjects;
        private DevExpress.XtraGrid.GridControl gridProjects;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProjects;
        private DevExpress.XtraEditors.SplitContainerControl splitGridsSubs;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private Label lblProjectSections;
        private DevExpress.XtraGrid.GridControl gridProjectSections;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProjectSections;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private Label lblProjectSectionParts;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl7;
        private DevExpress.XtraEditors.PanelControl panelControl8;
        private DevExpress.XtraGrid.GridControl gridProjectSectionParts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProjectSectionParts;
        private DevExpress.XtraEditors.SimpleButton butProjectsFilter;
        private DevExpress.XtraEditors.TextEdit txtFilterProjectName;
        private DevExpress.XtraEditors.SimpleButton btnProjectsSectionsFilter;
        private DevExpress.XtraEditors.TextEdit txtFilterProjectSectionName;
        private DevExpress.XtraEditors.SimpleButton butProjectsSectionPartsFilter;
        private DevExpress.XtraEditors.TextEdit txtFilterProjectSectionPartName;
        private OpenFileDialog dlgProjectImage;
        private OpenFileDialog dlgProjectSectionPhoto;
        private OpenFileDialog dlgProjectSectionPartPhoto;
        private BindingSource bsProjects;
        private DevExpress.XtraBars.Navigation.TabPane tabEditors;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabProjectEditors;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabSectionEditors;
        private DevExpress.XtraBars.Navigation.TabPane tabPane3;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabSectionEditor;
        private DevExpress.XtraEditors.PanelControl pnlSectionEditor;
        private Label lblSectopmActive;
        private Label lblSectionSelectedFileName;
        private PictureBox imgSectionPhoto;
        private DevExpress.XtraEditors.SimpleButton btnSectionvImage;
        private DevExpress.XtraEditors.SimpleButton btnSectionRestore;
        private DevExpress.XtraEditors.SimpleButton btnSectionDelete;
        private DevExpress.XtraEditors.SimpleButton btnSectionSave;
        private DevExpress.XtraEditors.SimpleButton btnSectionAddNew;
        private CheckBox chkSectionActive;
        private TextBox txtSectionDescription;
        private DevExpress.XtraEditors.TextEdit txtSectionName;
        private Label lblSectionDescription;
        private Label lblSectionName;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabPartsEditors;
        private DevExpress.XtraBars.Navigation.TabPane tabPane4;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabPartsEditor;
        private DevExpress.XtraEditors.PanelControl pnlPartsEdtior;
        private Label lblPartSelectedFileName;
        private PictureBox imgPartPhoto;
        private DevExpress.XtraEditors.SimpleButton btnPartImage;
        private DevExpress.XtraEditors.SimpleButton btnPartRestore;
        private DevExpress.XtraEditors.SimpleButton btnPartDelete;
        private DevExpress.XtraEditors.SimpleButton btnPartSave;
        private DevExpress.XtraEditors.SimpleButton btnPartAddNew;
        private CheckBox chkPartActive;
        private Label lblPartvActive;
        private TextBox txtPartDescription;
        private DevExpress.XtraEditors.TextEdit txtPartName;
        private Label lblPartDescription;
        private Label lblPartName;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabPartsProducts;
        private BindingSource bsSections;
        private BindingSource bsParts;
        private BindingSource bsProjectPartDocuments;
        private DevExpress.XtraEditors.PanelControl panelControl10;
        private DevExpress.XtraBars.Navigation.TabPane tabPane2;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabProjectEditor;
        private DevExpress.XtraEditors.PanelControl pnlProject_Editor;
        private Label lblProjectSelectedFileName;
        private PictureBox imgProjectPhoto;
        private DevExpress.XtraEditors.SimpleButton btnProjectImage;
        private DevExpress.XtraEditors.SimpleButton btnProjectRestore;
        private DevExpress.XtraEditors.SimpleButton btnProjectDelete;
        private DevExpress.XtraEditors.SimpleButton btnProjectSave;
        private DevExpress.XtraEditors.SimpleButton btnProjectAddNew;
        private CheckBox chkProjectActive;
        private Label lblProjectActive;
        private DevExpress.XtraEditors.TextEdit txtProject_Name;
        private Label lblProjectDescription;
        private Label lblProjectName;
        private DevExpress.XtraEditors.SimpleButton btnSampleDataDelete;
        private DevExpress.XtraEditors.SimpleButton btnSampleData;
        private DevExpress.XtraEditors.PanelControl panelControl9;
        private DevExpress.XtraEditors.PanelControl panelControl12;
        private DevExpress.XtraEditors.PanelControl panelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl14;
        private DevExpress.XtraEditors.PanelControl panelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabDocumentsManager;
        private TextBox txtProjectDescription;
        private UserControls.ucProjectDocs ucProjectDocs1;
        private DevExpress.XtraWaitForm.ProgressPanel pgProject;
        private DevExpress.XtraWaitForm.ProgressPanel pgSection;
        private DevExpress.XtraWaitForm.ProgressPanel pgParts;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabPartsProductss;
    }
}