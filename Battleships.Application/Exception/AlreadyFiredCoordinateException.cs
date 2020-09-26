using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Application.Exception
{
    public class AlreadyFiredCoordinateException : System.Exception
    {
        public AlreadyFiredCoordinateException() : base($"This coordinate has already been fired at")
        {
            
        }
    }
}
