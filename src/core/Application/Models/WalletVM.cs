using Domain.Enums;

namespace Application.Models;

public class WalletVM
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public double Balance { get; set; } = 0;
    public WithdrawMethodEnum WithdrawMethod { get; set; }
    public string WithdrawInformation { get; set; } = default!;
}
