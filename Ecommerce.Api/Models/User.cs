using Ecommerce.Api.Models;
using Ecommerce.Api.Models.Enums;

namespace Ecommerce.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.CUSTOMER;

    }
}
