﻿using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;
namespace Domain.Repositories.Abstractions;

public interface IArtworkRepository : IGenericRepository<Artwork>
{
    Task<IPagedList<Artwork>> GetAllArtworksAsync(
        string? keyword, string? sortColumn, string? sortOrder, int page, int pageSize,
        Guid? accountId = null, Guid? categoryId = null, Guid? tagId = null, StateEnum? state = null);
    Task<IPagedList<Artwork>> GetArtworksOfFollowingsAsync(Guid followerId, int page, int pageSize);
    Task<Artwork?> GetArtworkDetailByIdAsync(Guid artworkId);
    Task<List<Image>> GetArtworksDuplicateAsync(Guid artworkId);
}
