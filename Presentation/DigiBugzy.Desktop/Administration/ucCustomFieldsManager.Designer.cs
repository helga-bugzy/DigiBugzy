namespace DigiBugzy.Desktop.Administration
{
    partial class ucCustomFieldsManager
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.ucFilterStandard1 = new DigiBugzy.Desktop.MultiFunctional.ucFilterStandard();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.ucFilterStandard1);
            this.splitMain.Size = new System.Drawing.Size(1369, 770);
            this.splitMain.SplitterDistance = 105;
            this.splitMain.TabIndex = 0;
            // 
            // ucFilterStandard1
            // 
            this.ucFilterStandard1.CanFilterCategories = false;
            this.ucFilterStandard1.CanFilterClassifications = false;
            this.ucFilterStandard1.Location = new System.Drawing.Point(3, 3);
            this.ucFilterStandard1.Name = "ucFilterStandard1";
            this.ucFilterStandard1.Size = new System.Drawing.Size(1383, 112);
            this.ucFilterStandard1.TabIndex = 0;
            // 
            // ucCustomFieldsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Name = "ucCustomFieldsManager";
            this.Size = new System.Drawing.Size(1369, 770);
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitMain;
        private ucFilterStandard ucFilterStandard1;
    }
}
