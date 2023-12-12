using Domain.Entitites;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Application.Services.Authentication;

public interface ITokenHandler
{
    string CreateToken(Guid jti, Account user, string secretKey, DateTime issueTime, int expiredHours);
    Task<UserToken> CreateRefreshToken(Guid accountId, string JwtId, string RTSecretKey);
    Task ValidateToken(TokenValidatedContext context);
    Task ValidateRefreshToken(string RefreshToken);

}
