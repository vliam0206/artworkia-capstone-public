using Domain.Entitites;
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
        builder.HasOne(x => x.Account).WithMany(a => a.TransactionHistories).HasForeignKey(x => x.AccountId);
        builder.HasOne(x => x.Asset).WithMany(a => a.TransactionHistories).HasForeignKey(x => x.AssetId);
        builder.HasOne(x => x.Proposal).WithMany(p => p.TransactionHistories).HasForeignKey(x => x.ProposalId);
    }
}
