using Application.Commons;
using Application.Services.Abstractions;
using Domain.Entitites;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Authentication;

public class TokenHandler : ITokenHandler
{
    private readonly AppConfiguration _appConfig;
    private readonly IAccountService _accountService;

    public TokenHandler(AppConfiguration appConfig,
        IAccountService accountService)
    {
        _appConfig = appConfig;
        _accountService = accountService;
    }

    public string CreateToken(Guid jti, Account user, string secretKey, DateTime issueTime, int expiredHours)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, jti.ToString()),
            new Claim(JwtRegisteredClaimNames.Iss, _appConfig.JwtConfiguration.Issuer),            
            new Claim(JwtRegisteredClaimNames.Aud, _appConfig.JwtConfiguration.Audience),
            new Claim(JwtRegisteredClaimNames.Iat,issueTime.ToString("G")),
            new Claim(JwtRegisteredClaimNames.Exp,issueTime.AddHours(expiredHours).ToString("G")),           
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Name, user.Fullname),
            new Claim(ClaimTypes.Email, user.Email),   
            new Claim(ClaimTypes.Role, user.Role.ToString())            
        };
        var token = new JwtSecurityToken(
                claims: claims,
                notBefore: issueTime,
                expires: issueTime.AddHours(expiredHours),                
                signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task ValidateToken(TokenValidatedContext context)
    {
        var claims = context.Principal?.Claims.ToList();
        var identity = context.Principal?.Identity as ClaimsIdentity;
        // check if token empty
        if (claims == null || claims.Count == 0 || identity == null)
        {
            context.Fail("Invalid token! This token contains no required information.");
            return;
        }
        // check if token has valid issue
        var issuer = identity.FindFirst(JwtRegisteredClaimNames.Iss);
        if (issuer == null || !issuer.ToString().Equals(_appConfig.JwtConfiguration.Issuer))
        {
            context.Fail("Invalid token! This token is not issued by point entry.");
            return;
        }
        // check if token has valid user identity
        var username = identity.FindFirst(ClaimTypes.NameIdentifier)?.ToString();
        Account? user = null;
        if (username != null)
        {
            user = await _accountService.GetAccountByUsernamesync(username);          
        }
        var fullname = identity.FindFirst(ClaimTypes.Name)?.ToString();
        var email = identity.FindFirst(ClaimTypes.Email)?.ToString();
        if (username == null || user == null || 
            !user.Fullname.Equals(fullname) || !user.Email.Equals(email))
        {
            context.Fail("This token has invalid user indentity.");
            return;
        }
    }

    public Task<UserToken> CreateRefreshToken(Guid accountId, string JwtId, string RTSecretKey)
    {
        throw new NotImplementedException();
    }

    public Task ValidateRefreshToken(string RefreshToken)
    {
        throw new NotImplementedException();
    }    
}
