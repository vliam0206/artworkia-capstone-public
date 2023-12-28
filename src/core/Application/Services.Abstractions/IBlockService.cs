using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IBlockService
{
    Task CreateBlockAsync(Block block);
    Task DeleteBlockAsync(Guid blockingId, Guid blockedId);
    Task<List<Block>> GetAllBlockOfBlockingAsync(Guid blockingId);
    Task<List<Block>> GetAllBlockOfBlockedAsync(Guid blockedId);
    Task<Block?> GetBlockByIdAsync(Guid blockingId, Guid blockedId);
}
