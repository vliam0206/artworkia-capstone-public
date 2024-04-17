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

            // artwork 5
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 6
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },

            // artwork 7
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },

            // artwork 8
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 9
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },

            // artwork 10
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 11
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 12
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },

            // artwork 13
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 14
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

            // artwork 15
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

            // artwork 16
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },

            // artwork 17
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 18
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-00000000000e")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },

            // artwork 19
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 20
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },

            // artwork 21
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },

            // artwork 22
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },

            // artwork 23
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 24
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 25
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 26
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 27
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 28
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },

            // artwork 29
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },

            // artwork 30
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },

            // artwork 31
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new CategoryArtworkDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            }


        );
        #endregion

    }
}
