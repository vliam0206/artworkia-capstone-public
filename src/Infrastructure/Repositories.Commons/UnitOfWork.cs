using Domain.Repositories.Abstractions;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Commons;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _dbContext;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserTokenRepository _userTokenRepository;

    public UnitOfWork(AppDBContext dbContext, 
                      IAccountRepository accountRepository,
                      IUserTokenRepository userTokenRepository)
    {
        _dbContext = dbContext;
        _accountRepository = accountRepository;
        _userTokenRepository = userTokenRepository;
    }

    public IAccountRepository AccountRepository => _accountRepository;
    public IUserTokenRepository UserTokenRepository => _userTokenRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}
