using Application.Commons;
using Application.Filters;
using Application.Models;
using Domain.Entities.Commons;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;

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
    Task<PagedList<AccountVM>> GetAccountsAsync(AccountCriteria criteria);
    Task<List<Account>> GetDeletedAccountsAsync();
    Task UpdateAccountAsync(Account account);
    Task<PagedList<HiredAccountVM>> GetHiredAccountAsync(PagedCriteria pagedCriteria);
    Task EditAvatarAsync(Guid accountId, IFormFile avatar);
}
