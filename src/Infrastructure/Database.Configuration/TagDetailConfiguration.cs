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


        #region init data
        builder.HasData
        (
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000016")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            }
        );
        #endregion
    }
}
