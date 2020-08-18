namespace EfCorePostgre.Core
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>The password helper.</summary>
    public static class PasswordHelper
    {
        /// <summary>The encode password.</summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string EncodePassword(string password, string passwordSalt)
        {
            var bytePassword     = Encoding.Unicode.GetBytes(password);
            var bytePasswordSalt = Convert.FromBase64String(passwordSalt);
            var byteBuffer       = new byte[bytePasswordSalt.Length + bytePassword.Length];

            Buffer.BlockCopy(bytePasswordSalt, 0, byteBuffer, 0,                       bytePasswordSalt.Length);
            Buffer.BlockCopy(bytePassword,     0, byteBuffer, bytePasswordSalt.Length, bytePassword.Length);

            var byteEncryptSha1 = new SHA1CryptoServiceProvider().ComputeHash(byteBuffer);

            return Convert.ToBase64String(byteEncryptSha1);
        }

        /// <summary>The create salt.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateSaltPassword()
        {
            var saltBytes = new byte[64];
            var rng       = new RNGCryptoServiceProvider();

            rng.GetNonZeroBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
    }
}