using System.Collections.Generic;
using Battleships.Infrastructure.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Battleships.Infrastructure.SeedData
{
    internal static class CoordinatesSeed
    {
        private const int _boardRange = 10;
        public static void SeedCoordinates(this ModelBuilder modelBuilder)
        {
            InsertCoordinates(modelBuilder);
        }

        private static void InsertCoordinates(ModelBuilder modelBuilder)
        {
            var coordinates = new List<CoordinateEntity>();
            int id = 1; 
            for (int i = 1; i <= _boardRange; i++)
            {
                for (int j = 0; j < _boardRange; j++)
                {

                    coordinates.Add(CreateCoordinate(id++, i, (char)('a' + j)));
                }
            }

            modelBuilder.Entity<CoordinateEntity>().HasData(coordinates);
        }

        private static CoordinateEntity CreateCoordinate(int id, int row, char column)
        {
            return new CoordinateEntity
            {
                Id = id,
                Row = row,
                Column = column
            };
        }
    }
}
