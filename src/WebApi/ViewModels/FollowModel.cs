using Application.Models;
using Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class FollowModel
{
    [Required]
    public Guid AccountId { get; set; }
}

public class FollowingVM
{
    public AccountDisplayModel Account { get; set; } = default!;
}

public class FollowerVM
{
    public AccountDisplayModel Follower { get; set; } = default!;
}
