using Application.Commons;
using Application.Filters;
using Application.Models;
using Domain.Enums;

namespace Application.Services.Abstractions;
public interface IArtworkService
{
    Task<ArtworkVM?> GetArtworkByIdAsync(Guid artworkId);
    Task<PagedList<ArtworkPreviewVM>> GetAllArtworksAsync(ArtworkCriteria criteria);
    Task<PagedList<ArtworkModerationVM>> GetAllArtworksForModerationAsync(ArtworkCriteria criteria);
    Task<PagedList<ArtworkPreviewVM>> GetAllArtworksByAccountIdAsync(Guid accountId, ArtworkCriteria criteria);
    Task DeleteArtworkAsync(Guid artworkId);
    Task UpdateArtworkAsync(Guid artworkId, ArtworkEM artworkEM);
    Task UpdateArtworkStateAsync(Guid artworkId, StateEnum state);
    Task<ArtworkVM> AddArtworkAsync(ArtworkModel artwork);
}
