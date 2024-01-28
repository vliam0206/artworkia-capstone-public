using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class WalletHistoryService : IWalletHistoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WalletHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddWalletHistory(WalletHistory walletHistory)
    {
        await _unitOfWork.WalletHistoryRepository.AddAsync(walletHistory);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<WalletHistoryVM>> GetWalletHistoriesOfAccount(Guid accountId)
    {
        var result = await _unitOfWork.WalletHistoryRepository
                                .GetListByConditionAsync(x => x.CreatedBy == accountId);
        return _mapper.Map<List<WalletHistoryVM>>(result);
    }
}
