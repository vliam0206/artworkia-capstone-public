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
            new SoftwareDetail()
            {
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e")
            },
            new SoftwareDetail()
            {
                SoftwareUsedId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f")
            }
        );
        #endregion
    }
}
