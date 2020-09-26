using System.Collections.Generic;
using System.Linq;

namespace Battleships.Domain.Entities
{
    public class Ship
    {
        public Ship()
        {
            
        }
        public Ship(string name, List<Coordinate> shipPositions)
        {
            Name = name;
            ShipPositions = shipPositions;
        }
        public string Name { get; set; }
        public List<Coordinate> ShipPositions { get; set; }
        public bool IsSunk(List<Coordinate> shotsAt) => ShipPositions.All(shotsAt.Contains);
        public bool IsCollidingWith(Ship ship) => ShipPositions.Any(s => ship.ShipPositions.Contains(s));
    }
}
