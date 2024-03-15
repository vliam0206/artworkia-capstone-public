﻿using Domain.Entitites;
using Domain.Enums;
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
        builder.HasMany(x => x.Milestones).WithOne(m => m.Proposal).HasForeignKey(m => m.ProposalId);

        #region data
        builder.HasData(
            new Proposal()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ChatBoxId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ServiceId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ProjectTitle = "yeu cau lam website ecommerce",
                Category = "Website",
                Description = "yeu cau lam website ecommerce",
                TargetDelivery = DateTime.Parse("2024-2-2"),
                NumberOfConcept = 2,
                NumberOfRevision = 3,
                InitialPrice = 20000,
                Total = 69000,
                ProposalStatus = ProposalStateEnum.CompletePayment,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-2"),
                OrdererId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            }
            );
        #endregion
    }
}
