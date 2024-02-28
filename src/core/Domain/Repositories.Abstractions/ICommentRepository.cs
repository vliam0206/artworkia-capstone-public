using Domain.Entitites;

namespace Domain.Repositories.Abstractions;
public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<Comment>> GetCommentsWithRepliesAsync(Guid artworkId);
    Task<List<Comment>> GetReplyCommentsAsync(Guid commentId);
    Task<Comment?> GetCommentById(Guid commentId);
    void SoftDeleteReplies(Guid commentId);
}
