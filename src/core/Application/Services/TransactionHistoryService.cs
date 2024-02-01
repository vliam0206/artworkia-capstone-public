using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class TransactionHistoryService : ITransactionHistoryService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public TransactionHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<TransactionHistoryVM>> GetTransactionHistoriesOfAccount(Guid accountId)
    {
        var result = (await _unitOfWork.TransactionHistoryRepository
                                .GetListByConditionAsync(x => x.CreatedBy == accountId))
                                .OrderByDescending(x => x.CreatedOn);
        return _mapper.Map<List<TransactionHistoryVM>>(result);
    }
}
