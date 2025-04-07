
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockClicker_Two
{
    [Serializable]
    internal abstract class Modifiers : IBuyable
    {

        public string Name { get; set; }
        public float Multiplier { get; set; }
        public string ImagePath { get; set; }
        public Image Image { get; set; }
        public Type affectedAddOnType { get; set; }

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
    [Serializable]
    internal abstract class FistsUpgrade : Modifiers
    {
        public FistsUpgrade(string name, float multipler, string imagePath) : base(name, multipler, imagePath)
        {
            this.Image = RockClicker_Two.Properties.Resources.fist;
            this.Cost = 1000;
            this.affectedAddOnType = typeof(Fists);
        }
    }
    [Serializable]
    internal class FistsUpgrade1 : FistsUpgrade
    {
        public FistsUpgrade1() : base("FistsUpgrade1", 2.0f, @"\Properties\images\fistUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.fistUpgrade1;
            this.Cost = 1000;

        }
    }
    [Serializable]
    internal class FistsUpgrade2 : FistsUpgrade
    {
        public FistsUpgrade2() : base("FistsUpgrade2", 2.0f, @"\Properties\images\fistUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.fistUpgrade2;
            this.Cost = 5000;
        }
    }
    [Serializable]
    internal class  FistsUpgrade3  : FistsUpgrade
    {
        public FistsUpgrade3() : base("FistsUpgrade3", 2.0f, @"\Properties\images\fistUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.fistUpgrade3;
            this.Cost = 25000;
        }
    }
    [Serializable]
    internal abstract class PickaxeUpgrade : Modifiers
    {
        public PickaxeUpgrade(string name, float multipler, string imagePath) : base(name, multipler, imagePath)
        {
            this.Image = RockClicker_Two.Properties.Resources.pickaxe;
            this.Cost = 5000;
            this.affectedAddOnType = typeof(Pickaxe);
        }
    }

    [Serializable]
    internal class PickaxeUpgrade1 : PickaxeUpgrade
    {
        public PickaxeUpgrade1() : base("PickaxeUpgrade1", 2f, @"\Properties\images\pickaxeUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.pickaxeUpgrade1;
            this.Cost = 5000;
        }
    }
    [Serializable]
    internal class PickaxeUpgrade2 : PickaxeUpgrade
    {
        public PickaxeUpgrade2() : base("PickaxeUpgrade2", 2f, @"\Properties\images\pickaxeUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.pickaxeUpgrade2;
            this.Cost = 25000;
        }
    }
    [Serializable]
    internal class PickaxeUpgrade3 : PickaxeUpgrade
    {
        public PickaxeUpgrade3() : base("PickaxeUpgrade3", 2f, @"\Properties\images\pickaxeUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.pickaxeUpgrade3;
            this.Cost = 125000;
        }
    }
    [Serializable]
    internal abstract class JackhammerUpgrade : Modifiers
    {
        public JackhammerUpgrade(string name, float multipler, string imagePath) : base(name, multipler, imagePath)
        {
            this.Image = RockClicker_Two.Properties.Resources.jackhammer;
            this.Cost = 10000;
            this.affectedAddOnType = typeof(Jackhammer);
        }
    }
    [Serializable]
    internal class JackhammerUpgrade1 : JackhammerUpgrade
    {
        public JackhammerUpgrade1() : base("JackhammerUpgrade1", 2f, @"\Properties\images\jackhammerUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.jackhammerUpgrade1;
            this.Cost = 10000;
        }
    }

    [Serializable]
    internal class JackhammerUpgrade2 : JackhammerUpgrade
    {
        public JackhammerUpgrade2() : base("JackhammerUpgrade2", 2f, @"\Properties\images\jackhammerUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.jackhammerUpgrade2;
            this.Cost = 50000;
        }
    }
    [Serializable]
    internal class JackhammerUpgrade3 : JackhammerUpgrade
    {
        public JackhammerUpgrade3() : base("JackhammerUpgrade3", 2f, @"\Properties\images\jackhammerUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.jackhammerUpgrade3;
            this.Cost = 250000;
        }
    }
    [Serializable]
    internal abstract class DynamiteUpgrade : Modifiers
    {
        public DynamiteUpgrade(string name, float multipler, string imagePath) : base(name, multipler, imagePath)
        {
            this.Image = RockClicker_Two.Properties.Resources.dynamite;
            this.Cost = 25000;
            this.affectedAddOnType = typeof(Dynamite);
        }
    }
    [Serializable]
    internal class DynamiteUpgrade1 : DynamiteUpgrade
    {
        public DynamiteUpgrade1() : base("DynamiteUpgrade1", 2f, @"\Properties\images\dynamiteUpgrade1.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.dynamiteUpgrade1;
            this.Cost = 50000;
        }
    }

    [Serializable]
    internal class DynamiteUpgrade2 : DynamiteUpgrade
    {
        public DynamiteUpgrade2() : base("DynamiteUpgrade2", 2f, @"\Properties\images\dynamiteUpgrade2.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.dynamiteUpgrade2;
            this.Cost = 250000;
        }
    }
    [Serializable]
    internal class DynamiteUpgrade3 : DynamiteUpgrade
    {
        public DynamiteUpgrade3() : base("DynamiteUpgrade3", 2f, @"\Properties\images\dynamiteUpgrade3.png")
        {
            this.Image = RockClicker_Two.Properties.Resources.dynamiteUpgrade3;
            this.Cost = 1250000;
        }
    }
}
