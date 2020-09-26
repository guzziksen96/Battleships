using System.Threading;
using System.Threading.Tasks;
using Battleships.Application.Game.Services;
using MediatR;

namespace Battleships.Application.Game.Queries
{
    public class GetFinalGameStateQueryHandler : IRequestHandler<GetFinalGameStateQuery, Domain.Entities.Game>
    {
        private readonly IGameService _gameService;
        public GetFinalGameStateQueryHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<Domain.Entities.Game> Handle(GetFinalGameStateQuery request, CancellationToken cancellationToken)
        {
            return await _gameService.GetFinalState(request.GameId, cancellationToken);
        }
    }
}
