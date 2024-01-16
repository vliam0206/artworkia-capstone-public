using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ServiceRepository : GenericAuditableRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }

    public async Task<Service?> GetServiceByIdAsync(Guid id)
    {
        return await _dbContext.Services
            .Include(x => x.Account)
            .Include(x => x.ServiceDetails)
            .Include(x => x.CategoryServiceDetails)
                .ThenInclude(x => x.Category)
            .SingleOrDefaultAsync(x => x.Id == id && x.DeletedOn == null);
    }
}
