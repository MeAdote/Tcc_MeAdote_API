using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.UserAdressRepositories
{
    public interface IUserAdressRepository
    {
        public UserAdress Add(UserAdress userAdress);
        public UserAdress Get(int id);
    }
}
