using System;
using System.Threading;
using System.Threading.Tasks;
using Battleships.Application.Game.Models;

namespace Battleships.Application.Game.Services
{
    public interface IGameService
    {
        Domain.Entities.Game Get(Guid gameId);
        void Set(Domain.Entities.Game game);
    }
}