using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Battleships.Domain.Entities;

namespace Battleships.Application
{
    public interface IBoardGenerator
    {
        Board Generate();
    }
}