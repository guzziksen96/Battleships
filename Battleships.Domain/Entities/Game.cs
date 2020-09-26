using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void PlayerShootAt(Coordinate coordinate) => ComputerBoard.ShootAt(coordinate);
        public void ComputerShootAt(Coordinate coordinate) => PlayerBoard.ShootAt(coordinate);
        public GameResultEnum GetResult()
        {
            if (PlayerBoard.Ships.All(s => s.IsSunk(PlayerBoard.Hits)))
            {
                return GameResultEnum.PlayerLost;
            }

            if (ComputerBoard.Ships.All(s => s.IsSunk(ComputerBoard.Hits)))
            {
                return GameResultEnum.PlayerWon;
            }

            return GameResultEnum.Pending;
        }
    }
}
