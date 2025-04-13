using Microsoft.Extensions.Options;
using Owla.Observer.Configuration;
using System.Net.Http.Json;
using System.Text.Json;

namespace Owla.Observer.Services;
public class OwlaTokenProvider
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OwlaIdentityOptions _options;
    private readonly ILogger<OwlaTokenProvider> _logger;
    private string? _cachedToken;

    public OwlaTokenProvider(IHttpClientFactory httpClientFactory, IOptions<OwlaIdentityOptions> config, ILogger<OwlaTokenProvider> logger)
    {
        _httpClientFactory = httpClientFactory;
        _options = config.Value;
        _logger = logger;
    }

    public async Task<string?> GetTokenAsync()
    {

        if (!string.IsNullOrEmpty(_cachedToken))
        {
            return _cachedToken;
        }

        var client = _httpClientFactory.CreateClient();

        for (int attempt = 0; attempt < 5; attempt++)
        {
            try
            {
                var response = await client.PostAsJsonAsync("http://authix.auth:8080/auth/client", new
                {
                    ClientId = _options.Username,
                    ClientSecret = _options.Secret
                });
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadFromJsonAsync<JsonElement>();
                    _cachedToken = json.GetProperty("access_token").GetString();

                    return _cachedToken!;
                }

                _logger.LogWarning("Owla failed to authenticate: {Status}", response.StatusCode);
                return null;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogWarning(ex, "Owla failed to connect to Authix. Retrying...");
                await Task.Delay(2000);
            }
        }

        _logger.LogError("Owla could not reach Authix after multiple attempts.");
        return null;
    }
}