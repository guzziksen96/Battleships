using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Application.Game.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Battleships.Application.Game.Services
{
    public class GameService : IGameService
    {
        private readonly IMemoryCache _memoryCache;
        public GameService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Domain.Entities.Game Get(Guid gameId)
        {
            return _memoryCache.Get<Domain.Entities.Game>(gameId);
        }

        public void Set(Domain.Entities.Game game)
        {
            _memoryCache.Remove(game.Id);
            _memoryCache.Set(game.Id, game);
        }
    }
}
