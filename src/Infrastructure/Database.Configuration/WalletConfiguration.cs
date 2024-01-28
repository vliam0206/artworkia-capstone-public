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
                Id = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c0"),
                AccountId = Guid.Parse("7d580000-c214-88a4-cc1d-08dc1445b3e0"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0902287461",
                Balance = 2000
            },
            new Wallet // wallet of lamlam
            {
                Id = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c1"),
                AccountId = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0939959417",
                Balance = 1000
            },
            new Wallet // wallet of hoanganh
            {
                Id = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c2"),
                AccountId = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0902287462",
                Balance = 1000
            },
            new Wallet // wallet of thong
            {
                Id = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c3"),
                AccountId = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0902287463",
                Balance = 1000
            },
            new Wallet // wallet of phuhuynh
            {
                Id = Guid.Parse("73b5f912-28d7-4473-9c8d-56a734d8a1c4"),
                AccountId = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"),
                WithdrawMethod = WithdrawMethodEnum.Zalopay,
                WithdrawInformation = "0902287464",
                Balance = 1000
            }
        );
        #endregion

    }
}
