﻿using Application.Services.Abstractions;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;

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
}
