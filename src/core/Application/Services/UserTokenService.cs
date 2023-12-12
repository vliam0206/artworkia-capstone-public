using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class UserTokenService : IUserTokenService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserTokenService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<UserToken?> GetToken(Guid tokenId)
    {
        throw new NotImplementedException();
    }

    public Task SaveToken(UserToken userToken)
    {
        throw new NotImplementedException();
    }
}
