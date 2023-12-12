using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
{
    public void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.ToTable(nameof(Proposal));
        
        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Account).WithMany(a => a.Proposals).HasForeignKey(x => x.CreatedBy);
        builder.HasOne(x => x.Service).WithMany(s => s.Proposals).HasForeignKey(x => x.ServiceId);
        builder.HasOne(x => x.ChatBox).WithMany(c => c.Proposals).HasForeignKey(x => x.ChatBoxId);
        builder.HasMany(x => x.ProposalAssets).WithOne(a => a.Proposal).HasForeignKey(a => a.ProposalId);
        builder.HasOne(x => x.Review).WithOne(r => r.Proposal).HasForeignKey<Review>(x => x.ProposalId);
        builder.HasMany(x => x.TransactionHistories).WithOne(t => t.Proposal).HasForeignKey(t => t.ProposalId);
    }
}
