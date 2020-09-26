namespace Battleships.Domain.Rules
{
    public static class ShipNames
    {
        public const string Carrier = "Carrier";
        public const string Battleship = "Battleship";
        public const string Cruiser = "Cruiser";
        public const string Submarine = "Submarine";
        public const string Destroyer = "Destroyer";

        public static string[] All =
        {
            Carrier,
            Battleship,
            Cruiser,
            Submarine,
            Destroyer
        };
    }
}
