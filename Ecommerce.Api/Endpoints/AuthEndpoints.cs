using Ecommerce.Api.DTOs.Auth;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Ecommerce.Api.Endpoints;

public static class AuthEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/api/auth")
            .WithTags("Auth");

        group.MapPost("/register", async (
            RegisterDto dto,
            AuthServices services) =>
        {
            var result = await services.Register(dto);

            if (!result.Succeeded)
            {
                return Results.BadRequest(result.Errors);
            }

            return Results.Ok(new
            {
                message = "Account created successfully."
            });
        });

        group.MapPost("/login", async (
            LoginDto dto,
            AuthServices services) =>
        {
            var token = await services.Login(dto);

            if (token is null)
            {
                return Results.Unauthorized();
            }

            return Results.Ok(new { token });
        });

        // Returns the logged in users information. JWT-token needed.
        group.MapGet("/me", async (
            ClaimsPrincipal principal,
            UserManager<User> userManager) =>
            {   
            var user = await userManager.GetUserAsync(principal);

            if (user is null)
            {
                return Results.Unauthorized();
            }

            return Results.Ok(new
            {
                user.Id,
                user.UserName,
                user.Email
            });
        }).RequireAuthorization();
    }
}