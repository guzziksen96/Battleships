namespace Battleships.Application.Exception
{
    public class AlreadyFiredCoordinateException : System.Exception
    {
        public AlreadyFiredCoordinateException() : base($"This coordinate has already been fired at")
        {
            
        }
    }
}
