using Bytewood.Contracts.Roles;

namespace Authix.Data.Models;

public class ServiceClient
{
    public int Id { get; set; }
    public string ClientId { get; set; } = string.Empty;
    public string SecretHash { get; set; } = string.Empty;
    public ServiceRole Role { get; set; }
}