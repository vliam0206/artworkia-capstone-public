using Domain.Entitites;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class AssetModel
{
    public Guid ArtworkId { get; set; }
    [MaxLength(150)]
    public string AssetName { get; set; } = default!;
    public IFormFile File { get; set; } = default!; // file upload
    public double Price { get; set; } = 0;
}
