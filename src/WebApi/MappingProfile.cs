using AutoMapper;
using Domain.Entitites;
using WebApi.ViewModels;
namespace WebApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, AccountVM>().ReverseMap();
        CreateMap<Account, RegisterModel>().ReverseMap();
        CreateMap<Account, AccountModel>().ReverseMap();
        CreateMap<Tag, TagModel>().ReverseMap();
        CreateMap<Tag, TagVM>().ReverseMap();
        CreateMap<Asset, AssetModel>().ReverseMap();
        CreateMap<Artwork, ArtworkVM>().ReverseMap();
        CreateMap<Follow, FollowModel>().ReverseMap();
        CreateMap<Follow, FollowVM>().ReverseMap();
        CreateMap<Like, LikeModel>().ReverseMap();
        CreateMap<Like, LikeVM>().ReverseMap();
        CreateMap<Comment, CommentVM>().ReverseMap();
    }
}
