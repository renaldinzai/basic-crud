using BasicCrud.Common;
using BasicCrud.Domain.Entities;
using BasicCrud.Services;
using System.Security.Claims;
using BasicCrud.Models;

namespace BasicCrud
{
    public static class TokenBuilder
    {
        public static AuthenticationResponse Build(JwtManager? jwtManager, User? user)
        {
            ArgumentNullException.ThrowIfNull(jwtManager);

            ArgumentNullException.ThrowIfNull(user);

            List<Claim> claims =
            [
                .. ClaimManager.GenerateClaims(user),
            ];

            return new AuthenticationResponse(jwtManager.GenerateJwtToken(claims), user.TokenResetPassword ?? string.Empty, user.TokenResetPasswordExpiredDate);
        }
    }
}
