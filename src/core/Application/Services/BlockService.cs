using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class BlockService : IBlockService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;


    public BlockService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task CreateBlockAsync(BlockModel blockModel)
    {
        Guid blockingId = _claimService.GetCurrentUserId ?? default;
        
        var blockedAccountExist = await _unitOfWork.AccountRepository.IsExistedAsync(blockModel.BlockedId);
        if (!blockedAccountExist)
        {
            throw new NullReferenceException("Blocked Account not found.");
        }

        var tempBlock = await _unitOfWork.BlockRepository.GetByIdAsync(blockingId, blockModel.BlockedId);
        if (tempBlock != null)
        {
            throw new Exception("Blocked already!");
        }

        // delete follow if exist and vice versa
        var following = await _unitOfWork.FollowRepository.GetByIdAsync(blockingId, blockModel.BlockedId);
        var followed = await _unitOfWork.FollowRepository.GetByIdAsync(blockModel.BlockedId, blockingId);
        if (following != null)
        {
            _unitOfWork.FollowRepository.DeleteFollow(following);
        }
        if (followed != null)
        {
            _unitOfWork.FollowRepository.DeleteFollow(followed);
        } 

        Block block = new()
        {
            BlockingId = blockingId,
            BlockedId = blockModel.BlockedId
        };
        await _unitOfWork.BlockRepository.AddBlockAsync(block);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteBlockAsync(Guid blockedId)
    {
        Guid? blockingId = _claimService.GetCurrentUserId;
        if (blockingId == null)
        {
            throw new NullReferenceException("Blocking Account not found.");
        }
        var blockedAccountExist = await _unitOfWork.AccountRepository.IsExistedAsync(blockedId);
        if (!blockedAccountExist)
        {
            throw new NullReferenceException("Blocked Account not found.");
        }

        var block = await _unitOfWork.BlockRepository.GetByIdAsync(blockingId.Value, blockedId);
        if (block == null)
        {
            throw new NullReferenceException("Unblock already!");
        }
        // hard delete block in db
        _unitOfWork.BlockRepository.DeleteBlock(block);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<BlockingVM> GetBlockingsOfBlockerAsync(Guid blockerId)
    {
        var accountExist = await _unitOfWork.AccountRepository.IsExistedAsync(blockerId);
        if (!accountExist)
        {
            throw new NullReferenceException("blocker Account not found.");
        }

        var listBlocks = await _unitOfWork.BlockRepository.GetAllBlockOfBlockingAsync(blockerId);
        var listBlocking = new List<AccountBasicInfoVM>();
        foreach (var block in listBlocks)
        {
            listBlocking.Add(_mapper.Map<AccountBasicInfoVM>(block.Blocked));
        }
        BlockingVM blockingVM = new()
        {
            BlockerId = blockerId,
            Blockings = listBlocking
        };
        return blockingVM;
    }

    public async Task<BlockerVM> GetBlockersOfBlockingAsync(Guid blockingId)
    {
        var accountExist = await _unitOfWork.AccountRepository.IsExistedAsync(blockingId);
        if (!accountExist)
        {
            throw new NullReferenceException("Blocking Account not found.");
        }
        var listBlocks = await _unitOfWork.BlockRepository.GetAllBlockOfBlockedAsync(blockingId);
        var listBlocker = new List<AccountBasicInfoVM>();
        foreach (var block in listBlocks)
        {
            listBlocker.Add(_mapper.Map<AccountBasicInfoVM>(block.Blocking));
        }
        BlockerVM blockerVM = new()
        {
            BlockingId = blockingId,
            Blockers = listBlocker
        };
        return blockerVM;
    }

    public async Task<BlockVM?> GetBlockByIdAsync(Guid blockingId, Guid blockedId)
    {
        var block = await _unitOfWork.BlockRepository.GetByIdAsync(blockingId, blockedId);
        var blockVM = _mapper.Map<BlockVM>(block);
        return blockVM;
    }
}
