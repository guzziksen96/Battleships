using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Domain.Entities;

namespace Battleships.Application.Game.Models
{
    public class ComputerBoardDto
    {
        public List<Coordinate> MissShots { get; set; }
        public List<Coordinate> HitShots { get; set; }
        public List<string> SunkShips { get; set; }
    }
}
