using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IFollowService
{
    Task CreateFollowAsync(Follow follow);
    Task DeleteFollowAsync(Guid accountId, Guid followerId);
    Task<List<Follow>> GetAllFollowingsAsync(Guid followerId);
    Task<List<Follow>> GetAllFollowersAsync(Guid followingId);
    Task<Follow?> GetFollowByIdAsync(Guid accountId, Guid followerId);
    Task<bool> IsFollowedAsync(Guid accountId);
}
