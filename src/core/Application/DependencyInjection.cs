using Application.Services;
using Application.Services.Abstractions;
using Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();        
        services.AddScoped<ICategoryService, CategoryService>();        
        services.AddScoped<ITagService, TagService>();        
        services.AddScoped<IAssetService, AssetService>();        
        services.AddScoped<IUserTokenService, UserTokenService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
        services.AddScoped<IFollowService, FollowService>();

        return services;
    }
}
