using Ecommerce.Api.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;


using System.Text;

namespace Ecommerce.Api.Services;

public class TokenServices(IConfiguration configuration)
{

    public string CreateToken(User user)
    {
        // Claims are information that is stored  about 
        // the user. In this case, id and email.
        var claims = new Dictionary<string, object>
        {
            [JwtRegisteredClaimNames.Sub] = user.Id,
            [JwtRegisteredClaimNames.Email] = user.Email!
        };

        // Creating the key by getting the generated secret
        // from user-secrets. The string is made to bytes as
        // the cryptography uses bytes.
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)
            );

        // How is this token signed?. In this case, 
        // sign this token using this key and algorithm
        // (HMAC-SHA256).
        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
            );

        // Describe the token.
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = configuration["Jwt:Issuer"], // who is the creator?
            Audience = configuration["Jwt:Audience"], // What api is this for?
            Expires = DateTime.UtcNow.AddMinutes(60), // When does the token expire?
            Claims = claims, // Who is the token about?
            SigningCredentials = credentials // How is it signed?
        };

        // JsonWebTokenHandler takes the description
        // and creates the token.
        var tokenHandler = new JsonWebTokenHandler();

        return tokenHandler.CreateToken(tokenDescriptor);

    }
}