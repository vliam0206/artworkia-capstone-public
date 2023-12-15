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
        var account =  await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Username.Equals(username));
        if (account != null && password.Verify(account.Password))
        {
            return account;
        }
        return null;
        //return await _unitOfWork.AccountRepository
        //    .GetSingleByConditionAsync(x => x.Username.Equals(username)
        //                                    && x.Password.Equals(password));

    }

    public async Task<Account?> GetAccountByIdAsync(Guid accountId)
        => await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

    public async Task<Account?> GetAccountByUsernamesync(string username)
        => await _unitOfWork.AccountRepository
                .GetSingleByConditionAsync(x => x.Username.Equals(username));

    public async Task CreateAccountAsync(Account account)
    {
        // check if username, email duplicated
        string errMsg = "";
        var tmpAcc = await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Username.Equals(account.Username));
        if (tmpAcc != null)
        {
            errMsg = "Invalid! Username is duplicated.\n";
            tmpAcc = null;
        }
        tmpAcc = await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Email.Equals(account.Email));
        if (tmpAcc != null)
        {
            errMsg += "Invalid! Email is duplicated.";
        }
        if (!string.IsNullOrEmpty(errMsg))
        {
            throw new Exception(errMsg);
        }
        // account valid -> add new account in db
        account.Password = account.Password.Hash(); // hash the password
        await _unitOfWork.AccountRepository.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
    }
}
