using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;

namespace Domain.Repositories.Abstractions;

public interface IAccountRepository : IGenericRepository<Account>
{
    Task<IPagedList<Account>> GetAllAccountsAsync(string? keyword, string? sortColumn, string? sortOrder, int page, int pageSize);
}
