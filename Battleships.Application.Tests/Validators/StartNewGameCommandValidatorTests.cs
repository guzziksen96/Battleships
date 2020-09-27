using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        public void Should_Return_False_When_Given_DiffrenetShipsNames()
        {
            var ships = _fixture.CreateMany<Ship>(5).ToList();

            var result = _validator.AreShipsNamesValid(ships);

            Assert.False(result);
        }
    }
}
