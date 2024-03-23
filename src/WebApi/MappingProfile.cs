using Application.Commons;
using Application.Models;
using Application.Models.ZaloPayModels;
using AutoMapper;
using Domain.Entitites;
using WebApi.ViewModels;
namespace WebApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // chu y: 1 so model, view model nam o Application.Models
        CreateMap(typeof(PagedList<>), typeof(PagedList<>));

        CreateMap<Account, AccountVM>().ReverseMap();
        CreateMap<Account, RegisterModel>().ReverseMap();
        CreateMap<Account, AccountModel>().ReverseMap();

        CreateMap<Tag, TagModel>().ReverseMap();
        CreateMap<Tag, TagVM>().ReverseMap();
        CreateMap<TagDetail, TagDetailVM>().ReverseMap();
        CreateMap<Account, AccountDisplayModel>().ReverseMap();

        CreateMap<Tag, TagModel>().ReverseMap();
        CreateMap<Tag, TagVM>().ReverseMap();

        CreateMap<Asset, AssetModel>().ReverseMap();
        CreateMap<Asset, AssetVM>().ReverseMap();

        CreateMap<Image, ImageModel>().ReverseMap(); 
        CreateMap<Image, ImageVM>().ReverseMap(); 
        CreateMap<Image, ImageDuplicationVM>().ReverseMap(); 

        CreateMap<Category, CategoryModel>().ReverseMap();
        CreateMap<Category, CategoryVM>().ReverseMap();
        CreateMap<Category, CategoryEM>().ReverseMap();

        CreateMap<CategoryArtworkDetail, CategoryArtworkModel>().ReverseMap();
        CreateMap<CategoryArtworkDetail, CategoryArtworkVM>().ReverseMap();

        CreateMap<CategoryServiceDetail, CategoryServiceModel>().ReverseMap();
        CreateMap<CategoryServiceDetail, CategoryServiceVM>().ReverseMap();

        CreateMap<Artwork, ArtworkVM>()
            .ForMember(model => model.CategoryList, opt => opt.MapFrom(x => x.CategoryArtworkDetails.Select(y => y.Category).ToList()))
            .ForMember(model => model.TagList, opt => opt.MapFrom(x => x.TagDetails.Select(y => y.Tag).ToList()));
        CreateMap<Artwork, ArtworkModerationVM>()
            .ForMember(model => model.CategoryList, opt => opt.MapFrom(x => x.CategoryArtworkDetails.Select(y => y.Category).ToList()))
            .ForMember(model => model.TagList, opt => opt.MapFrom(x => x.TagDetails.Select(y => y.Tag).ToList()));
        CreateMap<Account, AccountBasicInfoVM>().ReverseMap();
        CreateMap<Artwork, ArtworkModel>().ReverseMap();
        CreateMap<Artwork, ArtworkPreviewVM>().ReverseMap();
        CreateMap<Artwork, ArtworkDisplayModel>()
            .ForMember(model => model.Author, opt => opt.MapFrom(src => src.Account));

        CreateMap<Follow, FollowModel>().ReverseMap();
        CreateMap<Follow, FollowingVM>().ReverseMap();
        CreateMap<Follow, FollowerVM>().ReverseMap();

        CreateMap<Like, LikeModel>().ReverseMap();
        CreateMap<Like, LikeVM>().ReverseMap();

        CreateMap<Comment, CommentVM>()
            .ForMember(model => model.CreatedBy, opt => opt.MapFrom(x => x.Account))
            .ForMember(model => model.ReplyCount, opt => opt.MapFrom(x => x.Replies.Count()));

        CreateMap<Block, BlockModel>().ReverseMap();
        CreateMap<Block, BlockVM>().ReverseMap();

        CreateMap<Service, ServiceModel>().ReverseMap();
        CreateMap<Service, ServiceVM>()
            .ForMember(model => model.Categories, opt => opt.MapFrom(x => x.CategoryServiceDetails.Select(y => y.Category).ToList()))
            .ForMember(model => model.ArtworkReferences, opt => opt.MapFrom(x => x.ServiceDetails.Select(y => y.Artwork).ToList()));

        CreateMap<Request, RequestModel>().ReverseMap();
        CreateMap<Request, RequestVM>().ReverseMap();

        CreateMap<Report, ReportModel>().ReverseMap();
        CreateMap<Report, ReportVM>().ReverseMap();

        CreateMap<Bookmark, BookmarkVM>().ReverseMap();
        CreateMap<Bookmark, BookmarkModel>().ReverseMap();
        
        CreateMap<Collection, CollectionDetailVM>()
            .ForMember(model => model.CreatedBy, opt => opt.MapFrom(src => src.Account))
            .ForMember(model => model.Artworks, opt => opt.MapFrom(src => src.Bookmarks));
        CreateMap<Collection, CollectionVM>()
            .ForMember(model => model.CreatedBy, opt => opt.MapFrom(src => src.Account))        
            .ForMember(model => model.Items, opt => opt.MapFrom(src => src.Bookmarks.Count()))        
            .ForMember(model => model.Thumbnail, opt => opt.MapFrom(src => src.Bookmarks.FirstOrDefault()!.Artwork.Thumbnail));        
        CreateMap<Collection, CollectionModificationModel>().ReverseMap();
        CreateMap<CollectionCreationModel, Collection>().ReverseMap();

        CreateMap<Wallet, WalletModel>().ReverseMap();
        CreateMap<Wallet, WalletVM>().ReverseMap();
        
        CreateMap<TransactionHistory, AssetTransactionModel>().ReverseMap();
        CreateMap<TransactionHistory, AssetTransactionVM>().ReverseMap();

        CreateMap<WalletHistory, WalletHistoryVM>()
            .ForMember(model => model.AccountId, opt => opt.MapFrom(src => src.CreatedBy));

        CreateMap<TransactionHistory, TransactionHistoryVM>()
            .ForMember(model => model.AccountId, opt => opt.MapFrom(src => src.CreatedBy));
        CreateMap<TransactionHistory, TransactionModel>().ReverseMap();

        CreateMap<ZPCreateOrderRequest, OrderCreateModel>().ReverseMap();

        CreateMap<Proposal, ProposalModel>().ReverseMap();
        CreateMap<Proposal, ProposalVM>().ReverseMap();

        CreateMap<ProposalAsset, ProposalAssetModel>().ReverseMap();
        CreateMap<ProposalAsset, ProposalAssetVM>().ReverseMap();
        
        CreateMap<Milestone, MilestoneVM>().ReverseMap();

        CreateMap<Message, MessageModel>().ReverseMap();
        CreateMap<Message, MessageVM>().ReverseMap();

        CreateMap<ChatBox, ChatBoxVM>().ReverseMap();

        CreateMap<Review, ReviewModel>().ReverseMap();
        CreateMap<Review, ReviewVM>().ReverseMap();

        CreateMap<Notification, NotificationModel>().ReverseMap();
        CreateMap<Notification, NotificationVM>().ReverseMap();
    }
}
