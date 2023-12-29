using Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Asset : BaseEntity, IModification, ISoftDelete
{    
    public Guid ArtworkId { get; set; }
    [MaxLength(150)]
    public string AssetName { get; set; } = default!;
    public string Location { get; set; } = default!; // url address
    public double Price { get; set; } = 0;
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }

    public virtual Artwork Artwork { get; set; } = default!;
    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
}
