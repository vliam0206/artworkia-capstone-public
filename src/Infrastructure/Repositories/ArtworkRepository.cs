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
            .Include(a => a.Account).ThenInclude(a => new { a.Id, a.Username, a.Email})
            .Include(i => i.Images).ThenInclude(i => new { i.Id, i.ImageName, i.Location, i.Order })
            .Include(a => a.TagDetails)
            .ThenInclude(ac => ac.Tag)
            .FirstOrDefaultAsync(a => a.Id == artworkId);
    }
}
