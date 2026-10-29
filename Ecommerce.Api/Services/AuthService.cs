using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Identity;
using Ecommerce.Api.DTOs.Auth;
namespace Ecommerce.Api.Services
{
    public class AuthServices(UserManager<User> userManager, TokenServices jwt)
    {
        public async Task<IdentityResult> Register(RegisterDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName.Trim(),
                Email = dto.Email.Trim(),
            };

            // This line does a lot of abstraction:
            //      - Validation of user
            //      - Hashing password
            //      - Saves user
            //      - Creates IdentityResult

            return await userManager.CreateAsync(user, dto.Password);
        }

        // It returns a string because the token is a string.
        public async Task<String?> Login(LoginDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);

            if (user is null)
            {
                return null;
            }

            var password = await userManager.CheckPasswordAsync(user, dto.Password);

            if (!password)
            {
                return null;
            }

            var token = jwt.CreateToken(user);

            return token;
        }
    }
}
