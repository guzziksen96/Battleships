using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Application.Exception;
using Battleships.Application.Game.Services;
using Battleships.Domain.Entities;
using Battleships.Domain.Enums;
using MediatR;

namespace Battleships.Application.Game.Commands.FireNewShot
{
    public class FireNewShotCommandHandler : IRequestHandler<FireNewShotCommand, int>
    {
        private readonly IBoardGenerator _boardGenerator;
        private readonly IGameService _gameService;
        public FireNewShotCommandHandler(IBoardGenerator boardGenerator, IGameService gameService)
        {
            _boardGenerator = boardGenerator;
            _gameService = gameService;
        }

        public async Task<int> Handle(FireNewShotCommand request, CancellationToken cancellationToken)
        {
            var game = _gameService.Get(request.GameId);

            var playerFiredCoordinates = game.ComputerBoard.HitShots.Union(game.ComputerBoard.MissShots).ToList();
            if(playerFiredCoordinates.Contains(request.Coordinate))
                throw new AlreadyFiredCoordinateException();

            game.PlayerShootAt(request.Coordinate);

            if (game.GetResult() == GameResultEnum.PlayerWon)
            {
                return 1;
            }

            var computerFiredCoordinates = game.PlayerBoard.HitShots.Union(game.PlayerBoard.MissShots);
            var computerCoordinate = _boardGenerator.GenerateRandomNotFiredCoordinate(computerFiredCoordinates.ToList());
            game.ComputerShootAt(computerCoordinate);

            _gameService.Set(game);
            return 0;

        }
    }
}
