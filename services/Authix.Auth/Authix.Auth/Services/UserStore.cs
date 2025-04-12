using Authix.Auth.Models;

namespace Authix.Auth.Services;

public static class UserStore
{
    public static readonly List<User> All = new()
    {
        new("Squee", Role.Scout),
        new("Owla", Role.Scout),
        new("Casha", Role.Guardian),
        new("Tweetle", Role.Scout),
        new("Grizzle", Role.Guardian)
    };

    public static User Find(string username)
    {
        var user = All.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        return user ?? new(username, Role.Wanderer);
    }
}
