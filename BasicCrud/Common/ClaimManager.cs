using BasicCrud.Domain.Entities;
using System.Security.Claims;

namespace BasicCrud.Common
{
    public static class ClaimManager
    {
        public static List<Claim> GenerateClaims(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            List<Claim> list =
            [
                new Claim(type: ClaimConstant.Id, value: user.Id.ToString()),
                new Claim(type: ClaimConstant.Name, value: user.Username)
            ];

            return list;
        }
    }
}
