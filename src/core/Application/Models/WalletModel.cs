using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class WalletModel
{
    public double Balance { get; set; } = 0;
    [Required]
    public WithdrawMethodEnum WithdrawMethod { get; set; }
    [Required]
    public string WithdrawInformation { get; set; } = default!;
}

public class WalletEM
{
    // them field nay de nap tien tam thoi, sau nay lam thanh toan se loai bo 
    public double Balance { get; set; } = 10 ^ 9; 
    [Required]
    public WithdrawMethodEnum WithdrawMethod { get; set; }
    [Required]
    public string WithdrawInformation { get; set; } = default!;
}