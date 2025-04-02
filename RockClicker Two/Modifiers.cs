using RockClicker_Two;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockClicker
{
    internal class Modifiers : IBuyable
    {
        public string Name { get; set; }
        public float Multiplier { get; set; }
        public string ImagePath { get; set; }
        public Image Image { get; set; }
        public Modifiers(string name, float multipler, string imagePath) { 
            this.Name = name;
            this.Multiplier = multipler;
            this.ImagePath = imagePath;

        }

        private long _cost = 0;
        public long Cost { get { return _cost; } set { _cost = value; } }

        public long _calculateCost(long discount)
        {
            float percent = discount / 100;
            return (long)(Cost * percent);
        }
    }

    internal class FistsUpgrade1 : Modifiers
    {
        public FistsUpgrade1() : base("FistsUpgrade1", 2.0f, @"\Properties\images\fistUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.fistUpgrade1;
            this.Cost = 1000;
        }
    }

    internal class FistsUpgrade2 : Modifiers
    {
        public FistsUpgrade2() : base("FistsUpgrade2", 3.0f, @"\Properties\images\fistUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.fistUpgrade2;
            this.Cost = 5000;
        }
    }

    internal class  FistUpgrade3 : Modifiers
    {
        public FistUpgrade3() : base("FistsUpgrade3", 4.0f, @"\Properties\images\fistUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.fistUpgrade3;
            this.Cost = 25000;
        }
    }


    internal class PickaxeUpgrade1 : Modifiers
    {
        public PickaxeUpgrade1() : base("PickaxeUpgrade1", 10f, @"\Properties\images\pickaxeUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.pickaxeUpgrade1;
            this.Cost = 5000;
        }
    }

    internal class PickaxeUpgrade2 : Modifiers
    {
        public PickaxeUpgrade2() : base("PickaxeUpgrade2", 15f, @"\Properties\images\pickaxeUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.pickaxeUpgrade2;
            this.Cost = 25000;
        }
    }

    internal class PickaxeUpgrade3 : Modifiers
    {
        public PickaxeUpgrade3() : base("PickaxeUpgrade3", 20f, @"\Properties\images\pickaxeUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.pickaxeUpgrade3;
            this.Cost = 125000;
        }
    }

    internal class JackhammerUpgrade1 : Modifiers
    {
        public JackhammerUpgrade1() : base("JackhammerUpgrade1", 200f, @"\Properties\images\jackhammerUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.jackhammerUpgrade1;
            this.Cost = 10000;
        }
    }


    internal class JackhammerUpgrade2 : Modifiers
    {
        public JackhammerUpgrade2() : base("JackhammerUpgrade2", 300f, @"\Properties\images\jackhammerUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.jackhammerUpgrade2;
            this.Cost = 50000;
        }
    }

    internal class JackhammerUpgrade3 : Modifiers
    {
        public JackhammerUpgrade3() : base("JackhammerUpgrade3", 400f, @"\Properties\images\jackhammerUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.jackhammerUpgrade3;
            this.Cost = 250000;
        }
    }

    internal class DynamiteUpgrade1 : Modifiers
    {
        public DynamiteUpgrade1() : base("DynamiteUpgrade1", 600f, @"\Properties\images\dynamiteUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.dynamiteUpgrade1;
            this.Cost = 50000;
        }
    }

    internal class DynamiteUpgrade2 : Modifiers
    {
        public DynamiteUpgrade2() : base("DynamiteUpgrade2", 800f, @"\Properties\images\dynamiteUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.dynamiteUpgrade2;
            this.Cost = 250000;
        }
    }

    internal class DynamiteUpgrade3 : Modifiers
    {
        public DynamiteUpgrade3() : base("DynamiteUpgrade3", 1000f, @"\Properties\images\dynamiteUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.dynamiteUpgrade3;
            this.Cost = 1250000;
        }
    }
}
