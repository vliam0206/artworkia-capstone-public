using Domain.Entitites;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;

// View model for view details of an artwork
public class ArtworkVM
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string Description { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public virtual Account Account { get; set; } = default!;
    public virtual ICollection<CategoryArtworkDetail> CategoryArtworkDetails { get; set; } = new List<CategoryArtworkDetail>();
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();

}

// View model for search results
public class ArtworkSearchVM
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string Description { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; } = default!;
    public DateTime CreatedOn { get; set; } 
    public DateTime? LastModificatedOn { get; set; }

    // You can include additional fields if needed for search purposes

    public virtual ICollection<CategoryArtworkDetail> CategoryArtworkDetails { get; set; } = new List<CategoryArtworkDetail>();
    // Omitting other navigation properties for simplicity
}

public class ArtworkModel
{
    [MaxLength(150)]
    [Required]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string? Description { get; set; }
    [Required]
    public PrivacyEnum Privacy { get; set; } = default!;
    [Required]
    public IFormFile Thumbnail { get; set; } = default!;
    [Required]
    public List<IFormFile> ImageFiles { get; set; } = default!;
    public List<SingleAssetModel>? AssetFiles { get; set; }
    [Required]
    public List<string> Tags { get; set; } = default!;
}

