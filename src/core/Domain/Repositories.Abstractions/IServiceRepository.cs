using Domain.Entitites;

namespace Domain.Repositories.Abstractions;
public interface IServiceRepository : IGenericRepository<Service>
{
    Task<Service?> GetServiceByIdAsync(Guid id);
    Task<List<Service>?> GetServicesByAccountIdAsync(Guid accountId);
}
