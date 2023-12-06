using Domain.Repositories.Abstractions;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Commons;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _dbContext;
    private readonly IAccountRepository _accountRepository;

    public UnitOfWork(AppDBContext dbContext, 
                      IAccountRepository accountRepository)
    {
        _dbContext = dbContext;
        _accountRepository = accountRepository;
    }

    public IAccountRepository AccountRepository => _accountRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}
