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

public static class RefreshEndpoint
{
    public static void MapRefreshEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/refresh", async (RefreshRequest request, IConfiguration config, AuthixDbContext dbContext) =>
        {
            var existing = await dbContext.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt =>
                    rt.Token == request.RefreshToken &&
                    rt.ExpiresAt > DateTime.UtcNow &&
                    !rt.IsUsed);

            if (existing is null)
            {
                return Results.Unauthorized();
            }

            var user = existing.User!;
            var jwtOptions = JwtSettingsProvider.Get(config);

            var accessToken = TokenFactory.CreateAccessToken(user.Username, user.Role, jwtOptions);

            var newRefreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsUsed = false,
                UserId = user.Id
            };

            existing.IsUsed = true;
            existing.ReplacedByToken = newRefreshToken.Token;

            dbContext.RefreshTokens.Add(newRefreshToken);
            await dbContext.SaveChangesAsync();

            return Results.Ok(new
            {
                access_token = accessToken,
                refresh_token = newRefreshToken.Token
            });
        })
            .WithTags("Auth")
            .WithSummary("Refresh access token")
            .WithDescription("Exchanges a refresh token for a new access token.");
    }
}
