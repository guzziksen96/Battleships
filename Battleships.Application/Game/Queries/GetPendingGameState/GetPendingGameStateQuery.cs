using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Application.Game.Models;
using MediatR;

namespace Battleships.Application.Game.Queries.GetPendingGameState
{
    public class GetPendingGameStateQuery : IRequest<PendingGameStateDto>
    {
        public int GameId { get; }

        public GetPendingGameStateQuery(int gameId)
        {
            GameId = gameId;
        }
    }
}
