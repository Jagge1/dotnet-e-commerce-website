using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Api.Models;

public class User : IdentityUser
{
    public string Name { get; set; } = string.Empty;
}
