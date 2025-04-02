using RockClicker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two
{
    public partial class Form1 : Form
    {
        private RockCalculator _rockCalculator;
        public Form1(GameCycle cycle)
        {
            InitializeComponent();
            _gameCycle = cycle;
            _gameCycle.CyclePassed += OnCyclePassed;
            _rockCalculator = new RockCalculator(this);
        }

        
        private GameCycle _gameCycle;
        private long _rockCount = 1000000;
        private long _rockCountAllTime = 1000;

        private float _multiplier = 1.0f;
        private float _clickMultiplier = 1.0f;

        internal List<Modifiers> upgrades = new List<Modifiers>
        { new FistsUpgrade1(),
            new FistsUpgrade2(),
            new FistUpgrade3(),
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


        internal List<Modifiers> ownedModifiers = new List<Modifiers>();
        internal Dictionary<AddOn,Label> addOnLabelPairs = new Dictionary<AddOn, Label>();




        internal List<RockType> ownedRockTypesList = new List<RockType>();
        internal Dictionary<Label, int> ownedHelpers;



        


        public long RockCount
        {
            get { return _rockCount; }
            set
            {
                _rockCount = value;
                    
                if(_rockCountAllTime<=_rockCount) _rockCountAllTime = value;
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
                if(rocksMinedAllTimeCounterLabel.InvokeRequired)
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


        private bool _isAffordable(long cost)
        {
            return RockCount >= cost;
        }

        private void _buyItem(IBuyable item, Label sender)
        {
            if (item == null) return;
           
            if (_isAffordable(item.Cost))
            {
                
                
                    this._buyAddOn(item, sender);

                
            }
        }

        private void _buyItem(IBuyable item)
        {
            if (item == null) return;

            if (_isAffordable(item.Cost))
            {
                
                    
                    if (item is Modifiers)
                    {
                        this._buyModifiers(item);
                    }
                    else if (item is RockType)
                    {
                        this._buyRockType(item);
                    }
                
            }
        }

        private void _buyRockType(IBuyable item)
        {
            RockCount -= item._calculateCost(100);
            ownedRockTypesList.Add((RockType)item);
            this.rockTypeListbox.Items.Remove(rockTypeListbox.SelectedItem);
            this.ownedRockTypes.Items.Add(item.Name);
        }

        private void _buyModifiers(IBuyable item)
        {
            RockCount -= item._calculateCost(100);
            ownedModifiers.Add((Modifiers)item);
            this.upgradeListbox.Items.Remove(upgradeListbox.SelectedItem);
            this.upgrades.Remove((Modifiers)item);
            this.ownedUpgradesListbox.Items.Add(item.Name);
        }

        private void _buyAddOn(IBuyable item, Label sender)
        {
            long currentNumberOfAddOns = ownedHelpers[sender];

            RockCount -= item._calculateCost(currentNumberOfAddOns);
            this.ownedHelpers[sender]++;
            this._updateAddOnsCounts();
            this._updateAddonCostLabel();
        }

        private void _updateAddonCostLabel()
        {
            Label labelToUpdate = this.addOnLabelPairs[addOns[addOnsListbox.SelectedIndex]];
            long count = ownedHelpers[labelToUpdate];
            addOnCostLabel.Text = addOns[addOnsListbox.SelectedIndex]._calculateCost(count).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new MainFormInitializer(this);

        }

        private void OnCyclePassed(object sender, EventArgs e)
        {
            long rocksToAdd = 0;
            rocksToAdd = this._rockCalculator.calculateCookiesPerSecond(rocksToAdd);
            RockCount += rocksToAdd;
            RockCountAllTime += rocksToAdd;

        }

        private void  _updateAddOnsCounts()
        {
            foreach (var helper in ownedHelpers)
            {
                helper.Key.Text = helper.Value.ToString();
            }
        }


        

        private void clickRockPicture_Click(object sender, EventArgs e)
        {
            RockCount += (long)(_clickMultiplier * 1);
        }




        private void addOnsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addOnsPictureLabel.Text = addOns[addOnsListbox.SelectedIndex].Name;
            this._updateAddonCostLabel();
            addOnsPictureBox.Image = addOns[addOnsListbox.SelectedIndex].image;
        }

        private void upgradeListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (upgradeListbox.SelectedIndex == -1) return;
            upgradePictureLabel.Text = upgrades[upgradeListbox.SelectedIndex].Name;
            upgradeCost.Text = upgrades[upgradeListbox.SelectedIndex].Cost.ToString();
            upgradePictureBox.Image = upgrades[upgradeListbox.SelectedIndex].Image;
        }

        private void rockTypeListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rockTypeListbox.SelectedIndex == -1) return;
            rockTypePictureLabel.Text = rockTypes[rockTypeListbox.SelectedIndex].Name;
            rockTypeCosts.Text = rockTypes[rockTypeListbox.SelectedIndex].Cost.ToString();
            rockTypePicture.Image = rockTypes[rockTypeListbox.SelectedIndex].Image;
        }

        private void ownedUpgradesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            upgradeLabel.Text = upgrades[ownedUpgradesListbox.SelectedIndex].Name;
            upgradeCost.Text = "";
            upgradePictureBox.Image = upgrades[ownedUpgradesListbox.SelectedIndex].Image;
        }

        private void upgradeLabel_Click(object sender, EventArgs e)
        {
            ownedUpgradesListbox.Visible = !ownedUpgradesListbox.Visible;
            
        }

        private void rockTypeLabel_Click(object sender, EventArgs e)
        {
            ownedRockTypes.Visible = !ownedRockTypes.Visible;
        }

        private void buyHelpersButton_Click(object sender, EventArgs e)
        {
            var temp =this.addOnsListbox.SelectedItem;
            if (temp != null)
            {
                Label labelToSend = null;
                if (temp.ToString() == "Fists")
                {
                    labelToSend = fistsCountLabel;
                }
                else if (temp.ToString() == "Pickaxe")
                {
                    labelToSend = pickaxesCountLabel;
                }
                else if (temp.ToString() == "Jackhammer")
                {
                    labelToSend = jackhammersCountLabel;
                }
                else if (temp.ToString() == "Dynamite")
                {
                    labelToSend = dynamiteCountLabel;
                }





                _buyItem(addOns[addOnsListbox.SelectedIndex], labelToSend );
            }
        }

        private void buyUpgradesButton_Click(object sender, EventArgs e)
        {
            if (upgradeListbox.SelectedIndex == -1) return;
            this._buyItem(upgrades[upgradeListbox.SelectedIndex]);
        }

        private void buyRockTypesButton_Click(object sender, EventArgs e)
        {
            if (rockTypeListbox.SelectedIndex == -1) return;
            this._buyItem(rockTypes[rockTypeListbox.SelectedIndex]);
        }
    }
}
