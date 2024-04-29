using Application.Commons;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Authentication;
using AutoMapper;
using Domain.Entitites;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Utils;

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
    private readonly AppConfiguration _appConfiguration;
    private readonly IClaimService _claimService;

    public AuthController(IAccountService accountService,
        IUserTokenService userTokenService,
        ITokenHandler tokenHandler,
        IMapper mapper,
        IThirdAuthenticationService thirdAuthenticationService,
        AppConfiguration appConfiguration,
        IClaimService claimService)
    {
        _accountService = accountService;
        _userTokenService = userTokenService;
        _tokenHandler = tokenHandler;
        _mapper = mapper;
        _thirdAuthenticationService = thirdAuthenticationService;
        _appConfiguration = appConfiguration;
        _claimService = claimService;
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
                ErrorMessage = "Thông tin không hợp lệ!"
            });
        }
        // check whether account exist in db
        var account = await _accountService.CheckLoginAsync(loginModel.Username, loginModel.Password);
        if (account == null)
        {
            return Unauthorized(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng."
            });
        }
        if (account.DeletedOn != null)
        {
            return Unauthorized(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Tài khoản của bạn đã bị vô hiệu hóa."
            });
        }
        // login success - issue (access token, refresh token) pair
        var issuedDate = CurrentTime.GetCurrentTime;
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
            ExpiredDate = issuedDate.AddHours(_appConfiguration.JwtConfiguration.RTExpHours),
        };
        await _userTokenService.SaveTokenAsync(token);

        return Ok(new TokenVM
        {
            AccessToken = token.AccessToken,
            RefreshToken = token.RefreshToken,
            UserId = account.Id,
            Username = account.Username,
            Email = account.Email,
            Fullname = account.Fullname,
            Avatar = account.Avatar,
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
                return BadRequest(new ApiResponse { ErrorMessage = "Refresh token không hợp lệ." });
            }
            return Ok(tokenModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var ATid = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti);
        if (ATid == null)
        {
            return Unauthorized(new ApiResponse { ErrorMessage = "Token không hợp lệ." });
        }
        var userToken = await _userTokenService.GetTokenByATidAsync(Guid.Parse(ATid.Value));
        if (userToken == null)
        {
            return BadRequest(new ApiResponse { ErrorMessage = "Không tìm thấy Access token" });
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
            return BadRequest(new ApiResponse { ErrorMessage = "Thông tin không hợp lệ." });
        }
        try
        {
            await _accountService.CreateAccountAsync(_mapper.Map<Account>(model));
            return Ok(new ApiResponse { IsSuccess = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }

    }

    [HttpPost("login-google")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] ThirdAuthenticationModel externalAuthDto)
    {
        try
        {
            var payload = await _thirdAuthenticationService.VerifyGoogleToken(externalAuthDto);
            if (payload == null)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Xác thực bên ngoài (payload) không hợp lệ." });
            }
            var account = await _accountService.GetAccountByEmailAsync(payload.Email);
            if (account == null)
            {
                account = new Account
                {
                    Email = payload.Email,
                    Fullname = payload.Name,
                    Username = payload.Email,
                    Avatar = payload.Picture
                };
                await _accountService.CreateAccountAsync(account);
            }

            // login success - issue (access token, refresh token) pair
            var issuedDate = CurrentTime.GetCurrentTime;
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
        }catch (ArgumentException ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        } catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("validate-access-token")]
    [Authorize]
    public IActionResult ValidateAccessToken()
    {
        return Ok(new
        {
            UserId = _claimService.GetCurrentUserId,
            UserName = _claimService.GetCurrentUserName,
            Role = _claimService.GetCurrentRole
        });
    }

}