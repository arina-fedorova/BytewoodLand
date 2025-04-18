using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authix.Auth.Configuration;
using Authix.Auth.Models;
using Bytewood.Contracts.Roles;
using Microsoft.IdentityModel.Tokens;

namespace Authix.Auth.Endpoints;

public static class IntrospectionEndpoint
{
    public static void MapIntrospectionEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/introspect", (TokenIntrospectionRequest request, IConfiguration config) =>
            {
                var jwtOptions = JwtSettingsProvider.Get(config);
                var handler = new JwtSecurityTokenHandler();
                try
                {
                    var validationParams = new TokenValidationParameters
                    {
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ClockSkew = TimeSpan.Zero
                    };

                    var principal = handler.ValidateToken(request.Token, validationParams, out var validatedToken);

                    var claims = principal.Claims.ToDictionary(c => c.Type, c => c.Value);

                    return Results.Ok(new TokenIntrospectionResponse
                    {
                        IsValid = true,
                        Subject = claims.GetValueOrDefault(ClaimTypes.Name),
                        Role = claims.GetValueOrDefault(ClaimTypes.Role),
                        ExpiresAt = (validatedToken as JwtSecurityToken)?.ValidTo
                    });
                }
                catch (Exception)
                {
                    return Results.Ok(new TokenIntrospectionResponse
                    {
                        IsValid = false
                    });
                }
            })
            .WithTags("Auth")
            .WithSummary("Introspects a JWT token")
            .WithDescription("Validates a JWT and returns metadata (for tooling or diagnostics).")
            .RequireAuthorization(policy =>
                policy.RequireRole(ServiceRole.Observer.AsString(), ServiceRole.Gateway.AsString()));
    }
}