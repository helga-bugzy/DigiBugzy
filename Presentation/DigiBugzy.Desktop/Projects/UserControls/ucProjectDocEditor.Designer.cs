namespace DigiBugzy.Desktop.Projects.UserControls
{
    partial class ucProjectDocEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjectDocEditor));
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
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblSelectedDocumentName = new System.Windows.Forms.Label();
            this.lblProject = new DevExpress.XtraEditors.LabelControl();
            this.lblSection = new DevExpress.XtraEditors.LabelControl();
            this.lblPart = new DevExpress.XtraEditors.LabelControl();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbPart = new System.Windows.Forms.ComboBox();
            this.cmbDocumentFileType = new System.Windows.Forms.ComboBox();
            this.lblFileType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsInstructions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecifications.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPlans.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIs3DPrintingDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.ImageOptions.Image")));
            this.btnSelectFile.Location = new System.Drawing.Point(482, 3);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(132, 41);
            this.btnSelectFile.TabIndex = 13;
            this.btnSelectFile.Text = "Select Document";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // chkIsInstructions
            // 
            this.chkIsInstructions.Location = new System.Drawing.Point(172, 292);
            this.chkIsInstructions.Name = "chkIsInstructions";
            this.chkIsInstructions.Properties.Caption = "Instructions";
            this.chkIsInstructions.Size = new System.Drawing.Size(88, 20);
            this.chkIsInstructions.TabIndex = 9;
            // 
            // chkIsSpecifications
            // 
            this.chkIsSpecifications.Location = new System.Drawing.Point(272, 292);
            this.chkIsSpecifications.Name = "chkIsSpecifications";
            this.chkIsSpecifications.Properties.Caption = "Specifications";
            this.chkIsSpecifications.Size = new System.Drawing.Size(98, 20);
            this.chkIsSpecifications.TabIndex = 10;
            // 
            // chkIsPlans
            // 
            this.chkIsPlans.Location = new System.Drawing.Point(382, 292);
            this.chkIsPlans.Name = "chkIsPlans";
            this.chkIsPlans.Properties.Caption = "Plans";
            this.chkIsPlans.Size = new System.Drawing.Size(55, 20);
            this.chkIsPlans.TabIndex = 11;
            // 
            // chkIs3DPrintingDocument
            // 
            this.chkIs3DPrintingDocument.Location = new System.Drawing.Point(81, 292);
            this.chkIs3DPrintingDocument.Name = "chkIs3DPrintingDocument";
            this.chkIs3DPrintingDocument.Properties.Caption = "3D Printing";
            this.chkIs3DPrintingDocument.Size = new System.Drawing.Size(85, 20);
            this.chkIs3DPrintingDocument.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(220, 329);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 32);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(352, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(76, 329);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 32);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add New";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(80, 167);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(364, 116);
            this.txtDescription.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 142);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(364, 20);
            this.txtName.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(8, 167);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(64, 13);
            this.lblDescription.TabIndex = 65;
            this.lblDescription.Text = "Description:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(8, 145);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(31, 13);
            this.lblTitle.TabIndex = 64;
            this.lblTitle.Text = "Title:";
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.DisplayMember = "Name";
            this.cmbDocumentType.FormattingEnabled = true;
            this.cmbDocumentType.Location = new System.Drawing.Point(80, 88);
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(364, 21);
            this.cmbDocumentType.TabIndex = 4;
            this.cmbDocumentType.ValueMember = "d";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(8, 88);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 77;
            this.lblType.Text = "Type:";
            // 
            // lblSelectedDocumentName
            // 
            this.lblSelectedDocumentName.AutoSize = true;
            this.lblSelectedDocumentName.Location = new System.Drawing.Point(482, 64);
            this.lblSelectedDocumentName.Name = "lblSelectedDocumentName";
            this.lblSelectedDocumentName.Size = new System.Drawing.Size(19, 13);
            this.lblSelectedDocumentName.TabIndex = 0;
            this.lblSelectedDocumentName.Text = "...";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(8, 3);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(34, 13);
            this.lblProject.TabIndex = 15;
            this.lblProject.Text = "Project";
            // 
            // lblSection
            // 
            this.lblSection.Location = new System.Drawing.Point(8, 34);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(35, 13);
            this.lblSection.TabIndex = 2;
            this.lblSection.Text = "Section";
            // 
            // lblPart
            // 
            this.lblPart.Location = new System.Drawing.Point(8, 61);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(20, 13);
            this.lblPart.TabIndex = 81;
            this.lblPart.Text = "Part";
            // 
            // cmbProject
            // 
            this.cmbProject.DisplayMember = "Name";
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(80, 7);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(364, 21);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.ValueMember = "Id";
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Name";
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(80, 34);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(364, 21);
            this.cmbSection.TabIndex = 2;
            this.cmbSection.ValueMember = "Id";
            // 
            // cmbPart
            // 
            this.cmbPart.DisplayMember = "Name";
            this.cmbPart.FormattingEnabled = true;
            this.cmbPart.Location = new System.Drawing.Point(80, 61);
            this.cmbPart.Name = "cmbPart";
            this.cmbPart.Size = new System.Drawing.Size(364, 21);
            this.cmbPart.TabIndex = 3;
            this.cmbPart.ValueMember = "Id";
            // 
            // cmbDocumentFileType
            // 
            this.cmbDocumentFileType.DisplayMember = "Name";
            this.cmbDocumentFileType.FormattingEnabled = true;
            this.cmbDocumentFileType.Location = new System.Drawing.Point(80, 114);
            this.cmbDocumentFileType.Name = "cmbDocumentFileType";
            this.cmbDocumentFileType.Size = new System.Drawing.Size(364, 21);
            this.cmbDocumentFileType.TabIndex = 5;
            this.cmbDocumentFileType.ValueMember = "d";
            // 
            // lblFileType
            // 
            this.lblFileType.Location = new System.Drawing.Point(8, 114);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(47, 13);
            this.lblFileType.TabIndex = 83;
            this.lblFileType.Text = "File Type:";
            // 
            // ucProjectDocEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDocumentFileType);
            this.Controls.Add(this.lblFileType);
            this.Controls.Add(this.cmbPart);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblPart);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.chkIsInstructions);
            this.Controls.Add(this.chkIsSpecifications);
            this.Controls.Add(this.chkIsPlans);
            this.Controls.Add(this.chkIs3DPrintingDocument);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbDocumentType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblSelectedDocumentName);
            this.Name = "ucProjectDocEditor";
            this.Size = new System.Drawing.Size(622, 374);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsInstructions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecifications.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPlans.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIs3DPrintingDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private ComboBox cmbDocumentType;
        private DevExpress.XtraEditors.LabelControl lblType;
        private Label lblSelectedDocumentName;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LabelControl lblSection;
        private DevExpress.XtraEditors.LabelControl lblPart;
        private ComboBox cmbProject;
        private ComboBox cmbSection;
        private ComboBox cmbPart;
        private ComboBox cmbDocumentFileType;
        private DevExpress.XtraEditors.LabelControl lblFileType;
    }
}
