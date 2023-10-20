using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class EncryptionUtils
    {
        public static void Encrypt(string data, out byte[] salt, out byte[] hash)
        {
            var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] Encrypt(string data, byte[] salt)
        {
            var hmac = new HMACSHA512(salt);
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        }
    }
}
