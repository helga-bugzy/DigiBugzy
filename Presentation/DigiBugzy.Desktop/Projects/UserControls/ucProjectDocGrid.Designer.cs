namespace DigiBugzy.Desktop.Projects.UserControls
{
    partial class ucProjectDocGrid
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
            this.gridDocuments = new DevExpress.XtraGrid.GridControl();
            this.gvDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDocuments
            // 
            this.gridDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDocuments.Location = new System.Drawing.Point(0, 0);
            this.gridDocuments.MainView = this.gvDocuments;
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.Size = new System.Drawing.Size(938, 488);
            this.gridDocuments.TabIndex = 0;
            this.gridDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocuments});
            // 
            // gvDocuments
            // 
            this.gvDocuments.GridControl = this.gridDocuments;
            this.gvDocuments.Name = "gvDocuments";
            // 
            // bindingSource1
            // 
            this.bindingSource1.PositionChanged += new System.EventHandler(this.bindingSource1_PositionChanged);
            // 
            // ucProjectDocGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDocuments);
            this.Name = "ucProjectDocGrid";
            this.Size = new System.Drawing.Size(938, 488);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocuments;
        private BindingSource bindingSource1;
    }
}
