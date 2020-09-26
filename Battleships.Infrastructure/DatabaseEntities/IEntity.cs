using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Infrastructure.DatabaseEntities
{
    public interface IEntity
    { 
        int Id { get; set; }
    }
}
