using Beamore.API.BusinessLogics.CO;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Beamore.API.BusinessLogics
{
    public static class PasswordUtilies
    {
        private const int MAXIMUM_SALT_LENGTH = 16;
        /// <summary>
        /// To encrypt the password 
        /// </summary>
        /// <param name="encryptString">Password</param>
        /// <returns>encryptedPassword</returns>
        public static EncryptionModelCO EncryptPassword(string encryptString)
        {
            SHA512 encrypt = new SHA512CryptoServiceProvider();
            string salt = GetSalt();

            string encryptedPassword = Convert.ToBase64String(encrypt.ComputeHash(Encoding.UTF8.GetBytes(encryptString + salt)));
            EncryptionModelCO ReturnModel = new EncryptionModelCO
            {
                Password = encryptedPassword,
                Salt = salt
            };
            return ReturnModel;
        }


        public static EncryptionModelCO EncryptPasswordForLogin(string encryptString, string salt)
        {
            SHA512 encrypt = new SHA512CryptoServiceProvider();

            string encryptedPassword = Convert.ToBase64String(encrypt.ComputeHash(Encoding.UTF8.GetBytes(encryptString + salt)));
            EncryptionModelCO ReturnModel = new EncryptionModelCO
            {
                Password = encryptedPassword,
                Salt = salt
            };
            return ReturnModel;
        }

        /// <summary>
        /// Generate a SALT string to add password
        /// </summary>
        /// <returns>SALT</returns>
        private static string GetSalt()
        {
            var salt = new byte[MAXIMUM_SALT_LENGTH];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
    }
}