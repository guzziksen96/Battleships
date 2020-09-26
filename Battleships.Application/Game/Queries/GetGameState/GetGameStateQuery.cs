using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Queries
{
    public class GetGameStateQuery : IRequest<GameState>
    {
        public GetGameStateQuery(int gameId)
        {
            GameId = gameId;
        }
        public int GameId { get; }
    }
}
