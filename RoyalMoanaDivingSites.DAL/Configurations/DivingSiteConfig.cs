using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.DAL.Configurations
{
    internal class DivingSiteConfig : IEntityTypeConfiguration<DivingSite>
    {
        public void Configure(EntityTypeBuilder<DivingSite> builder)
        {
            builder.Property(ds => ds.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(ds => ds.Latitude)
                .IsRequired()
                .HasColumnType("decimal(17,15)");

            builder.Property(ds => ds.Longitude)
                .IsRequired()
                .HasColumnType("decimal(17,15)");

            builder.Property(ds => ds.Level)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(ds => ds.Tide)
                .HasMaxLength(7);

            builder.Property(ds => ds.Current)
                .HasMaxLength(20);

            builder.Property(ds => ds.Depth)
                .IsRequired();

            builder.Property(ds => ds.LaunchingDifficulty)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(ds => ds.LaunchingDistance)
                .HasMaxLength(12);

            builder.Property(ds => ds.WindDirection)
                .HasConversion<string>()
                .HasMaxLength(2);

            builder.Property(ds => ds.IsSnorkeling)
                .IsRequired();

            builder.Property(ds => ds.IsInitiation)
                .IsRequired();

            builder.Property(ds => ds.IsForDisabledPerson)
                .IsRequired();

            builder.Property(ds => ds.IsSpecialDiving)
                .IsRequired();
        }
    }
}
