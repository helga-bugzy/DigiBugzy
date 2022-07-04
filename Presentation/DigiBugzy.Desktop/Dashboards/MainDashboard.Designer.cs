namespace DigiBugzy.Desktop.Dashboards
{
    partial class MainDashboard
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ContentTabControl = new System.Windows.Forms.TabControl();
            this.tabProjects = new System.Windows.Forms.TabPage();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.tabAdministration = new System.Windows.Forms.TabPage();
            this.tabctrlAdministrations = new System.Windows.Forms.TabControl();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.tabCustomFields = new System.Windows.Forms.TabPage();
            this.pnlContent.SuspendLayout();
            this.ContentTabControl.SuspendLayout();
            this.tabAdministration.SuspendLayout();
            this.tabctrlAdministrations.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 771);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1445, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1445, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 747);
            this.panel1.TabIndex = 4;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ContentTabControl);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 24);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1245, 747);
            this.pnlContent.TabIndex = 5;
            // 
            // ContentTabControl
            // 
            this.ContentTabControl.Controls.Add(this.tabProjects);
            this.ContentTabControl.Controls.Add(this.tabProducts);
            this.ContentTabControl.Controls.Add(this.tabAdministration);
            this.ContentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentTabControl.HotTrack = true;
            this.ContentTabControl.Location = new System.Drawing.Point(0, 0);
            this.ContentTabControl.Name = "ContentTabControl";
            this.ContentTabControl.SelectedIndex = 0;
            this.ContentTabControl.Size = new System.Drawing.Size(1245, 747);
            this.ContentTabControl.TabIndex = 0;
            this.ContentTabControl.Tag = "Administration";
            // 
            // tabProjects
            // 
            this.tabProjects.Location = new System.Drawing.Point(4, 24);
            this.tabProjects.Name = "tabProjects";
            this.tabProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjects.Size = new System.Drawing.Size(1237, 719);
            this.tabProjects.TabIndex = 0;
            this.tabProjects.Tag = "Project";
            this.tabProjects.Text = "Projects";
            this.tabProjects.UseVisualStyleBackColor = true;
            // 
            // tabProducts
            // 
            this.tabProducts.Location = new System.Drawing.Point(4, 24);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(1237, 719);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Tag = "Product";
            this.tabProducts.Text = "Products";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // tabAdministration
            // 
            this.tabAdministration.Controls.Add(this.tabctrlAdministrations);
            this.tabAdministration.Location = new System.Drawing.Point(4, 24);
            this.tabAdministration.Name = "tabAdministration";
            this.tabAdministration.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdministration.Size = new System.Drawing.Size(1237, 719);
            this.tabAdministration.TabIndex = 2;
            this.tabAdministration.Text = "Administration";
            this.tabAdministration.UseVisualStyleBackColor = true;
            // 
            // tabctrlAdministrations
            // 
            this.tabctrlAdministrations.Controls.Add(this.tabCategories);
            this.tabctrlAdministrations.Controls.Add(this.tabCustomFields);
            this.tabctrlAdministrations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrlAdministrations.HotTrack = true;
            this.tabctrlAdministrations.Location = new System.Drawing.Point(3, 3);
            this.tabctrlAdministrations.Name = "tabctrlAdministrations";
            this.tabctrlAdministrations.SelectedIndex = 0;
            this.tabctrlAdministrations.Size = new System.Drawing.Size(1231, 713);
            this.tabctrlAdministrations.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Location = new System.Drawing.Point(4, 24);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(1223, 685);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Tag = "Category";
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // tabCustomFields
            // 
            this.tabCustomFields.Location = new System.Drawing.Point(4, 24);
            this.tabCustomFields.Name = "tabCustomFields";
            this.tabCustomFields.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomFields.Size = new System.Drawing.Size(1223, 685);
            this.tabCustomFields.TabIndex = 1;
            this.tabCustomFields.Tag = "CustomField";
            this.tabCustomFields.Text = "CustomFields";
            this.tabCustomFields.UseVisualStyleBackColor = true;
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 793);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainDashboard";
            this.Text = "MainDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlContent.ResumeLayout(false);
            this.ContentTabControl.ResumeLayout(false);
            this.tabAdministration.ResumeLayout(false);
            this.tabctrlAdministrations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private Panel panel1;
        private Panel pnlContent;
        private TabControl ContentTabControl;
        private TabPage tabProjects;
        private TabPage tabProducts;
        private TabPage tabAdministration;
        private TabControl tabctrlAdministrations;
        private TabPage tabCategories;
        private TabPage tabCustomFields;
    }
}