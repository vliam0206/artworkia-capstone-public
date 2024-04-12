using Application.Services.Abstractions;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class TransactionHistoryRepository : GenericCreationRepository<TransactionHistory>, ITransactionHistoryRepository

{
    public TransactionHistoryRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }

    public async Task<TransactionHistory?> GetAssetTransactionAsync(Guid accountId, Guid assetId)
    {
        return await _dbContext.TransactionHistories.FirstOrDefaultAsync(x => x.CreatedBy == accountId && x.AssetId == assetId);
    }

    public async Task<TransactionHistory?> GetProposalTransactionAsync(Guid accountId, Guid proposalId)
    {
        return await _dbContext.TransactionHistories.FirstOrDefaultAsync(x => x.CreatedBy == accountId && x.ProposalId == proposalId);
    }


    public async Task<IPagedList<TransactionHistory>> GetAssetsBoughtOfAccountAsync(Guid accountId, int page, int pageSize)
    {
        var assetBoughts = _dbContext.TransactionHistories
            .Include(a => a.Asset)
            .Where(a => a.CreatedBy == accountId && a.AssetId != null);

        // sorting
        assetBoughts = assetBoughts.OrderByDescending(x => x.CreatedOn);

        #region paging
        var result = await ToPaginationAsync(assetBoughts, page, pageSize);
        #endregion

        return result;
    }

    public async Task<List<TransactionHistory>> GetTransactionHistoriesOfAccountAsync(Guid accountId)
    {
        var transactionsList = await _dbContext.TransactionHistories
            .Where(x => x.CreatedBy == accountId || x.ToAccountId == accountId)
            .Include(x => x.Account)
            .Include(x => x.ToAccount)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync();

        return transactionsList;
    }

    public async Task<IPagedList<TransactionHistory>> GetAllTransacrionHistoriesPaginationAsync(int pageNumber, int pageSize)
    {
        var transactionList = _dbContext.TransactionHistories
                                    .Include(x => x.Account)
                                    .Include(x => x.ToAccount)
                                    .OrderByDescending(x => x.CreatedOn);
        var result = await this.ToPaginationAsync(transactionList, pageNumber, pageSize);
        return result;
    }
}
