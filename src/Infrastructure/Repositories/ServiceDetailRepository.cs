using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;

namespace Infrastructure.Repositories;
public class ServiceDetailRepository : IServiceDetailRepository
{
    private readonly AppDBContext _dbContext;

    public ServiceDetailRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddServiceDetailAsync(ServiceDetail serviceDetail)
    {
        await _dbContext.ServiceDetails.AddAsync(serviceDetail);
    }
}
