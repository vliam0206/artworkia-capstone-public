using Application.Commons;
using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CommentRepository : GenericAuditableRepository<Comment>, ICommentRepository
{
    private IClaimService _claimService;
    public CommentRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
        _claimService = claimService;
    }
    public void SoftDeleteReplies(Guid commentId)
    {
        var currentUserId = _claimService.GetCurrentUserId;
        var replies = _dbContext.Comments
            .Where(x => x.ReplyId == commentId
                && x.CreatedBy == currentUserId);
        if (replies.Any())
        {
            foreach (var reply in replies)
            {
                reply.DeletedOn = CurrentTime.GetCurrentTime;
                reply.DeletedBy = currentUserId;
            }
            _dbContext.UpdateRange(replies);
        }
    }
    public async Task<List<Comment>> GetReplyCommentsAsync(Guid commentId)
    {
        return await _dbContext.Comments
            .Where(x => x.ReplyId == commentId
                && x.DeletedOn == null)
            .Include(x => x.Account)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync();
    }
    public async Task<List<Comment>> GetCommentsWithRepliesAsync(Guid artworkId)
    {
        return await _dbContext.Comments
            .Where(x => x.ArtworkId == artworkId
                    && x.DeletedOn == null)
            .Include(x => x.Replies)
            .Include(x => x.Account)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync();
    }

    public async Task<Comment?> GetCommentById(Guid commentId)
    {
        return await _dbContext.Comments
            .Include(x => x.Replies)
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == commentId);
    }
}
