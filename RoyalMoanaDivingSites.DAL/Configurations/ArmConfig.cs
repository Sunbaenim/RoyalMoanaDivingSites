using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.DAL.Configurations
{
    internal class ArmConfig : IEntityTypeConfiguration<Arm>
    {
        public void Configure(EntityTypeBuilder<Arm> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(a => a.DivingSite)
                .WithMany(ds => ds.Arms)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
