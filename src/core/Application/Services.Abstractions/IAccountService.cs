using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IAccountService
{
    Task<Account?> CheckLoginAsync(string username, string password);
    Task CreateAccountAsync(Account account);
    Task<Account?> GetAccountByIdAsync(Guid accountId);
    Task<Account?> GetAccountByUsernamesync(string username);
}
