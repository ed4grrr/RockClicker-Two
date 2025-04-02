using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two
{
    internal class RockCalculator
    {
        private Form1 form;
        internal RockCalculator(Form1 form) 
        {
            this.form = form;
        }

        internal long calculateCookiesPerSecond(long rocksToAdd)
        {
            foreach (var helper in form.ownedHelpers)
            {
                if (helper.Value == 0) continue;
                rocksToAdd = _calculateRocksPerSecondPerAddOn(rocksToAdd, helper);

            }

            return rocksToAdd;
        }

        private long _calculateRocksPerSecondPerAddOn(long rocksToAdd, KeyValuePair<Label, int> helper)
        {
            foreach (var addOn in this.form.addOns)
            {

                if (helper.Key.Name.Contains(addOn.Name.ToLower()))
                {

                    rocksToAdd += (long)(addOn.FlatRate * addOn.Multiplier * helper.Value);
                }


            }

            return rocksToAdd;
        }
    }
}
