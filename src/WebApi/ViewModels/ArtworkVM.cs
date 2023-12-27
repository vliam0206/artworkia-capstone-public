using Domain.Entitites;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class ArtworkVM
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string Description { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
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
