using Application.Commons;
using Application.Services.Abstractions;
using Application.Services.Authentication;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{    
    private readonly IAccountService _accountService;
    private readonly ITokenHandler _tokenHandler;
    private readonly AppConfiguration _appConfig;
    private readonly IMapper _mapper;

    public AuthController(IAccountService accountService, 
        ITokenHandler tokenHandler,
        AppConfiguration appConfiguration,
        IMapper mapper)
    {
        _accountService = accountService;
        _tokenHandler = tokenHandler;
        _appConfig = appConfiguration;
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
        // login success - issue (access token, refresh token) pair        
        var accessToken = _tokenHandler.CreateToken(NewId.Next().ToGuid() ,account, 
                        _appConfig.JwtConfiguration.SecretKey, DateTime.UtcNow.ToLocalTime(), 3);

        return Ok(new ApiResponse
        {
            IsSuccess = true,
            Result = new
            {
                AccessToken = accessToken,
                Account = _mapper.Map<AccountVM>(account)
            }
        });
    }
}
