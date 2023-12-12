using Application.Commons;
using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }    

    public async Task<Account?> CheckLoginAsync(string username, string password)
    {
        //return await _unitOfWork.AccountRepository
        //    .GetSingleByConditionAsync(x => x.Username.Equals(username)
        //                                    && x.Password.Equals(password.Hash()));
        return await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Username.Equals(username)
                                            && x.Password.Equals(password));

    }

    public async Task<Account?> GetAccountByIdAsync(Guid accountId)
        => await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

    public async Task<Account?> GetAccountByUsernamesync(string username)
        => await _unitOfWork.AccountRepository
                .GetSingleByConditionAsync(x => x.Username.Equals(username));
}
