using System.ComponentModel.DataAnnotations;
using Application.Models;

namespace WebApi.ViewModels;
public class BlockModel
{
    [Required]
    public Guid BlockingId { get; set; }
    [Required]
    public Guid BlockedId { get; set; }
}

public class BlockVM
{
    public AccountVM Blocking { get; set; } = default!;
    public AccountVM Blocked { get; set; } = default!;
}