using Battleships.Domain.Entities;
using MediatR;

namespace Battleships.Application.Game.Commands.FireNewShot
{
    public class FireNewShotCommand : IRequest<int>
    {
        public Coordinate Coordinate { get; set; }

        public int GameId { get; private set; }

        public void SetGameId(int gameId) => GameId = gameId;
    }
}
