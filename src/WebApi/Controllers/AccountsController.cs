﻿using Application.Filters;
using Application.Services;
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
    private readonly IAssetService _assetService;
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public AccountsController(
        IAccountService accountService,
        IMapper mapper,
        IClaimService claimService,
        IAssetService assetService,
        IServiceService serviceService
        )
    {
        _accountService = accountService;
        _mapper = mapper;
        _claimService = claimService;
        _assetService = assetService;   
        _serviceService = serviceService;
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
    public async Task<ActionResult<AccountVM>> GetAccount(Guid id)
    {
        // get account
        var account = await _accountService.GetAccountByIdAsync(id);
        if (account == null || account.DeletedOn != null)
        {
            return NotFound(new ApiResponse { ErrorMessage = "Account id not found!" });
        }
        return Ok(_mapper.Map<AccountVM>(account));
    }

    [HttpGet("role-enum")]
    public IActionResult GetAccountRoleEnum()
    {
        var roleEnums = Enum.GetValues(typeof(RoleEnum))
            .Cast<RoleEnum>().Select(r => new { Id = (int)r, Name = r.ToString() });
        return Ok(roleEnums);
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


    // GET: /api/accounts/{account_id}/assets
    [HttpGet("{accountId}/assets")]
    public async Task<IActionResult> GetAssetsOfAccount(Guid accountId, [FromQuery] AssetCriteria criteria)
    {
        try
        {
            var results = await _assetService.GetAssetsOfAccountAsync(accountId, criteria);
            if (results == null)
                return NotFound();
            return Ok(results);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    // GET: /api/accounts/{account_id}/services
    [HttpGet("{accountId}/services")]
    public async Task<IActionResult> GetServicesOfAccount(Guid accountId, [FromQuery] ServiceCriteria criteria)
    {
        try
        {
            var listServiceVM = await _serviceService.GetServicesOfAccountAsync(accountId, criteria);
            return Ok(listServiceVM);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }
}
