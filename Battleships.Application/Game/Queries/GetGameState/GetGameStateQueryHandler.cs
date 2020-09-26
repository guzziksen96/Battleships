using System.Threading;
using System.Threading.Tasks;
using Battleships.Application.Game.Services;
using MediatR;

namespace Battleships.Application.Game.Queries
{
    public class GetGameStateQueryHandler : IRequestHandler<GetGameStateQuery, Domain.Entities.Game>
    {
        private readonly IGameService _gameService;
        public GetGameStateQueryHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<Domain.Entities.Game> Handle(GetGameStateQuery request, CancellationToken cancellationToken)
        {
            return await _gameService.Get(request.GameId, cancellationToken);
        }
    }
}
