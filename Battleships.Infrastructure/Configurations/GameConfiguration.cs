using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Infrastructure.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battleships.Infrastructure.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.PlayerBoard).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ComputerBoard).WithOne().OnDelete(DeleteBehavior.Restrict);

        }
    }
}
