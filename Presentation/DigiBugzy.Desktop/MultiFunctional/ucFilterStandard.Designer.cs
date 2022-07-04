namespace DigiBugzy.Desktop.MultiFunctional
{
    partial class ucFilterStandard
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
            this.lblClassification = new System.Windows.Forms.Label();
            this.cmbClassification = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkLikeSearch = new System.Windows.Forms.CheckBox();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            this.chkIncludeDeleted = new System.Windows.Forms.CheckBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClassification
            // 
            this.lblClassification.AutoSize = true;
            this.lblClassification.Location = new System.Drawing.Point(17, 12);
            this.lblClassification.Name = "lblClassification";
            this.lblClassification.Size = new System.Drawing.Size(77, 15);
            this.lblClassification.TabIndex = 0;
            this.lblClassification.Text = "Classification";
            // 
            // cmbClassification
            // 
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Location = new System.Drawing.Point(100, 9);
            this.cmbClassification.Name = "cmbClassification";
            this.cmbClassification.Size = new System.Drawing.Size(327, 23);
            this.cmbClassification.TabIndex = 1;
            this.cmbClassification.SelectedIndexChanged += new System.EventHandler(this.cmbClassification_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(327, 23);
            this.txtName.TabIndex = 3;
            // 
            // chkLikeSearch
            // 
            this.chkLikeSearch.AutoSize = true;
            this.chkLikeSearch.Location = new System.Drawing.Point(456, 71);
            this.chkLikeSearch.Name = "chkLikeSearch";
            this.chkLikeSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLikeSearch.Size = new System.Drawing.Size(85, 19);
            this.chkLikeSearch.TabIndex = 4;
            this.chkLikeSearch.Text = "Like Search";
            this.chkLikeSearch.UseVisualStyleBackColor = true;
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Location = new System.Drawing.Point(214, 71);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIncludeInactive.Size = new System.Drawing.Size(109, 19);
            this.chkIncludeInactive.TabIndex = 5;
            this.chkIncludeInactive.Text = "Include Inactive";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            // 
            // chkIncludeDeleted
            // 
            this.chkIncludeDeleted.AutoSize = true;
            this.chkIncludeDeleted.Location = new System.Drawing.Point(342, 71);
            this.chkIncludeDeleted.Name = "chkIncludeDeleted";
            this.chkIncludeDeleted.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIncludeDeleted.Size = new System.Drawing.Size(108, 19);
            this.chkIncludeDeleted.TabIndex = 6;
            this.chkIncludeDeleted.Text = "Include Deleted";
            this.chkIncludeDeleted.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(17, 70);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(17, 15);
            this.lblId.TabIndex = 7;
            this.lblId.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(100, 67);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 8;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(516, 38);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(294, 23);
            this.txtDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(433, 41);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Description";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Enabled = false;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(516, 9);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(294, 23);
            this.cmbCategory.TabIndex = 12;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(433, 12);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(735, 71);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 13;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // ucFilterStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.chkIncludeDeleted);
            this.Controls.Add(this.chkIncludeInactive);
            this.Controls.Add(this.chkLikeSearch);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmbClassification);
            this.Controls.Add(this.lblClassification);
            this.Name = "ucFilterStandard";
            this.Size = new System.Drawing.Size(1383, 112);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblClassification;
        private ComboBox cmbClassification;
        private Label lblName;
        private TextBox txtName;
        private CheckBox chkLikeSearch;
        private CheckBox chkIncludeInactive;
        private CheckBox chkIncludeDeleted;
        private Label lblId;
        private TextBox txtId;
        private TextBox txtDescription;
        private Label lblDescription;
        private ComboBox cmbCategory;
        private Label lblCategory;
        private Button btnFilter;
    }
}
