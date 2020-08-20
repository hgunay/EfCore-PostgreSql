namespace EfCorePostgre.Core
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Linq;

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

            var byteRfc2898DeriveBytes = new Rfc2898DeriveBytes(bytePassword, bytePasswordSalt, 1000, HashAlgorithmName.SHA256);
            var rfcHash = byteRfc2898DeriveBytes.GetBytes(64);

            return Convert.ToBase64String(rfcHash);
        }

        /// <summary>The create salt.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateSaltPassword()
        {
            var saltBytes = new byte[64];
            new RNGCryptoServiceProvider().GetNonZeroBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
    }
}