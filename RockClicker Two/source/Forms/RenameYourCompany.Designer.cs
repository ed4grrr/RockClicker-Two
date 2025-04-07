namespace RockClicker_Two.source.Forms
{
    partial class RenameYourCompany
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
            this.renamePromptLabel = new System.Windows.Forms.Label();
            this.enteredCompanyNameTextbox = new System.Windows.Forms.MaskedTextBox();
            this.renameCompanyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // renamePromptLabel
            // 
            this.renamePromptLabel.AutoSize = true;
            this.renamePromptLabel.Location = new System.Drawing.Point(251, 211);
            this.renamePromptLabel.Name = "renamePromptLabel";
            this.renamePromptLabel.Size = new System.Drawing.Size(457, 32);
            this.renamePromptLabel.TabIndex = 0;
            this.renamePromptLabel.Text = "Enter new name for your Company!";
            // 
            // enteredCompanyNameTextbox
            // 
            this.enteredCompanyNameTextbox.Location = new System.Drawing.Point(276, 299);
            this.enteredCompanyNameTextbox.Name = "enteredCompanyNameTextbox";
            this.enteredCompanyNameTextbox.Size = new System.Drawing.Size(385, 38);
            this.enteredCompanyNameTextbox.TabIndex = 1;
            this.enteredCompanyNameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enteredCompanyNameTextbox_KeyPress);
            // 
            // renameCompanyButton
            // 
            this.renameCompanyButton.Location = new System.Drawing.Point(403, 380);
            this.renameCompanyButton.Name = "renameCompanyButton";
            this.renameCompanyButton.Size = new System.Drawing.Size(147, 113);
            this.renameCompanyButton.TabIndex = 2;
            this.renameCompanyButton.Text = "Rename Company";
            this.renameCompanyButton.UseVisualStyleBackColor = true;
            this.renameCompanyButton.Click += new System.EventHandler(this.renameCompanyButton_Click);
            // 
            // RenameYourCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 705);
            this.Controls.Add(this.renameCompanyButton);
            this.Controls.Add(this.enteredCompanyNameTextbox);
            this.Controls.Add(this.renamePromptLabel);
            this.Name = "RenameYourCompany";
            this.Text = "RenameYourCompany";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label renamePromptLabel;
        private System.Windows.Forms.MaskedTextBox enteredCompanyNameTextbox;
        private System.Windows.Forms.Button renameCompanyButton;
    }
}