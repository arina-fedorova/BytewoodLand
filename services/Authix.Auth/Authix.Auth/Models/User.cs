namespace Authix.Auth.Models;

public record User
{
    public string Username { get; init; }
    public Role Role { get; init; }
    public string PasswordHash { get; set; }

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
