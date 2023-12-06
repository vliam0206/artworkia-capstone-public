using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class ProposalAssetConfiguration : IEntityTypeConfiguration<ProposalAsset>
{
    public void Configure(EntityTypeBuilder<ProposalAsset> builder)
    {
        builder.ToTable(nameof(ProposalAsset));
        
        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Proposal).WithMany(p => p.ProposalAssets).HasForeignKey(x => x.ProposalId);
    }
}
