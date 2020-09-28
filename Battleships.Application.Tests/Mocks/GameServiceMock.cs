using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Application.Game.Services;
using Moq;

namespace Battleships.Application.Tests.Mocks
{
    public class GameServiceMock : Mock<IGameService>
    {
        public GameServiceMock SetGame(Domain.Entities.Game game)
        {
            Setup(x => x.Set(game));
            return this;
        }

        public GameServiceMock GetGame(Domain.Entities.Game game)
        {
            Setup(x => x.Get(game.Id))
                .Returns(game);
            return this;
        }
    }
}
