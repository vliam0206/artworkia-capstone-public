using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IWalletHistoryService
{
    Task<List<WalletHistoryVM>> GetWalletHistoriesOfAccount(Guid accountId);
    Task AddWalletHistory(WalletHistory walletHistory);
}
