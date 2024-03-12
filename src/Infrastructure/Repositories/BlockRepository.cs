using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class BlockRepository : IBlockRepository
{
    private readonly AppDBContext _dbContext;

    public BlockRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddBlockAsync(Block block)
     => await _dbContext.Blocks.AddAsync(block);

    public void DeleteBlock(Block block)
     => _dbContext.Blocks.Remove(block);

    public async Task<List<Block>> GetAllBlockOfBlockingAsync(Guid accountId)
    {
        return await _dbContext.Blocks
            .Where(x => x.BlockingId == accountId)
            .Include(x => x.Blocked)
            .ToListAsync();
    }

    public async Task<List<Block>> GetAllBlockOfBlockedAsync(Guid accountId)
    {
        return await _dbContext.Blocks
            .Where(x => x.BlockedId == accountId)
            .Include(x => x.Blocking)
            .ToListAsync();
    }

    public async Task<Block?> GetByIdAsync(Guid blockId, Guid blockedId)
    {
        return await _dbContext.Blocks
            .FirstOrDefaultAsync(x => x.BlockingId == blockId && x.BlockedId == blockedId);
    }
}
