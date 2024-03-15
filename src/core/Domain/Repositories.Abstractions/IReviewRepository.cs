﻿using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;

namespace Domain.Repositories.Abstractions;
public interface IReviewRepository : IGenericRepository<Review>
{
    public Task<IPagedList<Review>> GetReviewsAsync(
        string? keyword, string? sortColumn, string? sortOrder, int page, int pageSize,
        Guid? proposalId = null, Guid? accountId = null);
    public Task<Review?> GetReviewDetailAsync(Guid reviewId);
}
