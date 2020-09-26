namespace Battleships.Infrastructure.DatabaseEntities
{
    public class GameEntity : IEntity
    {
        public int Id { get; set; }
        public int PlayerBoardId { get; set; }
        public virtual BoardEntity PlayerBoard { get; set; }
        public int ComputerBoardId { get; set; }
        public virtual BoardEntity ComputerBoard { get; set; }
    }
}
