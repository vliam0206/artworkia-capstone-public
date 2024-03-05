using Application.Models;

namespace Application.Services.Abstractions;

public interface IBlockService
{
    Task CreateBlockAsync(BlockModel blockModel);
    Task DeleteBlockAsync(Guid blockedId);
    Task<List<BlockVM>> GetAllBlockOfBlockingAsync(Guid blockingId);
    Task<List<BlockVM>> GetAllBlockOfBlockedAsync(Guid blockedId);
    Task<BlockVM?> GetBlockByIdAsync(Guid blockingId, Guid blockedId);
}
