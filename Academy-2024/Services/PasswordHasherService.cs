using Academy_2024.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace Academy_2024.Services
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var byteValue = Encoding.UTF8.GetBytes(password);
            var byteHash = sha256.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
    }
}
