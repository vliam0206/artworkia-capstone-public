using Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.LastModificatedOn).HasDefaultValueSql("getutcdate()");

        builder.HasIndex(x => x.Username).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();

        // relationship
        builder.HasOne(x => x.Wallet).WithOne(w => w.Account).HasForeignKey<Wallet>(x => x.AccountId);
        builder.HasMany(x => x.ChatBoxes_1).WithOne(c => c.Account_1).HasForeignKey(c => c.AccountId_1);
        builder.HasMany(x => x.ChatBoxes_2).WithOne(c => c.Account_2).HasForeignKey(c => c.AccountId_2);
        builder.HasMany(x => x.Messages).WithOne(m => m.Account).HasForeignKey(m => m.CreatedBy);
        builder.HasMany(x => x.Proposals).WithOne(p => p.Account).HasForeignKey(p => p.CreatedBy);
        builder.HasMany(x => x.Reviews).WithOne(r => r.Account).HasForeignKey(r => r.CreatedBy);
        builder.HasMany(x => x.Services).WithOne(s => s.Account).HasForeignKey(s => s.CreatedBy);
        builder.HasMany(x => x.Requests).WithOne(r => r.Account).HasForeignKey(r => r.CreatedBy);
        builder.HasMany(x => x.UserTokens).WithOne(t => t.User).HasForeignKey(t => t.UserId);
        builder.HasMany(x => x.Artworks).WithOne(a => a.Account).HasForeignKey(a => a.CreatedBy);
        builder.HasMany(x => x.Notifications).WithOne(n => n.Account).HasForeignKey(n => n.SentToAccount);
        builder.HasMany(x => x.TransactionHistories).WithOne(t => t.Account).HasForeignKey(t => t.AccountId);
        builder.HasMany(x => x.Likes).WithOne(l => l.Account).HasForeignKey(l => l.AccountId);
        builder.HasMany(x => x.Comments).WithOne(c => c.Account).HasForeignKey(c => c.CreatedBy);
    }
}
