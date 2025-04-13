using Authix.Auth.Configuration;
using Authix.Auth.Helpers;
using Authix.Auth.Models;
using Authix.Data;
using Bytewood.Contracts.Roles;
using Microsoft.EntityFrameworkCore;

namespace Authix.Auth.Endpoints;

public static class ClientAuthEndpoint
{
    public static void MapClientAuthEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/client",
                async (ClientAuthRequest request, AuthixDbContext dbContext, IConfiguration config) =>
                {
                    var client = await dbContext.ServiceClients
                        .FirstOrDefaultAsync(c => c.ClientId == request.ClientId);

                    if (client is null || !BCrypt.Net.BCrypt.Verify(request.ClientSecret, client.SecretHash))
                    {
                        return Results.Unauthorized();
                    }

                    var jwtOptions = JwtSettingsProvider.Get(config);
                    var accessToken = TokenFactory.CreateAccessToken(client.ClientId, client.Role.AsString(), jwtOptions);

                    return Results.Ok(new
                    {
                        access_token = accessToken
                    });
              })
            .WithTags("Auth")
            .WithSummary("Authenticate service client")
            .WithDescription("Authenticates a service via client_id and secret.");
    }
}