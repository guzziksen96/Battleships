using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Infrastructure.Configurations;
using Battleships.Infrastructure.DatabaseEntities;
using Battleships.Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Battleships.Infrastructure
{
    public class BattleshipsDbContext : DbContext
    {
        public BattleshipsDbContext(DbContextOptions<BattleshipsDbContext> options)
            : base(options)
        {
        }
        public DbSet<BoardEntity> Boards { get; set; }
        public DbSet<CoordinateEntity> Coordinates { get; set; }
        public DbSet<ShipPositionEntity> ShipPositions { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<HitShotEntity> HitShots { get; set; }
        public DbSet<MissShotEntity> MissShots { get; set; }
        public DbSet<ShipEntity> Ships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MissShotConfiguration).Assembly);

            modelBuilder.SeedCoordinates();

            base.OnModelCreating(modelBuilder);
        }
    }
}
