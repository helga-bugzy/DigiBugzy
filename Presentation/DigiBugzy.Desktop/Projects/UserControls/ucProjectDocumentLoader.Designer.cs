namespace DigiBugzy.Desktop.Projects.UserControls
{
    partial class ucProjectDocumentLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjectDocumentLoader));
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblProjectPartsDocumentDescription = new System.Windows.Forms.Label();
            this.lblProjectPartsDocumentName = new System.Windows.Forms.Label();
            this.chkIs3DPrintingDocument = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsPlans = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsSpecifications = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsInstructions = new DevExpress.XtraEditors.CheckEdit();
            this.btnSelectFile = new DevExpress.XtraEditors.SimpleButton();
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.lblSelectedDocumentName = new System.Windows.Forms.Label();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIs3DPrintingDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPlans.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecifications.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsInstructions.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(221, 299);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 32);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "Delete";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(353, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 32);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(77, 299);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 32);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "Add New";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(77, 52);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(364, 139);
            this.txtDescription.TabIndex = 37;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(364, 20);
            this.txtName.TabIndex = 36;
            // 
            // lblProjectPartsDocumentDescription
            // 
            this.lblProjectPartsDocumentDescription.AutoSize = true;
            this.lblProjectPartsDocumentDescription.Location = new System.Drawing.Point(11, 54);
            this.lblProjectPartsDocumentDescription.Name = "lblProjectPartsDocumentDescription";
            this.lblProjectPartsDocumentDescription.Size = new System.Drawing.Size(64, 13);
            this.lblProjectPartsDocumentDescription.TabIndex = 35;
            this.lblProjectPartsDocumentDescription.Text = "Description:";
            // 
            // lblProjectPartsDocumentName
            // 
            this.lblProjectPartsDocumentName.AutoSize = true;
            this.lblProjectPartsDocumentName.Location = new System.Drawing.Point(11, 19);
            this.lblProjectPartsDocumentName.Name = "lblProjectPartsDocumentName";
            this.lblProjectPartsDocumentName.Size = new System.Drawing.Size(31, 13);
            this.lblProjectPartsDocumentName.TabIndex = 34;
            this.lblProjectPartsDocumentName.Text = "Title:";
            // 
            // chkIs3DPrintingDocument
            // 
            this.chkIs3DPrintingDocument.Location = new System.Drawing.Point(77, 247);
            this.chkIs3DPrintingDocument.Name = "chkIs3DPrintingDocument";
            this.chkIs3DPrintingDocument.Properties.Caption = "3D Printing";
            this.chkIs3DPrintingDocument.Size = new System.Drawing.Size(85, 20);
            this.chkIs3DPrintingDocument.TabIndex = 41;
            // 
            // chkIsPlans
            // 
            this.chkIsPlans.Location = new System.Drawing.Point(384, 247);
            this.chkIsPlans.Name = "chkIsPlans";
            this.chkIsPlans.Properties.Caption = "Plans";
            this.chkIsPlans.Size = new System.Drawing.Size(55, 20);
            this.chkIsPlans.TabIndex = 42;
            // 
            // chkIsSpecifications
            // 
            this.chkIsSpecifications.Location = new System.Drawing.Point(274, 247);
            this.chkIsSpecifications.Name = "chkIsSpecifications";
            this.chkIsSpecifications.Properties.Caption = "Specifications";
            this.chkIsSpecifications.Size = new System.Drawing.Size(98, 20);
            this.chkIsSpecifications.TabIndex = 43;
            // 
            // chkIsInstructions
            // 
            this.chkIsInstructions.Location = new System.Drawing.Point(174, 247);
            this.chkIsInstructions.Name = "chkIsInstructions";
            this.chkIsInstructions.Properties.Caption = "Instructions";
            this.chkIsInstructions.Size = new System.Drawing.Size(88, 20);
            this.chkIsInstructions.TabIndex = 44;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.ImageOptions.Image")));
            this.btnSelectFile.Location = new System.Drawing.Point(475, 19);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(132, 41);
            this.btnSelectFile.TabIndex = 45;
            this.btnSelectFile.Text = "Select Document";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // lblSelectedDocumentName
            // 
            this.lblSelectedDocumentName.AutoSize = true;
            this.lblSelectedDocumentName.Location = new System.Drawing.Point(475, 80);
            this.lblSelectedDocumentName.Name = "lblSelectedDocumentName";
            this.lblSelectedDocumentName.Size = new System.Drawing.Size(19, 13);
            this.lblSelectedDocumentName.TabIndex = 46;
            this.lblSelectedDocumentName.Text = "...";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(13, 202);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 47;
            this.lblType.Text = "Type:";
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.FormattingEnabled = true;
            this.cmbDocumentType.Location = new System.Drawing.Point(81, 207);
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(358, 21);
            this.cmbDocumentType.TabIndex = 48;
            // 
            // ucProjectDocumentLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDocumentType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblSelectedDocumentName);
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
            this.Controls.Add(this.lblProjectPartsDocumentDescription);
            this.Controls.Add(this.lblProjectPartsDocumentName);
            this.Name = "ucProjectDocumentLoader";
            this.Size = new System.Drawing.Size(640, 357);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIs3DPrintingDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPlans.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecifications.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsInstructions.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private TextBox txtDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private Label lblProjectPartsDocumentDescription;
        private Label lblProjectPartsDocumentName;
        private DevExpress.XtraEditors.CheckEdit chkIs3DPrintingDocument;
        private DevExpress.XtraEditors.CheckEdit chkIsPlans;
        private DevExpress.XtraEditors.CheckEdit chkIsSpecifications;
        private DevExpress.XtraEditors.CheckEdit chkIsInstructions;
        private DevExpress.XtraEditors.SimpleButton btnSelectFile;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private Label lblSelectedDocumentName;
        private DevExpress.XtraEditors.LabelControl lblType;
        private ComboBox cmbDocumentType;
    }
}
