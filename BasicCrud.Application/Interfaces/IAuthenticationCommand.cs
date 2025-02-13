using BasicCrud.Application.Users.Requests;
using BasicCrud.Common.Models;

namespace BasicCrud.Application.Interfaces
{
    public interface IAuthenticationCommand
    {
        Task<ApiResponse> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken);
    }
}
