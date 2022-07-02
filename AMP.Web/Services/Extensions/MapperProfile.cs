using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AutoMapper;

namespace AMP.Web.Services.Extensions;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ArtisanCommand, ArtisanDto>().ReverseMap();
        CreateMap<UserCommand, UserDto>().ReverseMap();
    }
}