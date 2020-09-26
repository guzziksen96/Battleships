using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Domain.Entities;

namespace Battleships.Application.Game.Models
{
    public class PendingGameStateDto
    {
        public Board PlayerBoard { get; set; }
        public ComputerBoardDto ComputerBoard { get; set; }
    }
}
