public class SqueeWorker : BackgroundService
{
    private readonly ILogger<SqueeWorker> _logger;

    public SqueeWorker(ILogger<SqueeWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("⏰ Squee is keeping time...");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Squee triggers a task at: {time}", DateTimeOffset.Now);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}