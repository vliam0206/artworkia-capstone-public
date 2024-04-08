using Domain.Enums;

namespace Application.Models;

public class TransactionHistoryVM
{
    public Guid Id { get; set; }
    public bool IsPositive { get; set; } = false;
    public AccountBasicInfoVM FromAccount { get; set; } = default!;
    public AccountBasicInfoVM ToAccount { get; set; } = default!;
    public Guid? AssetId { get; set; }
    public Guid? ProposalId { get; set; }
    public string Detail { get; set; } = default!;
    public double Price { get; set; }
    public string TransactionStatus { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
}

public class TransactionModel
{
    public Guid? ToAccountId { get; set; }
    public Guid? AssetId { get; set; }
    public Guid? ProposalId { get; set; }
    public string Detail { get; set; } = default!;
    public double Price { get; set; }
    public TransactionStatusEnum TransactionStatus { get; set; }
}
