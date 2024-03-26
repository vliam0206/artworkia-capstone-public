using Domain.Repositories.Abstractions;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Commons;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _dbContext;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserTokenRepository _userTokenRepository;
    private readonly IArtworkRepository _artworkRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IBookmarkRepository _bookmarkRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IImageRepository _imageRepository;
    private readonly ICategoryArtworkDetailRepository _categoryArtworkDetailRepository;
    private readonly ICategoryServiceDetailRepository _categoryServiceDetailRepository;
    private readonly IChatBoxRepository _chatBoxRepository;
    private readonly ICollectionRepository _collectionRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly ILicenseTypeRepository _licenseTypeRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly INotificationRepository _notificationRepository;
    private readonly IProposalAssetRepository _proposalAssetRepository;
    private readonly IProposalRepository _proposalRepository;
    private readonly IReportRepository _reportRepository;
    private readonly IRequestRepository _requestRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IServiceDetailRepository _serviceDetailRepository;
    private readonly ISoftwareDetailRepository _softwareDetailRepository;
    private readonly ISoftwareUsedRepository _softwareUsedRepository;
    private readonly ITagDetailRepository _tagDetailRepository;
    private readonly ITagRepository _tagRepository;
    private readonly ITransactionHistoryRepository _transactionHistoryRepository;
    private readonly IWalletHistoryRepository _walletHistoryRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IFollowRepository _followRepository;
    private readonly IBlockRepository _blockRepository;
    public IMilestoneRepository _milestoneRepository;

    public UnitOfWork(AppDBContext dbContext,
                      IAccountRepository accountRepository,
                      IUserTokenRepository userTokenRepository,
                      IArtworkRepository artworkRepository,
                      IAssetRepository assetRepository,
                      IBookmarkRepository bookmarkRepository,
                      ICategoryRepository categoryRepository,
                      IImageRepository imageRepository,
                      ICategoryArtworkDetailRepository categoryArtworkDetailRepository,
                      ICategoryServiceDetailRepository categoryServiceDetailRepository,
                      IChatBoxRepository chatBoxRepository,
                      ICollectionRepository collectionRepository,
                      ICommentRepository commentRepository,
                      ILikeRepository likeRepository,
                      ILicenseTypeRepository licenseTypeRepository,
                      IMessageRepository messageRepository,
                      INotificationRepository notificationRepository,
                      IProposalAssetRepository proposalAssetRepository,
                      IProposalRepository proposalRepository,
                      IReportRepository reportRepository,
                      IRequestRepository requestRepository,
                      IReviewRepository reviewRepository,
                      IServiceRepository serviceRepository,
                      IServiceDetailRepository serviceDetailRepository,
                      ISoftwareDetailRepository softwareDetailRepository,
                      ISoftwareUsedRepository softwareUsedRepository,
                      ITagDetailRepository tagDetailRepository,
                      ITagRepository tagRepository,
                      ITransactionHistoryRepository transactionHistoryRepository,
                      IWalletHistoryRepository walletHistoryRepository,
                      IWalletRepository walletRepository,
                      IFollowRepository followRepository,
                      IBlockRepository blockRepository,
                      IMilestoneRepository milestoneRepository)
    {
        _dbContext = dbContext;
        _accountRepository = accountRepository;
        _userTokenRepository = userTokenRepository;
        _artworkRepository = artworkRepository;
        _assetRepository = assetRepository;
        _bookmarkRepository = bookmarkRepository;
        _categoryRepository = categoryRepository;
        _imageRepository = imageRepository;
        _categoryArtworkDetailRepository = categoryArtworkDetailRepository;
        _categoryServiceDetailRepository = categoryServiceDetailRepository;
        _chatBoxRepository = chatBoxRepository;
        _collectionRepository = collectionRepository;
        _commentRepository = commentRepository;
        _likeRepository = likeRepository;
        _licenseTypeRepository = licenseTypeRepository;
        _messageRepository = messageRepository;
        _notificationRepository = notificationRepository;
        _proposalAssetRepository = proposalAssetRepository;
        _proposalRepository = proposalRepository;
        _reportRepository = reportRepository;
        _requestRepository = requestRepository;
        _reviewRepository = reviewRepository;
        _serviceRepository = serviceRepository;
        _serviceDetailRepository = serviceDetailRepository;
        _softwareDetailRepository = softwareDetailRepository;
        _softwareUsedRepository = softwareUsedRepository;
        _tagDetailRepository = tagDetailRepository;
        _tagRepository = tagRepository;
        _transactionHistoryRepository = transactionHistoryRepository;
        _walletHistoryRepository = walletHistoryRepository;
        _walletRepository = walletRepository;
        _followRepository = followRepository;
        _blockRepository = blockRepository;
        _milestoneRepository = milestoneRepository;
    }

    public IAccountRepository AccountRepository => _accountRepository;
    public IUserTokenRepository UserTokenRepository => _userTokenRepository;

    public IArtworkRepository ArtworkRepository => _artworkRepository;

    public IAssetRepository AssetRepository => _assetRepository;

    public IBookmarkRepository BookmarkRepository => _bookmarkRepository;
    public ICategoryRepository CategoryRepository => _categoryRepository;

    public ICategoryArtworkDetailRepository CategoryArtworkDetailRepository => _categoryArtworkDetailRepository;

    public ICategoryServiceDetailRepository CategoryServiceDetailRepository => _categoryServiceDetailRepository;

    public IChatBoxRepository ChatBoxRepository => _chatBoxRepository;

    public ICollectionRepository CollectionRepository => _collectionRepository;

    public ICommentRepository CommentRepository => _commentRepository;
    public IImageRepository ImageRepository => _imageRepository;

    public ILikeRepository LikeRepository => _likeRepository;

    public ILicenseTypeRepository LicenseTypeRepository => _licenseTypeRepository;
    public IMessageRepository MessageRepository => _messageRepository;

    public INotificationRepository NotificationRepository => _notificationRepository;

    public IProposalAssetRepository ProposalAssetRepository => _proposalAssetRepository;

    public IProposalRepository ProposalRepository => _proposalRepository;

    public IReportRepository ReportRepository => _reportRepository;

    public IRequestRepository RequestRepository => _requestRepository;

    public IReviewRepository ReviewRepository => _reviewRepository;

    public IServiceRepository ServiceRepository => _serviceRepository;

    public ISoftwareDetailRepository SoftwareDetailRepository => _softwareDetailRepository;

    public ISoftwareUsedRepository SoftwareUsedRepository => _softwareUsedRepository;

    public ITagDetailRepository TagDetailRepository => _tagDetailRepository;

    public ITagRepository TagRepository => _tagRepository;

    public ITransactionHistoryRepository TransactionHistoryRepository => _transactionHistoryRepository;

    public IWalletHistoryRepository WalletHistoryRepository => _walletHistoryRepository;

    public IWalletRepository WalletRepository => _walletRepository;
    public IFollowRepository FollowRepository => _followRepository;

    public IServiceDetailRepository ServiceDetailRepository => _serviceDetailRepository;

    public IBlockRepository BlockRepository => _blockRepository;
    
    public IMilestoneRepository MilestoneRepository => _milestoneRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}
