using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Battleships.Domain.Entities
{
    public class Ship
    {
        public Ship(string name, List<Coordinate> occupiedCoordinates)
        {
            Name = name;
            OccupiedCoordinates = occupiedCoordinates;
        }
        public string Name { get; set; }
        public List<Coordinate> OccupiedCoordinates { get; set; }
        public bool IsSunk(List<Coordinate> shotsAt) => OccupiedCoordinates.All(shotsAt.Contains);
        public bool IsCollidingWith(Ship ship) => OccupiedCoordinates.Any(s => ship.OccupiedCoordinates.Contains(s));
    }
}
