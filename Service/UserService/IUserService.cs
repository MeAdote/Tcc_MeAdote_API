namespace Tcc_MeAdote_API.Service.UserService;

using Tcc_MeAdote_API.Data.Dto;

public interface IUserService
{
    AuthUserToken Authenticate(UserLoginDto model);
    ReadUserDto GetPetUser(int id);
}