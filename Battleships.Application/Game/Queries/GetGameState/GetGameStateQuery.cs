using MediatR;

namespace Battleships.Application.Game.Queries
{
    public class GetGameStateQuery : IRequest<Domain.Entities.Game>
    {
        public GetGameStateQuery(int gameId)
        {
            GameId = gameId;
        }
        public int GameId { get; }
    }
}
