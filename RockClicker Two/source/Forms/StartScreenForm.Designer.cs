namespace RockClicker_Two
{
    partial class StartScreenForm
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.loadGameButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(429, 82);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(421, 32);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "WELCOME TO ROCK CLICKER";
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(542, 202);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(193, 93);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // loadGameButton
            // 
            this.loadGameButton.Location = new System.Drawing.Point(542, 373);
            this.loadGameButton.Name = "loadGameButton";
            this.loadGameButton.Size = new System.Drawing.Size(193, 93);
            this.loadGameButton.TabIndex = 2;
            this.loadGameButton.Text = "Load Game";
            this.loadGameButton.UseVisualStyleBackColor = true;
            this.loadGameButton.Click += new System.EventHandler(this.loadGameButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(542, 535);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(193, 93);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // StartScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 760);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loadGameButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "StartScreenForm";
            this.Text = "StartScreenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button loadGameButton;
        private System.Windows.Forms.Button exitButton;
    }
}