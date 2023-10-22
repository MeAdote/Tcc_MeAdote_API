using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.UserLoginRepositories
{
    public interface IUserLoginRepository
    {
        public UserLogin Add(UserLogin model);
        public UserLogin GetEmail(string email);
        public UserLogin GetUserLogin(UserLoginDto model);

        public IEnumerable<UserLogin> GetUsers();

    }
}
