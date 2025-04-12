using Authix.Data.Models;

namespace Authix.Auth.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string PasswordHash { get; set; } = string.Empty;

    internal User() { }

    public User(string username, Role role, string passwordHash)
    {
        if (role == Role.Wanderer)
        {
            throw new ArgumentException("Wanderer role is reserved for unauthenticated users.");
        }

        Username = username;
        Role = role;
        PasswordHash = passwordHash;
    }

    public override string ToString()
    {
        return $"{Username} ({Role})";
    }
}
