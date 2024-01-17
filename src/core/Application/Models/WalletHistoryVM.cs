namespace Application.Models;

public class WalletHistoryVM
{
    public Guid Id { get; set; }
    public Guid WalletId { get; set; }
    public Guid AccountId { get; set; }
    public double Amount { get; set; }
    public string Type { get; set; } = default!;
    public string PaymentMethod { get; set; } = default!;
    public string TransactionStatus { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
}
