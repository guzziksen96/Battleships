using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Application.Game.Models;
using Battleships.Domain.Enums;
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
        public async Task<Domain.Entities.Game> GetFinalState(int gameId, CancellationToken cancellationToken)
        {
            var gameEntity = await GetGameEntity(gameId, cancellationToken);

            return _mapper.Map<Domain.Entities.Game>(gameEntity);
        }
        public async Task<GameStateDto> GetGameState(int gameId, CancellationToken cancellationToken)
        {
            var gameEntity = await GetGameEntity(gameId, cancellationToken);
            var game = _mapper.Map<Domain.Entities.Game>(gameEntity);

            return _mapper.Map<GameStateDto>(game);
        }

        private async Task<GameEntity> GetGameEntity(int gameId, CancellationToken cancellationToken)
        {
            var gameEntity = await _context.Games
                .Include(g => g.PlayerBoard.Ships)
                .ThenInclude(s => s.ShipPositions).ThenInclude(sp => sp.Coordinate)
                .Include(g => g.PlayerBoard.HitShots)
                .ThenInclude(s => s.Coordinate)
                .Include(g => g.PlayerBoard.MissShots)
                .ThenInclude(s => s.Coordinate)
                .Include(g => g.ComputerBoard.Ships)
                .ThenInclude(s => s.ShipPositions).ThenInclude(sp => sp.Coordinate)
                .Include(g => g.ComputerBoard.HitShots)
                .ThenInclude(s => s.Coordinate)
                .Include(g => g.ComputerBoard.MissShots)
                .ThenInclude(s => s.Coordinate)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == gameId, cancellationToken);
            return gameEntity;
        }

       
    }
}
