using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface ILikeService
{
    Task CreateLikeAsync(Like like);
    Task DeleteLikeAsync(Guid accountId, Guid artworkId);
    Task<List<Like>> GetAllLikesOfArtworkAsync(Guid artworkId);
    Task<List<Like>> GetAllLikesOfAccountAsync(Guid accountId);
    Task<Like?> GetLikeByIdAsync(Guid accountId, Guid artworkId);
}
