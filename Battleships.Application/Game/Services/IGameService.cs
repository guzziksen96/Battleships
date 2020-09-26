using System.Threading;
using System.Threading.Tasks;

namespace Battleships.Application.Game.Services
{
    public interface IGameService
    {
        Task<Domain.Entities.Game> Get(int gameId, CancellationToken cancellationToken);
    }
}