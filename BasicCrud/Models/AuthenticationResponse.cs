namespace BasicCrud.Models
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse()
        {
            Scheme = "bearer";
        }

        public AuthenticationResponse(string token, string refreshToken, DateTime? refreshTokenExpiredOn) : this()
        {
            Token = token;
            RefreshToken = refreshToken;
            RefreshTokenExpiredOn = refreshTokenExpiredOn;
        }

        public AuthenticationResponse(string scheme, string token, string refreshToken, DateTime? refreshTokenExpiredOn)
        {
            Scheme = scheme;
            Token = token;
            RefreshToken = refreshToken;
            RefreshTokenExpiredOn = refreshTokenExpiredOn;
        }

        public string Scheme { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiredOn { get; set; }
    }
}
