using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Api.Data
{
    public class RoleSeeder
    {
        public static async Task CreateRolesAsync(IServiceProvider service) 
        {
            using var scope = service.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "Customer" };

            foreach(var role in roles)
            {
                // Checks if roles exist in the database and skips if it does.
                if (await roleManager.RoleExistsAsync(role))
                {
                    continue;
                }

                var result = await roleManager.CreateAsync(new IdentityRole(role));

                // Stops API startup if role creation fails.
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ",
                        result.Errors.Select(error => error.Description));

                    throw new InvalidOperationException(
                        $"Could not create role '{role}': {errors}");
                }
            }
        } 

    }
}
