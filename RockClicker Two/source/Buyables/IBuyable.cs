using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockClicker_Two
{
    internal interface IBuyable
    {
        string Name { get; }
        long Cost { get; }

        long _calculateCost(long currentlyOpened);


    }
}
