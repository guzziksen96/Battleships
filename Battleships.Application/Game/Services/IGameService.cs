using System;

namespace Battleships.Application.Game.Services
{
    public interface IGameService
    {
        Domain.Entities.Game Get(Guid gameId);
        void Set(Domain.Entities.Game game);
    }
}