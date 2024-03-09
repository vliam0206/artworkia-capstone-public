using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class LikeService : ILikeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public LikeService(
        IUnitOfWork unitOfWork,
        IClaimService claimService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
        _mapper = mapper;
    }

    public async Task CreateLikeAsync(LikeModel likeModel)
    {
        Guid accountId = _claimService.GetCurrentUserId ?? default;

        var tmpLike = await _unitOfWork.LikeRepository.GetByIdAsync(accountId, likeModel.ArtworkId);
        if (tmpLike != null)
        {
            throw new Exception("Liked already!");
        }

        Like like = new()
        {
            AccountId = accountId,
            ArtworkId = likeModel.ArtworkId
        };
        await _unitOfWork.LikeRepository.AddLikeAsync(like);
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(like.ArtworkId);
        if (artwork == null) 
            throw new ArgumentException("Artwork not found.");
        artwork.LikeCount++;
        _unitOfWork.ArtworkRepository.Update(artwork);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteLikeAsync(Guid artworkId)
    {
        Guid accountId = _claimService.GetCurrentUserId ?? default;

        var tmpLike = await _unitOfWork.LikeRepository.GetByIdAsync(accountId, artworkId);
        if (tmpLike == null)
        {
            throw new ArgumentException("AccountId or artworkId not found.");
        }

        // hard delete like in db
        _unitOfWork.LikeRepository.DeleteLike(tmpLike);
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (artwork == null)
            throw new ArgumentException("Artwork not found.");
        artwork.LikeCount--;
        _unitOfWork.ArtworkRepository.Update(artwork);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Like>> GetAllLikesOfAccountAsync(Guid accountId)
     => await _unitOfWork.LikeRepository.GetAllLikeOfAccountAsync(accountId);

    public async Task<List<Like>> GetAllLikesOfArtworkAsync(Guid artworkId)

     => await _unitOfWork.LikeRepository.GetAllLikeOfArtworkAsync(artworkId);

    public Task<Like?> GetLikeByIdAsync(Guid accountId, Guid artworkId)
     => _unitOfWork.LikeRepository.GetByIdAsync(accountId, artworkId);
}
