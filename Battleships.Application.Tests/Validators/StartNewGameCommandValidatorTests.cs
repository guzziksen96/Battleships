using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using Battleships.Application.Game.Commands.StartGame;
using Battleships.Domain.Entities;
using Xunit;

namespace Battleships.Application.Tests
{
    public class StartNewGameCommandValidatorTests
    {
        private readonly IFixture _fixture;
        private readonly StartNewGameCommandValidator _validator;

        public StartNewGameCommandValidatorTests()
        {
            _fixture = new Fixture();
            _validator = new StartNewGameCommandValidator();
        }

        [Theory]
        [AutoData]
        public void Should_Return_False_When_Given_MoreShips()
        {
             var ships = _fixture.CreateMany<Ship>(6).ToList();

             var result = _validator.AreShipsNamesValid(ships);

             Assert.False(result);
        }

        [Theory]
        [AutoData]
        public void Should_Return_False_When_Given_DifferentShipsNames()
        {
            var ships = _fixture.CreateMany<Ship>(5).ToList();

            var result = _validator.AreShipsNamesValid(ships);

            Assert.False(result);
        }


        [Theory]
        [AutoData]
        public void Should_Return_False_When_Given_ShipsNotInBoardRange()
        {
            var coordinatesNotInBoardRange = new List<Coordinate>()
            {
                new Coordinate(99, 'k')
            };
            var shipNotInBoardRange = _fixture.Build<Ship>()
                .With(x => x.ShipPositions, coordinatesNotInBoardRange)
                .Create();

            var result = _validator.AreShipsInBoardRange(new List<Ship>(){ shipNotInBoardRange });

            Assert.False(result);
        }

        [Theory]
        [InlineAutoData(10)]
        public void Should_Return_False_When_Given_ShipsWidthNotValid(int width)
        {
            var shipCoordinates = _fixture.CreateMany<Coordinate>(width);
            var shipNotInBoardRange = _fixture.Build<Ship>()
                .With(x => x.ShipPositions, shipCoordinates.ToList())
                .Create();

            var result = _validator.AreShipsWidthValid(new List<Ship>() { shipNotInBoardRange });

            Assert.False(result);
        }
    }
}
