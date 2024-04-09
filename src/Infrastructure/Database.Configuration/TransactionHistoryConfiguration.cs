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
        builder.HasOne(x => x.ToAccount).WithMany(a => a.TransactionHistoriesReceivedCoins).HasForeignKey(x => x.ToAccountId);
        builder.HasOne(x => x.Asset).WithMany(a => a.TransactionHistories).HasForeignKey(x => x.AssetId);
        builder.HasOne(x => x.Proposal).WithMany(p => p.TransactionHistories).HasForeignKey(x => x.ProposalId);

        #region Init data
        builder.HasData
        (
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000004"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000001"), // user
                Detail = "Mở khóa tài nguyên \"Cánh cụt ZIP\"",
                Price = 12000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-13T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000001"), // user
                Detail = "Mở khóa tài nguyên \"File PTS tuyển tập minh hoạ sách tâm lý\"",
                Price = 10000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-15T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000004"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000002"), // lamlam
                Detail = "Mở khóa tài nguyên \"Cánh cụt ZIP\"",
                Price = 12000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-14T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                ProposalId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000005"), // phuhuynh
                Detail = "	Đặt cọc thỏa thuận \"Làm web thiệp cưới\" (25%)",
                Price = 20000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-03T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002")  // lamlam
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                ProposalId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000005"), // phuhuynh
                Detail = "	Đặt cọc thỏa thuận \"Làm web thiệp cưới\" (25%)",
                Price = 20000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-02-01T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002")  // lamlam
            }
        );
        #endregion
    }
}
