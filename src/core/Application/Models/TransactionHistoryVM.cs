namespace Application.Models;

public class TransactionHistoryVM
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid? AssetId { get; set; }
    public Guid? ProposalId { get; set; }   
    public string Detail { get; set; } = default!;
    public double Price { get; set; }
    public string TransactionStatus { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
}
