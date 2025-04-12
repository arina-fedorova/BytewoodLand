using Authix.Auth.Configuration;
using Authix.Auth.Helpers;
using Authix.Auth.Models;
using Authix.Data;
using Authix.Data.Models;
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
        app.MapPost("/login", async (LoginRequest login, AuthixDbContext dbContext, IConfiguration config) =>
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Username == login.Username);

            if (user is null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {
                return Results.Unauthorized();
            }

            var jwtOptions = JwtSettingsProvider.Get(config);

            var accessToken = TokenFactory.CreateAccessToken(user.Username, user.Role, jwtOptions);

            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsUsed = false,
                UserId = user.Id
            };
            dbContext.RefreshTokens.Add(refreshToken);
            await dbContext.SaveChangesAsync();

            return Results.Ok(new
            {
                access_token = accessToken,
                refresh_token = refreshToken.Token
            });
        })
            .WithTags("Auth")
            .WithSummary("Login as a registered user")
            .WithDescription("Requires password. Returns access and refresh tokens");
    }
}
