using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.DAL.Configurations
{
    internal class LevelConfig : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.Property(a => a.LevelNumber)
                .IsRequired();

            builder.HasOne(a => a.DivingSite)
                .WithMany(ds => ds.Levels)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
