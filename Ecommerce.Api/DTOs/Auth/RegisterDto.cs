using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.DTOs.Auth
{
    public class RegisterDto
    {
        [Required, MaxLength(100), MinLength(1)]
        public string UserName { get; set; } = String.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;

        [Required, MinLength(8)]
        public string Password { get; set; } = String.Empty;
    }
}
