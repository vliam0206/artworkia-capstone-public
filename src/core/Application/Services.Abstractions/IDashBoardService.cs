using Domain.Models;
using Application.Models;
using Application.Commons;

namespace Application.Services.Abstractions;

public interface IDashBoardService
{
    Task<PagedList<WalletHistoryVM>> GetAllWalletHistoriesAsync(int pageNumber, int pgaeSize);
    Task<PagedList<TransactionHistoryVM>> GetAllTransactionHistoriesAsync(int pageNumber, int pgaeSize);
    Task<List<NoAssetTransByDate>> GetAssetTransactionStatisticAsync(DateTime? startTime = null, DateTime? endTime = null);
    Task<List<PercentageCategoryOfAssetTrans>> GetPercentageCategoryOfAssetTransStatisticAsync(
        DateTime? startTime = null, DateTime? endTime = null);
    Task<List<TopCreatorOfAssetTransVM>> GetTopCreatorOfAssetTransStatisticAsync(int topNumber = 10, DateTime? startTime = null, DateTime? endTime = null);
}
