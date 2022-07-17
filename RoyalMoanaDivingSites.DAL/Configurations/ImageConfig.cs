using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.DAL.Configurations
{
    internal class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.IsMainImage)
                .IsRequired();

            builder.Property(i => i.ImageUrl)
                .IsRequired();

            builder.HasOne(i => i.DivingSite)
                .WithMany(ds => ds.Images)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
