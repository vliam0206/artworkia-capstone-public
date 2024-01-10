using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class ServiceService : IServiceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ServiceVM>> GetAllServicesAsync()
    {
        var listService = await _unitOfWork.ServiceRepository.GetAllUndeletedAsync();
        var listServiceVM = _mapper.Map<List<ServiceVM>>(listService);    
        return listServiceVM;
    }

    public async Task<ServiceVM?> GetServiceByIdAsync(Guid serviceId)
    {
        var service = await _unitOfWork.ServiceRepository.GetByIdAsync(serviceId);
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
    public async Task<ServiceVM> AddServiceAsync(ServiceModel serviceModel)
    {
        var newService = _mapper.Map<Service>(serviceModel);
        await _unitOfWork.ServiceRepository.AddAsync(newService);
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
        oldService.ServiceName = serviceEM.ServiceName;
        oldService.Description = serviceEM.Description;
        oldService.DeliveryTime = serviceEM.DeliveryTime;
        oldService.NumberOfConcept = serviceEM.NumberOfConcept;
        oldService.NumberOfRevision = serviceEM.NumberOfRevision;
        oldService.StartingPrice = serviceEM.StartingPrice;
        oldService.CoverLocation = serviceEM.CoverLocation;
        await _unitOfWork.SaveChangesAsync();
    }
}
