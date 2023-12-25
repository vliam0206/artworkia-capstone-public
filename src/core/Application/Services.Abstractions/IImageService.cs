using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface IImageService
{
    Task<Image?> GetImageByIdAsync(Guid imageId);
    Task<List<Image>> GetAllImagesAsync();
    Task AddImageAsync(Image image);
    Task AddRangeImageAsync(Image image);
    Task UpdateImageAsync(Image image);
    Task DeleteImageAsync(Guid imageId);
}
