using Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Service : BaseEntity, ICreation, IModification, ISoftDelete
{
    [MaxLength(255)]
    public string ServiceName { get; set; } = default!;
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    [MaxLength(255)]
    public string DeliveryTime { get; set; } = default!;
    [MaxLength(255)]
    public string NumberOfConcept { get; set; } = default!;
    [MaxLength(255)]
    public string NumberOfRevision { get; set; } = default!;
    public double StartingPrice { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    public virtual ICollection<CategoryServiceDetail> CategoryServiceDetails { get; set; } = new List<CategoryServiceDetail>();
}
