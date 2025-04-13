using Authix.Auth.Models;

namespace Authix.Data.Models;

public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool IsUsed { get; set; }
    public string? ReplacedByToken { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}