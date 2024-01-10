using Application.Models;
using AutoMapper;
using Domain.Entitites;
using WebApi.ViewModels;
namespace WebApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // chu y: 1 so model, view model nam o Application.Models
        CreateMap<Account, AccountVM>().ReverseMap();
        CreateMap<Account, RegisterModel>().ReverseMap();
        CreateMap<Account, AccountModel>().ReverseMap();
        CreateMap<Account, AccountDisplayModel>().ReverseMap();

        CreateMap<Tag, TagModel>().ReverseMap();
        CreateMap<Tag, TagVM>().ReverseMap();

        CreateMap<Asset, AssetModel>().ReverseMap();
        CreateMap<Image, ImageModel>().ReverseMap(); 

        CreateMap<Artwork, ArtworkVM>().ReverseMap();
        CreateMap<Artwork, ArtworkModel>().ReverseMap();
        CreateMap<Artwork, ArtworkSearchVM>().ReverseMap();
        CreateMap<Artwork, ArtworkDisplayModel>()
            .ForMember(model => model.Author, opt => opt.MapFrom(src => src.Account));

        CreateMap<Follow, FollowModel>().ReverseMap();
        CreateMap<Follow, FollowVM>().ReverseMap();

        CreateMap<Like, LikeModel>().ReverseMap();
        CreateMap<Like, LikeVM>().ReverseMap();

        CreateMap<Comment, CommentVM>().ReverseMap();

        CreateMap<Block, BlockModel>().ReverseMap();
        CreateMap<Block, BlockVM>().ReverseMap();

        CreateMap<Report, ReportModel>().ReverseMap();
        CreateMap<Report, ReportVM>().ReverseMap();

        CreateMap<Bookmark, BookmarkVM>().ReverseMap();

        CreateMap<Collection, CollectionVM>()
            .ForMember(model => model.CreatedBy, opt => opt.MapFrom(src => src.Account))
            .ForMember(model => model.Artworks, opt => opt.MapFrom(src => src.Bookmarks));        
    }
}
