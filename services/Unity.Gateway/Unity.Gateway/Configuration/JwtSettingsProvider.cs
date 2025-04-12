namespace Unity.Gateway.Configuration;

public static class JwtSettingsProvider
{
    public static JwtOptions Get(IConfiguration config)
    {
        var options = config.GetRequiredSection("Jwt").Get<JwtOptions>()
            ?? throw new InvalidOperationException("JWT config section is missing");

        options.SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET")
            ?? throw new InvalidOperationException("JWT_SECRET is missing");

        return options;
    }
}
