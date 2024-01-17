using Domain.Entitites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class WalletHistoryConfiguration : IEntityTypeConfiguration<WalletHistory>
{
    public void Configure(EntityTypeBuilder<WalletHistory> builder)
    {
        builder.ToTable(nameof(WalletHistory));
        
        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Wallet).WithMany(w => w.WalletHistories).HasForeignKey(x => x.WalletId);

        #region init data
        builder.HasData
        (
            // lamlam histories
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0290"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c1"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,                
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-07T08:30:03.678Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0291"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c1"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-10T14:20:10.234Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0292"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c1"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 2000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-13T19:59:59.000Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0293"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c1"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 300,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-12-10T05:40:28.901Z"),
            },

            // hoanganh histories
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0294"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c2"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"), // hoanganh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-16T02:37:42.345Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0295"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c2"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"), // hoanganh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-28T18:30:15.567Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0296"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c2"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"), // hoanganh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1700,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-30T23:59:59.999Z"),
            },

            // thong histories
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0297"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c3"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"), // thong
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-19T05:40:28.901Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0298"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c3"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"), // thong
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-28T18:30:15.567Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf0299"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c3"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"), // thong
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1700,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-12-10T05:40:28.901Z"),
            },

            // phuhuynh histories
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf029a"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c4"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"), // phuhuynh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-22T05:37:42.345Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf029b"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c4"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"), // phuhuynh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-15T03:45:20.123Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf029c"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c4"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"), // phuhuynh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1700,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-12-05T02:37:42.345Z"),
            },

            // user histories
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf029d"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c0"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-cc1d-08dc1445b3e0"), //user
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 3000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-03T10:45:20.123Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf029e"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c0"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-cc1d-08dc1445b3e0"), //user
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-17T02:59:59.000Z"),
            },
            new WalletHistory
            {
                Id = Guid.Parse("7b7d2223-c1fe-4a45-ad69-8e893ebf029f"),
                WalletId = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c0"),
                CreatedBy = Guid.Parse("7d580000-c214-88a4-cc1d-08dc1445b3e0"), //user
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-05T18:20:45.890Z"),
            }
        );
        #endregion

    }
}
