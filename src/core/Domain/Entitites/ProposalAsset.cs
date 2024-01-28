using Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class ProposalAsset : BaseEntity, ICreation
{
    public Guid ProposalId { get; set; }
    [MaxLength(150)]
    public string Concept { get; set; } = string.Empty;
    public double Version { get; set; } = 1.0;
    public string AssetLocation { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }

    public virtual Proposal Proposal { get; set; } = default!;
}
