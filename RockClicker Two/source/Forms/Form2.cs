using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two.source.Forms
{
    public partial class Form2 : Form
    {
        public Form2(bool isNewCompany =true)
        {
            InitializeComponent();
            
            
            this.Text = "New Mining Company";
           
            
            
               
            
        }

        private void miningCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // List of invalid characters for Windows file names
            char[] invalidChars = { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

            // Check if the pressed key is an invalid character
            if (Array.IndexOf(invalidChars, e.KeyChar) != -1)
            {
                // If it is, cancel the key press event
                e.Handled = true;
            }
        }

        private void startJourneyButton_Click(object sender, EventArgs e)
        {
            string companyName = miningCompanyName.Text;
            //TODO make sure save files account for spaces in the name
            if (string.IsNullOrEmpty(companyName))
            {
                MessageBox.Show("Please enter a name for your mining company.");
            }
            else
            {
                GameCycle gameCycle = new GameCycle();
                
                Form1 form1 = new Form1(gameCycle, companyName);
                form1.Show();
                this.Hide();
            }
        }
    }
}
