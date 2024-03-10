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

    public async Task<ArtworkLikeVM> GetAllLikesOfAccountAsync(Guid accountId)
    {
        var listAccounts = await _unitOfWork.LikeRepository.GetAllLikeOfAccountAsync(accountId);
        var listArtworksLikeds = new List<ArtworkPreviewVM>();
        foreach (var like in listAccounts)
        {
            listArtworksLikeds.Add(_mapper.Map<ArtworkPreviewVM>(like.Artwork));
        }
        ArtworkLikeVM artworkLikeVM = new()
        {
            AccountId = accountId,
            ArtworkLikeds = listArtworksLikeds
        };
        return artworkLikeVM;
    }

    public async Task<AccountLikeVM> GetAllLikesOfArtworkAsync(Guid artworkId)
    {
        var listLikes = await _unitOfWork.LikeRepository.GetAllLikeOfArtworkAsync(artworkId);
        var listAccountsLikeds = new List<AccountBasicInfoVM>();
        foreach (var like in listLikes)
        {
            listAccountsLikeds.Add(_mapper.Map<AccountBasicInfoVM>(like.Account));
        }
        AccountLikeVM accountLikeVM = new()
        {
            ArtworkId = artworkId,
            AccountLikeds = listAccountsLikeds
        };
        return accountLikeVM;
    }
    public Task<Like?> GetLikeByIdAsync(Guid accountId, Guid artworkId)
     => _unitOfWork.LikeRepository.GetByIdAsync(accountId, artworkId);

    public async Task<IsLikedVM> GetIsLikedArtworkAsync(Guid accountId, Guid artworkId)
    {
        bool isArtworkExisted = await _unitOfWork.ArtworkRepository.IsExistedAsync(artworkId);  
        if (!isArtworkExisted)
            throw new NullReferenceException("Artwork not found.");
        var likeObj = await _unitOfWork.LikeRepository.GetByIdAsync(accountId, artworkId);
        return new IsLikedVM
        {
            ArtworkId = artworkId,
            IsLiked = likeObj != null
        };
    }

    public async Task<List<IsLikedVM>> GetListIsLikedArtworkAsync(Guid accountId, List<Guid> artworkIds)
    {
        List<IsLikedVM> listIsLiked = new();
        foreach (var artworkId in artworkIds)
        {
            bool isArtworkExisted = await _unitOfWork.ArtworkRepository.IsExistedAsync(artworkId);
            if (!isArtworkExisted)
                throw new NullReferenceException("Artwork not found.");
            var likeObj = await _unitOfWork.LikeRepository.GetByIdAsync(accountId, artworkId);
            listIsLiked.Add(new IsLikedVM
            {
                ArtworkId = artworkId,
                IsLiked = likeObj != null
            });
        }
        return listIsLiked;

    }
}
