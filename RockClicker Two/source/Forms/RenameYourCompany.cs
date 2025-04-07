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
    public partial class RenameYourCompany : Form
    {
        private GameState gameState;
        internal RenameYourCompany(GameState gameState)
        {

            InitializeComponent();
            this.gameState = gameState;
        }

        private void enteredCompanyNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void renameCompanyButton_Click(object sender, EventArgs e)
        {
             if (!string.IsNullOrEmpty(enteredCompanyNameTextbox.Text)) gameState.displayName = enteredCompanyNameTextbox.Text;
            this.Close();
        }
    }
}
