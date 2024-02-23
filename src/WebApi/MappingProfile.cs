using Application.Commons;
using Application.Models;
using Application.Models.ZaloPayModels;
using AutoMapper;
using Domain.Entitites;
using WebApi.ViewModels;
using static Application.Models.ArtworkVM;
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

        CreateMap<Category, CategoryModel>().ReverseMap();
        CreateMap<Category, CategoryVM>().ReverseMap();
        CreateMap<Category, CategoryEM>().ReverseMap();

        CreateMap<CategoryArtworkDetail, CategoryArtworkModel>().ReverseMap();
        CreateMap<CategoryArtworkDetail, CategoryArtworkVM>().ReverseMap();

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
        CreateMap<Follow, FollowVM>().ReverseMap();

        CreateMap<Like, LikeModel>().ReverseMap();
        CreateMap<Like, LikeVM>().ReverseMap();

        CreateMap<Comment, CommentVM>().ReverseMap();

        CreateMap<Block, BlockModel>().ReverseMap();
        CreateMap<Block, BlockVM>().ReverseMap();

        CreateMap<Service, ServiceModel>().ReverseMap();
        CreateMap<Service, ServiceVM>()
            .ForMember(model => model.CategoryList, opt => opt.MapFrom(x => x.CategoryServiceDetails.Select(y => y.Category).ToList()))
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
            .ForMember(model => model.Items, opt => opt.MapFrom(src => src.Bookmarks.Count()));        
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

        CreateMap<ZaloPayOrderCreate, OrderCreateModel>().ReverseMap();

        CreateMap<Proposal, ProposalModel>().ReverseMap();
        CreateMap<Proposal, ProposalVM>().ReverseMap();
        
        CreateMap<Milestone, MilestoneVM>().ReverseMap();
    }
}
