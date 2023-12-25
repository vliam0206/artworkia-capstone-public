    using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class CommentRepository : GenericAuditableRepository<Comment>, ICommentRepository
{
    public CommentRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }
}
