using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using Battleships.Domain.Entities;
using Battleships.Domain.Enums;
using Xunit;

namespace Battleships.Domain.Tests
{
    public class BoardTests
    {
        private readonly IFixture _fixture;

        public BoardTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Should_Return_False_When_CoordinateIsNotInBoundaries()
        {
            var coordinate = new Coordinate(11, 'p');

            var result  = Board.IsInBoundaries(coordinate);

            Assert.False(result);
        }

        [Theory]
        [AutoData]
        public void Should_Return_FireResult_Hit_When_Coordinate_ShotShip(Coordinate coordinate)
        {
            var shipPositions = _fixture.CreateMany<Coordinate>();
            var board = new Board()
            {
                Ships = new List<Ship>()
                {
                    new Ship()
                    {
                        ShipPositions = new List<Coordinate>()
                        {
                            coordinate
                        }
                    },
                    new Ship()
                    {
                        ShipPositions = shipPositions.ToList()
                    }
                }
            };

            var result = board.ShootAt(coordinate);

            Assert.Equal(FireResult.Hit, result);
        }

        [Theory]
        [AutoData]
        public void Should_Return_True_When_PositionOccupiedByShip(Coordinate coordinate)
        {
            var shipPositions = _fixture.CreateMany<Coordinate>();
            var board = new Board()
            {
                Ships = new List<Ship>()
                {
                    new Ship()
                    {
                        ShipPositions = new List<Coordinate>()
                        {
                            coordinate
                        }
                    },
                    new Ship()
                    {
                        ShipPositions = shipPositions.ToList()
                    }
                }
            };

            var result = board.IsPositionOccupied(coordinate);

            Assert.True(result);
        }
    }
}
