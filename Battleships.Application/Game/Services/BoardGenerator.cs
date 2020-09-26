using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Domain.Entities;
using Battleships.Domain.Enums;

namespace Battleships.Application
{
    public class BoardGenerator : IBoardGenerator
    {
        private const int _boardRange = 10;
        
        public async Task<Board> Generate()
        {
            var board = new Board();
            var carrierCoordinates = GetCoordinates(5, board);
            board.Ships.Add(new Ship("Carrier", carrierCoordinates));

            var battleShipCoordinates = GetCoordinates(4, board);
            board.Ships.Add(new Ship("BattleShip", battleShipCoordinates));

            var cruiserCoordinates = GetCoordinates(3, board);
            board.Ships.Add(new Ship("Cruiser", cruiserCoordinates));

            var submarineCoordinates = GetCoordinates(3, board);
            board.Ships.Add(new Ship("Submarine", submarineCoordinates));

            var destroyerCoordinates = GetCoordinates(2, board);
            board.Ships.Add(new Ship("Destroyer", destroyerCoordinates));
 
            return board; //save board and return board id
        }

        //public int Generate()
        //{
        //    return 1;
        //}
        private List<Coordinate> GetCoordinates(int width, Board board)
        {
            var result = new List<Coordinate>();
            var random = new Random();
            
            while(true)
            {
                var randomRow = random.Next(1, _boardRange + 1);
                var randomColumn = (char) ('a' + random.Next(0, _boardRange)); 
                
                var randomCoordinate = new Coordinate(randomRow, randomColumn);

                if (!IsOccupied(randomCoordinate, board))
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
                if (IsOccupied(potentialCoordinate, board) || !IsInBoardBoundaries(potentialCoordinate))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsInBoardBoundaries(Coordinate coordinate) 
            => coordinate.Row >= 1 && coordinate.Row <= 10 && coordinate.Column >= 'a' &&
               coordinate.Column <= (char) ('a' + 10);

        public bool IsOccupied(Coordinate coordinate, Board board)
          => board.Ships.Any(s => s.OccupiedCoordinates.Contains(coordinate));

    }
}
