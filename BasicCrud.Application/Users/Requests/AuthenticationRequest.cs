using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Application.Users.Requests
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
