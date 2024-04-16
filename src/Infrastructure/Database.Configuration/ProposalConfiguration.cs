using Domain.Entitites;
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
        builder.HasMany(x => x.ProposalAssets).WithOne(a => a.Proposal).HasForeignKey(a => a.ProposalId);
        builder.HasOne(x => x.Review).WithOne(r => r.Proposal).HasForeignKey<Review>(x => x.ProposalId);
        builder.HasMany(x => x.TransactionHistories).WithOne(t => t.Proposal).HasForeignKey(t => t.ProposalId);
        builder.HasMany(x => x.Milestones).WithOne(m => m.Proposal).HasForeignKey(m => m.ProposalId);
        builder.HasOne(x => x.MessageObj).WithOne(m => m.Proposal).HasForeignKey<Message>(m => m.ProposalId);

        #region data
        builder.HasData(
            new Proposal()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),                
                ServiceId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ProjectTitle = "Yêu cầu làm website mua bán thiệp đám cưới.",
                Category = "Website",
                Description = @"Yêu cầu làm website mua bán thiệp đám cưới. 
                                Giao diện trực quan, dễ sử dụng. 
                                Tìm kiếm và bộ lọc sản phẩm.
                                Hệ thống thanh toán an toàn.",
                TargetDelivery = DateTime.Parse("2024-01-30"),
                ActualDelivery = DateTime.Parse("2024-02-01"),
                NumberOfConcept = 2,
                NumberOfRevision = 3,
                InitialPrice = 0.25,
                Total = 80000,
                ProposalStatus = ProposalStateEnum.CompletePayment,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-31"),
                OrdererId = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phuhuynh
            }
            );
        #endregion
    }
}
