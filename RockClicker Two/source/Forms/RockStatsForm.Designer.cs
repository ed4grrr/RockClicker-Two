namespace RockClicker_Two
{
    partial class RockStatsForm
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
            this.AddOnsStatsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AddOnsStatsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AddOnsStatsGrid
            // 
            this.AddOnsStatsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddOnsStatsGrid.Location = new System.Drawing.Point(12, 12);
            this.AddOnsStatsGrid.Name = "AddOnsStatsGrid";
            this.AddOnsStatsGrid.RowHeadersWidth = 102;
            this.AddOnsStatsGrid.RowTemplate.Height = 40;
            this.AddOnsStatsGrid.Size = new System.Drawing.Size(1886, 1076);
            this.AddOnsStatsGrid.TabIndex = 0;
            // 
            // RockStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 1100);
            this.Controls.Add(this.AddOnsStatsGrid);
            this.Name = "RockStatsForm";
            this.Text = "RockStatsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RockStatsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.AddOnsStatsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AddOnsStatsGrid;
    }
}