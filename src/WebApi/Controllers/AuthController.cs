using Application.Commons;
using Application.Services.Abstractions;
using Application.Services.Authentication;
using AutoMapper;
using Domain.Entitites;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.ViewModels;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IUserTokenService _userTokenService;
    private readonly ITokenHandler _tokenHandler;
    private readonly AppConfiguration _appConfiguration;
    private readonly IMapper _mapper;

    public AuthController(IAccountService accountService,
        IUserTokenService userTokenService,
        ITokenHandler tokenHandler,
        AppConfiguration appConfiguration,
        IMapper mapper)
    {
        _accountService = accountService;
        _userTokenService = userTokenService;
        _tokenHandler = tokenHandler;
        _appConfiguration = appConfiguration;
        _mapper = mapper;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        if (loginModel == null)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "User is not exist!"
            });
        }
        // check whether account exist in db
        var account = await _accountService.CheckLoginAsync(loginModel.Username, loginModel.Password);
        if (account == null)
        {
            return Unauthorized(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Wrong username/password."
            });
        }
        if (account.DeletedOn != null)
        {
            return Unauthorized(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Account has been invalid."
            });
        }
        // login success - issue (access token, refresh token) pair
        var issuedDate = DateTime.UtcNow.ToLocalTime();
        (var accessToken, var ATid) = _tokenHandler.CreateAccessToken(account, issuedDate);
        (var refreshToken, var RTid) = _tokenHandler.CreateRefreshToken(account, issuedDate);
        var token = new UserToken
        {
            UserId = account.Id,
            ATid = ATid,
            AccessToken = accessToken,
            RTid = RTid,
            RefreshToken = refreshToken,
            IssuedDate = issuedDate,
            ExpiredDate = issuedDate.AddHours(_appConfiguration.JwtConfiguration.RTExpHours),
        };
        await _userTokenService.SaveTokenAsync(token);

        return Ok(new ApiResponse
        {
            IsSuccess = true,
            Result = new TokenVM
            {
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
                UserId = account.Id,
                Username = account.Username,
                Email = account.Email,
                Fullname = account.Fullname
            }
        });
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenModel model)
    {
        try
        {
            var tokenModel = await _tokenHandler.ValidateRefreshTokenAsync(model.RefreshToken);
            if (tokenModel == null)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Invalid refresh token."
                });
            }
            return Ok(new ApiResponse
            {
                IsSuccess = true,
                Result = tokenModel
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

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var ATid = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti);
        if (ATid == null)
        {
            return Unauthorized(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Invalid token."
            });
        }
        var userToken = await _userTokenService.GetTokenByATidAsync(Guid.Parse(ATid.Value));
        if (userToken == null)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Access token Id not found!"
            });
        }
        // token valid -> update in db
        userToken.IsRevoked = true;
        await _userTokenService.UpdateTokenAsync(userToken);

        return Ok(new ApiResponse { IsSuccess = true });
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (model == null)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Invalid input."
            });
        }
        try
        {
             await _accountService.CreateAccountAsync(_mapper.Map<Account>(model));
            return Ok(new ApiResponse { IsSuccess = true });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
        
    }
}