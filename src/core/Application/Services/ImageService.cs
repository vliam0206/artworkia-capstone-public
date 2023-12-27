using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;

    public ImageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Image>> GetAllImagesAsync()
    {
        return await _unitOfWork.ImageRepository.GetAllAsync();
    }

    public Task<Image?> GetImageByIdAsync(Guid imageId)
    {
        return _unitOfWork.ImageRepository.GetByIdAsync(imageId);
    }

    public async Task AddImageAsync(Image image)
    {
        await _unitOfWork.ImageRepository.AddAsync(image);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task AddRangeImageAsync(Image image)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteImageAsync(Guid imageId)
    {
        var result = await _unitOfWork.ImageRepository.GetByIdAsync(imageId);
        if (result == null)
            throw new Exception("Cannot found image!");
        _unitOfWork.ImageRepository.Delete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateImageAsync(Image image)
    {
        _unitOfWork.ImageRepository.Update(image);
        await _unitOfWork.SaveChangesAsync();
    }
}
