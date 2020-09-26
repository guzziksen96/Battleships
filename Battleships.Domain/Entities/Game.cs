using System.Linq;
using Battleships.Domain.Enums;

namespace Battleships.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public Game(Board playerBoard, Board computerBoard)
        {
            PlayerBoard = playerBoard;
            ComputerBoard = computerBoard;
        }
        public Board PlayerBoard { get; set; }
        public Board ComputerBoard { get; set; }
        public FireResult PlayerShootAt(Coordinate coordinate) => ComputerBoard.ShootAt(coordinate);
        public FireResult ComputerShootAt(Coordinate coordinate) => PlayerBoard.ShootAt(coordinate);
        public GameResultEnum GetResult()
        {
            if (PlayerBoard.Ships.All(s => s.IsSunk(PlayerBoard.HitShots)))
            {
                return GameResultEnum.PlayerLost;
            }

            if (ComputerBoard.Ships.All(s => s.IsSunk(ComputerBoard.HitShots)))
            {
                return GameResultEnum.PlayerWon;
            }

            return GameResultEnum.Pending;
        }
    }
}
