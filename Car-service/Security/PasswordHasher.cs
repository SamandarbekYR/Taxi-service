using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Security
{
    public class PasswordHasher
    {
        public static (string PasswordHash, string Salt) Hash(string Password)
        {
            string salt = GenerateSalt();
            var hash = BCrypt.Net.BCrypt.HashPassword(Password + salt);
            return (PasswordHash: hash, Salt: salt);
        }
        public static bool Verify(string password, string passwordHash, string salt)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt,  passwordHash);
        }

        public static string GenerateSalt() => Guid.NewGuid().ToString();
    }
}
