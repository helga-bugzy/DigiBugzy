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
            this.lblName = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmbValue = new System.Windows.Forms.ComboBox();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.rbFalse = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "FieldName";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(105, 11);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(346, 21);
            this.txtValue.TabIndex = 1;
            // 
            // cmbValue
            // 
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(105, 11);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(346, 21);
            this.cmbValue.TabIndex = 2;
            // 
            // rbTrue
            // 
            this.rbTrue.AutoSize = true;
            this.rbTrue.Location = new System.Drawing.Point(105, 15);
            this.rbTrue.Name = "rbTrue";
            this.rbTrue.Size = new System.Drawing.Size(68, 17);
            this.rbTrue.TabIndex = 3;
            this.rbTrue.TabStop = true;
            this.rbTrue.Text = "True/Yes";
            this.rbTrue.UseVisualStyleBackColor = true;
            // 
            // rbFalse
            // 
            this.rbFalse.AutoSize = true;
            this.rbFalse.Location = new System.Drawing.Point(208, 14);
            this.rbFalse.Name = "rbFalse";
            this.rbFalse.Size = new System.Drawing.Size(75, 17);
            this.rbFalse.TabIndex = 4;
            this.rbFalse.TabStop = true;
            this.rbFalse.Text = "False/Now";
            this.rbFalse.UseVisualStyleBackColor = true;
            // 
            // CustomFieldItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbFalse);
            this.Controls.Add(this.rbTrue);
            this.Controls.Add(this.cmbValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblName);
            this.Name = "CustomFieldItem";
            this.Size = new System.Drawing.Size(454, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private TextBox txtValue;
        private ComboBox cmbValue;
        private RadioButton rbTrue;
        private RadioButton rbFalse;
    }
}
