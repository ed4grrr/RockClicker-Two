using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two
{
    public partial class RockStatsForm : Form
    {
        private Form1 form1;
        public RockStatsForm(Form1 form1)
        {

            InitializeComponent();
            this.form1 = form1;
            AddOn item = form1._gameState.tempFists;
            InitializeGridColumns();
            addAllElements();
            this.form1._gameCycle.CyclePassed += updateGrid;


        }


        private void updateGrid(object sender, EventArgs args)
        {
            if (AddOnsStatsGrid.InvokeRequired)
            {
                AddOnsStatsGrid.Invoke(new Action(() => _updateGrid()));
            }
            else
            {
                _updateGrid();
            }
        }

        private void _updateGrid()
        {
            AddOnsStatsGrid.Rows.Clear();
            foreach (AddOn item in form1._gameState.addOns)
            {
                if (form1.ownedHelpers[form1._gameState.addOnLabelPairs[item]] > 0)
                {
                    addElement(item);
                }
            }
        }

        private void addAllElements()
        {
            foreach (AddOn item in form1._gameState.addOns)
            {
                if (form1.ownedHelpers[form1._gameState.addOnLabelPairs[item]] > 0)
                {
                    addElement(item);
                }
            }
        }

        private void addElement( AddOn item)
        {
            long RPS = (long)(item.FlatRate * item.Multiplier * form1.ownedHelpers[form1._gameState.addOnLabelPairs[item]]);
            AddOnsStatsGrid.Rows.Add(item.image, item.Name, item.FlatRate, item.Multiplier, form1.ownedHelpers[form1._gameState.addOnLabelPairs[item]], RPS);
        }

        private void InitializeGridColumns()
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Image";
            imageColumn.Name = "imageColumn";

            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            AddOnsStatsGrid.Columns.Add(imageColumn);

            AddOnsStatsGrid.Columns.Add("nameColumn", "Name");
            AddOnsStatsGrid.Columns.Add("flatRateColumn", "Flat Rate");
            AddOnsStatsGrid.Columns.Add("MultiplierColumn", "Multiplier");
            AddOnsStatsGrid.Columns.Add("NumberOwnedColumn", "Number Owned");
            AddOnsStatsGrid.Columns.Add("RocksPerSecondColumn", "RPS");
        }

        private void RockStatsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this is needed to remove the event handler when the form is closed
            // otherwise it will throw an error and the game will loop an error message
            this.form1._gameCycle.CyclePassed -= updateGrid;
        }
    }
}
