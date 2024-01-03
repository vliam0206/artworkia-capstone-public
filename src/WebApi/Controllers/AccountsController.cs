using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public AccountsController(IAccountService accountService,
        IMapper mapper,
        IClaimService claimService)
    {
        _accountService = accountService;
        _mapper = mapper;
        _claimService = claimService;
    }
    // GET: api/accounts
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<AccountVM>>> GetAccounts()
    {
        try
        {
            var accounts = await _accountService.GetAccountsAsync();

            return Ok(_mapper.Map<List<AccountVM>>(accounts));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    // GET: api/accounts/5
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<AccountVM>> GetAccount(Guid id)
    {
        // check authorize
        if (!CheckAuthorize(id))
        {
            return Forbid();
        }
        // get account
        var account = await _accountService.GetAccountByIdAsync(id);
        if (account == null || account.DeletedOn != null)
        {
            return NotFound(new ApiResponse { ErrorMessage = "Account id not found!" });
        }
        return Ok(_mapper.Map<AccountVM>(account));
    }

    // PUT: api/accounts/5    
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutAccount(Guid id, AccountModel model)
    {
        // check authorize
        if (!CheckAuthorize(id))
        {
            return Forbid();
        }
        try
        {
            var oldAcc = await _accountService.GetAccountByIdAsync(id);
            if (oldAcc == null || oldAcc.DeletedOn != null)
            {
                return NotFound(new ApiResponse { ErrorMessage = "Account id not found." });
            }
            var account = _mapper.Map<AccountModel, Account>(model, oldAcc);
            await _accountService.UpdateAccountAsync(account);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // POST: api/accounts    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Account>> PostAccount(RegisterModel model)
    {
        var account = _mapper.Map<Account>(model);
        try
        {
            await _accountService.CreateAccountAsync(account);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }

        return CreatedAtAction("GetAccount", new { id = account.Id }, _mapper.Map<AccountVM>(account));
    }

    // DELETE: api/accounts/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        try
        {
            await _accountService.DeleteAccountAsync(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // GET: api/accounts/deleted
    [HttpGet("deleted")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<ActionResult<IEnumerable<AccountVM>>> GetDeletedAccounts()
    {
        try
        {
            var accounts = await _accountService.GetDeletedAccountsAsync();

            return Ok(_mapper.Map<List<AccountVM>>(accounts));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    // PUT: api/accounts/{id}/password
    [HttpPut("{id}/password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(Guid id, [FromBody] AccountChangePasswordModel model)
    {
        try
        {
            await _accountService.EditPasswordAsync(id, model.OldPassword, model.NewPassword);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }
    
    private bool CheckAuthorize(Guid accountId)
{
    // check authorize
    var currentRole = _claimService.GetCurrentRole;
    if (!currentRole.Equals(RoleEnum.Moderator.ToString())
        && !currentRole.Equals(RoleEnum.Admin.ToString()))
    {
        if (_claimService.GetCurrentUserId != accountId)
        {
            return false;
        }
    }
    return true;
}
}
