using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class CategoryArtworkDetailConfiguration : IEntityTypeConfiguration<CategoryArtworkDetail>
{
    public void Configure(EntityTypeBuilder<CategoryArtworkDetail> builder)
    {
        builder.ToTable("CategoryArtworkDetail");
        builder.HasKey(x => new { x.CategoryId, x.ArtworkId });

        // relationship
        builder.HasOne(x => x.Category).WithMany(c => c.CategoryArtworkDetails).HasForeignKey(x => x.CategoryId);
        builder.HasOne(x => x.Artwork).WithMany(a => a.CategoryArtworkDetails).HasForeignKey(x => x.ArtworkId);

        #region init data
        builder.HasData
        (
            // artwork 1
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },

            // artwork 2
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },

            // artwork 3
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 4
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-00000000000a")
            },

            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000007")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            }
        );
        #endregion

    }
}
