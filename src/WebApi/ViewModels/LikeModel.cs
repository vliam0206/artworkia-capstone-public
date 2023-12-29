using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class LikeModel
{
    [Required]
    public Guid AccountId { get; set; }
    [Required]
    public Guid ArtworkId { get; set; }
}
public class LikeVM
{
    public AccountVM Account { get; set; } = default!;
    public ArtworkVM Artwork { get; set; } = default!;
}
