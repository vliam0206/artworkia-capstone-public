using Application.Services;
using Application.Services.Abstractions;
using Application.Services.Authentication;
using Application.Services.Firebase;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();        
        services.AddScoped<IArtworkService, ArtworkService>();        
        services.AddScoped<ICategoryService, CategoryService>();        
        services.AddScoped<ITagService, TagService>();        
        services.AddScoped<IImageService, ImageService>();        
        services.AddScoped<IAssetService, AssetService>();        
        services.AddScoped<IUserTokenService, UserTokenService>();
        services.AddScoped<IFollowService, FollowService>();
        services.AddScoped<ILikeService, LikeService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IBlockService, BlockService>();
        services.AddScoped<IReportService, ReportService>();

        services.AddScoped<ITokenHandler, TokenHandler>();
        services.AddScoped<IFirebaseService, FirebaseService>();
        services.AddScoped<IThirdAuthenticationService, ThirdAuthenticationService>();
        return services;
    }
}
