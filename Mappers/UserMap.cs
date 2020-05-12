using Album_Web.Entities;
using Album_Web.Models;

using AutoMapper;

namespace Album_Web.Mappers
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}