using RockClicker_Two.source.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two
{
    [Serializable]
    internal class GameState
    {
        private long _rockCount = 0;
        private long _rockCountAllTime = 0;
        internal string _originalName = "";
        internal string displayName = "";

        internal List<Modifiers> upgrades = new List<Modifiers>
        { new FistsUpgrade1(),
            new FistsUpgrade2(),
            new FistsUpgrade3(),
            new PickaxeUpgrade1(),
            new PickaxeUpgrade2(),
            new PickaxeUpgrade3(),
            new JackhammerUpgrade1(),
            new JackhammerUpgrade2(),
            new JackhammerUpgrade3(),
            new DynamiteUpgrade1(),
            new DynamiteUpgrade2(),
            new DynamiteUpgrade3()
        };
        internal Fists tempFists = new Fists();
        internal Pickaxe tempPickaxe = new Pickaxe();
        internal Jackhammer tempJackhammer = new Jackhammer();
        internal Dynamite tempDynamite = new Dynamite();
        internal List<AddOn> addOns = new List<AddOn>();
        internal List<RockType> rockTypes = new List<RockType>
        { new SedimentaryRock(),
          new IgneousRock(),
          new MetamorphicRock()
        };
        
        internal Dictionary<AddOn, Label> addOnLabelPairs = new Dictionary<AddOn, Label>(); //work on removing this and all label references
        internal List<Modifiers> ownedModifiers = new List<Modifiers>();
        internal List<RockType> ownedRockTypesList = new List<RockType>();
        
        
        
        internal Dictionary<Label, int> ownedHelpers; //change key to be of type AddOn
        internal Dictionary<AddOn, int> ownedAddOns = new Dictionary<AddOn, int>();


        internal DataSourceManager dataSourceManager = new DataSourceManager();

        public long RockCount
        {
            get { return _rockCount; }
            set
            {
                _rockCount = value;

                if (_rockCountAllTime <= _rockCount) _rockCountAllTime = value;
                if (rockCounter.InvokeRequired)
                {
                    rockCounter.Invoke(new Action(() => rockCounter.Text = _rockCount.ToString()));
                }
                else
                {
                    rockCounter.Text = _rockCount.ToString();

                }
            }
        }

        public long RockCountAllTime
        {
            get { return _rockCountAllTime; }
            set
            {
                _rockCountAllTime = value;

                // if statment to check if the control is on the same thread or not
                if (rocksMinedAllTimeCounterLabel.InvokeRequired)
                {
                    // if not on the same thread then invoke the action
                    // we do this because we can't update the UI from a different thread
                    rocksMinedAllTimeCounterLabel.Invoke(new Action(() => rocksMinedAllTimeCounterLabel.Text = _rockCountAllTime.ToString()));
                }
                else
                {   // if on the same thread then just update the text
                    rocksMinedAllTimeCounterLabel.Text = _rockCountAllTime.ToString();
                }

            }
        }

        public Label rockCounter;
        public Label rocksMinedAllTimeCounterLabel;
        internal GameState(Form1 form, string companyName)
        {
            this.rockCounter = form.rockCounter;
            this.rocksMinedAllTimeCounterLabel = form.rocksMinedAllTimeCounterLabel;
            this.ownedHelpers = form.ownedHelpers;
            this._originalName = companyName;
            this.displayName = companyName;
        }
    }
}
