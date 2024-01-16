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
            new CategoryArtworkDetail() { 
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                CategoryId = Guid.Parse("57dbdb36-f9ad-4926-9fb6-2df15969ed5e")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                CategoryId = Guid.Parse("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                CategoryId = Guid.Parse("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                CategoryId = Guid.Parse("57dbdb36-f9ad-4926-9fb6-2df15969ed5e")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                CategoryId = Guid.Parse("ced1a254-ecac-47e4-ae18-5d23c2711bf5")
            }
        );
        #endregion

    }
}
