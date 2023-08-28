using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Security.Cryptography
{
    public class PasswordValidation
    {
        public bool Validation(UserLogin userLogin, LoginUserDto model)
        {
            PasswordCrypthografy pC = new PasswordCrypthografy();
            var salt = Convert.FromBase64String(userLogin.Salt);
            string hasedPassword = pC.HashPassword(model.Password, salt);

            if (hasedPassword != userLogin.Password)
                return false;

            return true;
        }
    }
}