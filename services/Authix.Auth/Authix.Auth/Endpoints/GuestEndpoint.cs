using Authix.Auth.Configuration;
using Authix.Auth.Helpers;
using Bytewood.Contracts.Roles;

namespace Authix.Auth.Endpoints;

public static class GuestEndpoint
{
    public static void MapGuestEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/guest", (string userName, IConfiguration config) =>
            {
                var jwtOptions = JwtSettingsProvider.Get(config);

                var accessToken = TokenFactory.CreateAccessToken(userName, UserRole.Wanderer.AsString(), jwtOptions);

                return Results.Ok(new { token = accessToken });
            })
            .WithTags("Auth")
            .WithSummary("Login as a guest wanderer")
            .WithDescription("Generates a limited JWT token for unauthenticated guests.");
    }
}