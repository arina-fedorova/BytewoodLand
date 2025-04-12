using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Unity.Gateway.Helpers;
using Unity.Gateway.Models;

namespace Unity.Gateway.Endpoints;

public static class ProtectedEndpoints
{
    public static void MapProtectedEndpoints(this WebApplication app)
    {
        app.MapGet("/protected", (ClaimsPrincipal user) =>
        {
            var name = user.Identity?.Name ?? "unknown";
            var role = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "none";
            return $"🛡️ Hello {name}, your role is '{role}' — access granted to protected realm.";
        }).RequireAuthorization();

        app.MapGet("/secret-forest", (ClaimsPrincipal user) =>
        {
            var name = user.Identity?.Name ?? "unknown";
            return $"🌳 Welcome to the secret forest, Guardian {name}.";
        }).RequireAuthorization(new AuthorizeAttribute { Roles = Role.Guardian.AsString() });

        app.MapGet("/scout-hq", (ClaimsPrincipal user) =>
        {
            var name = user.Identity?.Name ?? "unknown";
            return $"🦊 Scout {name}, your event scrolls await!";
        }).RequireAuthorization(new AuthorizeAttribute { Roles = Role.Scout.AsString() });

        app.MapGet("/me", (ClaimsPrincipal user) =>
        {
            var name = user.Identity?.Name ?? "unknown";
            var role = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "none";

            return Results.Ok(new
            {
                name,
                role,
                message = $"🔐 You are {name}, a {role} of Bytewood."
            });
        }).RequireAuthorization();
    }
}
