using Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class ImageModel
{
    public Guid ArtworkId { get; set; }
    [MaxLength(150)]
    public string ImageName { get; set; } = default!;
    public string Location { get; set; } = default!; // url address
    public bool IsCover { get; set; }

    public virtual Artwork Artwork { get; set; } = default!;
}
