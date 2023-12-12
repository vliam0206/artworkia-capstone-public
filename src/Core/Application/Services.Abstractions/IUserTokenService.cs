using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IUserTokenService
{
    Task SaveToken(UserToken userToken);
    Task<UserToken?> GetToken(Guid tokenId);
}
