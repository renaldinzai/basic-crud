using BasicCrud.Application.Interfaces;
using BasicCrud.Application.Users.Requests;
using BasicCrud.Common.Constants;
using BasicCrud.Common.Exceptions;
using BasicCrud.Common.Extensions;
using BasicCrud.Common.Models;
using BasicCrud.Domain;
using BasicCrud.Domain.Interfaces;

namespace BasicCrud.Application.Users
{
    public class AuthenticationCommand : IAuthenticationCommand
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken) ?? throw new UserNotFoundException();

                if (!PasswordManager.ValidatePasswordHash(password: request.Password, salt: user.Salt, currentPassword: user.PasswordHash))
                {
                    throw new InvalidOperationException("Incorrect login info");
                }

                user.Update(
                    Guid.NewGuid().ToString().ToSHA256(),
                    DateTime.UtcNow.AddDays(7),
                    DateTime.UtcNow
                );

                await _userRepository.SaveAsync(cancellationToken);

                return new ApiResponse() { Results = user };
            }
            catch(UserNotFoundException ex)
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.Unathorized,
                    Message = ex.Message
                };
            }
            catch (InvalidOperationException ex)
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.Unathorized,
                    Message = ex.Message
                };
            }
            catch
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.InternalServerError,
                    Message = ErrorMessage.InternalServerError
                };
            }
        }
    }
}
