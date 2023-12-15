using Domain.Entitites;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Application.Services.Authentication;

public interface ITokenHandler
{
    (string, Guid) CreateRefreshToken(Account user, DateTime issueTime);
    (string, Guid) CreateAccessToken(Account user, DateTime issueTime);
    Task ValidateAccessTokenAsync(TokenValidatedContext context);
    Task<TokenVM?> ValidateRefreshTokenAsync(string RefreshToken);    
}
