using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Domain.Entities;
using Battleships.Infrastructure;
using Battleships.Infrastructure.DatabaseEntities;
using MediatR;

namespace Battleships.Application.Game.Commands.StartGame
{
    public class StartNewGameCommandHandler : IRequestHandler<StartNewGameCommand, int>
    {
        private readonly IBoardGenerator _boardGenerator;
        private readonly BattleshipsDbContext _context;
        private readonly IMapper _mapper;

        public StartNewGameCommandHandler(IBoardGenerator boardGenerator, BattleshipsDbContext context,
            IMapper mapper)
        {
            _boardGenerator = boardGenerator;
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(StartNewGameCommand request, CancellationToken cancellationToken)
        {
            var playerBoard = new Board(request.Ships);
            var playerBoardEntity = _mapper.Map<BoardEntity>(playerBoard);
            var computerBoard = _boardGenerator.Generate();
            var computerBoardEntity = _mapper.Map<BoardEntity>(computerBoard);
            
            var newGame = new GameEntity
            {
                PlayerBoard = playerBoardEntity, 
                ComputerBoard = computerBoardEntity
            };

            await _context.Games.AddAsync(newGame, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);


            return newGame.Id;
        }
    }
}
