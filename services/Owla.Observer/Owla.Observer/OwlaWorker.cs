using Owla.Observer.Services;
using System.Net.Http.Headers;

public class OwlaWorker : BackgroundService
{
    private readonly ILogger<OwlaWorker> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OwlaTokenProvider _tokenProvider;

    public OwlaWorker(ILogger<OwlaWorker> logger, IHttpClientFactory httpClientFactory, OwlaTokenProvider tokenProvider)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _tokenProvider = tokenProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _tokenProvider.GetTokenAsync();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        while (!stoppingToken.IsCancellationRequested)
        {
            await CheckUnity(client, stoppingToken);
            await CleanupExpiredTokens(client, stoppingToken);

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    private async Task CheckUnity(HttpClient client, CancellationToken ct)
    {
        try
        {
            var response = await client.GetAsync("http://unity.gateway:8080/ping", ct);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("🦉 Unity.Gateway is healthy ✅");
            }
            else
            {
                _logger.LogWarning("🦉 Unity.Gateway status: {Status}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "🦉 Failed to reach Unity.Gateway");
        }
    }

    private async Task CleanupExpiredTokens(HttpClient client, CancellationToken ct)
    {
        try
        {
            var response = await client.DeleteAsync("http://authix.auth:8080/tokens/expired", ct);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("🦉 Cleaned up expired tokens: {Body}", body);
            }
            else
            {
                _logger.LogWarning("🦉 Token cleanup failed: {Status}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "🦉 Failed to clean expired tokens");
        }
    }
}