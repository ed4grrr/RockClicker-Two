namespace RockClicker_Two.source.Forms
{
    partial class Form2
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
            this.namePromptLabel = new System.Windows.Forms.Label();
            this.miningCompanyName = new System.Windows.Forms.MaskedTextBox();
            this.startJourneyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namePromptLabel
            // 
            this.namePromptLabel.AutoSize = true;
            this.namePromptLabel.Location = new System.Drawing.Point(158, 125);
            this.namePromptLabel.Name = "namePromptLabel";
            this.namePromptLabel.Size = new System.Drawing.Size(789, 32);
            this.namePromptLabel.TabIndex = 0;
            this.namePromptLabel.Text = "Please Enter a Name for your BRAND NEW Mining Company!";
            // 
            // miningCompanyName
            // 
            this.miningCompanyName.BeepOnError = true;
            this.miningCompanyName.Location = new System.Drawing.Point(164, 239);
            this.miningCompanyName.Name = "miningCompanyName";
            this.miningCompanyName.Size = new System.Drawing.Size(783, 38);
            this.miningCompanyName.TabIndex = 1;
            this.miningCompanyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.miningCompanyName_KeyPress);
            // 
            // startJourneyButton
            // 
            this.startJourneyButton.Location = new System.Drawing.Point(414, 329);
            this.startJourneyButton.Name = "startJourneyButton";
            this.startJourneyButton.Size = new System.Drawing.Size(249, 105);
            this.startJourneyButton.TabIndex = 2;
            this.startJourneyButton.Text = "Start Your Rocky Journey!";
            this.startJourneyButton.UseVisualStyleBackColor = true;
            this.startJourneyButton.Click += new System.EventHandler(this.startJourneyButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 500);
            this.Controls.Add(this.startJourneyButton);
            this.Controls.Add(this.miningCompanyName);
            this.Controls.Add(this.namePromptLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label namePromptLabel;
        private System.Windows.Forms.MaskedTextBox miningCompanyName;
        private System.Windows.Forms.Button startJourneyButton;
    }
}