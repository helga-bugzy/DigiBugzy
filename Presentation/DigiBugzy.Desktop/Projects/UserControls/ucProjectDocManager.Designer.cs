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
            DigiBugzy.Core.Domain.Projects.ProjectDocument projectDocument2 = new DigiBugzy.Core.Domain.Projects.ProjectDocument();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grid = new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocGrid();
            this.ucBaseViewer2 = new DigiBugzy.Desktop.MultiFunctional.DocumentViewers.ucBaseViewer();
            this.ucBaseViewer1 = new DigiBugzy.Desktop.MultiFunctional.DocumentViewers.ucBaseViewer();
            this.splitViewer = new DevExpress.XtraEditors.SplitContainerControl();
            this.editor = new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocEditor();
            this.viewer = new DigiBugzy.Desktop.MultiFunctional.DocumentViewers.ucBaseViewer();
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
            this.splitMain.Panel1.Controls.Add(this.grid);
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
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(518, 587);
            this.grid.TabIndex = 2;
            this.grid.SelectedDocumentChanged += new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocGrid.SelectedDocumentChangedEvent(this.grid_SelectedDocumentChanged);
            // 
            // ucBaseViewer2
            // 
            this.ucBaseViewer2.Location = new System.Drawing.Point(264, 502);
            this.ucBaseViewer2.Name = "ucBaseViewer2";
            this.ucBaseViewer2.Size = new System.Drawing.Size(150, 150);
            this.ucBaseViewer2.TabIndex = 1;
            // 
            // ucBaseViewer1
            // 
            this.ucBaseViewer1.Location = new System.Drawing.Point(314, 59);
            this.ucBaseViewer1.Name = "ucBaseViewer1";
            this.ucBaseViewer1.Size = new System.Drawing.Size(150, 150);
            this.ucBaseViewer1.TabIndex = 0;
            // 
            // splitViewer
            // 
            this.splitViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitViewer.Location = new System.Drawing.Point(0, 0);
            this.splitViewer.Name = "splitViewer";
            // 
            // splitViewer.Panel1
            // 
            this.splitViewer.Panel1.Controls.Add(this.editor);
            this.splitViewer.Panel1.Text = "Panel1";
            // 
            // splitViewer.Panel2
            // 
            this.splitViewer.Panel2.Controls.Add(this.viewer);
            this.splitViewer.Panel2.Text = "Panel2";
            this.splitViewer.Size = new System.Drawing.Size(1176, 587);
            this.splitViewer.SplitterPosition = 659;
            this.splitViewer.TabIndex = 0;
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            projectDocument2.CreatedOn = new System.DateTime(((long)(0)));
            projectDocument2.Description = null;
            projectDocument2.DigiAdmin = null;
            projectDocument2.DigiAdminId = 0;
            projectDocument2.DocumentData = null;
            projectDocument2.DocumentFileType = null;
            projectDocument2.DocumentFileTypeId = 0;
            projectDocument2.DocumentType = null;
            projectDocument2.DocumentTypeId = 0;
            projectDocument2.Id = 0;
            projectDocument2.Is3DPrintingDocument = false;
            projectDocument2.IsActive = false;
            projectDocument2.IsDeleted = false;
            projectDocument2.IsInstructions = false;
            projectDocument2.IsPlans = false;
            projectDocument2.IsSpecifications = false;
            projectDocument2.Name = null;
            projectDocument2.Project = null;
            projectDocument2.ProjectId = 0;
            projectDocument2.ProjectSection = null;
            projectDocument2.ProjectSectionId = null;
            projectDocument2.ProjectSectionPart = null;
            projectDocument2.ProjectSectionPartId = null;
            this.editor.SelectedDocument = projectDocument2;
            this.editor.Size = new System.Drawing.Size(659, 587);
            this.editor.TabIndex = 0;
            this.editor.OnSave += new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocEditor.OnSaveDelegate(this.editor_OnSave);
            this.editor.OnDelete += new DigiBugzy.Desktop.Projects.UserControls.ucProjectDocEditor.OnDeleteDelegate(this.editor_OnDelete);
            // 
            // viewer
            // 
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(507, 587);
            this.viewer.TabIndex = 0;
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
        private ucProjectDocGrid grid;
        private MultiFunctional.DocumentViewers.ucBaseViewer ucBaseViewer2;
        private MultiFunctional.DocumentViewers.ucBaseViewer ucBaseViewer1;
        private ucProjectDocEditor editor;
        private MultiFunctional.DocumentViewers.ucBaseViewer viewer;
    }
}
