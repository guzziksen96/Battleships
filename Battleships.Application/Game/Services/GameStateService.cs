using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Battleships.Domain.Entities;

namespace Battleships.Application.Game.Services
{
    public class GameStateService : IGameStateService
    {
        public async Task<GameState> Get(int gameId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
