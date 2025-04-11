public class TweetleWorker : BackgroundService
{
    private readonly ILogger<TweetleWorker> _logger;

    public TweetleWorker(ILogger<TweetleWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Tweetle is awake and watching the queues 🐦📨");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Tweetle is checking the queue...");
            // Simulate doing message work
            await Task.Delay(5000, stoppingToken);
        }

        _logger.LogInformation("Tweetle is going to sleep 😴");
    }
}