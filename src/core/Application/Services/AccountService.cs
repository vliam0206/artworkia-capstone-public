using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public AccountService(
        IUnitOfWork unitOfWork, 
        IClaimService claimService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
        _mapper = mapper;
    }    

    public async Task<Account?> CheckLoginAsync(string username, string password)
    {        
        var account =  await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Username.Equals(username));
        if (account != null && password.Verify(account.Password!))
        {
            return account;
        }
        return null;
    }

    public async Task<Account?> GetAccountByIdAsync(Guid accountId)
        => await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

    public async Task<Account?> GetAccountByUsernameAsync(string username)
        => await _unitOfWork.AccountRepository
                .GetSingleByConditionAsync(x => x.Username.Equals(username));

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
        if (account.Password != null)
        {
            account.Password = account.Password.Hash(); // hash the password
        }
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
        if (account.DeletedOn != null)
        {
            throw new Exception("This account has been deleted already.");
        }
        // soft delete account in db
        _unitOfWork.AccountRepository.SoftDelete(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task EditPasswordAsync(Guid accountId , string oldPassword, string newPassword)
    {        
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);
        if (account == null)
        {
            throw new ArgumentException("Account id not found.");
        }
        // check authorized
        if (account.Id != _claimService.GetCurrentUserId)
        {
            throw new UnauthorizedAccessException("You are not allow to access this function.");
        }
        // check old password
        if (oldPassword.Verify(account.Password!))
        {
            // change password
            account.Password = newPassword.Hash();
            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();
        } else
        {
            throw new Exception("Old password is not correct.");
        }
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

    public async Task<Account?> GetAccountByEmailAsync(string email)
        => await _unitOfWork.AccountRepository
                .GetSingleByConditionAsync(x => x.Email.Equals(email));

    public async Task UndeleteAccountAsync(Guid id)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
        if (account == null)
        {
            throw new ArgumentException("Account id not found.");
        }
        if (account.DeletedOn == null)
        {
            throw new Exception("This account has not been deleted.");
        }
        account.DeletedOn = null;
        account.DeletedBy = null;
        _unitOfWork.AccountRepository.Update(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<PagedList<AccountVM>> GetAccountsAsync(AccountCriteria criteria)
    {
        var listAccount = await _unitOfWork.AccountRepository.GetAllAccountsAsync(
                       criteria.Keyword, criteria.SortColumn, criteria.SortOrder, 
                                  criteria.PageNumber, criteria.PageSize);
        var listAccountVM = _mapper.Map<PagedList<AccountVM>>(listAccount);
        return listAccountVM;
    }

    public async Task<PagedList<HiredAccountVM>> GetHiredAccountAsync(PagedCriteria pagedCriteria)
    {
        var hiredAccounts = await _unitOfWork.AccountRepository
            .GetAllHiredAccountsAsync(pagedCriteria.PageNumber, pagedCriteria.PageSize);
        var viewmodels = _mapper.Map<PagedList<HiredAccountVM>>(hiredAccounts);
        return viewmodels;
    }
}
