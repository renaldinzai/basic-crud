using BasicCrud.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicCrud.Services
{
    public class JwtManager
    {
        private readonly WebAppConfig _option;

        public JwtManager(IOptions<WebAppConfig> options)
        {
            _option = options.Value;
            if (string.IsNullOrWhiteSpace(_option.SecretKey))
            {
                throw new ArgumentException("Secret key is null");
            }
        }

        public string GenerateJwtToken(List<Claim> claims)
        {
            JwtSecurityTokenHandler tokenHandler = new();

            byte[] key = Encoding.UTF8.GetBytes(_option.SecretKey);

            ClaimsIdentity claimsIdentity = new(claims: claims);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = claimsIdentity,
                // generate token that is valid for 7 days
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken ValidateToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.UTF8.GetBytes(_option.SecretKey);
            _ = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;

            return jwtToken;
        }
    }
}
