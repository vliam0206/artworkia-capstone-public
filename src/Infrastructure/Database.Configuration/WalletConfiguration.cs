using Domain.Entitites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.ToTable(nameof(Wallet));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");

        // relationship
        builder.HasOne(x => x.Account).WithOne(a => a.Wallet).HasForeignKey<Wallet>(x => x.AccountId);

        #region init data
        builder.HasData(
            new Wallet // wallet of user
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                AccountId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0902287461",
                Balance = 2000000
            },
            new Wallet // wallet of lamlam
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                AccountId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0939959417",
                Balance = 1000000
            },
            new Wallet // wallet of hoanganh
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                AccountId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0902287462",
                Balance = 1000000
            },
            new Wallet // wallet of thong
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                AccountId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0902287463",
                Balance = 1000000
            },
            new Wallet // wallet of phuhuynh
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                AccountId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0398550944",
                Balance = 1000000
            }
        );
        #endregion

    }
}
