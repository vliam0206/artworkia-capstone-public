using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable(nameof(Asset));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.LastModificatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Artwork).WithMany(a => a.Assets).HasForeignKey(x => x.ArtworkId);
        builder.HasMany(x => x.TransactionHistories).WithOne(t => t.Asset).HasForeignKey(t => t.AssetId);
    }
}
