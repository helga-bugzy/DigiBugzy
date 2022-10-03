namespace DigiBugzy.Desktop.Projects.UserControls
{
    partial class ucProjectDocManager
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
            DigiBugzy.Core.Domain.Projects.ProjectDocument projectDocument1 = new DigiBugzy.Core.Domain.Projects.ProjectDocument();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitViewer = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucBaseViewer1 = new DigiBugzy.Desktop.MultiFunctional.DocumentViewers.ucBaseViewer();
            this.ucBaseViewer2 = new DigiBugzy.Desktop.MultiFunctional.DocumentViewers.ucBaseViewer();
            this.ucProjectDocEditor1 = new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocEditor();
            this.ucProjectDocGrid1 = new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocGrid();
            this.ucBaseViewer3 = new DigiBugzy.Desktop.MultiFunctional.DocumentViewers.ucBaseViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitViewer.Panel1)).BeginInit();
            this.splitViewer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitViewer.Panel2)).BeginInit();
            this.splitViewer.Panel2.SuspendLayout();
            this.splitViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.ucProjectDocGrid1);
            this.splitMain.Panel1.Controls.Add(this.ucBaseViewer2);
            this.splitMain.Panel1.Controls.Add(this.ucBaseViewer1);
            this.splitMain.Panel1.Text = "Panel1";
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitViewer);
            this.splitMain.Panel2.Text = "Panel2";
            this.splitMain.Size = new System.Drawing.Size(1704, 587);
            this.splitMain.SplitterPosition = 518;
            this.splitMain.TabIndex = 0;
            // 
            // splitViewer
            // 
            this.splitViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitViewer.Location = new System.Drawing.Point(0, 0);
            this.splitViewer.Name = "splitViewer";
            // 
            // splitViewer.Panel1
            // 
            this.splitViewer.Panel1.Controls.Add(this.ucProjectDocEditor1);
            this.splitViewer.Panel1.Text = "Panel1";
            // 
            // splitViewer.Panel2
            // 
            this.splitViewer.Panel2.Controls.Add(this.ucBaseViewer3);
            this.splitViewer.Panel2.Text = "Panel2";
            this.splitViewer.Size = new System.Drawing.Size(1176, 587);
            this.splitViewer.SplitterPosition = 659;
            this.splitViewer.TabIndex = 0;
            // 
            // ucBaseViewer1
            // 
            this.ucBaseViewer1.Location = new System.Drawing.Point(314, 59);
            this.ucBaseViewer1.Name = "ucBaseViewer1";
            this.ucBaseViewer1.Size = new System.Drawing.Size(150, 150);
            this.ucBaseViewer1.TabIndex = 0;
            // 
            // ucBaseViewer2
            // 
            this.ucBaseViewer2.Location = new System.Drawing.Point(264, 502);
            this.ucBaseViewer2.Name = "ucBaseViewer2";
            this.ucBaseViewer2.Size = new System.Drawing.Size(150, 150);
            this.ucBaseViewer2.TabIndex = 1;
            // 
            // ucProjectDocEditor1
            // 
            this.ucProjectDocEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProjectDocEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucProjectDocEditor1.Name = "ucProjectDocEditor1";
            projectDocument1.CreatedOn = new System.DateTime(((long)(0)));
            projectDocument1.Description = null;
            projectDocument1.DigiAdmin = null;
            projectDocument1.DigiAdminId = 0;
            projectDocument1.DocumentData = null;
            projectDocument1.DocumentType = null;
            projectDocument1.DocumentTypeId = 0;
            projectDocument1.Id = 0;
            projectDocument1.Is3DPrintingDocument = false;
            projectDocument1.IsActive = false;
            projectDocument1.IsDeleted = false;
            projectDocument1.IsInstructions = false;
            projectDocument1.IsPlans = false;
            projectDocument1.IsSpecifications = false;
            projectDocument1.Name = null;
            projectDocument1.Project = null;
            projectDocument1.ProjectId = 0;
            projectDocument1.ProjectSection = null;
            projectDocument1.ProjectSectionId = null;
            projectDocument1.ProjectSectionPart = null;
            projectDocument1.ProjectSectionPartId = null;
            this.ucProjectDocEditor1.SelectedDocument = projectDocument1;
            this.ucProjectDocEditor1.Size = new System.Drawing.Size(659, 587);
            this.ucProjectDocEditor1.TabIndex = 0;
            // 
            // ucProjectDocGrid1
            // 
            this.ucProjectDocGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProjectDocGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucProjectDocGrid1.Name = "ucProjectDocGrid1";
            this.ucProjectDocGrid1.Size = new System.Drawing.Size(518, 587);
            this.ucProjectDocGrid1.TabIndex = 2;
            // 
            // ucBaseViewer3
            // 
            this.ucBaseViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBaseViewer3.Location = new System.Drawing.Point(0, 0);
            this.ucBaseViewer3.Name = "ucBaseViewer3";
            this.ucBaseViewer3.Size = new System.Drawing.Size(507, 587);
            this.ucBaseViewer3.TabIndex = 0;
            // 
            // ucProjectDocManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Name = "ucProjectDocManager";
            this.Size = new System.Drawing.Size(1704, 587);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitViewer.Panel1)).EndInit();
            this.splitViewer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitViewer.Panel2)).EndInit();
            this.splitViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitViewer)).EndInit();
            this.splitViewer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.SplitContainerControl splitViewer;
        private ucProjectDocGrid ucProjectDocGrid1;
        private MultiFunctional.DocumentViewers.ucBaseViewer ucBaseViewer2;
        private MultiFunctional.DocumentViewers.ucBaseViewer ucBaseViewer1;
        private ucProjectDocEditor ucProjectDocEditor1;
        private MultiFunctional.DocumentViewers.ucBaseViewer ucBaseViewer3;
    }
}
