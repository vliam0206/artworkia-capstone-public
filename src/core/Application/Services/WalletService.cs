using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class WalletService : IWalletService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public WalletService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<WalletVM> AddWalletAsync(WalletModel walletModel)
    {
        Guid? accountId = _claimService.GetCurrentUserId;
        if (accountId is null)
        {
            throw new NullReferenceException("Account is not exist");
        }

        var wallet = await _unitOfWork.WalletRepository.GetSingleByConditionAsync(x => x.AccountId == accountId);  
        if (wallet is not null)
        {
            throw new Exception("Wallet of this account is already exist");
        }

        Wallet newWallet = _mapper.Map<Wallet>(walletModel);
        await _unitOfWork.WalletRepository.AddAsync(newWallet);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<WalletVM>(newWallet);
    }

    public async Task<WalletVM?> GetWalletByIdAsync(Guid walletId)
    {
        var wallet = await _unitOfWork.WalletRepository.GetByIdAsync(walletId);
        if (wallet is null)
        {
            throw new NullReferenceException("Wallet is not exist");
        }
        var walletVM = _mapper.Map<WalletVM>(wallet);
        return walletVM;
    }

    public async Task<WalletVM?> GetWalletByAccountIdAsync(Guid accountId)
    {
        var wallet = await _unitOfWork.WalletRepository.GetSingleByConditionAsync(x 
                                    => x.AccountId == accountId);
        if (wallet is null)
        {
            throw new NullReferenceException("Wallet is not exist");
        }
        var walletVM = _mapper.Map<WalletVM>(wallet);
        return walletVM;
    }

    public async Task UpdateWalletAsync(Guid walletId, WalletEM walletEM)
    {
        var oldWallet = await _unitOfWork.WalletRepository.GetByIdAsync(walletId);
        if (oldWallet is null)
        {
            throw new Exception("Wallet is not exist");
        }

        oldWallet.Balance = walletEM.Balance; // neu da lam thanh toan thi bo cai nay
        oldWallet.WithdrawMethod = walletEM.WithdrawMethod;
        oldWallet.WithdrawInformation = walletEM.WithdrawInformation;
        _unitOfWork.WalletRepository.Update(oldWallet);
        await _unitOfWork.SaveChangesAsync();
    }
}
