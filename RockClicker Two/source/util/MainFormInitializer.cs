using RockClicker_Two.source.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two
{
    internal class MainFormInitializer
    {
        internal DataSourceManager dataSourceManager = new DataSourceManager();
        public MainFormInitializer(Form1 form)
        {
            _initializeOwnedAddons(form);
            _initializedAddons(form);
            _initializeListboxes(form);
        }

        private void _initializeOwnedAddons(Form1 form)
        {
            // initialize the owned helpers
            form.ownedHelpers = new Dictionary<Label, int>
            {
                {form.fistsCountLabel, 0},
                {form.pickaxesCountLabel, 0},
                {form.jackhammersCountLabel, 0},
                {form.dynamiteCountLabel, 0}
            };
        }

        private void _initializedAddons(Form1 form)
        {
            //used to store attached data values
            form._gameState.addOns.Add(form._gameState.tempFists);
            form._gameState.addOns.Add(form._gameState.tempPickaxe);
            form._gameState.addOns.Add(form._gameState.tempJackhammer);
            form._gameState.addOns.Add(form._gameState.tempDynamite);


            //used to link the data values to the labels for appropriate Rock per second calculations
            form._gameState.addOnLabelPairs[form._gameState.tempFists] = form.fistsCountLabel;
            form._gameState.addOnLabelPairs[form._gameState.tempPickaxe] = form.pickaxesCountLabel;
            form._gameState.addOnLabelPairs[form._gameState.tempJackhammer] = form.jackhammersCountLabel;
            form._gameState.addOnLabelPairs[form._gameState.tempDynamite] = form.dynamiteCountLabel;
        }

        private void _initializeListboxes(Form1 form)
        {
            this.dataSourceManager.BindControls(form.owned, form._gameState);

            foreach (var upgrade in form._gameState.upgrades)
            {
                form.upgradeListbox.Items.Add(upgrade.Name);
            }




            foreach (var rockType in form._gameState.rockTypes)
            {
                form.rockTypeListbox.Items.Add(rockType.Name);
            }
        }
    }
}
