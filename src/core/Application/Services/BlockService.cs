using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class BlockService : IBlockService
{
    private readonly IUnitOfWork _unitOfWork;

    public BlockService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateBlockAsync(Block block)
    {
        var tempBlock = await _unitOfWork.BlockRepository.GetByIdAsync(block.BlockingId, block.BlockedId);
        if (tempBlock != null)
        {
            throw new Exception("Blocked already!");
        }
        await _unitOfWork.BlockRepository.AddBlockAsync(block);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteBlockAsync(Guid blockingId, Guid blockedId)
    {
        var block = await _unitOfWork.BlockRepository.GetByIdAsync(blockingId, blockedId);
        if (block == null)
        {
            throw new ArgumentException("BlockingId or blockedId not found.");
        }
        // hard delete block in db
        _unitOfWork.BlockRepository.DeleteBlock(block);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Block>> GetAllBlockOfBlockedAsync(Guid blockedId)
     => await _unitOfWork.BlockRepository.GetAllBlockOfBlockedAsync(blockedId); 

    public async Task<List<Block>> GetAllBlockOfBlockingAsync(Guid blockingId)
    => await _unitOfWork.BlockRepository.GetAllBlockOfBlockingAsync(blockingId);

    public async Task<Block?> GetBlockByIdAsync(Guid blockingId, Guid blockedId)
    => await _unitOfWork.BlockRepository.GetByIdAsync(blockingId, blockedId);
}
