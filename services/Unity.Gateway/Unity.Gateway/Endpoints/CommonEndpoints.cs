namespace Unity.Gateway.Endpoints;

public static class CommonEndpoints
{
    public static void MapCommonEndpoints(this WebApplication app)
    {
        app.MapGet("/", () =>
        {
            return "🌍 Welcome to the Unity Gateway!";
        });
        app.MapGet("/ping", () =>
        {
            return "Unity is alive and routing 🦄";
        });
    }
}
