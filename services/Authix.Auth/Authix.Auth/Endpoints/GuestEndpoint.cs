using Authix.Auth.Configuration;
using Authix.Auth.Helpers;
using Authix.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authix.Auth.Endpoints;

public static class GuestEndpoint
{
    public static void MapGuestEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/guest", (string userName, IConfiguration config) =>
        {
            var jwtOptions = JwtSettingsProvider.Get(config);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, Role.Wanderer.ToString().ToLower())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            return Results.Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        })
            .WithTags("Auth")
            .WithSummary("Login as a guest wanderer")
            .WithDescription("Generates a limited JWT token for unauthenticated guests.");
    }
}
