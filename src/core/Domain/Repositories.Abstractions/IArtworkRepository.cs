using Domain.Entitites;
using Domain.Pagination;
namespace Domain.Repositories.Abstractions;

public interface IArtworkRepository : IGenericRepository<Artwork>
{
    PagedList<Artwork> GetAllArtworksByAccountIdAsync(Guid accountId, string? sortBy, int page, int pageSize);
    Task<Artwork?> GetArtworkDetailByIdAsync(Guid artworkId);
}
