public class JwtOptions
{
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public string? SecretKey { get; set; }
}