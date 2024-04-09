using Domain.Entitites;
using Domain.Enums;
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

        #region data
        builder.HasData(
            new ProposalAsset()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),    
                ProposalId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Type = ProposalAssetEnum.Concept,
                ProposalAssetName = "concept1_3435438593.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                ContentType = "zip",
                Size = 13094430,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-5"),
            },
            new ProposalAsset()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ProposalId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Type = ProposalAssetEnum.Concept,
                ProposalAssetName = "concept1_3435433593.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                ContentType = "zip",
                Size = 12094430,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-10"),
            },
            new ProposalAsset()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                ProposalId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Type = ProposalAssetEnum.Final,
                ProposalAssetName = "concept1_3435733593.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                ContentType = "zip",
                Size = 16094430,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-25"),
            },
            new ProposalAsset()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                ProposalId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Type = ProposalAssetEnum.Revision,
                ProposalAssetName = "concept1_3433433593.zip",
                Location = "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip",
                ContentType = "zip",
                Size = 16084430,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-30"),
            }
        );
        #endregion
    }
}
