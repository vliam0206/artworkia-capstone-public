using Application.Commons;
using Application.Filters;
using Application.Models;
using Domain.Entities.Commons;
using Domain.Enums;

namespace Application.Services.Abstractions;
public interface IArtworkService
{
    Task<ArtworkVM?> GetArtworkByIdAsync(Guid artworkId);
    Task<PagedList<ArtworkPreviewVM>> GetAllArtworksAsync(ArtworkCriteria criteria);
    Task<PagedList<ArtworkModerationVM>> GetAllArtworksForModerationAsync(ArtworkModerationCriteria criteria);
    Task<PagedList<ArtworkPreviewVM>> GetAllArtworksByAccountIdAsync(Guid accountId, ArtworkModerationCriteria criteria);
    Task<PagedList<ArtworkPreviewVM>> GetArtworksOfFollowingsAsync(PagedCriteria criteria);
    Task DeleteArtworkAsync(Guid artworkId);
    Task SoftDeleteArtworkAsync(Guid artworkId);
    Task UpdateArtworkAsync(Guid artworkId, ArtworkEM artworkEM);
    Task UpdateArtworkStateAsync(Guid artworkId, ArtworkStateEM model);
    Task<ArtworkVM> AddArtworkAsync(ArtworkModel artwork);
    Task<List<ImageDuplicationVM>> GetArtworksDuplicateAsync(Guid artworkId);
}
