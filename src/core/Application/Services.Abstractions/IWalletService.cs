using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IWalletService
{
    Task<WalletVM?> GetWalletByIdAsync(Guid walletId);
    Task<WalletVM?> GetWalletByAccountIdAsync(Guid accountId);
    Task UpdateWalletAsync(Guid walletId, WalletEM walletEM);
    Task UpdateCurrentWalletAsync(WalletEM walletEM);
    Task<Wallet> AddWalletAsync(Guid acocuntId, WalletEM walletModel);
    Task DepositCoinsAsync(Guid accountId, double amount);
    Task AddCoinsToWallet(Guid walletId, double amount);
    Task SubtrasctCoinsFromWallet(Guid walletId, double amount);
}