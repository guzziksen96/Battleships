using System.Collections.Generic;

namespace Battleships.Infrastructure.DatabaseEntities
{
    public class ShipEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public virtual BoardEntity Board { get; set; }
        public virtual List<ShipPositionEntity> ShipPositions { get; set; }
    }
}
