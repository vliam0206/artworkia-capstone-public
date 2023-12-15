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
    }
}
