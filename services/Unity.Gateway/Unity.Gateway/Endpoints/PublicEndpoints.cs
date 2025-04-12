namespace Unity.Gateway.Endpoints;

public static class PublicEndpoints
{
    public static void MapPublicEndpoints(this WebApplication app)
    {
        app.MapGet("/public-info", () =>
        {
            return "🌿 This is public information for all wanderers.";
        });
    }
}