using System;
using System.Security.Cryptography;

namespace StudyApp
{
    public class PasswordHasher
    {
        private const int _saltSize = 16;
        private const int _keysize = 32;
        private const int _iterations = 100000;
        private static readonly HashAlgorithmName _hashalgorithmName = HashAlgorithmName.SHA256;
        private const char _saltdelimiter = ';';

        public static string hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashalgorithmName, _keysize);
            return string.Join(_saltdelimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public static bool Validate(string passwordHash, string password)
        {
            var pwdElements = passwordHash.Split(_saltdelimiter);
            var salt = Convert.FromBase64String(pwdElements[0]);
            var hash = Convert.FromBase64String(pwdElements[1]);
            var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashalgorithmName, _keysize);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}