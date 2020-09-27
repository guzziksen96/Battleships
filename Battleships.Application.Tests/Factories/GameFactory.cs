using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Battleships.Application.Helpres;
using Battleships.Domain.Entities;
using Battleships.Infrastructure;
using Battleships.Infrastructure.DatabaseEntities;

namespace Battleships.Application.Tests.Factories
{
    internal static class GameFactory
    {
        public static CoordinateEntity AddCoordinate(BattleshipsDbContext context, Coordinate coordinate)
        {
            var addedCoordinate = context.Coordinates.Add(new CoordinateEntity(){
                Row = coordinate.Row,
                Column = coordinate.Column
            });
            return addedCoordinate.Entity;
        }

        public static BoardEntity AddComputerBoard(BattleshipsDbContext context)
        {
            var addedBoard = context.Boards.Add(new BoardEntity());
            return addedBoard.Entity;
        }

        public static GameEntity AddGameWithMissedCoordinateInComputerBoard(BattleshipsDbContext context, Coordinate coordinate)
        {
            var addedCoordinate = context.Add(new CoordinateEntity()
            {
                Row = coordinate.Row,
                Column = coordinate.Column
            });

            context.SaveChanges();

            var addedComputerBoard = context.Boards.Add(new BoardEntity());
            var addedPlayerBoard = context.Boards.Add(new BoardEntity());

            context.SaveChanges();

            context.MissShots.Add(new MissShotEntity()
            {
                BoardId = addedComputerBoard.Entity.Id,
                CoordinateId = addedCoordinate.Entity.Id
            });

            context.SaveChanges();

            var addedGame = context.Games.Add(new GameEntity()
            {
                PlayerBoardId = addedPlayerBoard.Entity.Id,
                ComputerBoardId = addedComputerBoard.Entity.Id
            });

            context.SaveChanges();

            return addedGame.Entity;
        }
    }
}
