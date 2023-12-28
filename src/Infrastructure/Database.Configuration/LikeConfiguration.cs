using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;
public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable(nameof(Like));

        //composite key
        builder.HasKey(x => new { x.AccountId, x.ArtworkId });

        //relationship
        builder.HasOne(x => x.Account).WithMany(a => a.Likes).HasForeignKey(x => x.AccountId);
        builder.HasOne(x => x.Artwork).WithMany(a => a.Likes).HasForeignKey(x => x.ArtworkId);

    }
}
