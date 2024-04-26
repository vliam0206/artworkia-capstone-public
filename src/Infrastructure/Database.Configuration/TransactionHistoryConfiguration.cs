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
        #region asset
            // transaction 1 thong -> phu
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000030"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000004"), // thong
                Detail = "Mở khóa tài nguyên \"Ảnh cánh cụt\"",
                Price = -12000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-02T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phu
                WalletBalance = 88000
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000030"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000005"), // phu
                Detail = "Mở khóa tài nguyên \"Ảnh cánh cụt\"",
                Price = 11400,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-02T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000004"), //thong
                WalletBalance = 81400,
                Fee = 600
            },
            // transaction 2 thong -> lamlam
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000004"), // thong
                Detail = "Mở khóa tài nguyên \"Dấu vết của quá khứ\"",
                Price = -10000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-05T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002"),  //lamlam
                WalletBalance = 40000
            },            
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000002"), // lamlam
                Detail = "Mở khóa tài nguyên \"Dấu vết của quá khứ\"",
                Price = 9500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-05T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000004"),  //thong
                WalletBalance = 119500,
                Fee = 500
            },
            // transaction 3 lamlam -> thong
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000010"), 
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000002"), // lamlam
                Detail = "Mở khóa tài nguyên \"File PTS tuyển tập minh hoạ sách tâm lý\"",
                Price = -20000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-15T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // thong
                WalletBalance = 99500
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000010"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000004"), // thong
                Detail = "Mở khóa tài nguyên \"File PTS tuyển tập minh hoạ sách tâm lý\"",
                Price = 19000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-15T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // lamlam
                WalletBalance = 59000,
                Fee = 1000
            },
            // transaction 4 thong -> melodysheep
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000050"), 
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000004"), // thong
                Detail = "Mở khóa tài nguyên \"Không gian vũ trụ\"",
                Price = -50000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-16T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-00000000000b"), //melodysheep
                WalletBalance = 9000
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000050"),
                CreatedBy = new Guid("00000000-0000-0000-0000-00000000000b"), // melodysheep
                Detail = "Mở khóa tài nguyên \"Không gian vũ trụ\"",
                Price = 47500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-16T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000004"), //thong
                WalletBalance = 47500,
                Fee = 2500
            },
            // transaction 5 lamlam -> phu
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000030"), 
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000002"), // lamlam
                Detail = "Mở khóa tài nguyên \"Ảnh cánh cụt\"",
                Price = -12000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-14T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phu
                WalletBalance = 87500
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                AssetId = new Guid("00000000-0000-0000-0000-000000000030"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000005"), // phu
                Detail = "Mở khóa tài nguyên \"Ảnh cánh cụt\"",
                Price = 11400,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-14T15:30:03.678Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                WalletBalance = 92800,
                Fee = 600
            },
        #endregion


        #region proposal
            // init transaction
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000101"),
                ProposalId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000005"), // phuhuynh
                Detail = "Đặt cọc thỏa thuận \"Làm web thiệp cưới\" (25%)",
                Price = -20000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-03T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002"),  // lamlam
                WalletBalance = 72800
            },
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000102"),
                ProposalId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000002"), // lamlam
                Detail = "Đặt cọc thỏa thuận \"Làm web thiệp cưới\" (25%)",
                Price = 19000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-01-03T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000005"),  // phuhuynh
                WalletBalance = 106500,
                Fee = 1000
            },
            // complete transaction
            new TransactionHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000103"),
                ProposalId = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedBy = new Guid("00000000-0000-0000-0000-000000000005"), // phuhuynh
                Detail = "Hoàn tất thanh toán thỏa thuận \"Làm web thiệp cưới\" (75%)",
                Price = -60000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2024-02-01T02:59:59.000Z"),
                ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000002"),  // lamlam
                WalletBalance = 12800
            },
             new TransactionHistory
             {
                 Id = Guid.Parse("00000000-0000-0000-0000-000000000104"),
                 ProposalId = new Guid("00000000-0000-0000-0000-000000000001"),
                 CreatedBy = new Guid("00000000-0000-0000-0000-000000000002"), // lamlam
                 Detail = "Hoàn tất thanh toán thỏa thuận \"Làm web thiệp cưới\" (75%)",
                 Price = 57000,
                 TransactionStatus = TransactionStatusEnum.Success,
                 CreatedOn = DateTime.Parse("2024-02-01T02:59:59.000Z"),
                 ToAccountId = Guid.Parse("00000000-0000-0000-0000-000000000005"),  // phuhuynh
                 WalletBalance = 163500,
                 Fee = 3000
             }
             #endregion
        );
        #endregion
    }
}
