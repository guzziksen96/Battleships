using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Domain.Entities;
using Battleships.Domain.Enums;

namespace Battleships.Application.Game.Models
{
    public class GameStateDto
    {
        public Board PlayerBoard { get; set; }
        public ComputerBoardDto ComputerBoard { get; set; }
        public GameResultEnum Result { get; set; }
    }
}
