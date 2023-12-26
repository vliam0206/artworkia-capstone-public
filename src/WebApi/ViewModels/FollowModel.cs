using Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class FollowModel
{
    [Required]
    public Guid AccountId { get; set; }
    [Required]
    public Guid FollowerId { get; set; }
}

public class FollowVM
{
    public AccountVM Account { get; set; } = default!;
    public AccountVM Follower { get; set; } = default!;
}
