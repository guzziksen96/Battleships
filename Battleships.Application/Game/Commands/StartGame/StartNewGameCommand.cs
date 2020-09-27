using System;
using System.Collections.Generic;
using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Commands.StartGame
{
    public class StartNewGameCommand : IRequest<Guid>
    {
        public List<Ship> Ships { get; set; }
    }
}
