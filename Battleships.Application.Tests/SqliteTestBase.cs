using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Battleships.Application.Tests
{
    public class SqliteTestBase<T> : IDisposable where T : DbContext
    {
        public T DbContext;

        public SqliteTestBase()
        {
            DbContext = GetDbContext();
        }

        private T GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite("DataSource=:memory:", x => { });

            var dbContext = Activator.CreateInstance(typeof(T), builder.Options) as T;
            // SQLite needs to open connection to the DB.
            // Not required for in-memory-database.
            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated();
            return dbContext;

        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
