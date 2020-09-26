namespace Battleships.Infrastructure.DatabaseEntities
{
    public class CoordinateEntity : IEntity
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public char Column { get; set; }
    }
}
