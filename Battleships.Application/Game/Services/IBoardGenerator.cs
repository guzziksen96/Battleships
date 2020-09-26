using Battleships.Domain.Entities;

namespace Battleships.Application
{
    public interface IBoardGenerator
    {
        Board Generate();
        Coordinate GenerateRandomCoordinate();
    }
}