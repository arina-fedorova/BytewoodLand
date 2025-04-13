using Authix.Data.Models;
using Bytewood.Contracts.Roles;

namespace Authix.Auth.Models;

public class User
{
    internal User()
    {
    }

    public User(string username, UserRole role, string passwordHash)
    {
        if (role == UserRole.Wanderer)
            throw new ArgumentException("Wanderer role is reserved for unauthenticated users.");

        Username = username;
        Role = role;
        PasswordHash = passwordHash;
    }

    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string PasswordHash { get; set; } = string.Empty;

    public List<RefreshToken> RefreshTokens { get; set; } = new();

    public override string ToString()
    {
        return $"{Username} ({Role})";
    }
}