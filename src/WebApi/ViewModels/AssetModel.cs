using Domain.Entitites;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class AssetModel
{
    [MaxLength(150)]
    public string AssetName { get; set; } = default!;
    public AssetTypeEnum AssetType { get; set; }
    public IFormFile File { get; set; } = default!; // file upload
    public double Price { get; set; } = 0;

    public virtual Artwork Artwork { get; set; } = default!;
}
