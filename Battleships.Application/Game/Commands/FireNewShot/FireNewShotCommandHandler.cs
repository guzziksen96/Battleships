using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Domain.Entities;
using Battleships.Domain.Enums;
using Battleships.Infrastructure;
using Battleships.Infrastructure.DatabaseEntities;
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


        private void AddFiredCoordinate(BoardEntity board, Coordinate coordinate, FireResult fireResult)
        {
            if (fireResult == FireResult.Hit)
                board.HitShots.Add(_mapper.Map<HitShotEntity>(coordinate));
            else
                board.MissShots.Add(_mapper.Map<MissShotEntity>(coordinate));
        }
        public async Task<int> Handle(FireNewShotCommand request, CancellationToken cancellationToken)
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
                .FirstOrDefaultAsync(x => x.Id == request.GameId, cancellationToken);

            var game = _mapper.Map<Domain.Entities.Game>(gameEntity);

            var playerFireResult = game.PlayerShootAt(request.Coordinate);
            AddFiredCoordinate(gameEntity.ComputerBoard, request.Coordinate, playerFireResult);

            if (game.GetResult() == GameResultEnum.PlayerWon)
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }

            var computerFiredCoordinates = game.PlayerBoard.HitShots.Union(game.PlayerBoard.MissShots);
            var computerCoordinate = _boardGenerator.GenerateRandomNotFiredCoordinate(computerFiredCoordinates.ToList());
            var computerFireResult = game.ComputerShootAt(computerCoordinate);

            AddFiredCoordinate(gameEntity.PlayerBoard, computerCoordinate, computerFireResult);
            return await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
