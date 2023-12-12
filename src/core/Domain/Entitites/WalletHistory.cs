using Domain.Entities.Commons;
using Domain.Enums;

namespace Domain.Entitites;

public class WalletHistory : BaseEntity, ICreation
{
    public Guid WalletId { get; set; }
    public double Amount { get; set; }
    public WalletHistoryTypeEnum Type { get; set; }
    public PaymentMethodEnum PaymentMethod { get; set; }
    public TransactionStatusEnum TransactionStatus { get; set; }
    public Guid? CreatedBy {get; set;}
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();    

    public virtual Wallet Wallet { get; set; } = default!;
}
