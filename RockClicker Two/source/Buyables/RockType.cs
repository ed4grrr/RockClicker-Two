using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockClicker_Two
{
    [Serializable]
    internal class RockType : IBuyable
    {
        public string Name { get; set; }
        public float rockMultiplier { get; set; }
        public float clickMultiplier { get; set; }
        public string ImagePath { get; set; }

        public Image Image { get; set; }
        public RockType(string name,  string imagePath, float rockMultiplier=1, float clickMultiplier = 1)
        {
            this.Name = name;
            this.rockMultiplier = rockMultiplier;
            this.ImagePath = imagePath;

            this.clickMultiplier = clickMultiplier;
        }

        private long _cost = 0;

        public long Cost
        {
            get { return _cost; }
            set { _cost = value; }

        }

        public long _calculateCost(long discount = 100)
        {
            float percent = discount / 100;
            return (long)(Cost * percent);
        }
    }

    [Serializable]
    internal class SedimentaryRock : RockType
    {
        public SedimentaryRock() : base("Sedimentary Rock", @"\Properties\images\sedimentaryRock.png", 1.0f, 1.0f)
        {
            this.Image = RockClicker_Two.Properties.Resources.sedimentaryRock;
            this.Cost = 1000;
        }

    }
    [Serializable]
    internal class IgneousRock : RockType
    {
        public IgneousRock() : base("Igneous Rock", @"\Properties\images\igneousRock.png", 2f, 0.5f)
        {
            this.Image = RockClicker_Two.Properties.Resources.igeneousRock;
            this.Cost = 10000;
        }
    }
    [Serializable]
    internal class MetamorphicRock : RockType
    {
        public MetamorphicRock() : base("Metamorphic Rock", @"\Properties\images\metamorphicRock.png", 0.5f, 3.0f)
        {
            this.Image = RockClicker_Two.Properties.Resources.metamorphicRock;
            this.Cost = 100000;
        }
    }
}
