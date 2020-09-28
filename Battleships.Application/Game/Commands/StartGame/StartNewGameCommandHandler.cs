using System;
using System.Threading;
using System.Threading.Tasks;
using Battleships.Application.Game.Services;
using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Commands.StartGame
{
    public class StartNewGameCommandHandler : IRequestHandler<StartNewGameCommand, Guid>
    {
        private readonly IBoardGenerator _boardGenerator;
        private readonly IGameService _gameService;

        public StartNewGameCommandHandler(IBoardGenerator boardGenerator, IGameService gameService)
        {
            _boardGenerator = boardGenerator;
            _gameService = gameService;

        }
        public async Task<Guid> Handle(StartNewGameCommand request, CancellationToken cancellationToken)
        {
            var playerBoard = new Board(request.Ships);
            var computerBoard = _boardGenerator.Generate();
            
            var newGame = new Domain.Entities.Game(playerBoard, computerBoard)
            {
               Id = Guid.NewGuid()
            };

            _gameService.Set(newGame);
            return newGame.Id;
        }
    }
}
