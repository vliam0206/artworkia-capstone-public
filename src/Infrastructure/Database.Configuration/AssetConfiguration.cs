using Application.Commons;
using Domain.Entitites;
using Domain.Enums;
using MassTransit;
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
                Id = Guid.Parse("ec114537-eadb-49d4-ad49-675d06ce6ccc"),
                ArtworkId = new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                AssetTitle = "File PTS tuyển tập minh hoạ sách tâm lý",
                Description = "Mua đê",
                AssetName = "PTS_1.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                Price = 10,
            },
            new Asset()
            {
                Id = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                ArtworkId = new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                AssetTitle = "Touhout PTS",
                Description = "Tặng các bạn",
                AssetName = "PTS_1.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                Price = 0,
            },
            new Asset()
            {
                Id = Guid.Parse("8225058f-9f38-49f2-a68d-d9237b0a550f"),
                ArtworkId = new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                AssetTitle = "Tàu hũ ZIP",
                Description = null,
                AssetName = "PTS_1.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                Price = 12,
            }
        );
        #endregion
    }
}
