using Domain.Repositories.Abstractions;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Commons;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserTokenRepository, UserTokenRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
