using Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Review : BaseEntity, ICreation
{
    public double Vote { get; set; }
    [MaxLength(255)]
    public string Detail { get; set; } = string.Empty;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid ProposalId { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual Proposal Proposal { get; set; } = default!;

}
