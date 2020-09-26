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

            var result = await _boardGenerator.Generate();
            var gameState = new GameState(playerBoard, result);
            //todo create new service which will save new game 
            return result.Id;
        }
    }
}
