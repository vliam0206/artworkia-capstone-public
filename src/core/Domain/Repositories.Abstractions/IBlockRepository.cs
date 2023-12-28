using Domain.Entitites;

namespace Domain.Repositories.Abstractions;

public interface IBlockRepository
{
    Task AddBlockAsync(Block block);
    void DeleteBlock(Block block);
    Task<List<Block>> GetAllBlockOfBlockingAsync(Guid accountId);
    Task<List<Block>> GetAllBlockOfBlockedAsync(Guid accountId);
    Task<Block?> GetByIdAsync(Guid blockId, Guid blockedId);
}
