using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class AssetTransactionService : IAssetTransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public AssetTransactionService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<AssetTransactionVM> CreateAssetTransactionAsync(AssetTransactionModel assetTransactionModel)
    {
        // Check if user already has this asset
        var assetTransaction = await _unitOfWork.TransactionHistoryRepository
            .GetSingleByConditionAsync(x => x.CreatedBy == _claimService.GetCurrentUserId
            && x.AssetId == assetTransactionModel.AssetId);
        if (assetTransaction is not null)
            throw new Exception("You already have this asset in your library");

        // Check if asset is not found or deleted
        var asset = await _unitOfWork.AssetRepository.GetByIdAsync(assetTransactionModel.AssetId);
        if (asset is null)
            throw new NullReferenceException("Asset not found");
        if (asset.DeletedOn != null)
            throw new Exception("Asset is deleted");

        // Check if user has enough money to buy this asset
        Guid accountId = _claimService.GetCurrentUserId ?? default;
        Wallet? wallet = await _unitOfWork.WalletRepository.GetSingleByConditionAsync(x => x.AccountId == accountId);
        if (wallet is null)
        {
            throw new NullReferenceException("Wallet not found");
        }
        if (wallet.Balance < asset.Price)
            throw new Exception("You don't have enough money to buy this asset");

        wallet.Balance -= asset.Price;
        TransactionHistory newAssetTransaction = new TransactionHistory()
        {
            CreatedBy = accountId,
            AssetId = assetTransactionModel.AssetId,
            Detail = $"Bought {asset.AssetTitle} for {asset.Price} coins successfully",
            Price = asset.Price,
            TransactionStatus = TransactionStatusEnum.Success,
        };

        await _unitOfWork.TransactionHistoryRepository.AddAsync(newAssetTransaction);
        _unitOfWork.WalletRepository.Update(wallet);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<AssetTransactionVM>(newAssetTransaction);
        return result;
    }

    public async Task<IEnumerable<AssetTransactionVM>> GetAllAssetTransactionsAsync()
    {
        var allAssetTransactions = await _unitOfWork.TransactionHistoryRepository.GetListByConditionAsync(x => x.AssetId != null); 
        var result = _mapper.Map<IEnumerable<AssetTransactionVM>>(allAssetTransactions);
        return result;
    }

    public Task<IEnumerable<AssetTransactionVM>> GetAllAssetTransactionsByAccountIdAsync(Guid accountId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AssetTransactionVM>> GetAllAssetTransactionsByAssetIdAsync(Guid assetId)
    {
        throw new NotImplementedException();
    }

    public async Task<AssetTransactionVM> GetAssetTransactionByIdAsync(Guid assetTransactionId)
    {
        var assetTransaction = await _unitOfWork.TransactionHistoryRepository.GetByIdAsync(assetTransactionId);
        if (assetTransaction is null)
            throw new NullReferenceException("Asset transaction not found");
        var result = _mapper.Map<AssetTransactionVM>(assetTransaction);
        return result;
    }
}
