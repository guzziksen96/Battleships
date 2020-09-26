using System.Collections.Generic;

namespace Battleships.Domain.Rules
{
    public class ShipWidths
    {
        public static Dictionary<string, int> Values = new Dictionary<string, int>()
        {
            { ShipNames.Carrier, 5},
            { ShipNames.Battleship, 4},
            { ShipNames.Cruiser, 3},
            { ShipNames.Submarine, 3},
            { ShipNames.Destroyer, 2 }
        };
        
    }
}
