
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

        internal List<Modifiers> getModifiers(Type type)
        {
            List<Modifiers> modifiers = new List<Modifiers>();
            foreach (Modifiers modifier in form._gameState.ownedModifiers)
            {
                if (modifier.affectedAddOnType == type)
                {
                    modifiers.Add(modifier);
                }
            }

            return modifiers;
        }

        internal long calculateRocksPerSecond(long rocksToAdd)
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
            foreach (var addOn in this.form._gameState.addOns)
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
