using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Battleships.Application.Game.Commands.FireNewShot
{
    public class FireNewShotCommandHandler : IRequestHandler<FireNewShotCommand, int>
    {
        private readonly BattleshipsDbContext _context;
        private readonly IBoardGenerator _boardGenerator;
        private readonly IMapper _mapper;
        public FireNewShotCommandHandler(BattleshipsDbContext context,
            IMapper mapper, IBoardGenerator boardGenerator)
        {
            _context = context;
            _mapper = mapper;
            _boardGenerator = boardGenerator;
        }

        public async Task<int> Handle(FireNewShotCommand request, CancellationToken cancellationToken)
        {
            var gameEntity = await _context.Games
                .Include(x => x.ComputerBoard.HitShots)
                .ThenInclude(s => s.Coordinate)
                .Include(x => x.ComputerBoard.MissShots)
                .ThenInclude(s => s.Coordinate)
                .Include(x => x.ComputerBoard.Ships)
                .ThenInclude(s => s.ShipPositions).ThenInclude(sp => sp.Coordinate)
                .FirstOrDefaultAsync(x => x.Id == request.GameId, cancellationToken);

            var game = _mapper.Map<Domain.Entities.Game>(gameEntity);

            game.PlayerShootAt(request.Coordinate);
            game.ComputerShootAt(_boardGenerator.GenerateRandomCoordinate());

            //todo save changes 

            throw new NotImplementedException();
        }
    }
}
