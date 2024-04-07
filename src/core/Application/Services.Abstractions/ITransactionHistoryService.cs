using Application.Commons;
using Application.Models;
using Domain.Entities.Commons;
using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface ITransactionHistoryService
{
    Task<List<TransactionHistoryVM>> GetTransactionHistoriesOfAccount(Guid accountId);
    Task<TransactionHistoryVM> CreateTransactionHistory(TransactionModel model);
}
