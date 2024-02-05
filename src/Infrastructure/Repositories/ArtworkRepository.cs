using Application.Services.Abstractions;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;
public class ArtworkRepository : GenericAuditableRepository<Artwork>, IArtworkRepository
{
    public ArtworkRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }

    public async Task<IPagedList<Artwork>> GetAllArtworksAsync(Guid? categoryId, StateEnum? state, string? keyword, string? sortColumn, string? sortOrder, int page, int pageSize)
    {
        var allArtworks = _dbContext.Artworks
            .Include(a => a.Account)
            .Include(c => c.CategoryArtworkDetails)
                .ThenInclude(c => c.Category)
            .Include(t => t.TagDetails)
                .ThenInclude(t => t.Tag)
            .Where(a => a.DeletedOn == null);

        if (state != null)
        {
            allArtworks = allArtworks.Where(a => a.State == state);
        }   

        if (categoryId != null)
        {
            allArtworks = allArtworks
                .Where(a => a.CategoryArtworkDetails
                .Any(c => c.CategoryId == categoryId));
        }

        if (!string.IsNullOrEmpty(keyword))
        {
            keyword = keyword.ToLower();
            allArtworks = allArtworks.Where(a => a.Title.ToLower().Contains(keyword) 
            || (a.Description != null && a.Description.ToLower().Contains(keyword)));
        }

        #region sorting
        Expression<Func<Artwork, object>> orderBy = sortColumn?.ToLower() switch
        {
            "view" => a => a.ViewCount,
            "create" => a => a.CreatedOn,
            "comment" => a => a.CommentCount,
            "like" => a => a.LikeCount,
            _ => a => a.CreatedOn,
        };

        if (sortOrder?.ToLower() == "asc")
        {
            allArtworks = allArtworks.OrderBy(orderBy);
        }
        else
        {
            allArtworks = allArtworks.OrderByDescending(orderBy);
        }
        #endregion

        #region paging
        var result = await ToPaginationAsync(allArtworks, page, pageSize);
        #endregion

        return result;
    }

    public async Task<IPagedList<Artwork>> GetAllArtworksByAccountIdAsync(Guid accountId, StateEnum? state, string? keyword, string? sortColumn, string? sortOrder, int page, int pageSize)
    {
        var allArtworks = _dbContext.Artworks
            .Include(a => a.Account)
            .Where(a => a.CreatedBy == accountId && a.DeletedOn == null);

        if (state != null)
        {
            allArtworks = allArtworks.Where(a => a.State == state);
        }

        if (!string.IsNullOrEmpty(keyword))
        {
            keyword = keyword.ToLower();
            allArtworks = allArtworks.Where(a => a.Title.ToLower().Contains(keyword) 
            || (a.Description != null && a.Description.ToLower().Contains(keyword)));
        }

        #region sorting
        Expression<Func<Artwork, object>> orderBy = sortColumn?.ToLower() switch
        {
            "view" => a => a.ViewCount,
            "created_on" => a => a.CreatedOn,
            "created_on_desc" => a => a.CreatedOn,
            _ => a => a.CreatedOn,
        };

        if (sortOrder?.ToLower() == "asc")
        {
            allArtworks = allArtworks.OrderBy(orderBy);
        } else
        {
            allArtworks = allArtworks.OrderByDescending(orderBy);
        }
        #endregion

        #region paging
        var result = await ToPaginationAsync(allArtworks, page, pageSize);
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
