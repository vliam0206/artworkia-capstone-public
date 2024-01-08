﻿using Application.Services.Abstractions;
using Application.Services.Authentication;
using AutoMapper;
using Domain.Entitites;
using Domain.Models;
using Firebase.Auth;
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
    private readonly IMapper _mapper;
    private readonly IThirdAuthenticationService _thirdAuthenticationService;

    public AuthController(IAccountService accountService,
        IUserTokenService userTokenService,
        ITokenHandler tokenHandler,
        IMapper mapper,
        IThirdAuthenticationService thirdAuthenticationService)
    {
        _accountService = accountService;
        _userTokenService = userTokenService;
        _tokenHandler = tokenHandler;
        _mapper = mapper;
        _thirdAuthenticationService = thirdAuthenticationService;
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
        var accessToken = _tokenHandler.CreateAccessToken(account, issuedDate);
        var refreshToken = _tokenHandler.CreateRefreshToken(account, issuedDate);
        var token = new UserToken
        {
            UserId = account.Id,
            ATid = accessToken.TokenId,
            AccessToken = accessToken.Token,
            RTid = refreshToken.TokenId,
            RefreshToken = refreshToken.Token,
            IssuedDate = issuedDate,
            ExpiredDate = issuedDate.AddHours(24*7),
        };
        await _userTokenService.SaveTokenAsync(token);

        return Ok(new TokenVM
        {
            AccessToken = token.AccessToken,
            RefreshToken = token.RefreshToken,
            UserId = account.Id,
            Username = account.Username,
            Email = account.Email,
            Fullname = account.Fullname
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
                return BadRequest(new ApiResponse { ErrorMessage = "Invalid refresh token." });
            }
            return Ok(tokenModel);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var ATid = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti);
        if (ATid == null)
        {
            return Unauthorized(new ApiResponse { ErrorMessage = "Invalid token." });
        }
        var userToken = await _userTokenService.GetTokenByATidAsync(Guid.Parse(ATid.Value));
        if (userToken == null)
        {
            return BadRequest(new ApiResponse { ErrorMessage = "Access token Id not found!" });
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
            return BadRequest(new ApiResponse { ErrorMessage = "Invalid input." });
        }
        try
        {
            await _accountService.CreateAccountAsync(_mapper.Map<Account>(model));
            return Ok(new ApiResponse { IsSuccess = true });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
        
    }

    [HttpPost("login-google")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] ThirdAuthenticationModel externalAuthDto)
    {
        var payload = await _thirdAuthenticationService.VerifyGoogleToken(externalAuthDto);
        if (payload == null)
        {
            return BadRequest("Invalid external authentication!");
        }
        var newAccount = new Account
        {
            Email = payload.Email,
            Fullname = payload.Name,
            Username = payload.Email
        };
        var account = await _accountService.GetAccountByEmailAsync(newAccount.Email);
        if (account == null)
        {
            account = newAccount;
            await _accountService.CreateAccountAsync(account);
        }

        // login success - issue (access token, refresh token) pair
        var issuedDate = DateTime.UtcNow.ToLocalTime();
        var accessToken = _tokenHandler.CreateAccessToken(account, issuedDate);
        var refreshToken = _tokenHandler.CreateRefreshToken(account, issuedDate);
        var token = new UserToken
        {
            UserId = account.Id,
            ATid = accessToken.TokenId,
            AccessToken = accessToken.Token,
            RTid = refreshToken.TokenId,
            RefreshToken = refreshToken.Token,
            IssuedDate = issuedDate,
            ExpiredDate = issuedDate.AddHours(24 * 7),
        };
        await _userTokenService.SaveTokenAsync(token);

        return Ok(new TokenVM
        {
            AccessToken = token.AccessToken,
            RefreshToken = token.RefreshToken,
            UserId = account.Id,
            Username = account.Username,
            Email = account.Email,
            Fullname = account.Fullname
        });
    }
}