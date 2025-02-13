using BasicCrud.Common;
using BasicCrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private JwtManager? _applicationJwtManager;

        protected JwtManager? JwtManager => _applicationJwtManager ??= HttpContext.RequestServices.GetService<JwtManager>();

        [NonAction]
        public Guid GetCurrentUserId()
        {
            if (!User.Identity.IsAuthenticated) 
                throw new InvalidOperationException("If GetCurrentUserId is called, user must be authenticated");

            var str = User.FindFirst(x => x.Type == ClaimConstant.Id).Value;

            if (string.IsNullOrWhiteSpace(str)) 
                throw new Exception("Claim user id is null");

            try
            {
                return Guid.Parse(str);
            }
            catch
            {
                throw;
            }
        }
    }
}
