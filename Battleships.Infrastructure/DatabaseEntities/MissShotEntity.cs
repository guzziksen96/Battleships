namespace Battleships.Infrastructure.DatabaseEntities
{
    public class MissShotEntity : IEntity
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public virtual BoardEntity Board { get; set; }
        public int CoordinateId { get; set; }
        public virtual CoordinateEntity Coordinate { get; set; }
    }
}
