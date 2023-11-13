namespace Tcc_MeAdote_API.Service.UserService;

using Tcc_MeAdote_API.Data.Dto;

public interface IUserService
{
    AuthUserToken Authenticate(UserLoginDto model);
    ReadUserDto GetPetUserById(int id);

    public int GetUserId();
}