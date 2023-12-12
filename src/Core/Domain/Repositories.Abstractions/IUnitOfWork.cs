namespace Domain.Repositories.Abstractions;

public interface IUnitOfWork
{
    public IAccountRepository AccountRepository { get; }
    public IUserTokenRepository UserTokenRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
