using Application.Models;
using Domain.Entitites;
using Domain.Pagination;

namespace Application.Services.Abstractions;
public interface IArtworkService
{
    Task<ArtworkVM?> GetArtworkByIdAsync(Guid artworkId);
    Task<List<ArtworkPreviewVM>> GetAllArtworksAsync();
    Task<PagedList<ArtworkPreviewVM>> GetAllArtworksByAccountIdAsync(Guid accountId, string? sortBy, int page = 1, int pageSize = 10);
    Task<List<ArtworkPreviewVM>> GetArtworksBySearchAsync(SearchArtworkCriteria searchArtworkCriteria);
    Task DeleteArtworkAsync(Guid artworkId);
    Task UpdateArtworkAsync(Guid artworkId, ArtworkEM artworkEM);
    Task<ArtworkVM> AddArtworkAsync(ArtworkModel artwork);
}
