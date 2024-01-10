using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface ICollectionService
{
    Task<List<Collection>> GetAllCollectionsOfAccountAsync(Guid accountId);
    Task<Collection> GetCollectionDetailAsync(Guid collectionId);
    Task CreateCollectionAsync(Collection collection);
    Task AddArtworkToCollectionAsync(Bookmark bookmark);
    Task DeleteCollectionAsync(Guid collectionId);
    Task UpdateColelctionAsync(Collection newCollection);
}
