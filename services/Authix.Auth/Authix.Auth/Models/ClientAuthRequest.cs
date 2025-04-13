namespace Authix.Auth.Models;

public class ClientAuthRequest
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}