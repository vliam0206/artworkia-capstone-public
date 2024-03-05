using Application.Services.Abstractions;
using CoenM.ImageHash;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    private readonly IClaimService _claimService;

    public ImageRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext)
    {
        _claimService = claimService;
    }

    public async Task<List<Image>> GetImagesDuplicateAsync(Guid imageId)
    {
        var image = _dbContext.Images.Where(x => x.Id == imageId).FirstOrDefault()!;
        var artworkOfImage = _dbContext.Artworks.Where(x => x.Id == image.ArtworkId).FirstOrDefault();
        var createdByOfArtwork = artworkOfImage.CreatedBy;
        //x.Artwork.State == Domain.Enums.StateEnum.Accepted
        var result = await _dbContext.Images.Where(x => x.Artwork.CreatedBy != createdByOfArtwork 
        ).ToListAsync();
        var result2 = result.Where(x => CompareHash.Similarity(x.ImageHash.GetValueOrDefault(), image.ImageHash.GetValueOrDefault()) > 95).ToList();
        foreach (var item in result2)
        {
            Console.WriteLine(item.ImageName + ": " + CompareHash.Similarity(item.ImageHash.GetValueOrDefault(), image.ImageHash.GetValueOrDefault()));
        }
        return result2;
    }
}
