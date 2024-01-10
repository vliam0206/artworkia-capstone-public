using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface IArtworkService
{
    Task<ArtworkVM?> GetArtworkByIdAsync(Guid artworkId);
    Task<List<ArtworkPreviewVM>> GetAllArtworksAsync();
    Task<List<ArtworkPreviewVM>> GetArtworksBySearchAsync(SearchArtworkCriteria searchArtworkCriteria);
    Task DeleteArtworkAsync(Guid artworkId);
    Task UpdateArtworkAsync(Guid artworkId, ArtworkEM artworkEM);
    Task<ArtworkVM> AddArtworkAsync(ArtworkModel artwork);
}
