using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
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

    public async Task<TransactionHistoryVM> CreateTransactionHistory(TransactionModel model)
    {
        if (model.AssetId == null && model.ProposalId == null)
        {
            throw new ArgumentNullException("AssetId and proposalId can not be null at the same time.");
        }
        if (model.AssetId != null)
        {
            var assetExist = await _unitOfWork.AssetRepository.IsExistedAsync(model.AssetId.Value);
            if (!assetExist)
            {
                throw new ArgumentException("AssetId not found!");
            }
        }
        if (model.ProposalId != null)
        {
            var proposalExist = await _unitOfWork.ProposalRepository.IsExistedAsync(model.ProposalId.Value);
            if (!proposalExist)
            {
                throw new ArgumentException("ProposalId not found!");
            }
        }
        var transaction = _mapper.Map<TransactionHistory>(model);
        await _unitOfWork.TransactionHistoryRepository.AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TransactionHistoryVM>(transaction);
    }

    public async Task<List<TransactionHistoryVM>> GetTransactionHistoriesOfAccount(Guid accountId)
    {
        var result = (await _unitOfWork.TransactionHistoryRepository
                                .GetListByConditionAsync(x => x.CreatedBy == accountId))
                                .OrderByDescending(x => x.CreatedOn);
        return _mapper.Map<List<TransactionHistoryVM>>(result);
    }
}
