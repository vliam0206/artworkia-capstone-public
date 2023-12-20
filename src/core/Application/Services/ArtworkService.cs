using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class ArtworkService : IArtworkService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArtworkService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Artwork>> GetAllArtworksAsync()
    {
        return await _unitOfWork.ArtworkRepository.GetAllAsync();
    }

    public async Task<Artwork?> GetArtworkByIdAsync(Guid artworkId)
    {
        return await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
    }
    public async Task AddArtworkAsync(Artwork artwork)
    {
        await _unitOfWork.ArtworkRepository.AddAsync(artwork);
    }

    public async Task DeleteArtworkAsync(Guid artworkId)
    {
       var result = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (result == null)
            throw new Exception("Cannot found artwork!");
        _unitOfWork.ArtworkRepository.Delete(result);
    }

    public async Task UpdateArtworkAsync(Artwork artwork)
    {
        var result = await _unitOfWork.ArtworkRepository.GetByIdAsync(artwork.Id);
        if (result == null)
            throw new Exception("Cannot found artwork!");
        artwork.CreatedOn = result.CreatedOn;
        _unitOfWork.ArtworkRepository.Update(artwork);
    }
}
