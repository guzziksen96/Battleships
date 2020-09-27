using System;
using MediatR;

namespace Battleships.Application.Game.Queries
{
    public class GetFinalGameStateQuery : IRequest<Domain.Entities.Game>
    {
        public GetFinalGameStateQuery(Guid gameId)
        {
            GameId = gameId;
        }
        public Guid GameId { get; }
    }
}
