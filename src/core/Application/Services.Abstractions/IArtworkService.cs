using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface IArtworkService
{
    Task<Artwork?> GetArtworkByIdAsync(Guid artworkId);
    Task<List<Artwork>> GetAllArtworksAsync();
    Task<List<ArtworkSearchVM>> GetArtworksBySearchAsync();
    Task DeleteArtworkAsync(Guid artworkId);
    Task UpdateArtworkAsync(Artwork artwork);
    Task<Guid> AddArtworkAsync(ArtworkModel artwork);
}
