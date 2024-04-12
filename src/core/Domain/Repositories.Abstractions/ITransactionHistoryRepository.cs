﻿using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Models;

namespace Domain.Repositories.Abstractions;
public interface ITransactionHistoryRepository : IGenericRepository<TransactionHistory>
{
    //Task<TransactionHistory> GetTransactionHistoryByIdAsync(Guid transactionHistoryId);
    //Task<List<TransactionHistory>> GetTransactionHistoriesOfUserAsync(Guid userId);
    //Task<List<TransactionHistory>> GetTransactionHistoriesOfUserAsync(Guid userId, int page, int pageSize);
    //Task<List<TransactionHistory>> GetTransactionHistoriesOfUserAsync(Guid userId, DateTime fromDate, DateTime toDate);
    Task<TransactionHistory?> GetAssetTransactionAsync(Guid accountId, Guid assetId);
    Task<TransactionHistory?> GetProposalTransactionAsync(Guid accountId, Guid proposalId);
    Task<IPagedList<TransactionHistory>> GetAssetsBoughtOfAccountAsync(Guid accountId, int page, int pageSize);
    Task<List<TransactionHistory>> GetTransactionHistoriesOfAccountAsync(Guid accountId);
    Task<IPagedList<TransactionHistory>> GetAllTransacrionHistoriesPaginationAsync(int pageNumber, int pageSize);
    Task<List<NoTransByDate>> GetAssetTransactionStatistic(DateTime startTime, DateTime endTime);
}
