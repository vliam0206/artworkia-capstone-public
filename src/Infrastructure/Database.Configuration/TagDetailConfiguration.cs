using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class TagDetailConfiguration : IEntityTypeConfiguration<TagDetail>
{
    public void Configure(EntityTypeBuilder<TagDetail> builder)
    {
        builder.ToTable(nameof(TagDetail));
        builder.HasKey(x => new { x.TagId, x.ArtworkId });

        // relationship
        builder.HasOne(x => x.Tag).WithMany(t => t.TagDetails).HasForeignKey(x => x.TagId);
        builder.HasOne(x => x.Artwork).WithMany(t => t.TagDetails).HasForeignKey(x => x.ArtworkId);
    }
}
