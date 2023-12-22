namespace WebApi.ViewModels;

public class FollowVM
{
    public AccountVM Account { get; set; } = default!;
    public AccountVM Follower { get; set; } = default!;
}
