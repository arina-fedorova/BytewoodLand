namespace Authix.Auth.Helpers;

public static class ConfigurationExtensions
{
    public static T GetRequiredSection<T>(this IConfiguration config, string key)
    {
        var section = config.GetSection(key).Get<T>();
        return section ?? throw new InvalidOperationException($"Missing configuration section: {key}");
    }
}