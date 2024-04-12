using Domain.Models;
using Application.Models;
using Application.Commons;

namespace Application.Services.Abstractions;

public interface IDashBoardService
{
    Task<PagedList<WalletHistoryVM>> GetAllWalletHistoriesAsync(int pageNumber, int pgaeSize);
    Task<PagedList<TransactionHistoryVM>> GetAllTransactionHistoriesAsync(int pageNumber, int pgaeSize);
    Task<List<NoTransByDate>> GetAssetTransactionStatistic(DateTime startTime, DateTime? endTime = null);
}
