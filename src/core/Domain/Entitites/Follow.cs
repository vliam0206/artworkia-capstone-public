namespace Domain.Entitites;

public class Follow
{
    public Guid AccountId { get; set; }
    public Guid FollowerId { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual Account Follower { get; set; } = default!;
}
