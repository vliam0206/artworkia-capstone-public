using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IAccountService
{
    Task<Account?> CheckLoginAsync(string username, string password);
    Task CreateAccountAsync(Account account);
    Task DeleteAccountAsync(Guid id);
    Task UndeleteAccountAsync(Guid id);
    Task EditPasswordAsync(Guid accountId, string oldPassword, string newPassword);
    Task<Account?> GetAccountByEmailAsync(string email);
    Task<Account?> GetAccountByIdAsync(Guid accountId);
    Task<Account?> GetAccountByUsernameAsync(string username);
    Task<List<Account>> GetAccountsAsync();
    Task<List<Account>> GetDeletedAccountsAsync();
    Task UpdateAccountAsync(Account account);
}
