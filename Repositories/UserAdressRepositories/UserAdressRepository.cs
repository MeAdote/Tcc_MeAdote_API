using Tcc_MeAdote_API.Data;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.UserAdressRepositories
{
    public class UserAdressRepository : IUserAdressRepository
    {
        private readonly Context _context;
        public UserAdressRepository(Context context)
        {
            _context = context;
        }

        public UserAdress Add(UserAdress model)
        {
		    _context.UserAdress.Add(model);
            _context.SaveChanges();
            return model;
        }

        public UserAdress Get(int id)
        {
            return _context.UserAdress.FirstOrDefault(x => x.UserId == id);
        }
    }
}
