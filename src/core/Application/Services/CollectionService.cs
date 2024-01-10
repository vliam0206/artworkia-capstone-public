using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class CollectionService : ICollectionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICollectionRepository _collectionRepository;
    private readonly IMapper _mapper;

    public CollectionService(IUnitOfWork unitOfWork, IMapper mapper,
        ICollectionRepository collectionRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _collectionRepository = collectionRepository;
    }

    public Task AddArtworkToCollectionAsync(Bookmark bookmark)
    {
        throw new NotImplementedException();
    }

    public Task CreateCollectionAsync(Collection collection)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCollectionAsync(Guid collectionId)
    {
        var collection = await _unitOfWork.CollectionRepository.GetByIdAsync(collectionId);
        if (collection == null)
        {
            throw new ArgumentException("Collection Id not found!");
        }
        _unitOfWork.CollectionRepository.Delete(collection);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<Collection>> GetAllCollectionsOfAccountAsync(Guid accountId)
    {
        return await _unitOfWork.CollectionRepository
                                .GetAllCollectionsOfAccountWithArtworksAsync(accountId);
    }

    public async Task<Collection?> GetCollectionDetailAsync(Guid collectionId)
    {
        return await _unitOfWork.CollectionRepository
                                .GetCollectionWithArtworksAsync(collectionId);
    }

    public Task UpdateColelctionAsync(Collection newCollection)
    {
        throw new NotImplementedException();
    }
}
