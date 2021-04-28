using System;
using System.Security.Cryptography;

namespace StudyGuide.Cryptographic
{
    public class PBKDF2 : BaseCryptographic
    {
        public override string Encrypt(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var result = CreateHash(password, salt, 100000);
            var hash = result.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 0, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public override bool Verify(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            string savedPasswordHash = password;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            Array.Copy(hashBytes, 0, salt, 0, 16);
            var result = CreateHash(password, salt, 100000);
            var hash = result.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    throw new UnauthorizedAccessException("Senha inválidsa!");
                }
            }

            return true;
        }

        private Rfc2898DeriveBytes CreateHash(string password, byte[] salt, int number)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, number);
            return pbkdf2;
        }
    }
}