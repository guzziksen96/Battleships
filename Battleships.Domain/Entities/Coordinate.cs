using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Domain.Entities
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int row, char column)
        {
            Row = row;
            Column = column;
        }
        public int Row { get; private set; }
        public char Column { get; private set; }

        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row.GetHashCode() * 397) ^ Column;
            }
        }

    }
}
