using System.Collections.Generic;
using Battleships.Domain.Entities;
using Moq;

namespace Battleships.Application.Tests.Mocks
{
    public class BoardGeneratorMock : Mock<IBoardGenerator>
    {
        public BoardGeneratorMock GenerateRandomNotFiredCoordinate(List<Coordinate> coordinates, Coordinate output)
        {
            Setup(x => x.GenerateRandomNotFiredCoordinate(coordinates))
                .Returns(output);
            return this;
        }
    }
}
