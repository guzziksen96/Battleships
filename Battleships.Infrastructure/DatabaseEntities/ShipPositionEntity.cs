namespace Battleships.Infrastructure.DatabaseEntities
{
    public class ShipPositionEntity : IEntity
    {
        public int Id { get; set; }
        public int ShipId { get; set; }
        public virtual ShipEntity Ship { get; set; }
        public int CoordinateId { get; set; }
        public virtual CoordinateEntity Coordinate { get; set; }
    }
}
