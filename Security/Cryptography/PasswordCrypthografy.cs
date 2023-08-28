using System.Diagnostics;
using System.Security.Cryptography;

namespace Tcc_MeAdote_API.Security.Cryptography
{
    public class PasswordCrypthografy
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[32];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
