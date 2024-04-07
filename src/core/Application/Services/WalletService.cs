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

    public async Task<Wallet> AddWalletAsync(Guid acocuntId, WalletEM walletModel)
    {
        Wallet newWallet = _mapper.Map<Wallet>(walletModel);
        newWallet.AccountId = acocuntId;
        await _unitOfWork.WalletRepository.AddAsync(newWallet);
        await _unitOfWork.SaveChangesAsync();

        return newWallet;
    }

    public async Task<WalletVM?> GetWalletByIdAsync(Guid walletId)
    {
        var wallet = await _unitOfWork.WalletRepository.GetByIdAsync(walletId);
        if (wallet is null)
        {
            throw new KeyNotFoundException("Không tìm thấy ví.");
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
            throw new KeyNotFoundException("Không tìm thấy ví.");
        }
        var walletVM = _mapper.Map<WalletVM>(wallet);
        return walletVM;
    }

    public async Task UpdateWalletAsync(Guid walletId, WalletEM walletEM)
    {
        var oldWallet = await _unitOfWork.WalletRepository.GetByIdAsync(walletId);
        if (oldWallet is null)
        {
            throw new Exception("Không tìm thấy ví.");
        }
        oldWallet.WithdrawMethod = walletEM.WithdrawMethod;
        oldWallet.WithdrawInformation = walletEM.WithdrawInformation;
        _unitOfWork.WalletRepository.Update(oldWallet);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddCoinsToWallet(Guid accountId, double amount, bool isSaveChange = true)
    {
        var wallet = await _unitOfWork.WalletRepository
                                .GetSingleByConditionAsync(x => x.AccountId == accountId);
        if (wallet == null)
        {
            throw new Exception("Tài khoản này chưa có ví.");
        }
        wallet.Balance += amount;
        _unitOfWork.WalletRepository.Update(wallet);
        if (isSaveChange)
        {
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task SubtrasctCoinsFromWallet(Guid accountId, double amount, bool isSaveChange = true)
    {
        var wallet = await _unitOfWork.WalletRepository
                                .GetSingleByConditionAsync(x => x.AccountId == accountId);
        if (wallet == null)
        {
            throw new ArgumentException("Tài khoản này chưa có ví.");
        }
        if (wallet.Balance < amount)
        {
            throw new ArgumentOutOfRangeException("Số dư xu hiện có trong ví không đủ để thực hiện giao dịch.");
        }
        wallet.Balance -= amount;
        _unitOfWork.WalletRepository.Update(wallet);
        if (isSaveChange)
        {
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task UpdateCurrentWalletAsync(WalletEM walletEM)
    {
        var currentAccountId = _claimService.GetCurrentUserId ?? default;
        var wallet = await _unitOfWork.WalletRepository
            .GetSingleByConditionAsync(x => x.AccountId == currentAccountId);

        if (wallet == null)
        { // wallet not exist -> create new
            wallet = await this.AddWalletAsync(currentAccountId, walletEM);
        }
        else
        { // wallet exist -> update
            wallet.WithdrawInformation = walletEM.WithdrawInformation;
            wallet.WithdrawMethod = walletEM.WithdrawMethod;
            _unitOfWork.WalletRepository.Update(wallet);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<bool> CheckWithdrawBalance(Guid accountId, double amount)
    {
        var wallet = await _unitOfWork.WalletRepository
                                .GetSingleByConditionAsync(x => x.AccountId == accountId);
        if (wallet == null)
        {
            throw new ArgumentException("Tài khoản này chưa có ví.");
        }
        return (wallet.Balance >= amount);
    }
}