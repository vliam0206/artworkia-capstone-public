using Application.Models;

namespace Application.Services.Abstractions;

public interface ITransactionHistoryService
{
    Task<List<TransactionHistoryVM>> GetTransactionHistoriesOfAccount(Guid accountId);
    Task<TransactionHistoryVM> CreateTransactionHistory(TransactionModel model);
}
