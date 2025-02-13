using BasicCrud.Application.Interfaces;
using BasicCrud.Application.Users.Requests;
using BasicCrud.Common.Models;
using BasicCrud.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IAuthenticationCommand _authenticationCommand;

        public UserController(IAuthenticationCommand authenticationCommand)
        {
            _authenticationCommand = authenticationCommand;
        }

        [HttpPost("login")]
        public async Task<ApiResponse> AuthenticationAsync([FromBody] AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationCommand.Authenticate(request, cancellationToken);

            if (result.Results == null)
                return result;

            var authResp = TokenBuilder.Build(JwtManager, (User?)result.Results);

            result.Results = authResp;

            return result;
        }
    }
}
