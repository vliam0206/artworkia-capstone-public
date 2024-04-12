using Application.Commons;
using Application.Models;
using Domain.Entities.Commons;

namespace Application.Services.Abstractions;

public interface IDashBoardService
{
    Task<PagedList<WalletHistoryVM>> GetAllWalletHistoriesAsync(int pageNumber, int pgaeSize);
    Task<PagedList<TransactionHistoryVM>> GetAllTransactionHistoriesAsync(int pageNumber, int pgaeSize);
}
