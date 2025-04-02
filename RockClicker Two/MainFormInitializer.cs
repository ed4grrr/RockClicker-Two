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
            form.addOns.Add(form.tempFists);
            form.addOns.Add(form.tempPickaxe);
            form.addOns.Add(form.tempJackhammer);
            form.addOns.Add(form.tempDynamite);


            //used to link the data values to the labels for appropriate Rock per second calculations
            form.addOnLabelPairs[form.tempFists] = form.fistsCountLabel;
            form.addOnLabelPairs[form.tempPickaxe] = form.pickaxesCountLabel;
            form.addOnLabelPairs[form.tempJackhammer] = form.jackhammersCountLabel;
            form.addOnLabelPairs[form.tempDynamite] = form.dynamiteCountLabel;
        }

        private void _initializeListboxes(Form1 form)
        {
            foreach (var addOn in form.addOns)
            {
                form.addOnsListbox.Items.Add(addOn.Name);
            }

            foreach (var upgrade in form.upgrades)
            {
                form.upgradeListbox.Items.Add(upgrade.Name);
            }




            foreach (var rockType in form.rockTypes)
            {
                form.rockTypeListbox.Items.Add(rockType.Name);
            }
        }
    }
}
