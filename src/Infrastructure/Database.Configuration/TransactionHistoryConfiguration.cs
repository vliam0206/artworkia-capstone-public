using Domain.Entitites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
{
    public void Configure(EntityTypeBuilder<TransactionHistory> builder)
    {
        builder.ToTable(nameof(TransactionHistory));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Account).WithMany(a => a.TransactionHistories).HasForeignKey(x => x.CreatedBy);
        builder.HasOne(x => x.Asset).WithMany(a => a.TransactionHistories).HasForeignKey(x => x.AssetId);
        builder.HasOne(x => x.Proposal).WithMany(p => p.TransactionHistories).HasForeignKey(x => x.ProposalId);

        #region Init data
        builder.HasData
        (
            new TransactionHistory
            {
                Id = Guid.Parse("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d1"),
                AssetId = new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                CreatedBy = new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), // user
                Detail = "Mở khóa tài nguyên \"Tàu hũ ZIP\"",
                Price = 12,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-13T15:30:03.678Z")
            },
            new TransactionHistory
            {
                Id = Guid.Parse("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d2"),
                AssetId = new Guid("ec114537-eadb-49d4-ad49-675d06ce6ccc"),
                CreatedBy = new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), // user
                Detail = "Mở khóa tài nguyên \"File PTS tuyển tập minh hoạ sách tâm lý\"",
                Price = 10,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-15T02:59:59.000Z")
            },
            new TransactionHistory
            {
                Id = Guid.Parse("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d3"),
                AssetId = new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                CreatedBy = new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), // lamlam
                Detail = "Mở khóa tài nguyên \"Tàu hũ ZIP\"",
                Price = 12,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-14T15:30:03.678Z")
            }
        );
        #endregion
    }
}
