using Domain.Entitites;
namespace Domain.Repositories.Abstractions;

public interface IArtworkRepository : IGenericRepository<Artwork>
{
    Task<Artwork?> GetArtworkDetailByIdAsync(Guid artworkId);
}
