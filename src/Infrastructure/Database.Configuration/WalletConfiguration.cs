using Domain.Entitites;
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
        builder.HasMany(x => x.WalletHistories).WithOne(h => h.Wallet).HasForeignKey(h => h.WalletId);
    }
}
