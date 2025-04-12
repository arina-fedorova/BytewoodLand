using Authix.Auth.Configuration;
using Authix.Auth.Helpers;
using Authix.Auth.Models;
using Authix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authix.Auth.Endpoints;

public static class LoginEndpoint
{
    public static void MapLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/login", async (LoginRequest login, AuthixDbContext db, IConfiguration config) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Username == login.Username);

            if (user is null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {
                return Results.Unauthorized();
            }

            var jwtOptions = JwtSettingsProvider.Get(config);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString().ToLower())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Results.Ok(new { token = tokenString });
        })
            .WithTags("Auth")
            .WithSummary("Login as a registered user")
            .WithDescription("Requires password. Returns token with assigned role.");
    }
}
