using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder.ToTable(nameof(Follow));
        builder.HasKey(x => new { x.AccountId, x.FollowerId });

        // relationships
        builder.HasOne(x => x.Account).WithMany(a => a.Followings).HasForeignKey(x => x.AccountId);
        builder.HasOne(x => x.Follower).WithMany(a => a.Followers)
            .HasForeignKey(x => x.FollowerId)
            .OnDelete(DeleteBehavior.NoAction); 
    }
}
