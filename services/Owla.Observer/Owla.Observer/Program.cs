using Owla.Observer.Configuration;
using Owla.Observer.Services;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<OwlaIdentityOptions>(
            context.Configuration.GetSection("OwlaIdentity"));

        services.AddHttpClient();
        services.AddSingleton<OwlaTokenProvider>();
        services.AddHostedService<OwlaWorker>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .Build()
    .Run();
