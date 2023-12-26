using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;

    public CommentService(IUnitOfWork unitOfWork, IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
    }
    public async Task<Comment> AddCommentAsync(Guid artworkId, string commentText)
    {
        var comment = new Comment
        {
            ArtworkId = artworkId,
            Content = commentText
        };
        await _unitOfWork.CommentRepository.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();
        return (comment);
    }

    public async Task DeleteCommentAsync(Guid commentId)
    {
        // theo co che xoa comment cua facebook
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(commentId);
        if (comment == null || comment.DeletedOn != null)
        {
            throw new ArgumentException("Comment Id not found!");
        }
        // check authorize
        if (_claimService.GetCurrentRole.Equals(RoleEnum.CommonUser.ToString())
                && _claimService.GetCurrentUserId != comment.CreatedBy)
        {
            throw new UnauthorizedAccessException();
        }
        _unitOfWork.CommentRepository.SoftDelete(comment);
        _unitOfWork.CommentRepository.SoftDeleteReplies(commentId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task EditCommentAsync(Guid commentId, string newCommentText)
    {
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(commentId);
        if (comment == null || comment.DeletedOn != null)
        {
            throw new ArgumentException("Comment Id not found!");
        }
        // edit comment
        comment.Content = newCommentText;
        _unitOfWork.CommentRepository.Update(comment);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetCommentsByArtworkAsync(Guid artworkId)
    {
        return await _unitOfWork.CommentRepository
            .GetListByConditionAsync(x => x.ArtworkId == artworkId
                                        && x.DeletedOn == null);
    }

    public async Task<List<Comment>> GetCommentsByArtworkWithRepliesAsync(Guid artworkId)
    {
        return (await _unitOfWork.CommentRepository
            .GetCommentsWithRepliesAsync(artworkId))
            .Where(x => x.DeletedOn == null)
            .ToList();
    }

    public async Task<List<Comment>> GetReplyCommentsAsync(Guid commentId)
    {
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(commentId);
        if (comment == null || comment.DeletedOn != null)
        {
            throw new ArgumentException("Comment Id not found!");
        }
        return await _unitOfWork.CommentRepository.GetReplyCommentsAsync(commentId);
    }

    public async Task<Comment?> GetCommentByIdAsync(Guid commentId)
    {
        return await _unitOfWork.CommentRepository.GetByIdAsync(commentId);
    }

    public async Task<Comment> ReplyCommentAsync(Guid commentId, string replyCommentText)
    {
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(commentId);
        if (comment == null || comment.DeletedOn != null)
        {
            throw new ArgumentException("Comment Id not found!");
        }
        // reply comment
        var replyComment = new Comment
        {
            ReplyId = commentId,
            ArtworkId = comment.ArtworkId,
            Content = replyCommentText
        };
        await _unitOfWork.CommentRepository.AddAsync(replyComment);
        await _unitOfWork.SaveChangesAsync();
        return (replyComment);
    }
}
