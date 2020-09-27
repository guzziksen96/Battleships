using System;
using System.Collections.Generic;
using Battleships.Domain.Entities;
using Battleships.Domain.Enums;
using Battleships.Domain.Rules;

namespace Battleships.Application
{
    public class BoardGenerator : IBoardGenerator
    {
        public Board Generate()
        {
            var board = new Board();

            foreach (var shipName in ShipNames.All)
            {
                var shipCoordinate = GetCoordinates(ShipWidths.Values[shipName], board);
                board.Ships.Add(new Ship(shipName, shipCoordinate));
            }

            return board; 
        }

        public Coordinate GenerateRandomNotFiredCoordinate(List<Coordinate> firedCoordinates)
        {
            while (true)
            {
                var randomCoordinate = GenerateRandomCoordinate();
                if (!firedCoordinates.Contains(randomCoordinate))
                    return randomCoordinate;

            }
        }

        private Coordinate GenerateRandomCoordinate()
        {
            var random = new Random();
            var randomRow = random.Next(1, Board.BoardRange + 1);
            var randomColumn = (char)('a' + random.Next(0, Board.BoardRange));

            var randomCoordinate = new Coordinate(randomRow, randomColumn);
            return randomCoordinate;
        }

        private List<Coordinate> GetCoordinates(int width, Board board)
        {
            var result = new List<Coordinate>();
            var random = new Random();
            
            while(true)
            {
                var randomCoordinate = GenerateRandomCoordinate();

                if (!board.IsPositionOccupied(randomCoordinate))
                {
                    var randomShipDirection = (ShipDirection)random.Next(0, 4);
                    var canPlaceShip = CanPlaceShip(randomShipDirection, randomCoordinate, width, board);
                    if (canPlaceShip)
                    {
                        var shipCoords = GetShipCoordinates(randomCoordinate, randomShipDirection, width);
                        result.AddRange(shipCoords);
                        break;
                    }
                }
            }
            
            return result;
        }

        //rename to placeNextCoordinate
        private Dictionary<ShipDirection, Func<Coordinate, Coordinate>> _coordinateTransformer = new Dictionary<ShipDirection, Func<Coordinate, Coordinate>>()
        {
            {ShipDirection.North, c => new Coordinate(c.Row - 1, c.Column)},
            {ShipDirection.East, c => new Coordinate(c.Row, (char)(c.Column + 1))},
            {ShipDirection.South, c => new Coordinate(c.Row + 1, c.Column)},
            {ShipDirection.West, c => new Coordinate(c.Row, (char)(c.Column - 1))},
        };

        private IEnumerable<Coordinate> GetShipCoordinates(Coordinate coordinate, ShipDirection randomShipDirection, int width)
        {
            yield return coordinate;
            for (int i = 1; i < width; i++)
            {
                var transformer = _coordinateTransformer[randomShipDirection];
                coordinate = transformer(coordinate);
                yield return coordinate;
            }
        }

        private bool CanPlaceShip(ShipDirection shipDirection, Coordinate potentialCoordinate, int width, Board board)
        {
            for (int i = 1; i < width; i++)
            {
                var transformer = _coordinateTransformer[shipDirection];
                potentialCoordinate = transformer(potentialCoordinate);
                if (board.IsPositionOccupied(potentialCoordinate) || !Board.IsInBoundaries(potentialCoordinate))
                {
                    return false;
                }
            }

            return true;
        }



    }
}
