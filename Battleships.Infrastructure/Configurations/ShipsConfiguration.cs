using Battleships.Infrastructure.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battleships.Infrastructure.Configurations
{
    public class ShipsConfiguration : IEntityTypeConfiguration<ShipEntity>
    {
        public void Configure(EntityTypeBuilder<ShipEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Board).WithMany(c => c.Ships).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
