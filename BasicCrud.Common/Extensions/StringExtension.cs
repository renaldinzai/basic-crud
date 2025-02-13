using System.Security.Cryptography;
using System.Text;

namespace BasicCrud.Common.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Create new hash string using SHA256
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToSHA256(this string s)
        {
            string hash = string.Empty;
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(s).AsSpan(0, Encoding.UTF8.GetByteCount(s)));

            foreach (byte b in bytes)
            {
                hash += b.ToString("x2");
            }

            return hash;
        }

        /// <summary>
        /// Create new hash string using SHA512
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToSHA512(this string s)
        {
            string hash = string.Empty;
            byte[] bytes = SHA512.HashData(Encoding.UTF8.GetBytes(s).AsSpan(0, Encoding.UTF8.GetByteCount(s)));

            foreach (byte b in bytes)
            {
                hash += b.ToString("x2");
            }

            return hash;
        }
    }
}
