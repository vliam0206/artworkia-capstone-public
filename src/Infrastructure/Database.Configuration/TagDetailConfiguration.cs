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
            new TagDetail() { 
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                TagId = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                TagId = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                TagId = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                TagId = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                TagId = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                TagId = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9")
            }
        );
        #endregion
    }
}
