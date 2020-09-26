using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Battleships.Application.Game.Models;
using Battleships.Application.Game.Services;
using MediatR;

namespace Battleships.Application.Game.Queries.GetPendingGameState
{
    public class GetPendingGameStateQueryHandler : IRequestHandler<GetPendingGameStateQuery, PendingGameStateDto>
    {
        private readonly IGameService _gameService;
        public GetPendingGameStateQueryHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<PendingGameStateDto> Handle(GetPendingGameStateQuery request, CancellationToken cancellationToken)
        {
            return await _gameService.GetPendingState(request.GameId, cancellationToken);
        }
    }
}
