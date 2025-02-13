namespace BasicCrud.Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string NormalizedUsername { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime? LastLogin { get; set; }
        public string? TimeZone { get; set; }
        public string? Fullname { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TokenResetPassword { get; set; }
        public DateTime? TokenResetPasswordExpiredDate { get; set; }

        public void Update(string tokenResetPassword, DateTime tokenResetPasswordExpiredDate, DateTime lastLogin)
        {
            SetTokenResetPassword(tokenResetPassword);
            SetTokenResetPasswordExpiredDate(tokenResetPasswordExpiredDate);
            SetLastLogin(lastLogin);
        }

        private void SetTokenResetPassword(string tokenResetPassword)
        {
            TokenResetPassword = tokenResetPassword;
        }

        private void SetTokenResetPasswordExpiredDate(DateTime tokenResetPasswordExpiredDate)
        {
            TokenResetPasswordExpiredDate = tokenResetPasswordExpiredDate;
        }

        private void SetLastLogin(DateTime lastLogin)
        {
            LastLogin = lastLogin;
        }
    }
}
