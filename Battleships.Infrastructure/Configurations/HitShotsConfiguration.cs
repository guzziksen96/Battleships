using Battleships.Infrastructure.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battleships.Infrastructure.Configurations
{
    public class HitShotsConfiguration : IEntityTypeConfiguration<HitShotEntity>
    {
        public void Configure(EntityTypeBuilder<HitShotEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Board).WithMany(c => c.HitShots).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
