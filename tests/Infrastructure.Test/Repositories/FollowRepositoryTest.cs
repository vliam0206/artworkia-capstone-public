﻿using AutoFixture;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Domain.Test;
using FluentAssertions;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Test.Repositories;

public class FollowRepositoryTest : SetupTest
{
    private readonly IFollowRepository _followRepository;

    public FollowRepositoryTest()
    {
        _followRepository = new FollowRepository(_dbContext);
    }

    [Fact]
    public async Task FollowRepository_GetByIdAsync_ShouldReturnCorrectData()
    {
        // arrange
        var mockData = MockFollowList(1).FirstOrDefault()!;
        await _dbContext.Follows.AddAsync(mockData);
        await _dbContext.SaveChangesAsync();

        // act
        var result = await _followRepository
            .GetByIdAsync(mockData.AccountId, mockData.FollowerId);

        // assert
        result.Should().BeEquivalentTo(mockData);
    }

    [Fact]
    public async Task FollowRepository_GetByIdAsync_ShouldReturnNullWhenNotFound()
    {
        // arrange
        var mockData = MockFollowList(5);
        await _dbContext.Follows.AddRangeAsync(mockData);
        await _dbContext.SaveChangesAsync();

        // act
        var result = await _followRepository
            .GetByIdAsync(Guid.NewGuid(), Guid.NewGuid());

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task FollowRepository_AddFollowAsync_ShouldReturnCorrectData()
    {
        // arrange
        var mockData = MockFollowList(1).FirstOrDefault()!;

        // act
        await _followRepository.AddFollowAsync(mockData);
        var result = await _dbContext.SaveChangesAsync();

        // assert
        result.Should().Be(1);
    }

    [Fact]
    public async Task FollowRepository_DeleteFollow_ShouldReturnCorrectData()
    {
        // arrange
        var mockData = MockFollowList(1).FirstOrDefault()!;
        await _dbContext.Follows.AddAsync(mockData);
        await _dbContext.SaveChangesAsync();

        // act
        _followRepository.DeleteFollow(mockData);
        var result = await _dbContext.SaveChangesAsync();

        // assert
        result.Should().Be(1);
    }

    [Fact]
    public async Task FollowRepository_GetAllFollowingsAsync_ShouldReturnCorrectData()
    {
        // arrange        
        var followerId = Guid.NewGuid();
        var mockData = new List<Follow>();
        for (int i =0; i < 5; i++)
        {
            var account = MockAccountList(1).FirstOrDefault()!;
            mockData.Add(new Follow
            {
                AccountId = account.Id,
                FollowerId = followerId,
                Account = account
            });
        }
        await _dbContext.Follows.AddRangeAsync(mockData);
        await _dbContext.SaveChangesAsync();

        // act
        var result = await _followRepository.GetAllFollowingsAsync(followerId);

        // assert
        result.Should().BeEquivalentTo(mockData);
    }

    [Fact]
    public async Task FollowRepository_GetAllFollowingsAsync_ShouldReturnEmptyWhenNotFound()
    {
        // arrange        
        var followerId = Guid.NewGuid();

        // act
        var result = await _followRepository.GetAllFollowingsAsync(followerId);

        // assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task FollowRepository_GetAllFollowersAsync_ShouldReturnCorrectData()
    {
        // arrange        
        var followingId = Guid.NewGuid();
        var mockData = new List<Follow>();
        for (int i = 0; i < 5; i++)
        {
            var follower = MockAccountList(1).FirstOrDefault()!;
            mockData.Add(new Follow
            {
                AccountId = followingId,
                FollowerId = follower.Id,
                Follower = follower
            });
        }
        await _dbContext.Follows.AddRangeAsync(mockData);
        await _dbContext.SaveChangesAsync();

        // act
        var result = await _followRepository.GetAllFollowersAsync(followingId);

        // assert
        result.Should().BeEquivalentTo(mockData);
    }

    [Fact]
    public async Task FollowRepository_GetAllFollowersAsync_ShouldReturnEmptyWhenNotFound()
    {
        // arrange        
        var followingId = Guid.NewGuid();

        // act
        var result = await _followRepository.GetAllFollowersAsync(followingId);

        // assert
        result.Should().BeEmpty();
    }

}
