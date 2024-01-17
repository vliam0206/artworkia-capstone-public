using Domain.Entities.Commons;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class TransactionHistory : BaseEntity, ICreation
{
    public Guid? CreatedBy { get; set; }
    public Guid? AssetId { get; set; }
    public Guid? ProposalId { get; set; }
    [MaxLength(150)]
    public string Detail { get; set; } = default!;
    public double Price { get; set; }
    public TransactionStatusEnum TransactionStatus { get; set; } = TransactionStatusEnum.InProgress;
    public DateTime CreatedOn { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual Asset? Asset { get; set; }
    public virtual Proposal? Proposal { get; set; }    
}
