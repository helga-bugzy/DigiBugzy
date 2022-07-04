namespace DigiBugzy.Desktop
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbAdministrations = new System.Windows.Forms.ComboBox();
            this.lblAdministration = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbAdministrations
            // 
            this.cmbAdministrations.FormattingEnabled = true;
            this.cmbAdministrations.Location = new System.Drawing.Point(128, 32);
            this.cmbAdministrations.Name = "cmbAdministrations";
            this.cmbAdministrations.Size = new System.Drawing.Size(374, 23);
            this.cmbAdministrations.TabIndex = 0;
            // 
            // lblAdministration
            // 
            this.lblAdministration.AutoSize = true;
            this.lblAdministration.Location = new System.Drawing.Point(37, 35);
            this.lblAdministration.Name = "lblAdministration";
            this.lblAdministration.Size = new System.Drawing.Size(86, 15);
            this.lblAdministration.TabIndex = 1;
            this.lblAdministration.Text = "Administration";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(346, 70);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(427, 70);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 116);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblAdministration);
            this.Controls.Add(this.cmbAdministrations);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbAdministrations;
        private Label lblAdministration;
        private Button btnExit;
        private Button btnContinue;
    }
}