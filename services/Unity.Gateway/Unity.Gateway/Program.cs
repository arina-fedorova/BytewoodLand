var builder = WebApplication.CreateBuilder(args);

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// A health check endpoint for Owla 🦉
app.MapGet("/ping", () => "Unity is alive and routing 🦄");

// Sample routed endpoint
app.MapGet("/hello", () => "Welcome to Bytewood Gateway! 🦄🌲");

// Later: Forward requests to other services (Casha, Authix, etc.)

app.Run();