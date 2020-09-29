using System.Collections.Generic;
using Battleships.Domain.Entities;

namespace Battleships.Application.Tests.Factories
{
    internal static class GameFactory
    {
        public static Domain.Entities.Game AddGameWithMissedCoordinateInComputerBoard(Coordinate coordinate)
        {
            var computerBoard = new Board()
            {
                MissShots = new List<Coordinate>() {coordinate}
            };
            var playerBoard = new Board();
            var game = new Domain.Entities.Game(playerBoard, computerBoard);
            return game;
        }
    }
}
