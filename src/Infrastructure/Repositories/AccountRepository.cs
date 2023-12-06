using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;

public class AccountRepository : GenericAuditableRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDBContext dBContext, IClaimService claimService) 
        : base(dBContext, claimService)
    {
    }
}
