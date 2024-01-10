using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ArtworkRepository : GenericAuditableRepository<Artwork>, IArtworkRepository
{
    private AppDBContext _dbContext;
    private IClaimService _claimService;
    public ArtworkRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
        _dbContext = dBContext;
        _claimService = claimService;
    }

    public Task<Artwork?> GetArtworkDetailByIdAsync(Guid artworkId)
    {
        return _dbContext.Artworks
            .Include(a => a.Account)
            .Include(i => i.Images)
            .Include(a => a.Assets)
            .Include(a => a.TagDetails)
            .Include(a => a.CategoryArtworkDetails)
                .ThenInclude(c => c.Category)
            .FirstOrDefaultAsync(a => a.Id == artworkId);
    }
}
