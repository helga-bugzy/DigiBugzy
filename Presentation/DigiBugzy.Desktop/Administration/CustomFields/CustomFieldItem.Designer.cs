namespace DigiBugzy.Desktop.Administration.CustomFields
{
    partial class CustomFieldItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomFieldItem));
            this.lblName = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmbValue = new System.Windows.Forms.ComboBox();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.rbFalse = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblSaved = new DevExpress.XtraEditors.LabelControl();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "FieldName";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(153, 3);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(346, 21);
            this.txtValue.TabIndex = 1;
            this.txtValue.TextChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // cmbValue
            // 
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(153, 3);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(319, 21);
            this.cmbValue.TabIndex = 2;
            this.cmbValue.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // rbTrue
            // 
            this.rbTrue.AutoSize = true;
            this.rbTrue.Location = new System.Drawing.Point(153, 5);
            this.rbTrue.Name = "rbTrue";
            this.rbTrue.Size = new System.Drawing.Size(68, 17);
            this.rbTrue.TabIndex = 3;
            this.rbTrue.TabStop = true;
            this.rbTrue.Text = "True/Yes";
            this.rbTrue.UseVisualStyleBackColor = true;
            this.rbTrue.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // rbFalse
            // 
            this.rbFalse.AutoSize = true;
            this.rbFalse.Location = new System.Drawing.Point(256, 5);
            this.rbFalse.Name = "rbFalse";
            this.rbFalse.Size = new System.Drawing.Size(75, 17);
            this.rbFalse.TabIndex = 4;
            this.rbFalse.TabStop = true;
            this.rbFalse.Text = "False/Now";
            this.rbFalse.UseVisualStyleBackColor = true;
            this.rbFalse.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(477, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(22, 22);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.ToolTip = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(505, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(22, 22);
            this.btnSave.TabIndex = 6;
            this.btnSave.ToolTip = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSaved
            // 
            this.lblSaved.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblSaved.Appearance.Options.UseForeColor = true;
            this.lblSaved.Location = new System.Drawing.Point(596, 9);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(59, 13);
            this.lblSaved.TabIndex = 7;
            this.lblSaved.Text = "Value Saved";
            // 
            // lblType
            // 
            this.lblType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblType.Appearance.ForeColor = System.Drawing.Color.SlateGray;
            this.lblType.Appearance.Options.UseFont = true;
            this.lblType.Appearance.Options.UseForeColor = true;
            this.lblType.Location = new System.Drawing.Point(533, 7);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(45, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type(...)";
            // 
            // CustomFieldItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblSaved);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.rbFalse);
            this.Controls.Add(this.rbTrue);
            this.Controls.Add(this.cmbValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblName);
            this.Name = "CustomFieldItem";
            this.Size = new System.Drawing.Size(670, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private TextBox txtValue;
        private ComboBox cmbValue;
        private RadioButton rbTrue;
        private RadioButton rbFalse;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblSaved;
        private DevExpress.XtraEditors.LabelControl lblType;
    }
}
