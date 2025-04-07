using RockClicker_Two.source.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two.source.scratch
{
    public partial class DataBindingTest : Form
    {
        private List<Modifiers> upgrades = new List<Modifiers>
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
        private List<Modifiers> upgrades2 = new List<Modifiers>
        { new FistsUpgrade1(),
            new PickaxeUpgrade3(),
            new JackhammerUpgrade1(),
            new PickaxeUpgrade1(),
            new PickaxeUpgrade2(),

            new DynamiteUpgrade1(),
            new DynamiteUpgrade2(),
            
            new JackhammerUpgrade2(),
            new JackhammerUpgrade3(),

            new FistsUpgrade2(),
            new FistsUpgrade3(),
            new DynamiteUpgrade3()
        };
        private List<Modifiers> upgrades3 = new List<Modifiers>
        {

            new DynamiteUpgrade1(),
            new DynamiteUpgrade2(),
            new FistsUpgrade3(),
            new DynamiteUpgrade3(),
            new JackhammerUpgrade2(),
            new JackhammerUpgrade3(),
             new FistsUpgrade1(),
            new PickaxeUpgrade3(),
            new JackhammerUpgrade1(),
            new PickaxeUpgrade1(),
            new PickaxeUpgrade2(),
            new FistsUpgrade2()
            
        };


        internal List<Modifiers> Upgrades { get => upgrades; set => upgrades = value; }
        BindingSource modifiersBindingSource = new BindingSource();
        
        internal DataSourceManager dataSourceManager = new DataSourceManager();

        public DataBindingTest()
        {
            InitializeComponent();
            Console.WriteLine($"type of upgrades {upgrades.GetType()}");
            dataSourceManager.BindControl(upgrades, listBox1);
            dataSourceManager.BindControl(upgrades2, listBox2);
            dataSourceManager.BindControl(upgrades3, listBox3);
            //listBox1.DataSource = modifiersBindingSource;
            //listBox1.DisplayMember = "Name";
        }





    }
}
