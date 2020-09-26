using System.Threading;
using System.Threading.Tasks;
using Battleships.Domain.Entities;

namespace Battleships.Application.Game.Services
{
    public interface IGameStateService
    {
        Task<GameState> Get(int gameId, CancellationToken cancellationToken);
    }
}