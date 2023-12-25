using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;
public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable(nameof(Image));
        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.HasOne(x => x.Artwork).WithMany(w => w.Images).HasForeignKey(x => x.ArtworkId);

    }
}
