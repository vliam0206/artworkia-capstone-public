using Application.Models;
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

        CreateMap<Artwork, ArtworkVM>().ReverseMap();
        CreateMap<Account, AccountArtworkVM>().ReverseMap();
        CreateMap<Account, AccountArtworkVM>().ReverseMap();
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
        CreateMap<Service, ServiceVM>().ReverseMap();

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
        
    }
}
