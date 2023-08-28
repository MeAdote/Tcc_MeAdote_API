using Tcc_MeAdote_API.Data;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public User Add(User model)
        {
            _context.User.Add(model);
            _context.SaveChanges();
            return model;
        }

        public User Get(int id) 
        {
            return _context.User.FirstOrDefault(u => u.Id == id);
        }
    }
}
