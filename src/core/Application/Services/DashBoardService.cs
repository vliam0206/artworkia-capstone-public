using Application.Commons;
using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class DashBoardService : IDashBoardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DashBoardService(IUnitOfWork unitOfWork, IMapper mapper)
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
}
