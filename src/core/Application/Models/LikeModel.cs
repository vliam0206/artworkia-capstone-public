using Application.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;
public class LikeModel
{
    [Required]
    public Guid ArtworkId { get; set; }
}
public class LikeVM
{
    public AccountVM Account { get; set; } = default!;
    public ArtworkVM Artwork { get; set; } = default!;
}
