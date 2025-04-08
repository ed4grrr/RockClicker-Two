
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockClicker_Two.source.Forms;

namespace RockClicker_Two
{
    public partial class Form1 : Form
    {
        private RockCalculator _rockCalculator;

        internal GameState _gameState;


        internal GameCycle _gameCycle;


        private float _multiplier = 1.0f;
        private float _clickMultiplier = 1.0f;



        internal Dictionary<Label, int> ownedHelpers = new Dictionary<Label, int>();
        


        public Form1(GameCycle cycle, string companyName)
        {
            InitializeComponent();

            _gameCycle = cycle;
            _gameCycle.CyclePassed += OnCyclePassed;
            _rockCalculator = new RockCalculator(this);
            this.Text = "Rock Clicker - " + companyName;
            _gameState = new GameState(this, companyName);
        }


       



        private bool _isAffordable(long cost)
        {
            return _gameState.RockCount >= cost;
        }

        private void _buyItem(IBuyable item, Label sender)
        {
            if (item == null) return;

            if (_isAffordable(item.Cost))
            {


                this._buyAddOn((AddOn)item, sender);


            }
        }

        private void _buyItem(IBuyable item)
        {
            if (item == null) return;

            if (_isAffordable(item.Cost))
            {


                if (item is Modifiers)
                {
                    this._buyModifiers((Modifiers)item);
                }
                else if (item is RockType)
                {
                    this._buyRockType(item);
                }

            }
        }

        private void _buyRockType(IBuyable item)
        {
            _gameState.RockCount -= item._calculateCost(100);
            _gameState.ownedRockTypesList.Add((RockType)item);
            this.rockTypeListbox.Items.Remove(rockTypeListbox.SelectedItem);
            this.ownedRockTypes.Items.Add(item.Name);
            this.rockTypePicture.Image = null;
            this.rockTypePictureLabel.Text = "";
            this.rockTypeCosts.Text = "";
        }

        private void _buyModifiers(Modifiers item)
        {
            _gameState.RockCount -= item._calculateCost(100);
            _gameState.ownedModifiers.Add(item);
            this.upgradeListbox.Items.Remove(upgradeListbox.SelectedItem);
            _gameState.upgrades.Remove(item);
            this.updateAddonMultiplier(item);
            this.ownedUpgradesListbox.Items.Add(item.Name);
            this.upgradePictureBox.Image = null;
            this.upgradePictureLabel.Text = "";
            this.upgradeCost.Text = "";

        }

        private void updateAddonMultiplier(Modifiers item)
        {
            foreach (var addOn in _gameState.addOns)
            {
                if (addOn.GetType() == item.affectedAddOnType)
                {
                    addOn.Multiplier *= item.Multiplier;
                }

            }
        }


        private int returnAddOnCount(AddOn item)
        {
            if (item.GetType() == typeof(Fists))
            {
                return this.ownedHelpers[fistsCountLabel];
            }
            else if (item.GetType() == typeof(Pickaxe))
            {
                return this.ownedHelpers[pickaxesCountLabel];
            }
            else if (item.GetType() == typeof(Jackhammer))
            {
                return this.ownedHelpers[jackhammersCountLabel];
            }
            else if (item.GetType() == typeof(Dynamite))
            {
                return this.ownedHelpers[dynamiteCountLabel];
            }
            return 0;
        }


        private void _buyAddOn(AddOn item, Label sender)
        {
            long currentNumberOfAddOns = (long)item.GetType().GetField("_amount_Owmed").GetValue(null);
            

            _gameState.RockCount -= item._calculateCost(currentNumberOfAddOns);

            //this.ownedHelpers[_gameState.addOnLabelPairs[item]]++;
            item.GetType().GetField("_amountOwned").SetValue(item, currentNumberOfAddOns + 1);
            this._updateAddOnsCounts();
            this._updateAddonCostLabel();
        }

        private void _updateAddonCostLabel()
        {
            Label labelToUpdate = _gameState.addOnLabelPairs[_gameState.addOns[addOnsListbox.SelectedIndex]];
            long count = ownedHelpers[labelToUpdate];
            addOnCostLabel.Text = _gameState.addOns[addOnsListbox.SelectedIndex]._calculateCost(count).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new MainFormInitializer(this);

        }

        private void OnCyclePassed(object sender, EventArgs e)
        {
            long rocksToAdd = 0;
            rocksToAdd = this._rockCalculator.calculateRocksPerSecond(rocksToAdd);
            _gameState.RockCount += rocksToAdd;
            _gameState.RockCountAllTime += rocksToAdd;

        }

        private void _updateAddOnsCounts()
        {
            foreach (var helper in ownedHelpers)
            {
                helper.Key.Text = helper.Value.ToString();
            }
        }




        private void clickRockPicture_Click(object sender, EventArgs e)
        {
            _gameState.RockCount += (long)(_clickMultiplier * 1);
        }




        private void addOnsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addOnsPictureLabel.Text = _gameState.addOns[addOnsListbox.SelectedIndex].Name;
            this._updateAddonCostLabel();
            addOnsPictureBox.Image = _gameState.addOns[addOnsListbox.SelectedIndex].image;
        }

        // ****GENERALIZE THIS FOR THE CLASS
        private void upgradeListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (upgradeListbox.SelectedIndex == -1) return;
            upgradePictureLabel.Text = _gameState.upgrades[upgradeListbox.SelectedIndex].Name;
            upgradeCost.Text = _gameState.upgrades[upgradeListbox.SelectedIndex].Cost.ToString();
            upgradePictureBox.Image = _gameState.upgrades[upgradeListbox.SelectedIndex].Image;
        }

        private void rockTypeListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rockTypeListbox.SelectedIndex == -1) return;
            rockTypePictureLabel.Text = _gameState.rockTypes[rockTypeListbox.SelectedIndex].Name;
            rockTypeCosts.Text = _gameState.rockTypes[rockTypeListbox.SelectedIndex].Cost.ToString();
            rockTypePicture.Image = _gameState.rockTypes[rockTypeListbox.SelectedIndex].Image;
        }

        private void ownedUpgradesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownedUpgradesListbox.SelectedIndex == -1) return;
            upgradePictureLabel.Text = _gameState.ownedModifiers[ownedUpgradesListbox.SelectedIndex].Name;
            upgradeCost.Text = "";
            upgradePictureBox.Image = _gameState.ownedModifiers[ownedUpgradesListbox.SelectedIndex].Image;
        }

        private void ownedRockTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownedRockTypes.SelectedIndex == -1) return;
            rockTypePictureLabel.Text = _gameState.ownedRockTypesList[ownedRockTypes.SelectedIndex].Name;
            rockTypeCosts.Text = "";
            rockTypePicture.Image = _gameState.ownedRockTypesList[ownedRockTypes.SelectedIndex].Image;
        }



        private void upgradeLabel_Click(object sender, EventArgs e)
        {
            ownedUpgradesListbox.Visible = !ownedUpgradesListbox.Visible;
            upgradeLabel.Text = ownedUpgradesListbox.Visible ? "Owned Upgrades" : "Upgrades";
            upgradePictureBox.Image = null;
            upgradePictureLabel.Text = "";
            upgradeCost.Text = "";


        }

        private void rockTypeLabel_Click(object sender, EventArgs e)
        {
            ownedRockTypes.Visible = !ownedRockTypes.Visible;
            rockTypeLabel.Text = ownedRockTypes.Visible ? "Owned Rock Types" : "Rock Types";
            rockTypePicture.Image = null;
            rockTypePictureLabel.Text = "";
            rockTypeCosts.Text = "";
        }

        private void buyHelpersButton_Click(object sender, EventArgs e)
        {
            var temp = this.addOnsListbox.SelectedItem;
            if (temp != null)
            {
                Label labelToSend = null;
                if (temp.ToString() == "FistsUpgrade")
                {
                    labelToSend = fistsCountLabel;
                }
                else if (temp.ToString() == "PickaxeUpgrade")
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





                _buyItem(_gameState.addOns[addOnsListbox.SelectedIndex], labelToSend);
            }
        }

        private void buyUpgradesButton_Click(object sender, EventArgs e)
        {
            if (upgradeListbox.SelectedIndex == -1) return;
            this._buyItem(_gameState.upgrades[upgradeListbox.SelectedIndex]);
        }

        private void buyRockTypesButton_Click(object sender, EventArgs e)
        {
            if (rockTypeListbox.SelectedIndex == -1) return;
            this._buyItem(_gameState.rockTypes[rockTypeListbox.SelectedIndex]);
        }

        private void rockCollectionStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RockStatsForm rockStatsForm = new RockStatsForm(this);
            rockStatsForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string saveFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFiles");
            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
            }

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Path.Combine(saveFolderPath, "MyFile.bin"), FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, _gameState);
            }
        }

        private void changeCompanyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RenameYourCompany(_gameState).ShowDialog();
            this.Text = "Rock Clicker - " + _gameState.displayName;

        }

        private void loadSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///<summary>
            /// allows the user to load a save file
            /// 
            /// </summary>


            //check if the user wants to lose any unsaved progress
            DialogResult result = MessageBox.Show("Are you sure you want to load a save file? " +
                "YOU WILL LOSE ANY UNSAVED PROGRESS", "Load Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // user gotta save their progress
            if (result == DialogResult.No) return;

            OpenFileDialog OpenFileDialog = new OpenFileDialog(); //create a new open file dialog

            // this if statement checks if the file exists, if not then return nothing.
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //get the file path
                string filePath = OpenFileDialog.FileName;
                //create a new binary formatter
                IFormatter formatter = new BinaryFormatter();
                //create a new stream
                using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    //deserialize the object
                    _gameState = (GameState)formatter.Deserialize(stream);
                    this.Text = "Rock Clicker - " + _gameState.displayName;
                }
            }
        }
    }
}