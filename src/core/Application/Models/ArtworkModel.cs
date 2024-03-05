using Domain.Entitites;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class ArtworkEM
{
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(5000)]
    public string? Description { get; set; } 
    public PrivacyEnum Privacy { get; set; } = default!;
    public IFormFile? Thumbnail { get; set; }
    public List<IFormFile>? ImageFiles { get; set; }
    public List<string>? Tags { get; set; }
    public List<Guid>? Categories { get; set; } 
}

public class ArtworkModel
{
    [MaxLength(150)]
    [Required]
    public string Title { get; set; } = default!;
    [MaxLength(5000)]
    public string? Description { get; set; }
    [Required]
    public IFormFile Thumbnail { get; set; } = default!;
    [Required]
    public PrivacyEnum Privacy { get; set; } = default!;
    [Required]
    public List<IFormFile> ImageFiles { get; set; } = default!;
    public List<SingleAssetModel>? AssetFiles { get; set; }
    [Required]
    public List<string> Tags { get; set; } = default!;
    public List<Guid> Categories { get; set; } = default!;
}

public class ArtworkDisplayModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public PrivacyEnum Privacy { get; set; } = default!;
    public string Thumbnail { get; set; } = default!;
    public AccountDisplayModel Author { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModificatedOn { get; set; }
}