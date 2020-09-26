using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Infrastructure;
using Battleships.Infrastructure.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Battleships.Application.Game.Services
{
    public class GameService : IGameService
    {
        private readonly BattleshipsDbContext _context;
        private readonly IMapper _mapper;

        public GameService(BattleshipsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Domain.Entities.Game> Get(int gameId, CancellationToken cancellationToken)
        {
            var gameEntity = await _context.Games
                .Include(g => g.PlayerBoard.Ships)
                    .ThenInclude(s => s.ShipPositions)
                .Include(g => g.PlayerBoard.HitShots)
                    .ThenInclude(s => s.Coordinate)
                .Include(g => g.PlayerBoard.MissShots)
                    .ThenInclude(s => s.Coordinate)
                .FirstOrDefaultAsync(x => x.Id == gameId, cancellationToken);
          
            return _mapper.Map<GameEntity, Domain.Entities.Game>(gameEntity);

        }
    }
}
