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
        services.AddScoped<IAssetService, AssetService>();        
        services.AddScoped<IBlockService, BlockService>();
        services.AddScoped<ICategoryArtworkDetailService, CategoryArtworkDetailService>();
        services.AddScoped<ICategoryService, CategoryService>();        
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<IFollowService, FollowService>();
        services.AddScoped<IImageService, ImageService>();        
        services.AddScoped<ILikeService, LikeService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<ITagService, TagService>();        
        services.AddScoped<ITagDetailService, TagDetailService>();
        services.AddScoped<IWalletService, WalletService>();
        services.AddScoped<IAssetTransactionService, AssetTransactionService>();

        services.AddScoped<IUserTokenService, UserTokenService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
        services.AddScoped<IFirebaseService, FirebaseService>();
        services.AddScoped<IThirdAuthenticationService, ThirdAuthenticationService>();
        return services;
    }
}
