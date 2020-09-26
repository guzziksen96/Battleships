using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships.Domain.Entities
{
    public class Board
    {
        public Board()
        {
            
        }
        public Board(List<Ship> ships)
        {
            Ships = ships;
        }

        public int Id { get; set; }
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public List<Coordinate> Misses { get; set; } = new List<Coordinate>();
        public List<Coordinate> Hits { get; set; } = new List<Coordinate>();

        public void Display()
        {
            Console.WriteLine("*****************");
            Console.WriteLine(" \tABCDEFGHIJ");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}\t");
                for (int j = 0; j <  10; j++)
                {
                    var coord = new Coordinate(i, (char)('a' + j));
                    var isShipPlaced = Ships.Any(s => s.OccupiedCoordinates.Contains(coord));
                    if(isShipPlaced)
                        Console.Write("X");
                    else
                    {
                        Console.Write("O");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("*****************");
        }
        public void ShootAt(Coordinate coordinate)
        {
            foreach (var ship in Ships)
            {
                if (ship.OccupiedCoordinates.Contains(coordinate))
                {
                    Hits.Add(coordinate);
                }
                else
                {
                    Misses.Add(coordinate);
                }
            }
        }
    }
}
