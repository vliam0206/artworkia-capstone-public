using Application.Models;

namespace Application.Services.Abstractions;

public interface IServiceService
{
    Task<ServiceVM?> GetServiceByIdAsync(Guid serviceId);
    Task<List<ServiceVM>> GetAllServicesAsync();
    Task DeleteServiceAsync(Guid serviceId);
    Task<ServiceVM> AddServiceAsync(ServiceModel serviceModel);
    Task UpdateServiceAsync(Guid serviceId, ServiceEM serviceEM);
}
