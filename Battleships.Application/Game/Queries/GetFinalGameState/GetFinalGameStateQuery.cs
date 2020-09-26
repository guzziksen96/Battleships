using MediatR;

namespace Battleships.Application.Game.Queries
{
    public class GetFinalGameStateQuery : IRequest<Domain.Entities.Game>
    {
        public GetFinalGameStateQuery(int gameId)
        {
            GameId = gameId;
        }
        public int GameId { get; }
    }
}
