using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class FollowService : IFollowService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public FollowService(
        IUnitOfWork unitOfWork, 
        IClaimService claimService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
        _mapper = mapper;
    }

    public async Task CreateFollowAsync(FollowModel model)
    {
        Guid following = _claimService.GetCurrentUserId ?? default;
        Follow follow = new()
        {
            FollowingId = following,
            FollowedId = model.FollowedId
        };

        if (follow.FollowedId == follow.FollowingId)
        {
            throw new ArgumentException("You can not follow yourself.");
        }

        var accountExist = await _unitOfWork.AccountRepository.IsExistedAsync(follow.FollowedId);
        if (!accountExist)
        {
            throw new NullReferenceException("Followed account not found.");
        }

        var tmpFollow = await _unitOfWork.FollowRepository.GetByIdAsync(follow.FollowingId, follow.FollowedId);
        if (tmpFollow != null)
        {
            throw new Exception("Followed already!");
        }

        // check if account is blocking or blocked
        if (await _unitOfWork.BlockRepository.IsBlockedOrBlockingAsync(follow.FollowingId, follow.FollowedId))
        {
            throw new Exception("Can not follow because of blocking!");
        }

        await _unitOfWork.FollowRepository.AddFollowAsync(follow);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteFollowAsync(FollowModel model)
    {
        Guid followingId = _claimService.GetCurrentUserId ?? default;
        var follow = await _unitOfWork.FollowRepository.GetByIdAsync(followingId, model.FollowedId);
        if (follow == null)
        {
            throw new ArgumentException("Already unfollowed.");
        }
        // hard delete follow in db
        _unitOfWork.FollowRepository.DeleteFollow(follow);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<FollowingVM> GetAllFollowingsAsync(Guid followerId)
    {
        var accountExist = await _unitOfWork.AccountRepository.IsExistedAsync(followerId);
        if (!accountExist)
        {
            throw new NullReferenceException("follower account not found.");
        }

        var listFollow = await _unitOfWork.FollowRepository.GetAllFollowingsAsync(followerId);
        var listFollowing = new List<AccountBasicInfoVM>();
        foreach (var follow in listFollow)
        {
            listFollowing.Add(_mapper.Map<AccountBasicInfoVM>(follow.Followed));
        }
        FollowingVM followingVM = new()
        {
            FollowerId = followerId,
            Followings = listFollowing
        };
        return followingVM;
    }

    public async Task<FollowerVM> GetAllFollowersAsync(Guid followingId)
    {
        var accountExist = await _unitOfWork.AccountRepository.IsExistedAsync(followingId);
        if (!accountExist)
        {
            throw new NullReferenceException("following account not found.");
        }

        var listFollow = await _unitOfWork.FollowRepository.GetAllFollowersAsync(followingId);  
        var listFollower = new List<AccountBasicInfoVM>();
        foreach (var follow in listFollow)
        {
            listFollower.Add(_mapper.Map<AccountBasicInfoVM>(follow.Following));
        }
        FollowerVM followerVM = new()
        {
            FollowingId = followingId,
            Followers = listFollower
        };
        return followerVM;
    }

    public async Task<Follow?> GetFollowByIdAsync(Guid followingId, Guid followedId)
        => await _unitOfWork.FollowRepository.GetByIdAsync(followingId, followedId);

    public async Task<bool> IsFollowedAsync(Guid followedId)
    {
        var currentUserId = _claimService.GetCurrentUserId ?? default;
        return await _unitOfWork.FollowRepository
                    .GetByIdAsync(currentUserId, followedId) != null;
    }
}
