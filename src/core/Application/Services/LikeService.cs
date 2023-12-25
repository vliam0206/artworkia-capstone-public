using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class LikeService : ILikeService
{
    private readonly IUnitOfWork _unitOfWork;

    public LikeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateLikeAsync(Like like)
    {
        var tmpLike = await _unitOfWork.LikeRepository.GetByIdAsync(like.AccountId, like.ArtworkId);
        if (tmpLike != null)
        {
            throw new Exception("Liked already!");
        }
        await _unitOfWork.LikeRepository.AddLikeAsync(like);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteLikeAsync(Guid accountId, Guid artworkId)
    {
        var like = await _unitOfWork.LikeRepository.GetByIdAsync(accountId, artworkId);
        if (like == null)
        {
            throw new ArgumentException("AccountId or artworkId not found.");
        }
        // hard delete like in db
        _unitOfWork.LikeRepository.DeleteLike(like);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Like>> GetAllLikesOfAccountAsync(Guid accountId)
     => await _unitOfWork.LikeRepository.GetAllLikeOfAccountAsync(accountId);

    public async Task<List<Like>> GetAllLikesOfArtworkAsync(Guid artworkId)

     => await _unitOfWork.LikeRepository.GetAllLikeOfArtworkAsync(artworkId);

    public Task<Like?> GetLikeByIdAsync(Guid accountId, Guid artworkId)
     => _unitOfWork.LikeRepository.GetByIdAsync(accountId, artworkId);
}
