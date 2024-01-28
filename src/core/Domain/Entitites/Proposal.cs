using Domain.Entities.Commons;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Proposal : BaseEntity, ICreation
{
    public Guid ChatBoxId { get; set; }
    public Guid ServiceId { get; set; }
    [MaxLength(150)]
    public string ProjectTitle { get; set; } = default!;
    [MaxLength(255)]
    public string Category { get; set; } = default!;
    [MaxLength(1000)]
    public string Description { get; set; } = default!;
    public DateTime Deadline { get; set; }
    public double InitialPrice { get; set; }
    public double Total { get; set; }
    public StateEnum ProposalStatus { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }  

    public virtual Account Account { get; set; } = default!;
    public virtual Service Service { get; set; } = default!;
    public virtual ChatBox ChatBox { get; set; } = default!;
    public virtual ICollection<ProposalAsset> ProposalAssets { get; set; } = new List<ProposalAsset>();
    public virtual Review? Review { get; set; }
    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
