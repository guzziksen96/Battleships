using Battleships.Domain.Entities;

namespace Battleships.Application.Game.Models
{
    public class GameStateDto
    {
        public Board PlayerBoard { get; set; }
        public ComputerBoardDto ComputerBoard { get; set; }
        public string Result { get; set; }
    }
}
