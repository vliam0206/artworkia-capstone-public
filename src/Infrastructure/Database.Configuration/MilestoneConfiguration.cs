using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
{
    public void Configure(EntityTypeBuilder<Milestone> builder)
    {
        builder.ToTable(nameof(Milestone));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Proposal).WithMany(p => p.Milestones).HasForeignKey(x => x.ProposalId);
        builder.HasOne(x => x.CreatedAccount).WithMany(p => p.Milestones).HasForeignKey(x => x.CreatedBy);
    }
}
