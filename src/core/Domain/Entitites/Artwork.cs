using Domain.Entities.Commons;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Artwork : BaseEntity, ICreation, IModification, ISoftDelete
{
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string Description { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual ICollection<CategoryArtworkDetail> CategoryArtworkDetails { get; set; } = new List<CategoryArtworkDetail>();
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    public virtual ICollection<TagDetail> TagDetails { get; set; } = new List<TagDetail>();
}
