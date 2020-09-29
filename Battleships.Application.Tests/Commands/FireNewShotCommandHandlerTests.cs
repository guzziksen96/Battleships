using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using Battleships.Application.Exception;
using Battleships.Application.Game.Commands.FireNewShot;
using Battleships.Application.Tests.Factories;
using Battleships.Application.Tests.Mocks;
using Battleships.Domain.Entities;
using Xunit;

namespace Battleships.Application.Tests.Commands
{
    public class FireNewShotCommandHandlerTests
    {
        private readonly FireNewShotCommandHandler _handler;
        private readonly BoardGeneratorMock _boardGeneratorMock;
        private readonly GameServiceMock _gameServiceMock;
        private readonly IFixture _fixture;

        public FireNewShotCommandHandlerTests()
        {
            _fixture = new Fixture();
            _boardGeneratorMock = new BoardGeneratorMock();
            _gameServiceMock = new GameServiceMock();
            _handler = new FireNewShotCommandHandler(_boardGeneratorMock.Object, _gameServiceMock.Object);
        }

        [Theory]
        [AutoData]
        public async Task Should_ThrowAlreadyFiredCoordinateException_When_CoordinateUsed(Coordinate coordinate)
        {
            var game = GameFactory.AddGameWithMissedCoordinateInComputerBoard(coordinate);
            var computerCoordinateToFire = _fixture.Create<Coordinate>();
            var computerFiredCoordinates = _fixture.Create<List<Coordinate>>();
            _boardGeneratorMock.GenerateRandomNotFiredCoordinate(computerFiredCoordinates, computerCoordinateToFire);
            _gameServiceMock.SetGame(game);
            _gameServiceMock.GetGame(game);
            var command = new FireNewShotCommand();
            command.SetGameId(game.Id);
            command.Coordinate = coordinate;

            async Task Func() => await _handler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<AlreadyFiredCoordinateException>(Func);
        }
    }
}
