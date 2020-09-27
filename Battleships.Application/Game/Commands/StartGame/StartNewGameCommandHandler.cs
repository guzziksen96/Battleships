using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Commands.StartGame
{
    public class StartNewGameCommandHandler : IRequestHandler<StartNewGameCommand, Guid>
    {
        private readonly IBoardGenerator _boardGenerator;

        public StartNewGameCommandHandler(IBoardGenerator boardGenerator)
        {
            _boardGenerator = boardGenerator;
        }
        public async Task<Guid> Handle(StartNewGameCommand request, CancellationToken cancellationToken)
        {
            var playerBoard = new Board(request.Ships);
            var computerBoard = _boardGenerator.Generate();
            
            var newGame = new Domain.Entities.Game(playerBoard, computerBoard)
            {
               Id = Guid.NewGuid()
            };

            return newGame.Id;
        }
    }
}
