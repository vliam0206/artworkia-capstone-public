using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface ICommentService
{
    Task<Comment> AddCommentAsync(Guid artworkId, string commentText);
    Task DeleteCommentAsync(Guid commentId);
    Task EditCommentAsync(Guid commentId, string newCommentText);
    Task<Comment?> GetCommentByIdAsync(Guid commentId);
    Task<List<Comment>> GetCommentsByArtworkAsync(Guid artworkId);
    Task<List<Comment>> GetCommentsByArtworkWithRepliesAsync(Guid artworkId);
    Task<List<Comment>> GetReplyCommentsAsync(Guid commentId);
    Task<Comment> ReplyCommentAsync(Guid commentId, string replyCommentText);
}
