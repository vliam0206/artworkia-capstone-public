using Application.Services.Abstractions;
using AutoMapper;
using Domain.Models;
using Domain.Repositories.Abstractions;
using Application.Models;
using Application.Commons;
namespace Application.Services;

public class DashBoardService : IDashBoardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DashBoardService(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<TransactionHistoryVM>> GetAllTransactionHistoriesAsync(int pageNumber, int pgaeSize)
    {
        var result = await _unitOfWork.TransactionHistoryRepository
            .GetAllTransacrionHistoriesPaginationAsync(pageNumber, pgaeSize);
        return _mapper.Map<PagedList<TransactionHistoryVM>>(result);

    }

    public async Task<PagedList<WalletHistoryVM>> GetAllWalletHistoriesAsync(int pageNumber, int pgaeSize)
    {
        var result = await _unitOfWork.WalletHistoryRepository
            .GetAllWalletHistoriesPaginationAsync(pageNumber, pgaeSize);
        return _mapper.Map<PagedList<WalletHistoryVM>>(result);
    }

    public async Task<List<NoTransByDate>> GetAssetTransactionStatistic(DateTime startTime, DateTime? endTime = null)
    {
        if (endTime == null)
        {
            endTime = DateTime.UtcNow;
        }
        var result = await _unitOfWork.TransactionHistoryRepository.GetAssetTransactionStatistic(startTime, endTime.Value);
        return result;

    }
}
