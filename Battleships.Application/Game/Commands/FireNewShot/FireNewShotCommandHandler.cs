using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Infrastructure;
using MediatR;

namespace Battleships.Application.Game.Commands.FireNewShot
{
    public class FireNewShotCommandHandler : IRequestHandler<FireNewShotCommand, int>
    {
        private readonly IBoardGenerator _boardGenerator;
        private readonly BattleshipsDbContext _context;
        private readonly IMapper _mapper;
        public FireNewShotCommandHandler(IBoardGenerator boardGenerator, BattleshipsDbContext context,
            IMapper mapper)
        {
            _boardGenerator = boardGenerator;
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(FireNewShotCommand request, CancellationToken cancellationToken)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
