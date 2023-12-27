using Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class ImageModel
{
    public Guid ArtworkId { get; set; }
    public IFormFile Image { get; set; } = default!; // image upload
    public bool IsCover { get; set; }
}
