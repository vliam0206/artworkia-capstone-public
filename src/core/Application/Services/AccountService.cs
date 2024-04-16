using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class AccountService : IAccountService
{
    private static readonly string PARENT_FOLDER = "Account";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;
    private readonly IFirebaseService _firebaseService;
    private readonly IMapper _mapper;

    public AccountService(
        IUnitOfWork unitOfWork,
        IClaimService claimService,
        IFirebaseService firebaseService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
        _firebaseService = firebaseService;
        _mapper = mapper;
    }

    public async Task<Account?> CheckLoginAsync(string username, string password)
    {
        var account = await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Username.Equals(username));
        if (account != null && password.Verify(account.Password!))
        {
            return account;
        }
        return null;
    }

    public async Task<AccountVM> GetAccountByIdAsync(Guid accountId)
    {
        Guid? loginId = _claimService.GetCurrentUserId;

        var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId) 
            ?? throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        if (account.DeletedOn != null)
        {
            throw new KeyNotFoundException("Tài khoản này đã bị xóa.");
        }

        // check if user is logged in
        if (loginId != null)
        {
            // check if account is blocking or blocked
            if (await _unitOfWork.BlockRepository.IsBlockedOrBlockingAsync(loginId.Value, accountId))
            {
                throw new BadHttpRequestException("Không tìm thấy tài khoản vì chặn hoặc bị chặn.");
            }
        }

        var accountVM = _mapper.Map<AccountVM>(account);
        return accountVM;
    }

    public async Task<AccountModerationVM> GetAccountByIdForModerationAsync(Guid accountId)
    {
        var account = await _unitOfWork.AccountRepository.GetAccountDetailAsync(accountId);
        if (account == null)
        {
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        }

        var accountVM = _mapper.Map<AccountModerationVM>(account);
        return accountVM;
    }

    public async Task<PagedList<AccountVM>> GetAccountsAsync(AccountCriteria criteria)
    {
        var listAccount = await _unitOfWork.AccountRepository.GetAllAccountsAsync(
                       criteria.Keyword, criteria.SortColumn, criteria.SortOrder,
                                  criteria.PageNumber, criteria.PageSize);
        var listAccountVM = _mapper.Map<PagedList<AccountVM>>(listAccount);
        return listAccountVM;
    }

    public async Task<PagedList<AccountModerationVM>> GetAccountsForModerationAsync(AccountCriteria criteria)
    {
        var listAccount = await _unitOfWork.AccountRepository.GetAllAccountsForModerationAsync(
                       criteria.Keyword, criteria.SortColumn, criteria.SortOrder,
                                  criteria.PageNumber, criteria.PageSize);
        var listAccountModerationVM = _mapper.Map<PagedList<AccountModerationVM>>(listAccount);
        return listAccountModerationVM;
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
            throw new BadHttpRequestException(errMsg);
        }
        // account valid -> add new account in db
        if (account.Password != null)
        {
            account.Password = account.Password.Hash(); // hash the password
        }
        await _unitOfWork.AccountRepository.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAccountAsync(Guid id, AccountModel model)
    {
        var oldAcc = await _unitOfWork.AccountRepository.GetByIdAsync(id);
        if (oldAcc == null)
        {
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        }
        var account = _mapper.Map<AccountModel, Account>(model, oldAcc);

        var errMsg = await ValidateAccountAsync(account);
        if (!string.IsNullOrEmpty(errMsg))
        {
            throw new BadHttpRequestException(errMsg);
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
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        }
        if (account.DeletedOn != null)
        {
            throw new KeyNotFoundException("Tài khoản này đã bị xóa.");
        }
        // soft delete account in db
        _unitOfWork.AccountRepository.SoftDelete(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task EditPasswordAsync(Guid accountId, string oldPassword, string newPassword)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);
        if (account == null)
        {
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        }
        // check authorized
        if (account.Id != _claimService.GetCurrentUserId)
        {
            throw new UnauthorizedAccessException("Bạn không có quyền sử dụng chức năng này.");
        }
        // check old password
        if (oldPassword.Verify(account.Password!))
        {
            // change password
            account.Password = newPassword.Hash();
            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            throw new BadHttpRequestException("Mật khẩu cũ không đúng.");
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
            errMsg = "Username đã tồn tại\n";
            tmpAcc = null;
        }
        tmpAcc = await _unitOfWork.AccountRepository
            .GetSingleByConditionAsync(x => x.Email.Equals(account.Email));
        if (tmpAcc != null && tmpAcc.Id != account.Id)
        {
            errMsg += "Email đã tồn tại.";
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
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        }
        if (account.DeletedOn == null)
        {
            throw new KeyNotFoundException("Tài khoản này đã bị xóa.");
        }
        account.DeletedOn = null;
        account.DeletedBy = null;
        _unitOfWork.AccountRepository.Update(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<PagedList<HiredAccountVM>> GetHiredAccountAsync(PagedCriteria pagedCriteria)
    {
        var hiredAccounts = await _unitOfWork.AccountRepository
            .GetAllHiredAccountsAsync(pagedCriteria.PageNumber, pagedCriteria.PageSize);
        var viewmodels = _mapper.Map<PagedList<HiredAccountVM>>(hiredAccounts);
        return viewmodels;
    }

    public async Task EditAvatarAsync(Guid accountId, IFormFile avatar)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId) 
            ?? throw new KeyNotFoundException("Không tìm thấy tài khoản.");

        // change avatar
        string newAvatarName = accountId + "_ava";
        string folderName = $"{PARENT_FOLDER}/Avatar";
        //upload hinh anh len firebase, lay url
        var url = await _firebaseService.UploadFileToFirebaseStorageNoExtension(avatar, newAvatarName, folderName) 
            ?? throw new KeyNotFoundException("Lỗi khi tải ảnh đại diện lên đám mây.");
        account.Avatar = url;
        _unitOfWork.AccountRepository.Update(account);
        await _unitOfWork.SaveChangesAsync();
    }

}
