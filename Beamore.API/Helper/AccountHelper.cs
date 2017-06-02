using System;
using System.Security.Cryptography;
using System.Text;

namespace Beamore.API.Helper
{
    public class AccountHelper
    {
        public static string EncryptedMessage(string password)
        {
            SHA512 encrypt = new SHA512CryptoServiceProvider();
            string encryptedPassword = Convert.ToBase64String(encrypt.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return encryptedPassword;
        }
    }
}