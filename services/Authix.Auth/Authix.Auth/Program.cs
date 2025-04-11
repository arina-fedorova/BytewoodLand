var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer(); // Enables OpenAPI discovery
builder.Services.AddSwaggerGen();           // Swagger UI support

var app = builder.Build();

// Swagger UI in development only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Example endpoint (eventually: token generation!)
app.MapPost("/token", () => Results.Ok("Here’s a fake JWT 🐉🔐"));

app.Run();