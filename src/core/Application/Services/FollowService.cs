﻿using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class FollowService : IFollowService
{
    private readonly IUnitOfWork _unitOfWork;

    public FollowService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateFollowAsync(Follow follow)
    {
        var tmpFollow = await _unitOfWork.FollowRepository.GetByIdAsync(follow.AccountId, follow.FollowerId);
        if (tmpFollow != null)
        {
            throw new Exception("Followed already!");
        }
        await _unitOfWork.FollowRepository.AddFollowAsync(follow);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteFollowAsync(Guid accountId, Guid followerId)
    {
        var follow = await _unitOfWork.FollowRepository.GetByIdAsync(accountId, followerId);
        if (follow == null)
        {
            throw new ArgumentException("Follow ids not found.");
        }
        // hard delete follow in db
        _unitOfWork.FollowRepository.DeleteFollow(follow);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Follow>> GetAllFollowersAsync(Guid followingId)
        => await _unitOfWork.FollowRepository.GetAllFollowersAsync(followingId);

    public async Task<List<Follow>> GetAllFollowingsAsync(Guid followerId)
        => await _unitOfWork.FollowRepository.GetAllFollowingsAsync(followerId);

    public async Task<Follow?> GetFollowByIdAsync(Guid accountId, Guid followerId)
        => await _unitOfWork.FollowRepository.GetByIdAsync(accountId, followerId);
}
