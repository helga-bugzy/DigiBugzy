namespace DigiBugzy.Desktop.Projects.UserControls
{
    partial class ucProjectDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjectDocs));
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridDocuments = new DevExpress.XtraGrid.GridControl();
            this.gvDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitEditors = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlEditor = new DevExpress.XtraEditors.PanelControl();
            this.lblFileType = new DevExpress.XtraEditors.LabelControl();
            this.cmbPart = new System.Windows.Forms.ComboBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblPart = new DevExpress.XtraEditors.LabelControl();
            this.lblSection = new DevExpress.XtraEditors.LabelControl();
            this.lblProject = new DevExpress.XtraEditors.LabelControl();
            this.cmbDocumentFileType = new System.Windows.Forms.ComboBox();
            this.btnSelectFile = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsInstructions = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsSpecifications = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsPlans = new DevExpress.XtraEditors.CheckEdit();
            this.chkIs3DPrintingDocument = new DevExpress.XtraEditors.CheckEdit();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblSelectedDocumentName = new System.Windows.Forms.Label();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.rdPlans = new System.Windows.Forms.RadioButton();
            this.rdSpecs = new System.Windows.Forms.RadioButton();
            this.rdInstructions = new System.Windows.Forms.RadioButton();
            this.rd3D = new System.Windows.Forms.RadioButton();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.chkFilterPart = new DevExpress.XtraEditors.CheckEdit();
            this.chkFilterSection = new DevExpress.XtraEditors.CheckEdit();
            this.chkFilterProject = new DevExpress.XtraEditors.CheckEdit();
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditors.Panel1)).BeginInit();
            this.splitEditors.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditors.Panel2)).BeginInit();
            this.splitEditors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditor)).BeginInit();
            this.pnlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsInstructions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecifications.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPlans.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIs3DPrintingDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFilterPart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFilterSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFilterProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.splitMain);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1616, 676);
            this.pnlMain.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 41);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.progressPanel1);
            this.splitMain.Panel1.Controls.Add(this.gridDocuments);
            this.splitMain.Panel1.Text = "Panel1";
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitEditors);
            this.splitMain.Panel2.Text = "Panel2";
            this.splitMain.Size = new System.Drawing.Size(1616, 635);
            this.splitMain.SplitterPosition = 607;
            this.splitMain.TabIndex = 1;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Location = new System.Drawing.Point(246, 143);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 66);
            this.progressPanel1.TabIndex = 2;
            this.progressPanel1.Text = "progressPanel1";
            this.progressPanel1.Visible = false;
            // 
            // gridDocuments
            // 
            this.gridDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDocuments.Location = new System.Drawing.Point(0, 0);
            this.gridDocuments.MainView = this.gvDocuments;
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.Size = new System.Drawing.Size(607, 635);
            this.gridDocuments.TabIndex = 1;
            this.gridDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocuments});
            // 
            // gvDocuments
            // 
            this.gvDocuments.GridControl = this.gridDocuments;
            this.gvDocuments.Name = "gvDocuments";
            // 
            // splitEditors
            // 
            this.splitEditors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEditors.Location = new System.Drawing.Point(0, 0);
            this.splitEditors.Name = "splitEditors";
            // 
            // splitEditors.Panel1
            // 
            this.splitEditors.Panel1.Controls.Add(this.pnlEditor);
            this.splitEditors.Panel1.Text = "Panel1";
            // 
            // splitEditors.Panel2
            // 
            this.splitEditors.Panel2.Text = "Panel2";
            this.splitEditors.Size = new System.Drawing.Size(999, 635);
            this.splitEditors.SplitterPosition = 478;
            this.splitEditors.TabIndex = 0;
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.lblFileType);
            this.pnlEditor.Controls.Add(this.cmbPart);
            this.pnlEditor.Controls.Add(this.cmbSection);
            this.pnlEditor.Controls.Add(this.cmbProject);
            this.pnlEditor.Controls.Add(this.lblPart);
            this.pnlEditor.Controls.Add(this.lblSection);
            this.pnlEditor.Controls.Add(this.lblProject);
            this.pnlEditor.Controls.Add(this.cmbDocumentFileType);
            this.pnlEditor.Controls.Add(this.btnSelectFile);
            this.pnlEditor.Controls.Add(this.chkIsInstructions);
            this.pnlEditor.Controls.Add(this.chkIsSpecifications);
            this.pnlEditor.Controls.Add(this.chkIsPlans);
            this.pnlEditor.Controls.Add(this.chkIs3DPrintingDocument);
            this.pnlEditor.Controls.Add(this.btnDelete);
            this.pnlEditor.Controls.Add(this.btnSave);
            this.pnlEditor.Controls.Add(this.btnAdd);
            this.pnlEditor.Controls.Add(this.txtDescription);
            this.pnlEditor.Controls.Add(this.txtName);
            this.pnlEditor.Controls.Add(this.lblDescription);
            this.pnlEditor.Controls.Add(this.lblTitle);
            this.pnlEditor.Controls.Add(this.cmbDocumentType);
            this.pnlEditor.Controls.Add(this.lblType);
            this.pnlEditor.Controls.Add(this.lblSelectedDocumentName);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(478, 635);
            this.pnlEditor.TabIndex = 0;
            // 
            // lblFileType
            // 
            this.lblFileType.Location = new System.Drawing.Point(8, 126);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(47, 13);
            this.lblFileType.TabIndex = 106;
            this.lblFileType.Text = "File Type:";
            // 
            // cmbPart
            // 
            this.cmbPart.DisplayMember = "Name";
            this.cmbPart.FormattingEnabled = true;
            this.cmbPart.Location = new System.Drawing.Point(80, 73);
            this.cmbPart.Name = "cmbPart";
            this.cmbPart.Size = new System.Drawing.Size(364, 21);
            this.cmbPart.TabIndex = 88;
            this.cmbPart.ValueMember = "Id";
            this.cmbPart.Click += new System.EventHandler(this.cmbPart_SelectedIndexChanged);
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Name";
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(80, 46);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(364, 21);
            this.cmbSection.TabIndex = 86;
            this.cmbSection.ValueMember = "Id";
            this.cmbSection.Click += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // cmbProject
            // 
            this.cmbProject.DisplayMember = "Name";
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(80, 19);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(364, 21);
            this.cmbProject.TabIndex = 85;
            this.cmbProject.ValueMember = "Id";
            this.cmbProject.Click += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblPart
            // 
            this.lblPart.Location = new System.Drawing.Point(8, 73);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(20, 13);
            this.lblPart.TabIndex = 105;
            this.lblPart.Text = "Part";
            // 
            // lblSection
            // 
            this.lblSection.Location = new System.Drawing.Point(8, 46);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(35, 13);
            this.lblSection.TabIndex = 87;
            this.lblSection.Text = "Section";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(8, 19);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(34, 13);
            this.lblProject.TabIndex = 101;
            this.lblProject.Text = "Project";
            // 
            // cmbDocumentFileType
            // 
            this.cmbDocumentFileType.DisplayMember = "Name";
            this.cmbDocumentFileType.FormattingEnabled = true;
            this.cmbDocumentFileType.Location = new System.Drawing.Point(80, 126);
            this.cmbDocumentFileType.Name = "cmbDocumentFileType";
            this.cmbDocumentFileType.Size = new System.Drawing.Size(364, 21);
            this.cmbDocumentFileType.TabIndex = 90;
            this.cmbDocumentFileType.ValueMember = "d";
            this.cmbDocumentFileType.Click += new System.EventHandler(this.cmbDocumentFileType_SelectedIndexChanged);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.ImageOptions.Image")));
            this.btnSelectFile.Location = new System.Drawing.Point(8, 341);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(120, 37);
            this.btnSelectFile.TabIndex = 100;
            this.btnSelectFile.Text = "Select Document";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // chkIsInstructions
            // 
            this.chkIsInstructions.Location = new System.Drawing.Point(172, 304);
            this.chkIsInstructions.Name = "chkIsInstructions";
            this.chkIsInstructions.Properties.Caption = "Instructions";
            this.chkIsInstructions.Size = new System.Drawing.Size(88, 20);
            this.chkIsInstructions.TabIndex = 94;
            // 
            // chkIsSpecifications
            // 
            this.chkIsSpecifications.Location = new System.Drawing.Point(272, 304);
            this.chkIsSpecifications.Name = "chkIsSpecifications";
            this.chkIsSpecifications.Properties.Caption = "Specifications";
            this.chkIsSpecifications.Size = new System.Drawing.Size(98, 20);
            this.chkIsSpecifications.TabIndex = 95;
            // 
            // chkIsPlans
            // 
            this.chkIsPlans.Location = new System.Drawing.Point(382, 304);
            this.chkIsPlans.Name = "chkIsPlans";
            this.chkIsPlans.Properties.Caption = "Plans";
            this.chkIsPlans.Size = new System.Drawing.Size(55, 20);
            this.chkIsPlans.TabIndex = 97;
            // 
            // chkIs3DPrintingDocument
            // 
            this.chkIs3DPrintingDocument.Location = new System.Drawing.Point(81, 304);
            this.chkIs3DPrintingDocument.Name = "chkIs3DPrintingDocument";
            this.chkIs3DPrintingDocument.Properties.Caption = "3D Printing";
            this.chkIs3DPrintingDocument.Size = new System.Drawing.Size(85, 20);
            this.chkIs3DPrintingDocument.TabIndex = 93;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(252, 341);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 32);
            this.btnDelete.TabIndex = 98;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(356, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 32);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(147, 341);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 32);
            this.btnAdd.TabIndex = 96;
            this.btnAdd.Text = "Add New";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(80, 179);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(364, 116);
            this.txtDescription.TabIndex = 92;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 154);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(364, 20);
            this.txtName.TabIndex = 91;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(8, 179);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(64, 13);
            this.lblDescription.TabIndex = 103;
            this.lblDescription.Text = "Description:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(8, 157);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(31, 13);
            this.lblTitle.TabIndex = 102;
            this.lblTitle.Text = "Title:";
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.DisplayMember = "Name";
            this.cmbDocumentType.FormattingEnabled = true;
            this.cmbDocumentType.Location = new System.Drawing.Point(80, 100);
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(364, 21);
            this.cmbDocumentType.TabIndex = 89;
            this.cmbDocumentType.ValueMember = "d";
            this.cmbDocumentType.Click += new System.EventHandler(this.cmbDocumentType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(8, 100);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 104;
            this.lblType.Text = "Type:";
            // 
            // lblSelectedDocumentName
            // 
            this.lblSelectedDocumentName.AutoSize = true;
            this.lblSelectedDocumentName.Location = new System.Drawing.Point(17, 394);
            this.lblSelectedDocumentName.Name = "lblSelectedDocumentName";
            this.lblSelectedDocumentName.Size = new System.Drawing.Size(19, 13);
            this.lblSelectedDocumentName.TabIndex = 84;
            this.lblSelectedDocumentName.Text = "...";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.rdAll);
            this.pnlFilter.Controls.Add(this.rdPlans);
            this.pnlFilter.Controls.Add(this.rdSpecs);
            this.pnlFilter.Controls.Add(this.rdInstructions);
            this.pnlFilter.Controls.Add(this.rd3D);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.chkFilterPart);
            this.pnlFilter.Controls.Add(this.chkFilterSection);
            this.pnlFilter.Controls.Add(this.chkFilterProject);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1616, 41);
            this.pnlFilter.TabIndex = 0;
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Checked = true;
            this.rdAll.Location = new System.Drawing.Point(213, 9);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(68, 17);
            this.rdAll.TabIndex = 107;
            this.rdAll.TabStop = true;
            this.rdAll.Text = "All Types";
            this.rdAll.UseVisualStyleBackColor = true;
            // 
            // rdPlans
            // 
            this.rdPlans.AutoSize = true;
            this.rdPlans.Location = new System.Drawing.Point(578, 9);
            this.rdPlans.Name = "rdPlans";
            this.rdPlans.Size = new System.Drawing.Size(50, 17);
            this.rdPlans.TabIndex = 106;
            this.rdPlans.Text = "Plans";
            this.rdPlans.UseVisualStyleBackColor = true;
            // 
            // rdSpecs
            // 
            this.rdSpecs.AutoSize = true;
            this.rdSpecs.Location = new System.Drawing.Point(476, 9);
            this.rdSpecs.Name = "rdSpecs";
            this.rdSpecs.Size = new System.Drawing.Size(90, 17);
            this.rdSpecs.TabIndex = 105;
            this.rdSpecs.Text = "Specifications";
            this.rdSpecs.UseVisualStyleBackColor = true;
            // 
            // rdInstructions
            // 
            this.rdInstructions.AutoSize = true;
            this.rdInstructions.Location = new System.Drawing.Point(382, 9);
            this.rdInstructions.Name = "rdInstructions";
            this.rdInstructions.Size = new System.Drawing.Size(82, 17);
            this.rdInstructions.TabIndex = 104;
            this.rdInstructions.Text = "Instructions";
            this.rdInstructions.UseVisualStyleBackColor = true;
            // 
            // rd3D
            // 
            this.rd3D.AutoSize = true;
            this.rd3D.Location = new System.Drawing.Point(293, 9);
            this.rd3D.Name = "rd3D";
            this.rd3D.Size = new System.Drawing.Size(77, 17);
            this.rd3D.TabIndex = 103;
            this.rd3D.Text = "3D Printing";
            this.rd3D.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.ImageOptions.Image")));
            this.btnFilter.Location = new System.Drawing.Point(643, 5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(83, 26);
            this.btnFilter.TabIndex = 102;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // chkFilterPart
            // 
            this.chkFilterPart.EditValue = true;
            this.chkFilterPart.Location = new System.Drawing.Point(161, 9);
            this.chkFilterPart.Name = "chkFilterPart";
            this.chkFilterPart.Properties.Caption = "Part";
            this.chkFilterPart.Size = new System.Drawing.Size(75, 20);
            this.chkFilterPart.TabIndex = 2;
            // 
            // chkFilterSection
            // 
            this.chkFilterSection.EditValue = true;
            this.chkFilterSection.Location = new System.Drawing.Point(86, 9);
            this.chkFilterSection.Name = "chkFilterSection";
            this.chkFilterSection.Properties.Caption = "Section";
            this.chkFilterSection.Size = new System.Drawing.Size(75, 20);
            this.chkFilterSection.TabIndex = 1;
            // 
            // chkFilterProject
            // 
            this.chkFilterProject.EditValue = true;
            this.chkFilterProject.Location = new System.Drawing.Point(11, 9);
            this.chkFilterProject.Name = "chkFilterProject";
            this.chkFilterProject.Properties.Caption = "Project";
            this.chkFilterProject.Size = new System.Drawing.Size(75, 20);
            this.chkFilterProject.TabIndex = 0;
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // bindingSource1
            // 
            this.bindingSource1.PositionChanged += new System.EventHandler(this.bindingSource1_PositionChanged);
            // 
            // ucProjectDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucProjectDocs";
            this.Size = new System.Drawing.Size(1616, 676);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditors.Panel1)).EndInit();
            this.splitEditors.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitEditors.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditors)).EndInit();
            this.splitEditors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditor)).EndInit();
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsInstructions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecifications.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPlans.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIs3DPrintingDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFilterPart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFilterSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFilterProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.SplitContainerControl splitEditors;
        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraEditors.PanelControl pnlEditor;
        private DevExpress.XtraEditors.LabelControl lblFileType;
        private ComboBox cmbPart;
        private ComboBox cmbSection;
        private ComboBox cmbProject;
        private DevExpress.XtraEditors.LabelControl lblPart;
        private DevExpress.XtraEditors.LabelControl lblSection;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private ComboBox cmbDocumentFileType;
        private DevExpress.XtraEditors.SimpleButton btnSelectFile;
        private DevExpress.XtraEditors.CheckEdit chkIsInstructions;
        private DevExpress.XtraEditors.CheckEdit chkIsSpecifications;
        private DevExpress.XtraEditors.CheckEdit chkIsPlans;
        private DevExpress.XtraEditors.CheckEdit chkIs3DPrintingDocument;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private TextBox txtDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private Label lblDescription;
        private Label lblTitle;
        private ComboBox cmbDocumentType;
        private DevExpress.XtraEditors.LabelControl lblType;
        private Label lblSelectedDocumentName;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private DevExpress.XtraGrid.GridControl gridDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocuments;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraEditors.CheckEdit chkFilterPart;
        private DevExpress.XtraEditors.CheckEdit chkFilterSection;
        private DevExpress.XtraEditors.CheckEdit chkFilterProject;
        private BindingSource bindingSource1;
        private RadioButton rdPlans;
        private RadioButton rdSpecs;
        private RadioButton rdInstructions;
        private RadioButton rd3D;
        private RadioButton rdAll;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
    }
}
