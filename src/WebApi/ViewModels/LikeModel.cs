using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class LikeModel
{
    [Required]
    public Guid AccountId { get; set; }
    [Required]
    public Guid ArtworkId { get; set; }
}
