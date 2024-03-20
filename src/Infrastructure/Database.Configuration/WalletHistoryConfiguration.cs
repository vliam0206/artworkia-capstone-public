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
        builder.HasIndex(x => x.AppTransId).IsUnique();

        // relationship
        builder.HasOne(x => x.Account).WithMany(w => w.WalletHistories).HasForeignKey(x => x.CreatedBy);

        #region init data
        builder.HasData
        (
            // lamlam histories
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,                
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-07T08:30:03.678Z"),
                AppTransId = "240128_7635981"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-10T14:20:10.234Z"),
                AppTransId = "180623_2054176"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 2000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-13T19:59:59.000Z"),
                AppTransId = "210430_6849203"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // lamlam
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 300,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-12-10T05:40:28.901Z"),
                AppTransId = "190815_3095728"
            },

            // hoanganh histories
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // hoanganh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-16T02:37:42.345Z"),
                AppTransId = "220506_1478963"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // hoanganh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-28T18:30:15.567Z"),
                AppTransId = "231112_8023456"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // hoanganh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1700,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-30T23:59:59.999Z"),
                AppTransId = "200925_6193840"
            },

            // thong histories
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), // thong
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-19T05:40:28.901Z"),
                AppTransId = "171212_4357692"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), // thong
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-28T18:30:15.567Z"),
                AppTransId = "160509_9270134"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), // thong
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1700,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-12-10T05:40:28.901Z"),
                AppTransId = "250321_4685027"
            },

            // phuhuynh histories
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // phuhuynh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 200,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-22T05:37:42.345Z"),
                AppTransId = "231205_7890123"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // phuhuynh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 2500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-15T03:45:20.123Z"),
                AppTransId = "200703_4567890"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // phuhuynh
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1700,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-12-05T02:37:42.345Z"),
                AppTransId = "180924_1234567"
            },

            // user histories
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001"), //user
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 3000,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-03T10:45:20.123Z"),
                AppTransId = "210817_8901234"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001"), //user
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Withdraw,
                Amount = 1500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-17T02:59:59.000Z"),
                AppTransId = "220129_5678901"
            },
            new WalletHistory
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001"), //user
                PaymentMethod = PaymentMethodEnum.ZaloPay,
                Type = WalletHistoryTypeEnum.Deposit,
                Amount = 500,
                TransactionStatus = TransactionStatusEnum.Success,
                CreatedOn = DateTime.Parse("2023-11-05T18:20:45.890Z"),
                AppTransId = "160827_3456789"
            }
        );
        #endregion

    }
}
