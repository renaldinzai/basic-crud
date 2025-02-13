using BasicCrud.Common.Extensions;

namespace BasicCrud.Domain
{
    public static class PasswordManager
    {
        /// <summary>
        /// Validate password
        /// </summary>
        /// <param name="password">Request password</param>
        /// <param name="salt">Salt from db</param>
        /// <param name="currentPassword">Password from db</param>
        /// <returns></returns>
        public static bool ValidatePasswordHash(string password, string salt, string currentPassword)
        {
            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentException($"'{nameof(salt)}' cannot be null or empty", nameof(salt));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty", nameof(password));
            }

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                throw new ArgumentException($"'{nameof(currentPassword)}' cannot be null or whitespace", nameof(currentPassword));
            }

            return string.Concat(salt, password).ToSHA512() == currentPassword;
        }

        public static string HashPassword(string salt, string password)
        {
            return string.Concat(salt, password).ToSHA512();
        }
    }
}
