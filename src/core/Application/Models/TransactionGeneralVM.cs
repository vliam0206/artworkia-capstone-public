﻿namespace Application.Models;

public class TransactionGeneralVM
{
    public TransactionHistoryForUserVM? TransactionHistory {  get; set; }
    public WalletHistoryVM? WalletHistory {  get; set; }
    public DateTime CreatedOn { get; set; }
}
