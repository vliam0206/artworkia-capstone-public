﻿using Domain.Repositories.Abstractions;
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
        services.AddScoped<IArtworkRepository, ArtworkRepository>();
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IBookmarkRepository, BookmarkRepository>();
        services.AddScoped<ICategoryArtworkDetailRepository, CategoryArtworkDetailRepository>();
        services.AddScoped<ICategoryServiceDetailRepository, CategoryServiceDetailRepository>();
        services.AddScoped<IChatBoxRepository, ChatBoxRepository>();
        services.AddScoped<ICollectionRepository, CollectionRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IProposalAssetRepository, ProposalAssetRepository>();
        services.AddScoped<IProposalRepository, ProposalRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<ITagDetailRepository, TagDetailRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
        services.AddScoped<IWalletHistoryRepository, WalletHistoryRepository>();
        services.AddScoped<IWalletRepository, WalletRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
