using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface ICollectionService
{
    Task<List<Collection>> GetAllCollectionsOfAccount(Guid accountId);
    Task<Collection> GetCollectionDetail(Guid collectionId);
    Task CreateCollection(Collection collection);
    Task AddArtworkToCollection(Bookmark bookmark);
    Task DeleteCollection(Guid collectionId);
    Task UpdateColelction(Collection newCollection);
}
