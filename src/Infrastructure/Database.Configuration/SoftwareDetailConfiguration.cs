using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class SoftwareDetailConfiguration : IEntityTypeConfiguration<SoftwareDetail>
{
    public void Configure(EntityTypeBuilder<SoftwareDetail> builder)
    {
        builder.ToTable(nameof(SoftwareDetail));

        builder.HasKey(x => new { x.SoftwareUsedId, x.ArtworkId });

        builder.HasOne(x => x.SoftwareUsed)
            .WithMany(x => x.SoftwareDetails)
            .HasForeignKey(x => x.SoftwareUsedId);

        builder.HasOne(x => x.Artwork)
            .WithMany(x => x.SoftwareDetails)
            .HasForeignKey(x => x.ArtworkId);

        #region init data
        builder.HasData
        (
            // artwork 1
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-00000000003a"),
            },

            // artwork 2
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 3
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
            },

            // artwork 5
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-00000000003a"),
            },

            // artwork 6
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 7
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 8
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            },

            // artwork 9
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 10
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 11
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 12
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 13
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-00000000003a"),
            },

            // artwork 14
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 15
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 16
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000039"),
            },

            // artwork 18
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            },

            // artwork 20
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            },
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            },

            // artwork 21
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            },

            // artwork 22
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            },

            // artwork 23
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            },

            // artwork 27
            new SoftwareDetail()
            {
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-00000000003a"),
            }
        );
        #endregion
    }
}
