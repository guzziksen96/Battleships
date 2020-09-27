using System;
using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Commands.FireNewShot
{
    public class FireNewShotCommand : IRequest<int>
    {
        public Coordinate Coordinate { get; set; }

        public Guid GameId { get; private set; }

        public void SetGameId(Guid gameId) => GameId = gameId;
    }
}
