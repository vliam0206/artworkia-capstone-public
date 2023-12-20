using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class AssetService : IAssetService
{
    private readonly IUnitOfWork _unitOfWork;

    public AssetService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Asset>> GetAllAssetsAsync()
    {
        return await _unitOfWork.AssetRepository.GetAllAsync();
    }

    public async Task<Asset?> GetAssetByIdAsync(Guid assetId)
    {
        return await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
    }

    public Task AddAssetAsync(Asset asset)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAssetAsync(Asset asset)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAssetAsync(Guid assetId)
    {
        var result = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (result == null)
            throw new Exception("Cannot found asset!");
        _unitOfWork.AssetRepository.SoftDelete(result);
    }

    public Task UpdateAssetAsync(Asset asset)
    {
        throw new NotImplementedException();
    }
}
