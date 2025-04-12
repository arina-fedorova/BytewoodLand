using Authix.Auth.Configuration;
using Authix.Auth.Helpers;
using Authix.Auth.Models;
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

            var accessToken = TokenFactory.CreateAccessToken(userName, Role.Wanderer, jwtOptions);

            return Results.Ok(new { token = accessToken });
        })
            .WithTags("Auth")
            .WithSummary("Login as a guest wanderer")
            .WithDescription("Generates a limited JWT token for unauthenticated guests.");
    }
}
