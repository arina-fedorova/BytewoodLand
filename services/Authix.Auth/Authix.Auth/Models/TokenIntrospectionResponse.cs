namespace Authix.Auth.Models;

public class TokenIntrospectionResponse
{
    public bool IsValid { get; set; }
    public string? Subject { get; set; }
    public string? Role { get; set; }
    public DateTime? ExpiresAt { get; set; }
}