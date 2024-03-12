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

        #region relationships
        // relationships
        builder.HasOne(x => x.Account).WithMany(a => a.Followings).HasForeignKey(x => x.AccountId);
        builder.HasOne(x => x.Follower).WithMany(a => a.Followers)
            .HasForeignKey(x => x.FollowerId)
            .OnDelete(DeleteBehavior.NoAction);
        #endregion

        #region init data
        builder.HasData(
            new Follow
            {
                AccountId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // hoanganh
                FollowerId = Guid.Parse("00000000-0000-0000-0000-000000000002")  // lamlam
            },
            new Follow
            {
                AccountId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // hoanganh
                FollowerId = Guid.Parse("00000000-0000-0000-0000-000000000005")  // phuhuynh
            }
        );
        #endregion
    }
}
