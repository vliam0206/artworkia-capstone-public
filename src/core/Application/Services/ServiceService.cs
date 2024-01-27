using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class ServiceService : IServiceService
{
    private static readonly string PARENT_FOLDER = "Service";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFirebaseService _firebaseService;

    public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IFirebaseService firebaseService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _firebaseService = firebaseService;
    }

    public async Task<List<ServiceVM>> GetAllServicesAsync()
    {
        var listService = await _unitOfWork.ServiceRepository.GetAllUndeletedAsync();
        var listServiceVM = _mapper.Map<List<ServiceVM>>(listService);    
        return listServiceVM;
    }

    public async Task<ServiceVM?> GetServiceByIdAsync(Guid serviceId)
    {
        var service = await _unitOfWork.ServiceRepository.GetServiceByIdAsync(serviceId);
        if (service == null)
        {
            throw new NullReferenceException("Service does not exist");
        }
        if (service.DeletedOn != null)
        {
            throw new Exception("Service has been deleted");
        }
        var serviceVM = _mapper.Map<ServiceVM>(service);    
        return serviceVM;
    }

    public async Task<List<ServiceVM>> GetServicesByAccountIdAsync(Guid accountId)
    {
        var listService = await _unitOfWork.ServiceRepository.GetServicesByAccountIdAsync(accountId);
        var listServiceVM = _mapper.Map<List<ServiceVM>>(listService);
        return listServiceVM;
    }

    public async Task<ServiceVM> AddServiceAsync(ServiceModel serviceModel)
    {
        foreach (var artworkId in serviceModel.ArtworkReference)
        {
            var artworkExistInDb = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
            if (artworkExistInDb == null || artworkExistInDb.DeletedOn != null)
            {
                throw new NullReferenceException("Artwork does not exist or has been deleted");
            }
        }

        var newService = _mapper.Map<Service>(serviceModel);
        string newThumbnailName = newService.Id + "_t";
        string folderName = $"{PARENT_FOLDER}/{newService.Id}/Thumbnail";

        // them thumbnail image vao firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(serviceModel.Thumbnail, newThumbnailName, folderName);
        if (url == null)
            throw new Exception("Cannot upload thumbnail image to firebase!");
        newService.Thumbnail = url;

        await _unitOfWork.ServiceRepository.AddAsync(newService);
        foreach (Guid artworkId in serviceModel.ArtworkReference)
        {
            ServiceDetail serviceDetail = new()
            {
                ArtworkId = artworkId,
                ServiceId = newService.Id
            };
            await _unitOfWork.ServiceDetailRepository.AddServiceDetailAsync(serviceDetail);
        }
        await _unitOfWork.SaveChangesAsync();

        var serviceVM = _mapper.Map<ServiceVM>(newService);
        return serviceVM;
    }

    public async Task DeleteServiceAsync(Guid serviceId)
    {
        var service = await _unitOfWork.ServiceRepository.GetByIdAsync(serviceId);
        if (service == null)
        {
            throw new NullReferenceException("Service does not exist");
        }
        _unitOfWork.ServiceRepository.SoftDelete(service);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateServiceAsync(Guid serviceId, ServiceEM serviceEM)
    {
        var oldService = await _unitOfWork.ServiceRepository.GetByIdAsync(serviceId);
        if (oldService == null)
        {
            throw new NullReferenceException("Service does not exist");
        }
        string newThumbnailName = serviceId + "_t";
        string folderName = $"{PARENT_FOLDER}/{serviceId}/Thumbnail";

        // them thumbnail image vao firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(serviceEM.Thumbnail, newThumbnailName, folderName);
        if (url == null)
            throw new Exception("Cannot upload thumbnail image to firebase!");

        oldService.Thumbnail = url;
        oldService.ServiceName = serviceEM.ServiceName;
        oldService.Description = serviceEM.Description;
        oldService.DeliveryTime = serviceEM.DeliveryTime;
        oldService.NumberOfConcept = serviceEM.NumberOfConcept;
        oldService.NumberOfRevision = serviceEM.NumberOfRevision;
        oldService.StartingPrice = serviceEM.StartingPrice;
        await _unitOfWork.SaveChangesAsync();
    }
}
