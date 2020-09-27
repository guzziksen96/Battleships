using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Battleships.Application.Game.Models;
using Battleships.Application.Game.Services;
using MediatR;

namespace Battleships.Application.Game.Queries.GetPendingGameState
{
    public class GetPendingGameStateQueryHandler : IRequestHandler<GetPendingGameStateQuery, GameStateDto>
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public GetPendingGameStateQueryHandler(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        public async Task<GameStateDto> Handle(GetPendingGameStateQuery request, CancellationToken cancellationToken)
        {
            var game = _gameService.Get(request.GameId);
            return  _mapper.Map<GameStateDto>(game);
        }
    }
}
