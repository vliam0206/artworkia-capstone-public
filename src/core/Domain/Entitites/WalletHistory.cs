using Domain.Entities.Commons;
using Domain.Enums;

namespace Domain.Entitites;

public class WalletHistory : BaseEntity, ICreation
{
    //public Guid WalletId { get; set; }
    public double Amount { get; set; }
    public WalletHistoryTypeEnum Type { get; set; }
    public PaymentMethodEnum PaymentMethod { get; set; } = PaymentMethodEnum.ZaloPay;
    public TransactionStatusEnum TransactionStatus { get; set; } = TransactionStatusEnum.InProgress;
    public Guid? CreatedBy {get; set;}
    public DateTime CreatedOn { get; set; }
    public string AppTransId { get; set; } = default!;

    //public virtual Wallet Wallet { get; set; } = default!;
    public virtual Account Account { get; set; } = default!;
}
