

using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms.PropertyGridInternal;

namespace RockClicker_Two{

    [Serializable]
    public class AddOn : IBuyable
{
    public AddOn(string name, float flatRate, string imagePath)
    {
        Name = name;
        FlatRate = flatRate;
        ImagePath = imagePath;
    }

    public string Name { get; set; }
    public float FlatRate { get; set; }
    public string ImagePath { get; set; }
    public Image image { get; set; }

    private long _cost = 0;

    private float _costModifier = 0.10f;

    internal long _amountOwned = 0;




        private float multiplier = 1.0f;

        public float Multiplier
    {
        get { return multiplier; }
        set { multiplier = value; }
    }

    public float CostModifier
    {
        get { return _costModifier; }
        set { _costModifier = value; }
    }
    public long Cost
    {
        get { return _cost; }
        set { _cost = value; }

    }

    public long _calculateCost(long currentlyOpened)
    {
        if (currentlyOpened < 1)
        {
            return Cost;
        }
        return (long)(Cost * (1 +(currentlyOpened * CostModifier)));
    }
}

    [Serializable]
    public class Fists : AddOn
{
        internal static int amountOwned = 0;

        public Fists() : base("Fists", 1.0f, @"\Properties\images\fist.png")
    {
        this.image = RockClicker_Two.Properties.Resources.fist;
        this.Cost = 100;
        
    }
}
    [Serializable]
    public class Pickaxe : AddOn
{
        internal static int amountOwned = 0;

        public Pickaxe() : base("Pickaxe", 50f, @"\Properties\images\pickaxe.png")
    {
        this.image = RockClicker_Two.Properties.Resources.pickaxe;
        this.Cost = 1000;
    }
}
    [Serializable]
    public class Jackhammer : AddOn
{
        internal static int amountOwned = 0;

        public Jackhammer() : base("Jackhammer", 500f, @"\Properties\images\jackhammer.png")
    {
        this.image = RockClicker_Two.Properties.Resources.jackhammer;
        this.Cost = 10000;
    }
}

    [Serializable]
    public class Dynamite : AddOn
{
        internal static int amountOwned = 0;

        public Dynamite() : base("Dynamite", 5000f, @"\Properties\images\dynamite.png")
    {
        this.image = RockClicker_Two.Properties.Resources.dynamite;
        this.Cost = 100000;
    }
}}
