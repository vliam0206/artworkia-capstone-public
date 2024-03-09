﻿using Application.Services.Abstractions;
using CoenM.ImageHash;
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
    private readonly static int MIN_SIMILARITY = 95;
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

    public async Task<List<Image>> GetArtworksDuplicateAsync(Guid artworkId)
    {
        var artwork = await _dbContext.Artworks
            .Include(x => x.Images)
            .Where(x => x.Id == artworkId).FirstOrDefaultAsync();
        if (artwork == null) 
            throw new Exception("Artwork not found");
        var createdByOfArtwork = artwork.CreatedBy;
        //x.Artwork.State == Domain.Enums.StateEnum.Accepted
        var listImage = await _dbContext.Images
            .Include(x => x.Artwork)
            .Where(x => x.Artwork.CreatedBy != createdByOfArtwork).ToListAsync();
        List<Image> result2 = new List<Image>();
        foreach (Image item in listImage)
        {
            foreach (Image image in artwork.Images)
            {
                var similarity = CompareHash.Similarity(item.ImageHash.GetValueOrDefault(), image.ImageHash.GetValueOrDefault());
                if (similarity >= MIN_SIMILARITY)
                {
                    item.Similarity = similarity;
                    result2.Add(item);
                }
                if (result2.Count > 10)
                {
                    break;
                }
            }
        }
        return result2;
    }
}
