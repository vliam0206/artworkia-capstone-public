using Application.Commons;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AccountService(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
    }

    public async Task<Account?> GetAccountByIdAsync(Guid accountId)
        => await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

    public async Task<Account?> GetAccountByUsernamesync(string username)
        => await _unitOfWork.AccountRepository
                .GetSingleByConditionAsync(x => x.Username.Equals(username));

    public async Task<List<Account>> GetAccountsAsync()
    {
        var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
        return accounts.Where(x => x.DeletedOn == null)
                       .OrderByDescending(x => x.CreatedOn).ToList();
    }

    public async Task<List<Account>> GetDeletedAccountsAsync()
    {
        var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
        return accounts.Where(x => x.DeletedOn != null)
                       .OrderByDescending(x => x.CreatedOn).ToList();
    }

    public async Task CreateAccountAsync(Account account)
    {
        // check if username, email duplicated
        var errMsg = await ValidateAccountAsync(account);
        if (!string.IsNullOrEmpty(errMsg))
        {
            throw new Exception(errMsg);
        }
        // account valid -> add new account in db
        account.Password = account.Password.Hash(); // hash the password
        await _unitOfWork.AccountRepository.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAccountAsync(Account account)
    {
        var errMsg = await ValidateAccountAsync(account);
        if (!string.IsNullOrEmpty(errMsg))
        {
            throw new Exception(errMsg);
        }
        // account valid -> update account in db
        _unitOfWork.AccountRepository.Update(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAccountAsync(Guid id)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
        if (account == null)
        {
            throw new ArgumentException("Account id not found.");
        }
        // soft delete account in db
        _unitOfWork.AccountRepository.SoftDelete(account);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<string> ValidateAccountAsync(Account account)
    {
        // check if username, email duplicated
        string errMsg = "";
        var tmpAcc = await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Username.Equals(account.Username));
        if (tmpAcc != null && tmpAcc.Id != account.Id)
        {
            errMsg = "Invalid! Username is duplicated.\n";
            tmpAcc = null;
        }
        tmpAcc = await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Email.Equals(account.Email));
        if (tmpAcc != null && tmpAcc.Id != account.Id)
        {
            errMsg += "Invalid! Email is duplicated.";
        }
        return errMsg;
    }
}
