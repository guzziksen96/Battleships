using System.Threading;
using System.Threading.Tasks;
using Battleships.Application.Game.Models;

namespace Battleships.Application.Game.Services
{
    public interface IGameService
    {
        Task<Domain.Entities.Game> GetFinalState(int gameId, CancellationToken cancellationToken);
        Task<PendingGameStateDto> GetPendingState(int gameId, CancellationToken cancellationToken);
    }
}