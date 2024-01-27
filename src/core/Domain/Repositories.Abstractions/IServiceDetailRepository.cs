using Domain.Entitites;

namespace Domain.Repositories.Abstractions;
public interface IServiceDetailRepository
{
    Task AddServiceDetailAsync(ServiceDetail serviceDetail);
}
