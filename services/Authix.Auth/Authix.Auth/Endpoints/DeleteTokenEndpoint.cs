using Authix.Data;

namespace Authix.Auth.Endpoints;

public static class DeleteTokenEndpoint
{
    public static void MapDeleteTokenEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/tokens/expired", async (AuthixDbContext dbContext) =>
        {
            var now = DateTime.UtcNow;
            var expired = dbContext.RefreshTokens.Where(rt => rt.ExpiresAt < now);

            dbContext.RefreshTokens.RemoveRange(expired);
            var deleted = await dbContext.SaveChangesAsync();

            return Results.Ok(new { deleted });
        })
            .WithTags("Maintenance")
            .WithSummary("Deletes expired refresh tokens")
            .WithDescription("Used by Owla 🦉 to clean up old junk.")
            .RequireAuthorization();
    }
}
