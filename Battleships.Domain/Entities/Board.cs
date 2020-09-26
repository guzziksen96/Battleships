using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships.Domain.Entities
{
    public class Board
    {
        public const int BoardRange = 10;
        public Board()
        {
            
        }
        public Board(List<Ship> ships)
        {
            Ships = ships;
        }

        public List<Ship> Ships { get; set; } = new List<Ship>();
        public List<Coordinate> Misses { get; set; } = new List<Coordinate>();
        public List<Coordinate> Hits { get; set; } = new List<Coordinate>();

        public void ShootAt(Coordinate coordinate)
        {
            foreach (var ship in Ships)
            {
                if (ship.ShipPositions.Contains(coordinate))
                {
                    Hits.Add(coordinate);
                }
                else
                {
                    Misses.Add(coordinate);
                }
            }
        }
        public bool IsPositionOccupied(Coordinate coordinate)
            => Ships.Any(s => s.ShipPositions.Contains(coordinate));

        public static bool IsInBoundaries(Coordinate coordinate)
            => coordinate.Row >= 1 && coordinate.Row <= 10 && coordinate.Column >= 'a' &&
               coordinate.Column <= (char)('a' + 10);

        public static bool IsInBoundaries(Ship ship)
            => ship.ShipPositions.All(IsInBoundaries);
    }
}
