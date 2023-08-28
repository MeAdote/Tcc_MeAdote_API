using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public User Add(User model);
        public User Get(int id);
    }
}
