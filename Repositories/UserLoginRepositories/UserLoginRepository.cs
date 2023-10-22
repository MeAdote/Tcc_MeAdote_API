using System.Reflection.Metadata.Ecma335;
using Tcc_MeAdote_API.Data;
using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.UserLoginRepositories
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly Context _context;
        public UserLoginRepository(Context context)
        {
            _context = context;
        }

        public UserLogin Add(UserLogin model)
        {
            _context.UserLogin.Add(model);
            _context.SaveChanges();

            return model;
        }

        public UserLogin GetEmail(string email)
        {
            return _context.UserLogin.FirstOrDefault(u => u.Email == email);
        }

        public UserLogin GetUserLogin(UserLoginDto model)
        {
            return _context.UserLogin.FirstOrDefault(u => u.Email == model.Email);
        }

        public IEnumerable<UserLogin> GetUsers()
        {
            return _context.UserLogin;
        }
    }
}
