using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ArtworkRepository : GenericAuditableRepository<Artwork>, IArtworkRepository
{
    public ArtworkRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }

    public Task<Artwork?> GetArtworkDetailByIdAsync(Guid artworkId)
    {
        return _dbContext.Artworks
            .Include(a => a.Account)
            .Include(i => i.Images)
            .Include(a => a.Assets)
            .Include(c => c.Comments)
            .Include(a => a.TagDetails)
                .ThenInclude(t => t.Tag)
            .Include(a => a.CategoryArtworkDetails)
                .ThenInclude(c => c.Category)
            .FirstOrDefaultAsync(a => a.Id == artworkId);
    }
}
