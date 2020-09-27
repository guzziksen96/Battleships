using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Application.Game.Models;
using MediatR;

namespace Battleships.Application.Game.Queries.GetPendingGameState
{
    public class GetPendingGameStateQuery : IRequest<GameStateDto>
    {
        public Guid GameId { get; }

        public GetPendingGameStateQuery(Guid gameId)
        {
            GameId = gameId;
        }
    }
}
