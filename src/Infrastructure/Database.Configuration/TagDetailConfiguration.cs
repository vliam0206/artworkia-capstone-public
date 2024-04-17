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
            // artwork 1
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },

            // artwork 2
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000c")
            },

            // artwork 3
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001a")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001c")
            },

            // artwork 4
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001a")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001c")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001d")
            },

            // artwork 5
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000c")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },


            // artwork 6
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000013")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001f")
            },

            // artwork 7
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },

            // artwork 8
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000e")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001e")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001f")
            },

            // artwork 9
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000c")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000017")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000021")
            },


            // artwork 10
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001f")
            },

            // artwork 11
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000017")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000020")
            },

            // artwork 12
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000014")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },

            // artwork 13
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },

            // artwork 14
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
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000017")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000021")
            },

            // artwork 15
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000016")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },

            // artwork 16
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },

            // artwork 17
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000011")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000018")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001d")
            },

            // artwork 18
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000022")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000023")
            },

            // artwork 19
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000007")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000016")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001a")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001c")
            },

            // artwork 20
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000c")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000017")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000020")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000021")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000024")
            },

            // artwork 21
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000021")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000024")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },

            // artwork 22
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000009")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000017")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000020")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000021")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000024")
            },

            // artwork 23
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000b")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000017")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000022")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // artwork 24
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000007")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000f")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000025")
            },

            // artwork 25
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000010")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000025")
            },

            // artwork 26
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000007")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000f")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000e")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000000c")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000025")
            },

            // artwork 27
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000019")
            },

            // artwork 28
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000018")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001a")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000025")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },

            // artwork 29
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000018")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001a")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000025")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },

            // artwork 30
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000018")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001a")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000025")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            },

            // artwork 31
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000018")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-00000000001a")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000025")
            },
            new TagDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                TagId = Guid.Parse("00000000-0000-0000-0000-000000000015")
            }
        );
        #endregion
    }
}
