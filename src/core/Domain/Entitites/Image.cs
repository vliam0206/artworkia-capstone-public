using Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;
public class Image : BaseEntity, IModification, ISoftDelete
{
    public Guid ArtworkId { get; set; }
    [MaxLength(150)]
    public string ImageName { get; set; } = default!;
    public string Location { get; set; } = default!; // url address
    public bool IsCover { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    public virtual Artwork Artwork { get; set; } = default!;
}
