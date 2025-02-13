using BasicCrud.Common;
using BasicCrud.Common.Interfaces;
using System.Security.Claims;

namespace BasicCrud.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimConstant.Id) ?? string.Empty;
            IsAuthenticated = string.IsNullOrWhiteSpace(UserId);
        }

        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
