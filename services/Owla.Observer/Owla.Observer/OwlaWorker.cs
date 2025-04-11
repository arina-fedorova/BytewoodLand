public class OwlaWorker : BackgroundService
{
    private readonly ILogger<OwlaWorker> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public OwlaWorker(ILogger<OwlaWorker> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var client = _httpClientFactory.CreateClient();

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var response = await client.GetAsync("http://unity.gateway/ping", stoppingToken);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("🦉 Unity.Gateway is healthy ✅");
                }
                else
                {
                    _logger.LogWarning("🦉 Unity.Gateway is responding with status: {Status}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🦉 Failed to reach Unity.Gateway");
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}