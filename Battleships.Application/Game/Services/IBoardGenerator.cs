using System.Collections.Generic;
using Battleships.Domain.Entities;

namespace Battleships.Application
{
    public interface IBoardGenerator
    {
        Board Generate();
        Coordinate GenerateRandomNotFiredCoordinate(List<Coordinate> firedCoordinates);
    }
}