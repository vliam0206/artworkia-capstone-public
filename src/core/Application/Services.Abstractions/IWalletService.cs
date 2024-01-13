using Application.Models;

namespace Application.Services.Abstractions;

public interface IWalletService
{
    Task<WalletVM?> GetWalletByIdAsync(Guid walletId);
    Task<WalletVM?> GetWalletByAccountIdAsync(Guid accountId);
    Task UpdateWalletAsync(Guid walletId, WalletEM walletEM);
    Task<WalletVM> AddWalletAsync(WalletModel walletModel);
}
