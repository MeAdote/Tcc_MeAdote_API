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

        public bool Add(User modelUser, UserAdress modelAdress, UserLogin modelLogin)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.User.Add(modelUser);
                _context.SaveChanges();
                modelAdress.UserId = modelUser.Id;
                modelLogin.UserId = modelUser.Id;
                _context.UserAdress.Add(modelAdress);
                _context.UserLogin.Add(modelLogin);

                _context.SaveChanges();

                transaction.Commit();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                throw;
            }

            return true;
        }

        public User GetById(int id) 
        {
            return _context.User.FirstOrDefault(u => u.Id == id);
        }
    }
}
