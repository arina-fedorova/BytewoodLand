using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Register Redis connection
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(builder.Configuration["Redis__Host"] ?? "localhost:6379"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Test GET: read value
app.MapGet("/cache/{key}", async (string key) =>
{
    var value = await app.Services.GetRequiredService<IConnectionMultiplexer>().GetDatabase().StringGetAsync(key);
    return value.HasValue ? Results.Ok(value.ToString()) : Results.NotFound();
});

// Test POST: set value
app.MapPost("/cache", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();
    var key = form["key"].ToString();
    var value = form["value"].ToString();
    await app.Services.GetRequiredService<IConnectionMultiplexer>().GetDatabase().StringSetAsync(key, value);
    return Results.Ok(new { key, value });
});

app.Run();