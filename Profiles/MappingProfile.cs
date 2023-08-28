using AutoMapper;
using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.User;
using Tcc_MeAdote_API.Utils;

namespace Tcc_MeAdote_API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserDto, User>();
            CreateMap<UserLoginDto, UserLogin>();
            CreateMap<UserAdressDto, UserAdress>();
        }
    }
}
