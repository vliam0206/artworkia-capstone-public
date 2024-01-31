using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Pagination;
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

    public PagedList<Artwork> GetAllArtworksByAccountIdAsync(Guid accountId, string? sortBy, int page, int pageSize)
    {
        var allArtworks = _dbContext.Artworks
            .Include(a => a.Account)
            .Where(a => a.CreatedBy == accountId).AsQueryable();

        #region sorting
        allArtworks = sortBy switch
        {
            "view" => allArtworks.OrderBy(a => a.ViewCount),
            "created_on" => allArtworks.OrderBy(a => a.CreatedOn),
            "created_on_desc" => allArtworks.OrderByDescending(a => a.CreatedOn),
            _ => allArtworks.OrderByDescending(a => a.CreatedOn),
        };
        #endregion

        #region paging
        var result = PagedList<Artwork>.GetPagedList(allArtworks, page, pageSize);
        #endregion

        return result;
    }

    public async Task<Artwork?> GetArtworkDetailByIdAsync(Guid artworkId)
    {
        return await _dbContext.Artworks
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
