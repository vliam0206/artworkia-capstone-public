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

        #region init data
        builder.HasData
        (
            new Asset()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ArtworkId = new Guid("00000000-0000-0000-0000-000000000008"),
                AssetTitle = "File PTS tuyển tập minh hoạ sách tâm lý",
                Description = "tập tin PTS tuyển tập minh hoạ sách tâm lý " +
                "sẽ cung cấp một cái nhìn tổng quan và thú vị.",
                AssetName = "PTS_1.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                Price = 10000,
                ContentType = "zip",
                Size = 1476992
            },
            new Asset()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ArtworkId = new Guid("00000000-0000-0000-0000-00000000000e"),
                AssetTitle = "Robot PTS",
                Description = "Tặng các bạn",
                AssetName = "PTS_1.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                Price = 0,
                ContentType = "zip",
                Size = 3243243
            },
            new Asset()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                ArtworkId = new Guid("00000000-0000-0000-0000-00000000000f"),
                AssetTitle = "Canh cụt ZIP",
                Description = null,
                AssetName = "PTS_1.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                Price = 12000,
                ContentType = "zip",
                Size = 2568643
            }
        );
        #endregion
    }
}
