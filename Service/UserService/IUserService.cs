namespace Tcc_MeAdote_API.Service.UserService;

using Tcc_MeAdote_API.Data.Dto;

interface IUserService
{
    AuthUserToken Authenticate(AuthUserDto model);
}