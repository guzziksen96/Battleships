using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Commands.StartGame
{
    public class StartNewGameCommandHandler : IRequestHandler<StartNewGameCommand, int>
    {
        private readonly IBoardGenerator _boardGenerator;

        public StartNewGameCommandHandler(IBoardGenerator boardGenerator)
        {
            _boardGenerator = boardGenerator;
        }
        public async Task<int> Handle(StartNewGameCommand request, CancellationToken cancellationToken)
        {
            var playerBoard = new Board(request.Ships);

            var computerBoard = _boardGenerator.Generate();
            var newGame = new Domain.Entities.Game(playerBoard, computerBoard);

            //todo create new service which will save new game 
            return newGame.Id;
        }
    }
}
