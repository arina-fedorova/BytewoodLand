Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SqueeWorker>();
    })
    .Build()
    .Run();