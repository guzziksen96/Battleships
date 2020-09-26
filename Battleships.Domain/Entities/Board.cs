using System.Collections.Generic;
using System.Linq;
using Battleships.Domain.Enums;

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
        public List<Coordinate> MissShots { get; set; } = new List<Coordinate>();
        public List<Coordinate> HitShots { get; set; } = new List<Coordinate>();

        public FireResult ShootAt(Coordinate coordinate)
        {
            foreach (var ship in Ships)
            {
                if (ship.ShipPositions.Contains(coordinate))
                {
                    HitShots.Add(coordinate);
                    return FireResult.Hit;
                }
            }

            MissShots.Add(coordinate);
            return FireResult.Miss;
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
