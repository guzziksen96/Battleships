//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoFixture;
//using AutoFixture.Xunit2;
//using AutoMapper;
//using Battleships.Application.Exception;
//using Battleships.Application.Game.Commands.FireNewShot;
//using Battleships.Application.Helpres;
//using Battleships.Application.Tests.Factories;
//using Battleships.Application.Tests.Mocks;
//using Battleships.Domain.Entities;
//using Xunit;

//namespace Battleships.Application.Tests.Commands
//{
//    public class FireNewShotCommandHandlerTests 
//    {
//        private readonly FireNewShotCommandHandler _handler;
//        private readonly BoardGeneratorMock _boardGeneratorMock;
//        private readonly IMapper _mapper;
//        private readonly IFixture _fixture;

//        public FireNewShotCommandHandlerTests()
//        {
//            _fixture = new Fixture();
//            _boardGeneratorMock = new BoardGeneratorMock();
//            _mapper = AutoMapperFactory.Create(new MappingProfiles());
//            _handler = new FireNewShotCommandHandler(_mapper, _boardGeneratorMock.Object);
//        }

//        [Theory]
//        [AutoData]
//        public async Task Should_ThrowAlreadyFiredCoordinateException_When_CoordinateUsed(Coordinate coordinate)
//        {
//            var game = GameFactory.AddGameWithMissedCoordinateInComputerBoard(_context, coordinate);
//            var computerCoordinateToFire = _fixture.Create<Coordinate>();
//            var computerFiredCoordinates = _fixture.Create<List<Coordinate>>();
//            _boardGeneratorMock.GenerateRandomNotFiredCoordinate(computerFiredCoordinates, computerCoordinateToFire);
//            var command = new FireNewShotCommand();
//            command.SetGameId(game.Id);
//            command.Coordinate = coordinate;

//            async Task Func() => await _handler.Handle(command, CancellationToken.None);

//            await Assert.ThrowsAsync<AlreadyFiredCoordinateException>(Func);
//        }
//    }
//}
