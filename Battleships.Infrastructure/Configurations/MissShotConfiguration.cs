using Battleships.Infrastructure.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battleships.Infrastructure.Configurations
{
    public class MissShotConfiguration : IEntityTypeConfiguration<MissShotEntity>
    {
        public void Configure(EntityTypeBuilder<MissShotEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Board).WithMany(c => c.MissShots).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
