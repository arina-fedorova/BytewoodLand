using Authix.Auth.Models;

namespace Authix.Auth.Services;

public static class UserStore
{
    public static readonly List<User> All = new()
    {
        // TODO: replace plain-text password with hashed password
        new("Squee", Role.Scout, "squeescout"),
        new("Owla", Role.Scout, "owlascout"),
        new("Casha", Role.Guardian, "cashaguardian"),
        new("Tweetle", Role.Scout, "tweetlescout"),
        new("Grizzle", Role.Guardian, "grizzleguardian")
    };

    public static User? Find(string username)
    {
        return All.FirstOrDefault(u => u.Username.Equals(username));
    }
}
