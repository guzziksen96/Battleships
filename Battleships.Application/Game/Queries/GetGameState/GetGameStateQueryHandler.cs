using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Battleships.Application.Game.Services;
using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Queries
{
    public class GetGameStateQueryHandler : IRequestHandler<GetGameStateQuery, GameState>
    {
        private readonly IGameStateService _gameStateService;
        public GetGameStateQueryHandler(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public async Task<GameState> Handle(GetGameStateQuery request, CancellationToken cancellationToken)
        {
            return await _gameStateService.Get(request.GameId, cancellationToken);
        }
    }
}
